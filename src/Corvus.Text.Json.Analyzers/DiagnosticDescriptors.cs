// <copyright file="DiagnosticDescriptors.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using Microsoft.CodeAnalysis;

namespace Corvus.Text.Json.Analyzers;

/// <summary>
/// Diagnostic descriptors for the Corvus.Text.Json production analyzers.
/// </summary>
internal static class DiagnosticDescriptors
{
    private const string Category = "Performance";
    private const string UsageCategory = "Usage";
    private const string HelpLinkBase = "https://corvus-text-json.dev/docs/analyzers.html";

    /// <summary>
    /// CTJ001: Prefer UTF-8 string literal.
    /// </summary>
    public static readonly DiagnosticDescriptor PreferUtf8StringLiteral = new(
        id: "CTJ001",
        title: "Prefer UTF-8 string literal",
        messageFormat: "Use \"{0}\"u8 instead of \"{0}\" — a ReadOnlySpan<byte> overload is available",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        helpLinkUri: HelpLinkBase + "#ctj001--prefer-utf-8-string-literal");

    /// <summary>
    /// CTJ002: Unnecessary conversion to .NET type.
    /// </summary>
    public static readonly DiagnosticDescriptor UnnecessaryConversion = new(
        id: "CTJ002",
        title: "Unnecessary conversion to .NET type",
        messageFormat: "Unnecessary conversion to '{0}' — the original type converts implicitly to the target parameter type",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        helpLinkUri: HelpLinkBase + "#ctj002--unnecessary-conversion-to-net-type");

    /// <summary>
    /// CTJ003: Match lambda should be static.
    /// </summary>
    public static readonly DiagnosticDescriptor MatchLambdaShouldBeStatic = new(
        id: "CTJ003",
        title: "Match lambda should be static",
        messageFormat: "Lambda passed to Match is not static — {0}",
        category: UsageCategory,
        defaultSeverity: DiagnosticSeverity.Info,
        isEnabledByDefault: true,
        helpLinkUri: HelpLinkBase + "#ctj003--match-lambda-should-be-static");
}
