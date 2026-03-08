// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Corvus.Text.Json.Tests.GeneratedModels.Draft202012;
using Xunit;

namespace Corvus.Text.Json.Tests
{
    /// <summary>
    /// Tests for generated fixed-size numeric array (tensor) types.
    /// Covers rank 1 (vector), rank 2 (matrix), rank 3 (cube) with both double and int32 numeric types.
    /// Tests static properties, CreateTensor, wrong-size validation, and round-trip materialisation.
    /// </summary>
    public class GeneratedNumericArrayTests
    {
        #region Static properties

        [Fact]
        public void Rank1DoubleVector_StaticProperties()
        {
            Assert.Equal(1, Rank1DoubleVector.Rank);
            Assert.Equal(3, Rank1DoubleVector.Dimension);
            Assert.Equal(3, Rank1DoubleVector.ValueBufferSize);
        }

        [Fact]
        public void Rank1Int32Vector_StaticProperties()
        {
            Assert.Equal(1, Rank1Int32Vector.Rank);
            Assert.Equal(4, Rank1Int32Vector.Dimension);
            Assert.Equal(4, Rank1Int32Vector.ValueBufferSize);
        }

        [Fact]
        public void Rank2DoubleMatrix_StaticProperties()
        {
            Assert.Equal(2, Rank2DoubleMatrix.Rank);
            Assert.Equal(2, Rank2DoubleMatrix.Dimension);
            Assert.Equal(6, Rank2DoubleMatrix.ValueBufferSize);
        }

        [Fact]
        public void Rank3Int32Cube_StaticProperties()
        {
            Assert.Equal(3, Rank3Int32Cube.Rank);
            Assert.Equal(2, Rank3Int32Cube.Dimension);
            Assert.Equal(12, Rank3Int32Cube.ValueBufferSize);
        }

        #endregion

        #region Rank 1 double vector — Build + CreateTensor

        [Fact]
        public void Rank1DoubleVector_Build_CreateTensor()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Rank1DoubleVector.Source source = Rank1DoubleVector.Build(
                static (ref Rank1DoubleVector.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.5, 2.5, 3.5];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank1DoubleVector.Mutable> doc =
                Rank1DoubleVector.BuildDocument(workspace, source);
            Rank1DoubleVector.Mutable root = doc.RootElement;

            Assert.Equal(3, root.GetArrayLength());
            Assert.Equal(1.5, (double)root[0]);
            Assert.Equal(2.5, (double)root[1]);
            Assert.Equal(3.5, (double)root[2]);
        }

        [Fact]
        public void Rank1DoubleVector_Build_CreateTensor_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Rank1DoubleVector.Source source = Rank1DoubleVector.Build(
                static (ref Rank1DoubleVector.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.5, 2.5, 3.5];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank1DoubleVector.Mutable> doc =
                Rank1DoubleVector.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<Rank1DoubleVector> reparsed =
                ParsedJsonDocument<Rank1DoubleVector>.Parse(json);
            Assert.Equal(3, reparsed.RootElement.GetArrayLength());
            Assert.Equal(1.5, (double)reparsed.RootElement[0]);
            Assert.Equal(2.5, (double)reparsed.RootElement[1]);
            Assert.Equal(3.5, (double)reparsed.RootElement[2]);
        }

        #endregion

        #region Rank 1 int32 vector — Build + CreateTensor

        [Fact]
        public void Rank1Int32Vector_Build_CreateTensor()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Rank1Int32Vector.Source source = Rank1Int32Vector.Build(
                static (ref Rank1Int32Vector.Builder builder) =>
                {
                    ReadOnlySpan<int> values = [10, 20, 30, 40];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank1Int32Vector.Mutable> doc =
                Rank1Int32Vector.BuildDocument(workspace, source);
            Rank1Int32Vector.Mutable root = doc.RootElement;

            Assert.Equal(4, root.GetArrayLength());
            Assert.Equal(10, (int)root[0]);
            Assert.Equal(20, (int)root[1]);
            Assert.Equal(30, (int)root[2]);
            Assert.Equal(40, (int)root[3]);
        }

        [Fact]
        public void Rank1Int32Vector_Build_CreateTensor_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Rank1Int32Vector.Source source = Rank1Int32Vector.Build(
                static (ref Rank1Int32Vector.Builder builder) =>
                {
                    ReadOnlySpan<int> values = [10, 20, 30, 40];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank1Int32Vector.Mutable> doc =
                Rank1Int32Vector.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<Rank1Int32Vector> reparsed =
                ParsedJsonDocument<Rank1Int32Vector>.Parse(json);
            Assert.Equal(4, reparsed.RootElement.GetArrayLength());
            Assert.Equal(10, (int)reparsed.RootElement[0]);
            Assert.Equal(20, (int)reparsed.RootElement[1]);
            Assert.Equal(30, (int)reparsed.RootElement[2]);
            Assert.Equal(40, (int)reparsed.RootElement[3]);
        }

        #endregion

        #region Rank 1 wrong-size tensor — ArgumentException

        [Fact]
        public void Rank1DoubleVector_CreateTensor_WrongSize_ThrowsArgumentException()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Assert.Throws<ArgumentException>(() =>
            {
                Rank1DoubleVector.Source source = Rank1DoubleVector.Build(
                    static (ref Rank1DoubleVector.Builder builder) =>
                    {
                        ReadOnlySpan<double> values = [1.0, 2.0];
                        builder.CreateTensor(values);
                    });

                Rank1DoubleVector.BuildDocument(workspace, source).Dispose();
            });
        }

        [Fact]
        public void Rank1Int32Vector_CreateTensor_WrongSize_ThrowsArgumentException()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Assert.Throws<ArgumentException>(() =>
            {
                Rank1Int32Vector.Source source = Rank1Int32Vector.Build(
                    static (ref Rank1Int32Vector.Builder builder) =>
                    {
                        ReadOnlySpan<int> values = [1, 2, 3, 4, 5];
                        builder.CreateTensor(values);
                    });

                Rank1Int32Vector.BuildDocument(workspace, source).Dispose();
            });
        }

