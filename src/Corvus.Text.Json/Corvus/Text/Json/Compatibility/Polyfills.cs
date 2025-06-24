////// Licensed to the .NET Foundation under one or more agreements.
////// The .NET Foundation licenses this file to you under the MIT license.

////using System.IO;
////using Corvus.Text.Json.Internal;

////namespace Corvus.Text.Json.Compatibility
////{
////    /// <summary>
////    /// Provides polyfills for Corvus.JsonSchema API compatibility.
////    /// </summary>
////    [CLSCompliant(false)]
////    public static class Polyfills
////    {
////        private static class Instances<T>
////            where T : struct, IJsonElement<T>
////        {
////            public static readonly T NullInstance = ParsedJsonDocument<T>.ParseValue("null", default).RootElement;
////        }

////        extension<T>(T element)
////            where T : struct, IJsonElement<T>
////        {
////            public bool IsValid()
////            {
////                return element.EvaluateSchema();
////            }

////            public bool HasDotnetBacking => false;
////            public bool HasJsonElementBacking => true;

////            public static T Null => Instances<T>.NullInstance;
////            public static T Undefined => default;

////            public JsonElement AsJsonElement => new(element.ParentDocument, element.ParentDocumentIndex);

////            // JsonElement is the equivalent of JsonAny in Corvus.JsonSchema
////            public JsonElement AsAny => new(element.ParentDocument, element.ParentDocumentIndex);

////            public static T Parse(string value, JsonDocumentOptions options = default)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, options);
////                return document.RootElement;
////            }

////            public static T Parse(Stream value, JsonDocumentOptions options = default)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, options);
////                return document.RootElement;
////            }

////            public static T Parse(ReadOnlyMemory<byte> value, JsonDocumentOptions options = default)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value.Span, options);
////                return document.RootElement;
////            }

////            public static T Parse(ReadOnlyMemory<char> value, JsonDocumentOptions options = default)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value.Span, options);
////                return document.RootElement;
////            }

////            public static T ParseValue(string value)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, default);
////                return document.RootElement;
////            }

////            public static T ParseValue(ReadOnlySpan<char> value)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value.ToArray(), default);
////                return document.RootElement;
////            }

////            public static T ParseValue(ReadOnlySpan<byte> value)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(value, default);
////                return document.RootElement;
////            }

////            public static T ParseValue(ref Utf8JsonReader value)
////            {
////                // This is the unrented path/
////                ParsedJsonDocument<T> document = ParsedJsonDocument<T>.ParseValue(ref value);
////                return document.RootElement;
////            }

////            public static T FromJson<TTarget>(in TTarget value)
////                where TTarget : struct, IJsonElement<TTarget>
////            {
////#if NET
////                return T.CreateInstance(value.ParentDocument, value.ParentDocumentIndex);
////#else
////                return JsonElementHelpers.CreateInstance<T>(value.ParentDocument, value.ParentDocumentIndex);
////#endif
////            }

////            public TTarget As<TTarget>()
////                where TTarget : struct, IJsonElement<TTarget>
////            {
////#if NET
////                return TTarget.CreateInstance(element.ParentDocument, element.ParentDocumentIndex);
////#else
////                return JsonElementHelpers.CreateInstance<TTarget>(element.ParentDocument, element.ParentDocumentIndex);
////#endif
////            }

////            /// <summary>
////            /// Validates the instance against its own schema.
////            /// </summary>
////            /// <param name="context">The current validation context.</param>
////            /// <param name="validationLevel">The validation level. (Defaults to <see cref="ValidationLevel.Flag"/>).</param>
////            /// <returns>The <see cref="ValidationContext"/> updated with the results from this validation operation.</returns>
////            public ValidationContext Validate(in ValidationContext context, ValidationLevel validationLevel = ValidationLevel.Flag)
////            {
////                if (validationLevel == ValidationLevel.Flag)
////                {
////                    return new(element.EvaluateSchema());
////                }

////                JsonSchemaResultsCollector collector = context.Collector ?? JsonSchemaResultsCollector.Create(ValidationContext.MapLevel(validationLevel));
////                bool isMatch = element.EvaluateSchema(collector);
////                return new(isMatch && context.IsValid, collector);
////            }
////        }
////    }
////}
