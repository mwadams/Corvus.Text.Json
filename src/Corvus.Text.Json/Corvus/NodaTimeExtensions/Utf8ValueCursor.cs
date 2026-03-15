// <copyright file="Utf8ValueCursor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// <licensing>
// Derived from code licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licensed this code under the MIT license.
// https:// github.com/dotnet/runtime/blob/388a7c4814cb0d6e344621d017507b357902043a/LICENSE.TXT
// </licensing>
using System.Diagnostics;
using Corvus.Text.Json;

namespace NodaTime.Text;

/// <summary>
/// Provides a cursor over text being parsed. None of the methods in this class throw exceptions (unless
/// there is a bug in Noda Time, in which case an exception is appropriate) and none of the methods
/// have ref parameters indicating failures, unlike subclasses. This class is used as the basis for both
/// value and pattern parsing, so can make no judgement about what's wrong (i.e. it wouldn't know what
/// type of failure to indicate). Instead, methods return Boolean values to indicate success or failure.
/// </summary>
[DebuggerStepThrough]
internal ref struct Utf8ValueCursor
{
    /// <summary>
    /// A nul character. This character is not allowed in any string that can be parsed, and is used to
    /// indicate that the current character is not set.
    /// </summary>
    internal const byte Nul = (byte)'\0';

    /// <summary>
    /// Initializes a new instance to parse the given value.
    /// </summary>
    /// <param name="value">The value on which to base the cursor.</param>
    public Utf8ValueCursor(ReadOnlySpan<byte> value)
    {
        // Validated by caller.
        this.Value = value;
        this.Length = value.Length;
        this.Move(-1);
    }

    /// <summary>
    /// Gets the current character.
    /// </summary>
    internal byte Current { get; private set; }

    /// <summary>
    /// Gets the current index into the string being parsed.
    /// </summary>
    internal int Index { get; private set; }

    /// <summary>
    /// Gets the length of the string being parsed.
    /// </summary>
    internal int Length { get; }

    /// <summary>
    /// Gets the string being parsed.
    /// </summary>
    internal ReadOnlySpan<byte> Value { get; }

    /// <summary>
    /// Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override readonly string ToString() =>
        this.Index <= 0 ? $"^{JsonReaderHelper.GetTextFromUtf8(this.Value)}"
            : this.Index >= this.Length ? $"{JsonReaderHelper.GetTextFromUtf8(this.Value)}^"
            : JsonReaderHelper.GetTextFromUtf8(this.Value).Insert(this.Index, "^");

    /// <summary>
    /// Moves the specified target index. If the new index is out of range of the valid indices
    /// for this string then the index is set to the beginning or the end of the string whichever
    /// is nearest the requested index.
    /// </summary>
    /// <param name="targetIndex">Index of the target.</param>
    /// <returns><c>true</c> if the requested index is in range.</returns>
    internal bool Move(int targetIndex)
    {
        unchecked
        {
            if (targetIndex >= 0)
            {
                if (targetIndex < this.Length)
                {
                    this.Index = targetIndex;
                    this.Current = this.Value[this.Index];
                    return true;
                }
                else
                {
                    this.Current = Nul;
                    this.Index = this.Length;
                    return false;
                }
            }

            this.Current = Nul;
            this.Index = -1;
            return false;
        }
    }

    /// <summary>
    /// Moves to the next character.
    /// </summary>
    /// <returns><c>true</c> if the requested index is in range.</returns>
    internal bool MoveNext()
    {
        unchecked
        {
            // Logically this is Move(Index + 1), but it's micro-optimized as we
            // know we'll never hit the lower limit this way.
            int targetIndex = this.Index + 1;
            if (targetIndex < this.Length)
            {
                this.Index = targetIndex;
                this.Current = this.Value[this.Index];
                return true;
            }

            this.Current = Nul;
            this.Index = this.Length;
            return false;
        }
    }

    /// <summary>
    /// Parses digits at the current point in the string as a fractional value.
    /// </summary>
    /// <param name="maximumDigits">The maximum allowed digits. Trusted to be less than or equal to scale.</param>
    /// <param name="scale">The scale of the fractional value.</param>
    /// <param name="result">The result value scaled by scale. The value of this is not guaranteed
    /// to be anything specific if the return value is false.</param>
    /// <param name="minimumDigits">The minimum number of digits that must be specified in the value.</param>
    /// <returns><c>true</c> if the digits were parsed.</returns>
    internal bool ParseFraction(int maximumDigits, int scale, out int result, int minimumDigits)
    {
        unchecked
        {
            result = 0;
            int localIndex = this.Index;
            int minIndex = localIndex + minimumDigits;
            if (minIndex > this.Length)
            {
                // If we don't have all the digits we're meant to have, we can't possibly succeed.
                return false;
            }

            int maxIndex = Math.Min(localIndex + maximumDigits, this.Length);
            for (; localIndex < maxIndex; localIndex++)
            {
                // Optimized digit handling: rather than checking for the range, returning -1
                // and then checking whether the result is -1, we can do both checks at once.
                int digit = this.Value[localIndex] - '0';
                if (digit < 0 || digit > 9)
                {
                    break;
                }

                result = (result * 10) + digit;
            }

            int count = localIndex - this.Index;

            // Couldn't parse the minimum number of digits required?
            if (count < minimumDigits)
            {
                return false;
            }

            result = (int)(result * Math.Pow(10.0, scale - count));
            this.Move(localIndex);
            return true;
        }
    }

    /// <summary>
    /// Parses digits at the current point in the string as a signed 64-bit integer value.
    /// Currently this method only supports cultures whose negative sign is "-" (and
    /// using ASCII digits).
    /// </summary>
    /// <param name="result">The result integer value. The value of this is not guaranteed
    /// to be anything specific if the return value is non-null.</param>
    /// <returns><see langword="true"/> if the value was parsed successfully.</returns>
    internal bool ParseInt64(out long result)
    {
        unchecked
        {
            result = 0L;
            int startIndex = this.Index;
            bool negative = this.Current == '-';
            if (negative)
            {
                if (!this.MoveNext())
                {
                    this.Move(startIndex);
                    return false;
                }
            }

            int count = 0;
            int digit;
            while (result < 922337203685477580 && (digit = this.GetDigit()) != -1)
            {
                result = (result * 10) + digit;
                count++;
                if (!this.MoveNext())
                {
                    break;
                }
            }

            if (count == 0)
            {
                this.Move(startIndex);
                return false;
            }

            if (result >= 922337203685477580 && (digit = this.GetDigit()) != -1)
            {
                if (result > 922337203685477580)
                {
                    return false;
                }

                if (negative && digit == 8)
                {
                    this.MoveNext();
                    result = long.MinValue;
                    return true;
                }

                if (digit > 7)
                {
                    return false;
                }

                // We know we can cope with this digit...
                result = (result * 10) + digit;
                this.MoveNext();
                if (this.GetDigit() != -1)
                {
                    // Too many digits. Die.
                    return false;
                }
            }

            if (negative)
            {
                result = -result;
            }

            return true;
        }
    }

    /// <summary>
    /// Gets the integer value of the current digit character, or -1 for "not a digit".
    /// </summary>
    /// <remarks>
    /// This currently only handles ASCII digits, which is all we have to parse to stay in line with the BCL.
    /// </remarks>
    private readonly int GetDigit()
    {
        unchecked
        {
            int c = this.Current;
            return c < '0' || c > '9' ? -1 : c - '0';
        }
    }
}