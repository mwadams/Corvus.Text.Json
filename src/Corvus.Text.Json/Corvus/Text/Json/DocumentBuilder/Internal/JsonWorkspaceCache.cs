// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Diagnostics;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Defines a thread-local cache for JsonSerializer to store reusable Utf8JsonWriter/IBufferWriter instances.
    /// </summary>
    internal static class JsonWorkspaceCache
    {
        [ThreadStatic]
        private static ThreadLocalState? t_threadLocalState;

        public static JsonWorkspace RentWorkspace(int initialDocumentCapacity = 5, JsonWriterOptions? options = null)
        {
            ThreadLocalState state = t_threadLocalState ??= new();
            JsonWorkspace workspace;

            if (state.RentedWorkspaces++ == 0)
            {
                // First call in the stack -- initialize & return the cached instance.
                workspace = state.Workspace;
                workspace.Reset(initialDocumentCapacity, options);
            }
            else
            {
                // We're in a recursive call -- return a fresh instance.
                workspace = new JsonWorkspace(true, initialDocumentCapacity, options);
            }

            return workspace;
        }

        public static void ReturnWorkspace(JsonWorkspace workspace)
        {
            Debug.Assert(t_threadLocalState != null);
            ThreadLocalState state = t_threadLocalState;

            workspace.ResetAllStateForCacheReuse();

            int rentedWorkspaces = --state.RentedWorkspaces;
            Debug.Assert((rentedWorkspaces == 0) == ReferenceEquals(state.Workspace, workspace));
        }

        private sealed class ThreadLocalState
        {
            public readonly JsonWorkspace Workspace;
            public int RentedWorkspaces;

            public ThreadLocalState()
            {
                Workspace = JsonWorkspace.CreateEmptyInstanceForCaching();
            }
        }
    }
}