        #endregion

        #region Rank 2 double matrix — Build + CreateTensor

        [Fact]
        public void Rank2DoubleMatrix_Build_CreateTensor()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            // 2×3 matrix: [[1.0, 2.0, 3.0], [4.0, 5.0, 6.0]]
            Rank2DoubleMatrix.Source source = Rank2DoubleMatrix.Build(
                static (ref Rank2DoubleMatrix.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.0, 2.0, 3.0, 4.0, 5.0, 6.0];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank2DoubleMatrix.Mutable> doc =
                Rank2DoubleMatrix.BuildDocument(workspace, source);
            Rank2DoubleMatrix.Mutable root = doc.RootElement;

            Assert.Equal(2, root.GetArrayLength());

            // First row: [1.0, 2.0, 3.0]
            Rank2DoubleMatrix.ItemsEntityArray.Mutable row0 = root[0];
            Assert.Equal(3, row0.GetArrayLength());
            Assert.Equal(1.0, (double)row0[0]);
            Assert.Equal(2.0, (double)row0[1]);
            Assert.Equal(3.0, (double)row0[2]);

            // Second row: [4.0, 5.0, 6.0]
            Rank2DoubleMatrix.ItemsEntityArray.Mutable row1 = root[1];
            Assert.Equal(3, row1.GetArrayLength());
            Assert.Equal(4.0, (double)row1[0]);
            Assert.Equal(5.0, (double)row1[1]);
            Assert.Equal(6.0, (double)row1[2]);
        }

        [Fact]
        public void Rank2DoubleMatrix_Build_CreateTensor_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Rank2DoubleMatrix.Source source = Rank2DoubleMatrix.Build(
                static (ref Rank2DoubleMatrix.Builder builder) =>
                {
                    ReadOnlySpan<double> values = [1.0, 2.0, 3.0, 4.0, 5.0, 6.0];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank2DoubleMatrix.Mutable> doc =
                Rank2DoubleMatrix.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<Rank2DoubleMatrix> reparsed =
                ParsedJsonDocument<Rank2DoubleMatrix>.Parse(json);
            Assert.Equal(2, reparsed.RootElement.GetArrayLength());

            Rank2DoubleMatrix.ItemsEntityArray row0 = reparsed.RootElement[0];
            Assert.Equal(3, row0.GetArrayLength());
            Assert.Equal(1.0, (double)row0[0]);
            Assert.Equal(2.0, (double)row0[1]);
            Assert.Equal(3.0, (double)row0[2]);

            Rank2DoubleMatrix.ItemsEntityArray row1 = reparsed.RootElement[1];
            Assert.Equal(3, row1.GetArrayLength());
            Assert.Equal(4.0, (double)row1[0]);
            Assert.Equal(5.0, (double)row1[1]);
            Assert.Equal(6.0, (double)row1[2]);
        }

        [Fact]
        public void Rank2DoubleMatrix_CreateTensor_WrongSize_ThrowsArgumentException()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Assert.Throws<ArgumentException>(() =>
            {
                Rank2DoubleMatrix.Source source = Rank2DoubleMatrix.Build(
                    static (ref Rank2DoubleMatrix.Builder builder) =>
                    {
                        ReadOnlySpan<double> values = [1.0, 2.0, 3.0];
                        builder.CreateTensor(values);
                    });

                Rank2DoubleMatrix.BuildDocument(workspace, source).Dispose();
            });
        }

        #endregion

        #region Rank 2 double matrix — inner type static properties

        [Fact]
        public void Rank2DoubleMatrix_InnerType_StaticProperties()
        {
            Assert.Equal(1, Rank2DoubleMatrix.ItemsEntityArray.Rank);
            Assert.Equal(3, Rank2DoubleMatrix.ItemsEntityArray.Dimension);
            Assert.Equal(3, Rank2DoubleMatrix.ItemsEntityArray.ValueBufferSize);
        }

