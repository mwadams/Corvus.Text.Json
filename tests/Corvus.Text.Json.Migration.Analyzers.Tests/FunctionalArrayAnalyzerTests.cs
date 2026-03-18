// <copyright file="FunctionalArrayAnalyzerTests.cs" company="Endjin Limited">
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
    Corvus.Text.Json.Migration.Analyzers.FunctionalArrayAnalyzer,
    Corvus.Text.Json.Migration.Analyzers.FunctionalArrayCodeFix,
    Microsoft.CodeAnalysis.Testing.DefaultVerifier>;
using Verify = Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerVerifier<
    Corvus.Text.Json.Migration.Analyzers.FunctionalArrayAnalyzer,
    Microsoft.CodeAnalysis.Testing.DefaultVerifier>;

namespace Corvus.Text.Json.Migration.Analyzers.Tests;

/// <summary>
/// Tests for CVJ012: Functional array operations migration.
/// </summary>
public class FunctionalArrayAnalyzerTests
{
    private const string V4Stubs = @"
namespace Corvus.Json
{
    public interface IJsonValue { }

    public struct JsonArray : IJsonValue
    {
        public JsonArray Add(JsonAny item) => default;
        public JsonArray Insert(int index, JsonAny item) => default;
        public JsonArray SetItem(int index, JsonAny item) => default;
        public JsonArray RemoveAt(int index) => default;
    }

    public struct JsonAny : IJsonValue { }
}
";

    [Fact]
    public async Task Add_TriggersCVJ012_AndCodeFixRenames()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            arr = arr.{|#0:Add|}(item);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.AddItem(item);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task Insert_TriggersCVJ012_AndCodeFixRenames()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            arr = arr.{|#0:Insert|}(0, item);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.InsertItem(0, item);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Insert", "InsertItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task SetItem_TriggersCVJ012_AndCodeFixKeepsName()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            arr = arr.{|#0:SetItem|}(0, item);
        }
    }
}",
            FixedState =
            {
                Sources = { V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.{|#0:SetItem|}(0, item);
        }
    }
}" },
                ExpectedDiagnostics =
                {
                    Verify.Diagnostic().WithLocation(0).WithArguments("SetItem", "SetItem"),
                },
            },
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("SetItem", "SetItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task RemoveAt_TriggersCVJ012_AndCodeFixKeepsName()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            arr = arr.{|#0:RemoveAt|}(0);
        }
    }
}",
            FixedState =
            {
                Sources = { V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            arr.{|#0:RemoveAt|}(0);
        }
    }
}" },
                ExpectedDiagnostics =
                {
                    Verify.Diagnostic().WithLocation(0).WithArguments("RemoveAt", "RemoveAt"),
                },
            },
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("RemoveAt", "RemoveAt"));
        await test.RunAsync();
    }

    [Fact]
    public async Task LocalDeclaration_DropsAssignment()
    {
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            Corvus.Json.JsonArray result = arr.{|#0:Add|}(item);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.AddItem(item);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task NonJsonValueType_NoDiagnostic()
    {
        string testCode = @"
using System.Collections.Generic;

namespace TestApp
{
    class Test
    {
        void M()
        {
            var list = new List<int>();
            list.Add(42);
        }
    }
}";

        await Verify.VerifyAnalyzerAsync(testCode);
    }

    // ── Edge case tests ─────────────────────────────────────────────

    [Fact]
    public async Task Add_VarType_DropsAssignment()
    {
        // var instead of explicit type
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            var result = arr.{|#0:Add|}(item);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.AddItem(item);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task Add_AssignToDifferentVariable_DropsAssignment()
    {
        // Result assigned to a different variable than the receiver
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            Corvus.Json.JsonArray other = arr.{|#0:Add|}(item);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.AddItem(item);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task Add_InExpressionContext_StillRenames()
    {
        // Add() used as argument — cannot drop the outer call, but
        // should still rename Add to AddItem (or at least fire diagnostic).
        string testCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void Consume(Corvus.Json.JsonArray arr) { }

        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            Consume(arr.{|#0:Add|}(item));
        }
    }
}";

        await Verify.VerifyAnalyzerAsync(testCode,
            Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
    }

    [Fact]
    public async Task Add_InReturnStatement_PreservesReturn()
    {
        // return arr.Add(item) → arr.AddItem(item); return arr;
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        Corvus.Json.JsonArray M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny item = default;
            return arr.{|#0:Add|}(item);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        Corvus.Json.JsonArray M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.AddItem(item);
            return arr;
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task Add_Chained_SplitsIntoSeparateCalls()
    {
        // arr = arr.Add(a).Add(b) → arr.AddItem(a); arr.AddItem(b);
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray arr = default;
            Corvus.Json.JsonAny a = default;
            Corvus.Json.JsonAny b = default;
            arr = arr.{|#0:Add|}(a).{|#1:Add|}(b);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny a = default;
            Corvus.Json.JsonAny b = default;
            arr.AddItem(a);
            arr.AddItem(b);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
            NumberOfFixAllIterations = 1,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(1).WithArguments("Add", "AddItem"));
        await test.RunAsync();
    }

    [Fact]
    public async Task Add_AlreadyMutable_DoesNotDoubleAppend()
    {
        // If the type is already Corvus.Json.JsonArray.Mutable, don't change it
        var test = new CodeFixTest
        {
            TestCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr = arr.{|#0:Add|}(item);
        }
    }
}",
            FixedCode = V4Stubs + @"
namespace TestApp
{
    class Test
    {
        void M()
        {
            Corvus.Json.JsonArray.Mutable arr = default;
            Corvus.Json.JsonAny item = default;
            arr.AddItem(item);
        }
    }
}",
            CompilerDiagnostics = CompilerDiagnostics.None,
        };

        test.ExpectedDiagnostics.Add(Verify.Diagnostic().WithLocation(0).WithArguments("Add", "AddItem"));
        await test.RunAsync();
    }
}
