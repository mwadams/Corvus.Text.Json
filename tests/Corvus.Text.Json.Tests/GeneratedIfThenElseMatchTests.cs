// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for generated if/then/else Match pattern.
    /// Exercises: conditional matching when the 'if' schema matches (→ then)
    /// and when it does not match (→ else), both with and without context.
    /// </summary>
    public class GeneratedIfThenElseMatchTests
    {
        [Fact]
        public void Match_WhenIfConditionMet_CallsThenMatcher()
        {
            using ParsedJsonDocument<IfThenElse> doc =
                ParsedJsonDocument<IfThenElse>.Parse("""{"kind":"special","value":42}""");

            string result = doc.RootElement.Match(
                matchCorvusTextJsonTestsGeneratedModelsDraft202012IfThenElseThenEntity:
                    static (in IfThenElse.ThenEntity v) => "then:" + v.Value.ToString(),
                matchCorvusTextJsonTestsGeneratedModelsDraft202012IfThenElseElseEntity:
                    static (in IfThenElse.ElseEntity _) => "else");

            Assert.Equal("then:42", result);
        }

        [Fact]
        public void Match_WhenIfConditionNotMet_CallsElseMatcher()
        {
            using ParsedJsonDocument<IfThenElse> doc =
                ParsedJsonDocument<IfThenElse>.Parse("""{"kind":"normal","value":"hello"}""");

            string result = doc.RootElement.Match(
                matchCorvusTextJsonTestsGeneratedModelsDraft202012IfThenElseThenEntity:
                    static (in IfThenElse.ThenEntity _) => "then",
                matchCorvusTextJsonTestsGeneratedModelsDraft202012IfThenElseElseEntity:
                    static (in IfThenElse.ElseEntity v) => "else:" + v.Value.ToString());

            Assert.Equal("else:hello", result);
        }

        [Fact]
        public void MatchWithContext_PassesContextThrough()
        {
            using ParsedJsonDocument<IfThenElse> doc =
                ParsedJsonDocument<IfThenElse>.Parse("""{"kind":"special","value":99}""");

            string result = doc.RootElement.Match(
                "ctx",
                matchCorvusTextJsonTestsGeneratedModelsDraft202012IfThenElseThenEntity:
                    static (in IfThenElse.ThenEntity v, in string ctx) => ctx + ":then:" + v.Value.ToString(),
                matchCorvusTextJsonTestsGeneratedModelsDraft202012IfThenElseElseEntity:
                    static (in IfThenElse.ElseEntity _, in string ctx) => ctx + ":else");

            Assert.Equal("ctx:then:99", result);
        }
    }
}
