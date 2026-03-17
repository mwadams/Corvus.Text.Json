// <copyright file="WithMutationCodeFixTests.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https://github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>

using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;

using Xunit;

using CodeFixTest = Microsoft.CodeAnalysis.CSharp.Testing.CSharpCodeFixTest<
    Corvus.Text.Json.Migration.Analyzers.WithMutationAnalyzer,
    Corvus.Text.Json.Migration.Analyzers.WithMutationCodeFix,
    Microsoft.CodeAnalysis.Testing.DefaultVerifier>;
using Verify = Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerVerifier<
    Corvus.Text.Json.Migration.Analyzers.WithMutationAnalyzer,
    Microsoft.CodeAnalysis.Testing.DefaultVerifier>;

namespace Corvus.Text.Json.Migration.Analyzers.Tests;

/// <summary>
/// Tests for CVJ011 code fix: With*() to Set*() with unchaining and nested collapse.
/// </summary>
public class WithMutationCodeFixTests
{
    private const string V4Stubs = @"
namespace Corvus.Json
{
    public interface IJsonValue { }

    public struct JsonString : IJsonValue
    {
        private readonly string _value;
        public JsonString(string v) { _value = v; }
        public static explicit operator JsonString(string v) => new JsonString(v);
    }

    public struct JsonAny : IJsonValue { }
}
";

    private const string PersonStubs = @"
namespace TestApp
{
    struct Address : Corvus.Json.IJsonValue
    {
        public Address WithCity(string city) => this;
        public Address WithStreet(string street) => this;
    }

    struct TagsArray : Corvus.Json.IJsonValue
    {
        public TagsArray Add(Corvus.Json.JsonString value) => this;
    }

    struct Person : Corvus.Json.IJsonValue
    {
        public Address AddressValue => default;
        public TagsArray Tags => default;
        public Person WithName(string name) => this;
        public Person WithAge(int age) => this;
        public Person WithAddressValue(Address addr) => this;
        public Person WithTags(TagsArray tags) => this;
    }
}
";

    [Fact]
    public async Task SimpleWith_RenamesAndDropsAssignment()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            Person updated = person.{|#0:WithName|}(""Bob"");
        }
    }
}",
            FixedCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            person.SetName(""Bob"");
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(0)
                .WithArguments("WithName", "Name"));

        await test.RunAsync();
    }

    [Fact]
    public async Task ChainedWith_UnchainsToSeparateStatements()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            Person updated = person
                .{|#0:WithName|}(""Bob"")
                .{|#1:WithAge|}(25);
        }
    }
}",
            FixedCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            person.SetName(""Bob"");
            person.SetAge(25);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(0)
                .WithArguments("WithName", "Name"));
        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(1)
                .WithArguments("WithAge", "Age"));

        await test.RunAsync();
    }

    [Fact]
    public async Task NestedExtractMutateReassign_CollapsesToDeepSetter()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            Address address = person.AddressValue;
            Address updatedAddress = address.{|#0:WithCity|}(""Manchester"");
            Person updatedPerson = person.{|#1:WithAddressValue|}(updatedAddress);
        }
    }
}",
            FixedCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            person.AddressValue.SetCity(""Manchester"");
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(0)
                .WithArguments("WithCity", "City"));
        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(1)
                .WithArguments("WithAddressValue", "AddressValue"));

        await test.RunAsync();
    }

    [Fact]
    public async Task InlineNestedChain_UnchainsAndRenamesBoth()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            Address address = person.AddressValue;
            Person result = person
                .{|#0:WithAddressValue|}(address.{|#1:WithCity|}(""Manchester""));
        }
    }
}",
            FixedCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            Address address = person.AddressValue;
            person.SetAddressValue(address.SetCity(""Manchester""));
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(0)
                .WithArguments("WithAddressValue", "AddressValue"));
        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(1)
                .WithArguments("WithCity", "City"));

        await test.RunAsync();
    }

    [Fact]
    public async Task InlineNestedChainWithMultipleOuterCalls_UnchainsAll()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            Address address = person.AddressValue;
            Person result = person
                .{|#0:WithAddressValue|}(address.{|#1:WithCity|}(""Manchester""))
                .{|#2:WithTags|}(person.Tags.Add((Corvus.Json.JsonString)""superadmin""));
        }
    }
}",
            FixedCode = V4Stubs + PersonStubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Person person = default;
            Address address = person.AddressValue;
            person.SetAddressValue(address.SetCity(""Manchester""));
            person.SetTags(person.Tags.Add((Corvus.Json.JsonString)""superadmin""));
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
            // Iteration 1: outer chain unchains both calls
            // Iteration 2: inner WithCity renames to SetCity
            NumberOfFixAllIterations = 2,
        };

        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(0)
                .WithArguments("WithAddressValue", "AddressValue"));
        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(1)
                .WithArguments("WithCity", "City"));
        test.ExpectedDiagnostics.Add(
            Verify.Diagnostic()
                .WithLocation(2)
                .WithArguments("WithTags", "Tags"));

        await test.RunAsync();
    }
}
