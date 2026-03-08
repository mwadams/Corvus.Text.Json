// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for generated fixed-size numeric array (tensor) types where items and/or
    /// inner arrays are referenced via $ref or composed via allOf, rather than inlined.
    /// Verifies that the generated APIs are consistent with fully-inline tensor schemas.
    /// </summary>
    public class GeneratedRefNumericArrayTests
    {
        #region RefItemsDoubleVector — $ref items type, rank 1

        [Fact]
        public void RefItemsDoubleVector_StaticProperties()
        {
            Assert.Equal(1, RefItemsDoubleVector.Rank);
            Assert.Equal(3, RefItemsDoubleVector.Dimension);
            Assert.Equal(3, RefItemsDoubleVector.ValueBufferSize);
        }

        [Fact]
        public void RefItemsDoubleVector_Build_CreateTensor()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            RefItemsDoubleVector.Source source = RefItemsDoubleVector.Build(
                static (ref RefItemsDoubleVector.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.5, 2.5, 3.5];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<RefItemsDoubleVector.Mutable> doc =
                RefItemsDoubleVector.BuildDocument(workspace, source);
            RefItemsDoubleVector.Mutable root = doc.RootElement;

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal(1.5, (double)root[0]);
            Assert.Equal(2.5, (double)root[1]);
            Assert.Equal(3.5, (double)root[2]);
        }

        [Fact]
        public void RefItemsDoubleVector_Build_CreateTensor_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            RefItemsDoubleVector.Source source = RefItemsDoubleVector.Build(
                static (ref RefItemsDoubleVector.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.5, 2.5, 3.5];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<RefItemsDoubleVector.Mutable> doc =
                RefItemsDoubleVector.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<RefItemsDoubleVector> reparsed =
                ParsedJsonDocument<RefItemsDoubleVector>.Parse(json);
            Assert.Equal(3, reparsed.RootElement.GetArrayLength());
            Assert.Equal(1.5, (double)reparsed.RootElement[0]);
            Assert.Equal(2.5, (double)reparsed.RootElement[1]);
            Assert.Equal(3.5, (double)reparsed.RootElement[2]);
        }

        [Fact]
        public void RefItemsDoubleVector_FromArray_CreatesValidSource()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<double> values = [1.1, 2.2, 3.3];
            RefItemsDoubleVector.Source source = RefItemsDoubleVector.Source.FromArray(values);

            using JsonDocumentBuilder<RefItemsDoubleVector.Mutable> doc =
                RefItemsDoubleVector.BuildDocument(workspace, source);
            RefItemsDoubleVector.Mutable root = doc.RootElement;

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal(1.1, (double)root[0]);
            Assert.Equal(2.2, (double)root[1]);
            Assert.Equal(3.3, (double)root[2]);
        }

        [Fact]
        public void RefItemsDoubleVector_CreateTensor_WrongSize_ThrowsArgumentException()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Assert.Throws<ArgumentException>(() =>
            {
                RefItemsDoubleVector.Source source = RefItemsDoubleVector.Build(
                    static (ref RefItemsDoubleVector.Builder builder) =>
                    {
                        ReadOnlySpan<double> values = [1.0, 2.0];
                        builder.CreateTensor(values);
                    });

                RefItemsDoubleVector.BuildDocument(workspace, source).Dispose();
            });
        }

        #endregion

        #region RefItemsInt32Vector — $ref items type, rank 1

        [Fact]
        public void RefItemsInt32Vector_StaticProperties()
        {
            Assert.Equal(1, RefItemsInt32Vector.Rank);
            Assert.Equal(4, RefItemsInt32Vector.Dimension);
            Assert.Equal(4, RefItemsInt32Vector.ValueBufferSize);
        }

        [Fact]
        public void RefItemsInt32Vector_Build_CreateTensor()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            RefItemsInt32Vector.Source source = RefItemsInt32Vector.Build(
                static (ref RefItemsInt32Vector.Builder builder) =>
                {
                    ReadOnlySpan<int> values = [10, 20, 30, 40];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<RefItemsInt32Vector.Mutable> doc =
                RefItemsInt32Vector.BuildDocument(workspace, source);
            RefItemsInt32Vector.Mutable root = doc.RootElement;

            Assert.Equal(4, root.GetArrayLength());
            Assert.Equal(10, (int)root[0]);
            Assert.Equal(20, (int)root[1]);
            Assert.Equal(30, (int)root[2]);
            Assert.Equal(40, (int)root[3]);
        }

        [Fact]
        public void RefItemsInt32Vector_Build_CreateTensor_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            RefItemsInt32Vector.Source source = RefItemsInt32Vector.Build(
                static (ref RefItemsInt32Vector.Builder builder) =>
                {
                    ReadOnlySpan<int> values = [10, 20, 30, 40];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<RefItemsInt32Vector.Mutable> doc =
                RefItemsInt32Vector.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<RefItemsInt32Vector> reparsed =
                ParsedJsonDocument<RefItemsInt32Vector>.Parse(json);
            Assert.Equal(4, reparsed.RootElement.GetArrayLength());
            Assert.Equal(10, (int)reparsed.RootElement[0]);
            Assert.Equal(20, (int)reparsed.RootElement[1]);
            Assert.Equal(30, (int)reparsed.RootElement[2]);
            Assert.Equal(40, (int)reparsed.RootElement[3]);
        }

        [Fact]
        public void RefItemsInt32Vector_FromArray_CreatesValidSource()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<int> values = [100, 200, 300, 400];
            RefItemsInt32Vector.Source source = RefItemsInt32Vector.Source.FromArray(values);

            using JsonDocumentBuilder<RefItemsInt32Vector.Mutable> doc =
                RefItemsInt32Vector.BuildDocument(workspace, source);
            RefItemsInt32Vector.Mutable root = doc.RootElement;

            Assert.Equal(4, root.GetArrayLength());
            Assert.Equal(100, (int)root[0]);
            Assert.Equal(200, (int)root[1]);
            Assert.Equal(300, (int)root[2]);
            Assert.Equal(400, (int)root[3]);
        }

        #endregion

        #region RefInnerArrayDoubleMatrix — $ref inner array, rank 2

        [Fact]
        public void RefInnerArrayDoubleMatrix_StaticProperties()
        {
            Assert.Equal(2, RefInnerArrayDoubleMatrix.Rank);
            Assert.Equal(2, RefInnerArrayDoubleMatrix.Dimension);
            Assert.Equal(6, RefInnerArrayDoubleMatrix.ValueBufferSize);
        }

        [Fact]
        public void RefInnerArrayDoubleMatrix_InnerType_StaticProperties()
        {
            Assert.Equal(1, RefInnerArrayDoubleMatrix.DoubleRow.Rank);
            Assert.Equal(3, RefInnerArrayDoubleMatrix.DoubleRow.Dimension);
            Assert.Equal(3, RefInnerArrayDoubleMatrix.DoubleRow.ValueBufferSize);
        }

        [Fact]
        public void RefInnerArrayDoubleMatrix_Build_CreateTensor()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            // 2×3 matrix: [[1.0, 2.0, 3.0], [4.0, 5.0, 6.0]]
            RefInnerArrayDoubleMatrix.Source source = RefInnerArrayDoubleMatrix.Build(
                static (ref RefInnerArrayDoubleMatrix.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.0, 2.0, 3.0, 4.0, 5.0, 6.0];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<RefInnerArrayDoubleMatrix.Mutable> doc =
                RefInnerArrayDoubleMatrix.BuildDocument(workspace, source);
            RefInnerArrayDoubleMatrix.Mutable root = doc.RootElement;

            Assert.Equal(2, root.GetArrayLength());

            RefInnerArrayDoubleMatrix.DoubleRow.Mutable row0 = root[0];
            Assert.Equal(3, row0.GetArrayLength());
            Assert.Equal(1.0, (double)row0[0]);
            Assert.Equal(2.0, (double)row0[1]);
            Assert.Equal(3.0, (double)row0[2]);

            RefInnerArrayDoubleMatrix.DoubleRow.Mutable row1 = root[1];
            Assert.Equal(3, row1.GetArrayLength());
            Assert.Equal(4.0, (double)row1[0]);
            Assert.Equal(5.0, (double)row1[1]);
            Assert.Equal(6.0, (double)row1[2]);
        }

        [Fact]
        public void RefInnerArrayDoubleMatrix_Build_CreateTensor_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            RefInnerArrayDoubleMatrix.Source source = RefInnerArrayDoubleMatrix.Build(
                static (ref RefInnerArrayDoubleMatrix.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.0, 2.0, 3.0, 4.0, 5.0, 6.0];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<RefInnerArrayDoubleMatrix.Mutable> doc =
                RefInnerArrayDoubleMatrix.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<RefInnerArrayDoubleMatrix> reparsed =
                ParsedJsonDocument<RefInnerArrayDoubleMatrix>.Parse(json);
            Assert.Equal(2, reparsed.RootElement.GetArrayLength());

            RefInnerArrayDoubleMatrix.DoubleRow row0 = reparsed.RootElement[0];
            Assert.Equal(3, row0.GetArrayLength());
            Assert.Equal(1.0, (double)row0[0]);
            Assert.Equal(2.0, (double)row0[1]);
            Assert.Equal(3.0, (double)row0[2]);

            RefInnerArrayDoubleMatrix.DoubleRow row1 = reparsed.RootElement[1];
            Assert.Equal(3, row1.GetArrayLength());
            Assert.Equal(4.0, (double)row1[0]);
            Assert.Equal(5.0, (double)row1[1]);
            Assert.Equal(6.0, (double)row1[2]);
        }

        [Fact]
        public void RefInnerArrayDoubleMatrix_CreateTensor_WrongSize_ThrowsArgumentException()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Assert.Throws<ArgumentException>(() =>
            {
                RefInnerArrayDoubleMatrix.Source source = RefInnerArrayDoubleMatrix.Build(
                    static (ref RefInnerArrayDoubleMatrix.Builder builder) =>
                    {
                        ReadOnlySpan<double> values = [1.0, 2.0, 3.0];
                        builder.CreateTensor(values);
                    });

                RefInnerArrayDoubleMatrix.BuildDocument(workspace, source).Dispose();
            });
        }

        [Fact]
        public void RefInnerArrayDoubleMatrix_FromArray_CreatesValidSource()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<double> values = [1.0, 2.0, 3.0, 4.0, 5.0, 6.0];
            RefInnerArrayDoubleMatrix.Source source = RefInnerArrayDoubleMatrix.Source.FromArray(values);

            using JsonDocumentBuilder<RefInnerArrayDoubleMatrix.Mutable> doc =
                RefInnerArrayDoubleMatrix.BuildDocument(workspace, source);

            // FromArray creates a flat numeric array for Source (no nested structure)
            Assert.Equal(6, doc.RootElement.GetArrayLength());
        }

        #endregion

        #region AllOfDoubleVector — allOf-composed rank-1 vector

        [Fact]
        public void AllOfDoubleVector_StaticProperties()
        {
            // Outer type only gets Rank; Dimension and ValueBufferSize live on the inner BaseVector type
            Assert.Equal(1, AllOfDoubleVector.Rank);
        }

        [Fact]
        public void AllOfDoubleVector_BaseVector_StaticProperties()
        {
            // The inner BaseVector type gets full tensor properties
            Assert.Equal(1, AllOfDoubleVector.BaseVector.Rank);
            Assert.Equal(3, AllOfDoubleVector.BaseVector.Dimension);
            Assert.Equal(3, AllOfDoubleVector.BaseVector.ValueBufferSize);
        }

        [Fact]
        public void AllOfDoubleVector_Build_Add_Items()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            AllOfDoubleVector.Source source = AllOfDoubleVector.Build(
                static (ref AllOfDoubleVector.Builder builder) =>
                {
                    builder.Add(1.5);
                    builder.Add(2.5);
                    builder.Add(3.5);
                });

            using JsonDocumentBuilder<AllOfDoubleVector.Mutable> doc =
                AllOfDoubleVector.BuildDocument(workspace, source);
            AllOfDoubleVector.Mutable root = doc.RootElement;

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal(1.5, (double)root[0]);
            Assert.Equal(2.5, (double)root[1]);
            Assert.Equal(3.5, (double)root[2]);
        }

        [Fact]
        public void AllOfDoubleVector_Build_Add_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            AllOfDoubleVector.Source source = AllOfDoubleVector.Build(
                static (ref AllOfDoubleVector.Builder builder) =>
                {
                    builder.Add(1.5);
                    builder.Add(2.5);
                    builder.Add(3.5);
                });

            using JsonDocumentBuilder<AllOfDoubleVector.Mutable> doc =
                AllOfDoubleVector.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<AllOfDoubleVector> reparsed =
                ParsedJsonDocument<AllOfDoubleVector>.Parse(json);
            Assert.Equal(3, reparsed.RootElement.GetArrayLength());
            Assert.Equal(1.5, (double)reparsed.RootElement[0]);
            Assert.Equal(2.5, (double)reparsed.RootElement[1]);
            Assert.Equal(3.5, (double)reparsed.RootElement[2]);
        }

        [Fact]
        public void AllOfDoubleVector_TryGetAsBaseVector_AccessesComposedType()
        {
            using ParsedJsonDocument<AllOfDoubleVector> doc =
                ParsedJsonDocument<AllOfDoubleVector>.Parse("[1.0, 2.0, 3.0]");

            Assert.True(doc.RootElement.TryGetAsBaseVector(out AllOfDoubleVector.BaseVector baseVector));
            Assert.Equal(3, baseVector.GetArrayLength());
            Assert.Equal(1.0, (double)baseVector[0]);
            Assert.Equal(2.0, (double)baseVector[1]);
            Assert.Equal(3.0, (double)baseVector[2]);
        }

        [Fact]
        public void AllOfDoubleVector_FromArray_CreatesValidSource()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<double> values = [1.1, 2.2, 3.3];
            AllOfDoubleVector.Source source = AllOfDoubleVector.Source.FromArray(values);

            using JsonDocumentBuilder<AllOfDoubleVector.Mutable> doc =
                AllOfDoubleVector.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<AllOfDoubleVector> reparsed =
                ParsedJsonDocument<AllOfDoubleVector>.Parse(json);
            Assert.Equal(3, reparsed.RootElement.GetArrayLength());
            Assert.Equal(1.1, (double)reparsed.RootElement[0]);
            Assert.Equal(2.2, (double)reparsed.RootElement[1]);
            Assert.Equal(3.3, (double)reparsed.RootElement[2]);
        }

        #endregion

        #region AllOfInt32Matrix — allOf-composed rank-2 matrix

        [Fact]
        public void AllOfInt32Matrix_StaticProperties()
        {
            // Outer type only gets Rank; Dimension and ValueBufferSize live on the inner BaseMatrix type
            Assert.Equal(2, AllOfInt32Matrix.Rank);
        }

        [Fact]
        public void AllOfInt32Matrix_BaseMatrix_StaticProperties()
        {
            // The inner BaseMatrix type gets full tensor properties
            Assert.Equal(2, AllOfInt32Matrix.BaseMatrix.Rank);
            Assert.Equal(2, AllOfInt32Matrix.BaseMatrix.Dimension);
            Assert.Equal(6, AllOfInt32Matrix.BaseMatrix.ValueBufferSize);
        }

        [Fact]
        public void AllOfInt32Matrix_Build_Add_Rows()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            AllOfInt32Matrix.Source source = AllOfInt32Matrix.Build(
                static (ref AllOfInt32Matrix.Builder builder) =>
                {
                    builder.Add(AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Build(
                        static (ref AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Builder inner) =>
                        {
                            inner.Add(1);
                            inner.Add(2);
                            inner.Add(3);
                        }));
                    builder.Add(AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Build(
                        static (ref AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Builder inner) =>
                        {
                            inner.Add(4);
                            inner.Add(5);
                            inner.Add(6);
                        }));
                });

            using JsonDocumentBuilder<AllOfInt32Matrix.Mutable> doc =
                AllOfInt32Matrix.BuildDocument(workspace, source);
            AllOfInt32Matrix.Mutable root = doc.RootElement;

            Assert.Equal(2, root.GetArrayLength());

            var row0 = root[0];
            Assert.Equal(3, row0.GetArrayLength());
            Assert.Equal(1, (int)row0[0]);
            Assert.Equal(2, (int)row0[1]);
            Assert.Equal(3, (int)row0[2]);

            var row1 = root[1];
            Assert.Equal(3, row1.GetArrayLength());
            Assert.Equal(4, (int)row1[0]);
            Assert.Equal(5, (int)row1[1]);
            Assert.Equal(6, (int)row1[2]);
        }

        [Fact]
        public void AllOfInt32Matrix_Build_Add_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            AllOfInt32Matrix.Source source = AllOfInt32Matrix.Build(
                static (ref AllOfInt32Matrix.Builder builder) =>
                {
                    builder.Add(AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Build(
                        static (ref AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Builder inner) =>
                        {
                            inner.Add(1);
                            inner.Add(2);
                            inner.Add(3);
                        }));
                    builder.Add(AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Build(
                        static (ref AllOfInt32Matrix.BaseMatrix.ItemsEntityArray.Builder inner) =>
                        {
                            inner.Add(4);
                            inner.Add(5);
                            inner.Add(6);
                        }));
                });

            using JsonDocumentBuilder<AllOfInt32Matrix.Mutable> doc =
                AllOfInt32Matrix.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<AllOfInt32Matrix> reparsed =
                ParsedJsonDocument<AllOfInt32Matrix>.Parse(json);
            Assert.Equal(2, reparsed.RootElement.GetArrayLength());

            var row0 = reparsed.RootElement[0];
            Assert.Equal(3, row0.GetArrayLength());
            Assert.Equal(1, (int)row0[0]);
            Assert.Equal(2, (int)row0[1]);
            Assert.Equal(3, (int)row0[2]);

            var row1 = reparsed.RootElement[1];
            Assert.Equal(3, row1.GetArrayLength());
            Assert.Equal(4, (int)row1[0]);
            Assert.Equal(5, (int)row1[1]);
            Assert.Equal(6, (int)row1[2]);
        }

        [Fact]
        public void AllOfInt32Matrix_TryGetAsBaseMatrix_AccessesComposedType()
        {
            using ParsedJsonDocument<AllOfInt32Matrix> doc =
                ParsedJsonDocument<AllOfInt32Matrix>.Parse("[[1,2,3],[4,5,6]]");

            Assert.True(doc.RootElement.TryGetAsBaseMatrix(out AllOfInt32Matrix.BaseMatrix baseMatrix));
            Assert.Equal(2, baseMatrix.GetArrayLength());
            Assert.Equal(1, (int)baseMatrix[0][0]);
            Assert.Equal(6, (int)baseMatrix[1][2]);
        }

        [Fact]
        public void AllOfInt32Matrix_FromArray_CreatesValidSource()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            ReadOnlySpan<int> values = [1, 2, 3, 4, 5, 6];
            AllOfInt32Matrix.Source source = AllOfInt32Matrix.Source.FromArray(values);

            using JsonDocumentBuilder<AllOfInt32Matrix.Mutable> doc =
                AllOfInt32Matrix.BuildDocument(workspace, source);

            // FromArray creates a flat numeric array for Source (no nested structure)
            Assert.Equal(6, doc.RootElement.GetArrayLength());
        }

        #endregion
    }
}
