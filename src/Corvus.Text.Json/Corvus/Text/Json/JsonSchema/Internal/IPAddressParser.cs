// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace Corvus.Text.Json.Internal
{
    internal static class IPAddressParser
    {
        internal const int MaxIPv4StringLength = 15; // 4 numbers separated by 3 periods, with up to 3 digits per number
        internal const int MaxIPv6StringLength = 65;

        public static unsafe bool IsValidIPV6(ReadOnlySpan<byte> ipSpan, bool disallowScope = true)
        {
            fixed (byte* ipStringPtr = &MemoryMarshal.GetReference(ipSpan))
            {
                if (ipSpan.IndexOf((byte)':') >= 0)
                {
                    return IPv6AddressHelper.IsValidStrict(ipStringPtr, 0, ipSpan.Length, disallowScope);
                }

                return false;
            }
        }

        public static unsafe bool IsValidIPV4(ReadOnlySpan<byte> ipSpan, bool requireCanonical = true)
        {
            fixed (byte* ipStringPtr = &MemoryMarshal.GetReference(ipSpan))
            {
                if (ipSpan.IndexOf((byte)':') >= 0)
                {
                    return false;
                }
                else
                {
                    int end = ipSpan.Length;
                    long address = IPv4AddressHelper.ParseNonCanonical(ipStringPtr, 0, ref end, notImplicitFile: true, requireCanonical);
                    return address != IPv4AddressHelper.Invalid && end == ipSpan.Length;
                }
            }
        }
    }
}
