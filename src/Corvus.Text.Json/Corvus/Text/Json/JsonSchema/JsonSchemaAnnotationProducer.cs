// <copyright file="JsonSchemaAnnotationProducer.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Corvus.Text.Json;

/// <summary>
/// Extracts JSON Schema annotations from a <see cref="JsonSchemaResultsCollector"/> that
/// has been used in <see cref="JsonSchemaResultsLevel.Verbose"/> mode.
/// </summary>
/// <remarks>
/// <para>
/// Annotations in JSON Schema are produced by keywords that do not perform validation but
/// instead attach metadata to the instance. When a <see cref="JsonSchemaResultsCollector"/> is
/// used in verbose mode, annotation-producing keywords emit results via
/// <c>IgnoredKeyword</c>. This class filters those results and extracts them as
/// structured annotation values.
/// </para>
/// <para>
/// Each annotation is identified by:
/// <list type="bullet">
/// <item><description><strong>Instance location:</strong> The JSON Pointer into the instance being validated (e.g., "", "/foo", "/items/0").</description></item>
/// <item><description><strong>Keyword:</strong> The annotation keyword name (e.g., "title", "description", "default").</description></item>
/// <item><description><strong>Schema location:</strong> The absolute JSON Pointer into the schema where the keyword appears (e.g., "#", "#/$defs/foo").</description></item>
/// <item><description><strong>Value:</strong> The raw JSON value of the annotation.</description></item>
/// </list>
/// </para>
/// </remarks>
public static class JsonSchemaAnnotationProducer
{
    /// <summary>
    /// A callback invoked for each annotation found in the results.
    /// </summary>
    /// <param name="instanceLocation">The instance location as a JSON Pointer string.</param>
    /// <param name="keyword">The annotation keyword name.</param>
    /// <param name="schemaLocation">The schema location as a JSON Pointer string.</param>
    /// <param name="annotationValue">The raw JSON value of the annotation.</param>
    /// <returns><see langword="true"/> to continue enumeration; <see langword="false"/> to stop.</returns>
    public delegate bool AnnotationCallback(
        string instanceLocation,
        string keyword,
        string schemaLocation,
        string annotationValue);

    /// <summary>
    /// Enumerates annotations from the collector, invoking the callback for each one.
    /// </summary>
    /// <param name="collector">The results collector (must have been used in <see cref="JsonSchemaResultsLevel.Verbose"/> mode).</param>
    /// <param name="callback">The callback to invoke for each annotation.</param>
    public static void EnumerateAnnotations(
        JsonSchemaResultsCollector collector,
        AnnotationCallback callback)
    {
        foreach (JsonSchemaResultsCollector.Result result in collector.EnumerateResults())
        {
            // Annotations are always match=true results from IgnoredKeyword.
            // They have a non-empty message (the annotation value) and the
            // evaluation location ends with the keyword name.
            if (!result.IsMatch)
            {
                continue;
            }

            System.ReadOnlySpan<byte> message = result.Message;
            if (message.Length == 0)
            {
                continue;
            }

            // The evaluation location is like "/title" or "/properties/foo/description".
            // The last segment (after the final '/') is the keyword name.
            System.ReadOnlySpan<byte> evaluationLocation = result.EvaluationLocation;
            int lastSlash = evaluationLocation.LastIndexOf((byte)'/');
            if (lastSlash < 0)
            {
                continue;
            }

            System.ReadOnlySpan<byte> keywordBytes = evaluationLocation[(lastSlash + 1)..];
            if (keywordBytes.Length == 0)
            {
                continue;
            }

            string keyword = JsonReaderHelper.GetTextFromUtf8(keywordBytes);
            string instanceLocation = result.GetDocumentEvaluationLocationText();

            // The internal schema evaluation path is a JSON Pointer without the "#" prefix.
            // For spec-conformant annotation output, prepend "#" to form a proper fragment.
            string schemaLocation = "#" + result.GetSchemaEvaluationLocationText();
            string annotationValue = result.GetMessageText();

            if (!callback(instanceLocation, keyword, schemaLocation, annotationValue))
            {
                return;
            }
        }
    }

    /// <summary>
    /// Collects all annotations from the collector into a dictionary keyed by
    /// (instanceLocation, keyword), with values being a dictionary of
    /// schemaLocation → annotationValue.
    /// </summary>
    /// <param name="collector">The results collector (must have been used in <see cref="JsonSchemaResultsLevel.Verbose"/> mode).</param>
    /// <returns>A dictionary of annotations keyed by (instanceLocation, keyword).</returns>
    /// <remarks>
    /// This is a convenience method primarily intended for testing. For production use,
    /// prefer <see cref="EnumerateAnnotations"/> to avoid unnecessary allocations.
    /// </remarks>
    public static Dictionary<(string InstanceLocation, string Keyword), Dictionary<string, string>> CollectAnnotations(
        JsonSchemaResultsCollector collector)
    {
        var result = new Dictionary<(string, string), Dictionary<string, string>>();

        EnumerateAnnotations(
            collector,
            (instanceLocation, keyword, schemaLocation, annotationValue) =>
            {
                var key = (instanceLocation, keyword);
                if (!result.TryGetValue(key, out Dictionary<string, string>? schemaMap))
                {
                    schemaMap = new Dictionary<string, string>();
                    result[key] = schemaMap;
                }

                schemaMap[schemaLocation] = annotationValue;
                return true;
            });

        return result;
    }
}