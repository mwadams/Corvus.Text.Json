// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace Corvus.Text.Json.Internal
{
    internal static class IPAddressParser
    {
        internal const int MaxIPv4StringLength = 15; // 4 numbers separated by 3 periods, with up to 3 digits per number
        internal const int MaxIPv6StringLength = 65;

        public static unsafe bool IsValid(ReadOnlySpan<byte> ipSpan, bool disallowV6Scope = true, bool requireCanonicalIPV4 = true)
        {
            fixed (byte* ipStringPtr = &MemoryMarshal.GetReference(ipSpan))
            {
                if (ipSpan.IndexOf((byte)':') >= 0)
                {
                    return IPv6AddressHelper.IsValidStrict(ipStringPtr, 0, ipSpan.Length, disallowV6Scope);
                }
                else
                {
                    int end = ipSpan.Length;
                    long address = IPv4AddressHelper.ParseNonCanonical(ipStringPtr, 0, ref end, notImplicitFile: true, requireCanonicalIPV4);
                    return address != IPv4AddressHelper.Invalid && end == ipSpan.Length;
                }
            }
        }

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


        ////internal static IPAddress? Parse(ReadOnlySpan<byte> ipSpan, bool tryParse)
        ////{
        ////    if (ipSpan.IndexOf((byte)':') >= 0)
        ////    {
        ////        // The address is parsed as IPv6 if and only if it contains a colon. This is valid because
        ////        // we don't support/parse a port specification at the end of an IPv4 address.
        ////        Span<ushort> numbers = stackalloc ushort[IPAddressParserStatics.IPv6AddressShorts];
        ////        numbers.Clear();
        ////        if (TryParseIPv6(ipSpan, numbers, IPAddressParserStatics.IPv6AddressShorts, out uint scope))
        ////        {
        ////            return new IPAddress(numbers, scope);
        ////        }
        ////    }
        ////    else if (TryParseIpv4(ipSpan, out long address))
        ////    {
        ////        return new IPAddress(address);
        ////    }

        ////    if (tryParse)
        ////    {
        ////        return null;
        ////    }

        ////    throw new FormatException(SR.dns_bad_ip_address, new SocketException(SocketError.InvalidArgument));
        ////}

        ////private static unsafe bool TryParseIpv4(ReadOnlySpan<byte> ipSpan, out long address)
        ////{
        ////    int end = ipSpan.Length;
        ////    long tmpAddr;

        ////    fixed (byte* ipStringPtr = &MemoryMarshal.GetReference(ipSpan))
        ////    {
        ////        tmpAddr = IPv4AddressHelper.ParseNonCanonical(ipStringPtr, 0, ref end, notImplicitFile: true);
        ////    }

        ////    if (tmpAddr != IPv4AddressHelper.Invalid && end == ipSpan.Length)
        ////    {
        ////        // IPv4AddressHelper.ParseNonCanonical returns the bytes in host order.
        ////        // Convert to network order and return success.
        ////        address = (uint)IPAddress.HostToNetworkOrder(unchecked((int)tmpAddr));
        ////        return true;
        ////    }

        ////    // Failed to parse the address.
        ////    address = 0;
        ////    return false;
        ////}

        ////private static unsafe bool TryParseIPv6(ReadOnlySpan<byte> ipSpan, Span<ushort> numbers, int numbersLength, out uint scope)
        ////{
        ////    Debug.Assert(numbersLength >= IPAddressParserStatics.IPv6AddressShorts);

        ////    fixed (byte* ipStringPtr = &MemoryMarshal.GetReference(ipSpan))
        ////    {
        ////        if (!IPv6AddressHelper.IsValidStrict(ipStringPtr, 0, ipSpan.Length))
        ////        {
        ////            scope = 0;
        ////            return false;
        ////        }
        ////    }

        ////    IPv6AddressHelper.Parse(ipSpan, numbers, out ReadOnlySpan<byte> scopeIdSpan);

        ////    if (scopeIdSpan.Length > 1)
        ////    {
        ////        bool parsedNumericScope;
        ////        scopeIdSpan = scopeIdSpan.Slice(1);

        ////        parsedNumericScope = Utf8Parser.TryParse(scopeIdSpan, out scope, out _);

        ////        if (parsedNumericScope)
        ////        {
        ////            return true;
        ////        }
        ////        else
        ////        {
        ////            uint interfaceIndex = InterfaceInfoPal.InterfaceNameToIndex(scopeIdSpan);

        ////            if (interfaceIndex > 0)
        ////            {
        ////                scope = interfaceIndex;
        ////                return true; // scopeId is a known interface name
        ////            }
        ////        }

        ////        // scopeId is an unknown interface name
        ////    }

        ////    // scopeId is not presented
        ////    scope = 0;
        ////    return true;
        ////}
    }
}
