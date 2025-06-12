// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System.Diagnostics;

namespace Corvus.Text.Json.Internal
{
    internal readonly struct JsonRegexNode
    {
        /// <summary>Arbitrary number of repetitions of the same character when we'd prefer to represent that as a repeater of that character rather than a string.</summary>
        internal const int MultiVsRepeaterLimit = 64;

        internal static JsonRegexNode Null { get; } = new JsonRegexNode(-1);

        internal JsonRegexNode(int index)
        {
            _idx = index;
        }

        private readonly int _idx;

        internal readonly bool IsNull => _idx < 0;

        public void AddChild(ref JsonRegexValidator validator, in JsonRegexNode child)
        {
            validator.SetParent(child._idx, _idx);
        }

        public void SetParent(ref JsonRegexValidator validator, in JsonRegexNode parent) => validator.SetParent(_idx, parent._idx);
        public readonly JsonRegexNode GetParent(ref JsonRegexValidator validator) => validator.GetParent(_idx);

        public readonly JsonRegexNodeKind GetNodeKind(ref JsonRegexValidator validator) => validator.GetNodeKind(_idx);

        public readonly int GetChildCount(ref JsonRegexValidator validator) => validator.GetChildCount(_idx);

        internal readonly JsonRegexNode MakeQuantifier(ref JsonRegexValidator validator, bool lazy, int min, int max)
        {
            // Certain cases of repeaters (min == max) can be handled specially
            if (min == max)
            {
                switch (max)
                {
                    case 0:
                        // The node is repeated 0 times, so it's actually empty.
                        return validator.CreateNode(JsonRegexNodeKind.Empty);

                    case 1:
                        // The node is repeated 1 time, so it's not actually a repeater.
                        return this;

                    case <= MultiVsRepeaterLimit when GetNodeKind(ref validator) == JsonRegexNodeKind.One:
                        // The same character is repeated a fixed number of times, so it's actually a multi.
                        // While this could remain a repeater, multis are more readily optimized later in
                        // processing. The counts used here in real-world expressions are invariably small (e.g. 4),
                        // but we set an upper bound just to avoid creating really large strings.
                        Debug.Assert(max >= 2);
                        validator.SetKind(_idx, JsonRegexNodeKind.Multi);
                        return this;
                }
            }

            switch (GetNodeKind(ref validator))
            {
                case JsonRegexNodeKind.One:
                case JsonRegexNodeKind.Notone:
                case JsonRegexNodeKind.Set:
                    MakeRep(ref validator, lazy ? JsonRegexNodeKind.Onelazy : JsonRegexNodeKind.Oneloop);
                    return this;

                default:
                    JsonRegexNode result = validator.CreateNode(lazy ? JsonRegexNodeKind.Lazyloop : JsonRegexNodeKind.Loop);
                    result.AddChild(ref validator, this);
                    return result;
            }
        }

        /// <summary>
        /// Pass type as OneLazy or OneLoop
        /// </summary>
        private void MakeRep(ref JsonRegexValidator validator, JsonRegexNodeKind kind)
        {
            JsonRegexNodeKind currentKind = validator.GetNodeKind(_idx);
            currentKind += kind - JsonRegexNodeKind.One;
            validator.SetKind(_idx, currentKind);
        }

    }
}
