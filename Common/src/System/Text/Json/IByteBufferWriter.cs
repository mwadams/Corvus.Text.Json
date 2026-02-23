// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code to you under the MIT license.

using System.Buffers;

namespace Corvus.Text.Json;

public interface IByteBufferWriter : IBufferWriter<byte>, IDisposable
{
    int Capacity { get; }
    ReadOnlyMemory<byte> WrittenMemory { get; }
    ReadOnlySpan<byte> WrittenSpan { get; }

    void ClearAndReturnBuffers();
}
