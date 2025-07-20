// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Corvus.Text.Json
{
    /// <summary>
    /// Provides helper methods for accessing application context switches related to JSON serialization.
    /// </summary>
    internal static class AppContextSwitchHelper
    {
        /// <summary>
        /// Gets a value indicating whether source generation reflection fallback is enabled.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the "Corvus.Text.Json.Serialization.EnableSourceGenReflectionFallback" 
        /// switch is enabled; otherwise, <see langword="false"/>.
        /// </value>
        public static bool IsSourceGenReflectionFallbackEnabled { get; } =
            AppContext.TryGetSwitch(
                switchName: "Corvus.Text.Json.Serialization.EnableSourceGenReflectionFallback",
                isEnabled: out bool value)
            ? value : false;

        /// <summary>
        /// Gets a value indicating whether nullable annotations should be respected by default.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the "Corvus.Text.Json.Serialization.RespectNullableAnnotationsDefault" 
        /// switch is enabled; otherwise, <see langword="false"/>.
        /// </value>
        public static bool RespectNullableAnnotationsDefault { get; } =
            AppContext.TryGetSwitch(
                switchName: "Corvus.Text.Json.Serialization.RespectNullableAnnotationsDefault",
                isEnabled: out bool value)
            ? value : false;

        /// <summary>
        /// Gets a value indicating whether required constructor parameters should be respected by default.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the "Corvus.Text.Json.Serialization.RespectRequiredConstructorParametersDefault" 
        /// switch is enabled; otherwise, <see langword="false"/>.
        /// </value>
        public static bool RespectRequiredConstructorParametersDefault { get; } =
            AppContext.TryGetSwitch(
                switchName: "Corvus.Text.Json.Serialization.RespectRequiredConstructorParametersDefault",
                isEnabled: out bool value)
            ? value : false;
    }
}
