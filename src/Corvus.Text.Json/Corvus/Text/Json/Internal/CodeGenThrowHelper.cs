// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Corvus.Text.Json.Internal
{
    /// <summary>
    /// Provides helper methods for throwing exceptions in code generation and runtime scenarios for Corvus.Text.Json.
    /// This class centralizes exception creation and throwing logic to ensure consistent error handling and messaging.
    /// </summary>
    public static partial class CodeGenThrowHelper
    {
        // If the exception source is this value, the serializer will re-throw as JsonException.
        public const string ExceptionSourceValueToRethrowAsJsonException = "Corvus.Text.Json.Rethrowable";


        public static void ThrowArgumentException_ArrayBufferLength(string paramName, int expectedLength)
        {
            throw new ArgumentException(SR.Format(SR.IncorrectArrayBufferLength, expectedLength), paramName);
        }

        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException_ArrayIndexNegative(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, SR.ArrayIndexNegative);
        }

        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException_NeedNonNegNum(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, SR.ArgumentOutOfRange_Generic_MustBeNonNegative);
        }

        [DoesNotReturn]
        public static void ThrowArgumentException_InvalidOffLen()
        {
            throw new ArgumentException(SR.Argument_InvalidOffLen);
        }

        [DoesNotReturn]
        public static void ThrowArgumentException_ArrayTooSmall(string paramName)
        {
            throw new ArgumentException(SR.ArrayTooSmall, paramName);
        }

        private static ArgumentException GetArgumentException(string message)
        {
            return new ArgumentException(message);
        }

        [DoesNotReturn]
        public static void ThrowArgumentException(string message)
        {
            throw GetArgumentException(message);
        }

        [DoesNotReturn]
        public static void ThrowArgumentException_DestinationTooShort()
        {
            throw GetArgumentException(SR.DestinationTooShort);
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException(string message)
        {
            throw GetInvalidOperationException(message);
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst()
        {
            throw GetInvalidOperationException(SR.PrefixTupleMustBeCreatedFirst);
        }

        private static InvalidOperationException GetInvalidOperationException(string message)
        {
            return new InvalidOperationException(message) { Source = ExceptionSourceValueToRethrowAsJsonException };
        }

        public static InvalidOperationException GetInvalidOperationException_ExpectedArray(JsonTokenType tokenType)
        {
            return GetInvalidOperationException("array", tokenType);
        }

        public static InvalidOperationException GetInvalidOperationException_ExpectedObject(JsonTokenType tokenType)
        {
            return GetInvalidOperationException("object", tokenType);
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ExpectedNumber(JsonTokenType tokenType)
        {
            throw GetInvalidOperationException("number", tokenType);
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ExpectedBoolean(JsonTokenType tokenType)
        {
            throw GetInvalidOperationException("boolean", tokenType);
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ExpectedString(JsonTokenType tokenType)
        {
            throw GetInvalidOperationException("string", tokenType);
        }

        private static InvalidOperationException GetInvalidOperationException(string message, JsonTokenType tokenType)
        {
            return GetInvalidOperationException(SR.Format(SR.InvalidCast, tokenType, message));
        }

        private static InvalidOperationException GetInvalidOperationException(JsonTokenType tokenType)
        {
            return GetInvalidOperationException(SR.Format(SR.InvalidComparison, tokenType));
        }

        [DoesNotReturn]
        internal static void ThrowJsonElementWrongTypeException(
            JsonTokenType expectedType,
            JsonTokenType actualType)
        {
            throw GetJsonElementWrongTypeException(expectedType.ToValueKind(), actualType.ToValueKind());
        }

        internal static InvalidOperationException GetJsonElementWrongTypeException(
            JsonValueKind expectedType,
            JsonValueKind actualType)
        {
            return GetInvalidOperationException(
                SR.Format(SR.JsonElementHasWrongType, expectedType, actualType));
        }

        private static bool IsPrintable(byte value) => value >= 0x20 && value < 0x7F;

        [DoesNotReturn]
        public static void ThrowArgumentException_InvalidUTF8(ReadOnlySpan<byte> value)
        {
            var builder = new StringBuilder();

            int printFirst10 = Math.Min(value.Length, 10);

            for (int i = 0; i < printFirst10; i++)
            {
                byte nextByte = value[i];
                if (IsPrintable(nextByte))
                {
                    builder.Append((char)nextByte);
                }
                else
                {
                    builder.Append($"0x{nextByte:X2}");
                }
            }

            if (printFirst10 < value.Length)
            {
                builder.Append("...");
            }

            throw new ArgumentException(SR.Format(SR.CannotEncodeInvalidUTF8, builder));
        }

        [DoesNotReturn]
        public static void ThrowArgumentException_InvalidUTF16(int charAsInt)
        {
            throw new ArgumentException(SR.Format(SR.CannotEncodeInvalidUTF16, $"0x{charAsInt:X2}"));
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ReadInvalidUTF16(int charAsInt)
        {
            throw GetInvalidOperationException(SR.Format(SR.CannotReadInvalidUTF16, $"0x{charAsInt:X2}"));
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ReadIncompleteUTF16()
        {
            throw GetInvalidOperationException(SR.CannotReadIncompleteUTF16);
        }

        public static ArgumentException GetArgumentException_ReadInvalidUTF16(EncoderFallbackException innerException)
        {
            return new ArgumentException(SR.CannotTranscodeInvalidUtf16, innerException);
        }

        [CLSCompliant(false)]
        [DoesNotReturn]
        public static void ThrowOutOfMemoryException(uint capacity)
        {
            throw new OutOfMemoryException(SR.Format(SR.BufferMaximumSizeExceeded, capacity));
        }

        [DoesNotReturn]
        public static void ThrowFormatException()
        {
            throw new FormatException { Source = ExceptionSourceValueToRethrowAsJsonException };
        }

        [DoesNotReturn]
        public static void ThrowFormatException(CodeGenNumericType numericType)
        {
            string message = "";

            switch (numericType)
            {
                case CodeGenNumericType.Byte:
                    message = SR.FormatByte;
                    break;
                case CodeGenNumericType.SByte:
                    message = SR.FormatSByte;
                    break;
                case CodeGenNumericType.Int16:
                    message = SR.FormatInt16;
                    break;
                case CodeGenNumericType.Int32:
                    message = SR.FormatInt32;
                    break;
                case CodeGenNumericType.Int64:
                    message = SR.FormatInt64;
                    break;
                case CodeGenNumericType.Int128:
                    message = SR.FormatInt128;
                    break;
                case CodeGenNumericType.UInt16:
                    message = SR.FormatUInt16;
                    break;
                case CodeGenNumericType.UInt32:
                    message = SR.FormatUInt32;
                    break;
                case CodeGenNumericType.UInt64:
                    message = SR.FormatUInt64;
                    break;
                case CodeGenNumericType.UInt128:
                    message = SR.FormatUInt128;
                    break;
                case CodeGenNumericType.Half:
                    message = SR.FormatHalf;
                    break;
                case CodeGenNumericType.Single:
                    message = SR.FormatSingle;
                    break;
                case CodeGenNumericType.Double:
                    message = SR.FormatDouble;
                    break;
                case CodeGenNumericType.Decimal:
                    message = SR.FormatDecimal;
                    break;
                default:
                    Debug.Fail($"The CodeGenNumericType enum value: {numericType} is not part of the switch. Add the appropriate case and exception message.");
                    break;
            }

            throw new FormatException(message) { Source = ExceptionSourceValueToRethrowAsJsonException };
        }

        [DoesNotReturn]
        public static void ThrowFormatException(CodeGenDataType dataType)
        {
            string message = "";

            switch (dataType)
            {
                case CodeGenDataType.Boolean:
                case CodeGenDataType.DateOnly:
                case CodeGenDataType.DateTime:
                case CodeGenDataType.DateTimeOffset:
                case CodeGenDataType.TimeOnly:
                case CodeGenDataType.TimeSpan:
                case CodeGenDataType.Guid:
                case CodeGenDataType.Version:
                    message = SR.Format(SR.UnsupportedFormat, dataType);
                    break;
                case CodeGenDataType.Base64String:
                    message = SR.CannotDecodeInvalidBase64;
                    break;
                default:
                    Debug.Fail($"The CodeGenDataType enum value: {dataType} is not part of the switch. Add the appropriate case and exception message.");
                    break;
            }

            throw new FormatException(message) { Source = ExceptionSourceValueToRethrowAsJsonException };
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ExpectedChar(JsonTokenType tokenType)
        {
            throw GetInvalidOperationException("char", tokenType);
        }
    }

    /// <summary>
    /// Specifies the numeric type used in code generation scenarios.
    /// </summary>
    public enum CodeGenNumericType
    {
        /// <summary>Represents an 8-bit unsigned integer.</summary>
        Byte,
        /// <summary>Represents an 8-bit signed integer.</summary>
        SByte,
        /// <summary>Represents a 16-bit signed integer.</summary>
        Int16,
        /// <summary>Represents a 32-bit signed integer.</summary>
        Int32,
        /// <summary>Represents a 64-bit signed integer.</summary>
        Int64,
        /// <summary>Represents a 128-bit signed integer.</summary>
        Int128,
        /// <summary>Represents a 16-bit unsigned integer.</summary>
        UInt16,
        /// <summary>Represents a 32-bit unsigned integer.</summary>
        UInt32,
        /// <summary>Represents a 64-bit unsigned integer.</summary>
        UInt64,
        /// <summary>Represents a 128-bit unsigned integer.</summary>
        UInt128,
        /// <summary>Represents a 16-bit floating point number.</summary>
        Half,
        /// <summary>Represents a 32-bit floating point number.</summary>
        Single,
        /// <summary>Represents a 64-bit floating point number.</summary>
        Double,
        /// <summary>Represents a 128-bit decimal number.</summary>
        Decimal
    }

    /// <summary>
    /// Specifies the data type used in code generation scenarios.
    /// </summary>
    public enum CodeGenDataType
    {
        /// <summary>Represents a boolean value.</summary>
        Boolean,
        /// <summary>Represents a date-only value.</summary>
        DateOnly,
        /// <summary>Represents a date and time value.</summary>
        DateTime,
        /// <summary>Represents a date and time with offset value.</summary>
        DateTimeOffset,
        /// <summary>Represents a time-only value.</summary>
        TimeOnly,
        /// <summary>Represents a time span value.</summary>
        TimeSpan,
        /// <summary>Represents a base64-encoded string.</summary>
        Base64String,
        /// <summary>Represents a GUID value.</summary>
        Guid,
        /// <summary>Represents a version value.</summary>
        Version,
    }
}
