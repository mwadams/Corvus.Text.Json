// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Defines a thread-local cache for us to store reusable JsonSchemaResultsCollector instances.
    /// </summary>
    internal static class JsonSchemaResultsCollectorCache
    {
        [ThreadStatic]
        private static ThreadLocalState? t_threadLocalState;

        public static JsonSchemaResultsCollector RentResultsCollector(JsonSchemaResultsLevel level = JsonSchemaResultsLevel.Basic, int initialCapacity = 30)
        {
            ThreadLocalState state = t_threadLocalState ??= new();
            JsonSchemaResultsCollector collector;

            if (state.RentedCollectors++ == 0)
            {
                // First call in the stack -- initialize & return the cached instance.
                collector = state.Collector;
                collector.Reset(level, initialCapacity);
            }
            else
            {
                // We've created a second collector, so we're going to create another instance.
                collector = new JsonSchemaResultsCollector(true, level, initialCapacity);
            }

            return collector;
        }

        public static void ReturnResultsCollector(JsonSchemaResultsCollector collector)
        {
            Debug.Assert(t_threadLocalState != null);
            ThreadLocalState state = t_threadLocalState;

            collector.ResetAllStateForCacheReuse();

            int rentedWorkspaces = --state.RentedCollectors;
            Debug.Assert((rentedWorkspaces == 0) == ReferenceEquals(state.Collector, collector));
        }

        private sealed class ThreadLocalState
        {
            public readonly JsonSchemaResultsCollector Collector;
            public int RentedCollectors;

            public ThreadLocalState()
            {
                Collector = JsonSchemaResultsCollector.CreateEmptyInstanceForCaching();
            }
        }
    }
}
