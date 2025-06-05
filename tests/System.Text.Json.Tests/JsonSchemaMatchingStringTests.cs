// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;
using Corvus.Text.Json.Internal;

namespace Corvus.Text.Json.Tests;

public class JsonSchemaMatchingStringTests
{
    [Theory]
    [InlineData("user@example.com", true)] // Standard ASCII email
    [InlineData("user@xn--bcher-kva.ch", true)] // Punycode domain
    [InlineData("user@bücher.ch", true)] // Unicode domain (IDN)
    [InlineData("用户@例子.公司", true)] // Unicode local and domain
    [InlineData("user@sub.例子.公司", true)] // Unicode subdomain
    [InlineData("user@", false)] // Missing domain
    [InlineData("@example.com", false)] // Missing local part
    [InlineData("userexample.com", false)] // Missing '@'
    [InlineData("user@.com", false)] // Invalid domain
    [InlineData("user@com", false)] // No dot in domain
    [InlineData("user@例子", false)] // No dot in Unicode domain
    [InlineData("", false)] // Empty string
    public void MatchIdnEmail_ValidatesCorrectly(string email, bool expected)
    {
        // Arrange
        byte[] utf8 = Encoding.UTF8.GetBytes(email);

        // Act
        bool result = JsonSchemaMatching.MatchIdnEmail(utf8);

        // Assert
        Assert.Equal(expected, result);
    }
}