        #endregion

        #region Rank 3 int32 cube — Build + CreateTensor

        [Fact]
        public void Rank3Int32Cube_Build_CreateTensor()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            // 2×2×3 cube: [[[1,2,3],[4,5,6]],[[7,8,9],[10,11,12]]]
            Rank3Int32Cube.Source source = Rank3Int32Cube.Build(
                static (ref Rank3Int32Cube.Builder builder) =>
                {
                    ReadOnlySpan<int> values = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank3Int32Cube.Mutable> doc =
                Rank3Int32Cube.BuildDocument(workspace, source);
            Rank3Int32Cube.Mutable root = doc.RootElement;

            Assert.Equal(2, root.GetArrayLength());

            // First plane: [[1,2,3],[4,5,6]]
            var plane0 = root[0];
            Assert.Equal(2, plane0.GetArrayLength());
            var row00 = plane0[0];
            Assert.Equal(3, row00.GetArrayLength());
            Assert.Equal(1, (int)row00[0]);
            Assert.Equal(2, (int)row00[1]);
            Assert.Equal(3, (int)row00[2]);
            var row01 = plane0[1];
            Assert.Equal(3, row01.GetArrayLength());
            Assert.Equal(4, (int)row01[0]);
            Assert.Equal(5, (int)row01[1]);
            Assert.Equal(6, (int)row01[2]);

            // Second plane: [[7,8,9],[10,11,12]]
            var plane1 = root[1];
            Assert.Equal(2, plane1.GetArrayLength());
            var row10 = plane1[0];
            Assert.Equal(3, row10.GetArrayLength());
            Assert.Equal(7, (int)row10[0]);
            Assert.Equal(8, (int)row10[1]);
            Assert.Equal(9, (int)row10[2]);
            var row11 = plane1[1];
            Assert.Equal(3, row11.GetArrayLength());
            Assert.Equal(10, (int)row11[0]);
            Assert.Equal(11, (int)row11[1]);
            Assert.Equal(12, (int)row11[2]);
        }

        [Fact]
        public void Rank3Int32Cube_Build_CreateTensor_MaterializesRoundTrip()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Rank3Int32Cube.Source source = Rank3Int32Cube.Build(
                static (ref Rank3Int32Cube.Builder builder) =>
                {
                    ReadOnlySpan<int> values = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
                    builder.CreateTensor(values);
                });

            using JsonDocumentBuilder<Rank3Int32Cube.Mutable> doc =
                Rank3Int32Cube.BuildDocument(workspace, source);

            string json = doc.RootElement.ToString();

            using ParsedJsonDocument<Rank3Int32Cube> reparsed =
                ParsedJsonDocument<Rank3Int32Cube>.Parse(json);
            Assert.Equal(2, reparsed.RootElement.GetArrayLength());

            // Verify first plane, first row
            var plane0 = reparsed.RootElement[0];
            Assert.Equal(2, plane0.GetArrayLength());
            var row00 = plane0[0];
            Assert.Equal(1, (int)row00[0]);
            Assert.Equal(2, (int)row00[1]);
            Assert.Equal(3, (int)row00[2]);

            // Verify last plane, last row
            var plane1 = reparsed.RootElement[1];
            var row11 = plane1[1];
            Assert.Equal(10, (int)row11[0]);
            Assert.Equal(11, (int)row11[1]);
            Assert.Equal(12, (int)row11[2]);
        }

        [Fact]
        public void Rank3Int32Cube_CreateTensor_WrongSize_ThrowsArgumentException()
        {
            using JsonWorkspace workspace = JsonWorkspace.Create();

            Assert.Throws<ArgumentException>(() =>
            {
                Rank3Int32Cube.Source source = Rank3Int32Cube.Build(
                    static (ref Rank3Int32Cube.Builder builder) =>
                    {
                        ReadOnlySpan<int> values = [1, 2, 3, 4, 5, 6];
                        builder.CreateTensor(values);
                    });

                Rank3Int32Cube.BuildDocument(workspace, source).Dispose();
            });
        }

        #endregion

        #region Rank 3 int32 cube — inner type static properties

        [Fact]
        public void Rank3Int32Cube_InnerTypes_StaticProperties()
        {
            // Middle rank: 2×3 matrix
            Assert.Equal(2, Rank3Int32Cube.ItemsArray2Array.Rank);
            Assert.Equal(2, Rank3Int32Cube.ItemsArray2Array.Dimension);
            Assert.Equal(6, Rank3Int32Cube.ItemsArray2Array.ValueBufferSize);

            // Innermost rank: 3-element vector
            Assert.Equal(1, Rank3Int32Cube.ItemsArray2Array.ItemsEntityArray.Rank);
            Assert.Equal(3, Rank3Int32Cube.ItemsArray2Array.ItemsEntityArray.Dimension);
            Assert.Equal(3, Rank3Int32Cube.ItemsArray2Array.ItemsEntityArray.ValueBufferSize);
        }

        #endregion
    }
}
