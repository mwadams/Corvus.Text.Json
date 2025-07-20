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

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when an array buffer has an incorrect length.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="expectedLength">The expected length of the array buffer.</param>
        /// <exception cref="ArgumentException">Always thrown.</exception>
        public static void ThrowArgumentException_ArrayBufferLength(string paramName, int expectedLength)
        {
            throw new ArgumentException(SR.Format(SR.IncorrectArrayBufferLength, expectedLength), paramName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> when an array index is negative.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException_ArrayIndexNegative(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, SR.ArrayIndexNegative);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> when a value must be non-negative.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException_NeedNonNegNum(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, SR.ArgumentOutOfRange_Generic_MustBeNonNegative);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when offset and length parameters are invalid.
        /// </summary>
        /// <exception cref="ArgumentException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowArgumentException_InvalidOffLen()
        {
            throw new ArgumentException(SR.Argument_InvalidOffLen);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when an array is too small.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowArgumentException_ArrayTooSmall(string paramName)
        {
            throw new ArgumentException(SR.ArrayTooSmall, paramName);
        }

        private static ArgumentException GetArgumentException(string message)
        {
            return new ArgumentException(message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> with the specified message.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <exception cref="ArgumentException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowArgumentException(string message)
        {
            throw GetArgumentException(message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when the destination buffer is too short.
        /// </summary>
        /// <exception cref="ArgumentException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowArgumentException_DestinationTooShort()
        {
            throw GetArgumentException(SR.DestinationTooShort);
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> with the specified message.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowInvalidOperationException(string message)
        {
            throw GetInvalidOperationException(message);
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when a prefix tuple must be created first.
        /// </summary>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowInvalidOperationException_PrefixTupleMustBeCreatedFirst()
        {
            throw GetInvalidOperationException(SR.PrefixTupleMustBeCreatedFirst);
        }

        private static InvalidOperationException GetInvalidOperationException(string message)
        {
            return new InvalidOperationException(message) { Source = ExceptionSourceValueToRethrowAsJsonException };
        }

        /// <summary>
        /// Creates an <see cref="InvalidOperationException"/> when an array was expected but a different token type was encountered.
        /// </summary>
        /// <param name="tokenType">The actual token type that was encountered.</param>
        /// <returns>An exception indicating that an array was expected.</returns>
        public static InvalidOperationException GetInvalidOperationException_ExpectedArray(JsonTokenType tokenType)
        {
            return GetInvalidOperationException("array", tokenType);
        }

        /// <summary>
        /// Creates an <see cref="InvalidOperationException"/> when an object was expected but a different token type was encountered.
        /// </summary>
        /// <param name="tokenType">The actual token type that was encountered.</param>
        /// <returns>An exception indicating that an object was expected.</returns>
        public static InvalidOperationException GetInvalidOperationException_ExpectedObject(JsonTokenType tokenType)
        {
            return GetInvalidOperationException("object", tokenType);
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when a number was expected but a different token type was encountered.
        /// </summary>
        /// <param name="tokenType">The actual token type that was encountered.</param>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ExpectedNumber(JsonTokenType tokenType)
        {
            throw GetInvalidOperationException("number", tokenType);
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when a boolean was expected but a different token type was encountered.
        /// </summary>
        /// <param name="tokenType">The actual token type that was encountered.</param>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ExpectedBoolean(JsonTokenType tokenType)
        {
            throw GetInvalidOperationException("boolean", tokenType);
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when a string was expected but a different token type was encountered.
        /// </summary>
        /// <param name="tokenType">The actual token type that was encountered.</param>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
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

        /// <summary>
        /// Throws an exception when a JSON element has an unexpected type.
        /// </summary>
        /// <param name="expectedType">The expected JSON token type.</param>
        /// <param name="actualType">The actual JSON token type.</param>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
        [DoesNotReturn]
        internal static void ThrowJsonElementWrongTypeException(
            JsonTokenType expectedType,
            JsonTokenType actualType)
        {
            throw GetJsonElementWrongTypeException(expectedType.ToValueKind(), actualType.ToValueKind());
        }

        /// <summary>
        /// Creates an exception when a JSON element has an unexpected value kind.
        /// </summary>
        /// <param name="expectedType">The expected JSON value kind.</param>
        /// <param name="actualType">The actual JSON value kind.</param>
        /// <returns>An exception indicating the type mismatch.</returns>
        internal static InvalidOperationException GetJsonElementWrongTypeException(
            JsonValueKind expectedType,
            JsonValueKind actualType)
        {
            return GetInvalidOperationException(
                SR.Format(SR.JsonElementHasWrongType, expectedType, actualType));
        }

        private static bool IsPrintable(byte value) => value >= 0x20 && value < 0x7F;

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when invalid UTF-8 bytes are encountered.
        /// </summary>
        /// <param name="value">The invalid UTF-8 byte sequence.</param>
        /// <exception cref="ArgumentException">Always thrown.</exception>
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

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> when an invalid UTF-16 character is encountered.
        /// </summary>
        /// <param name="charAsInt">The invalid character represented as an integer.</param>
        /// <exception cref="ArgumentException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowArgumentException_InvalidUTF16(int charAsInt)
        {
            throw new ArgumentException(SR.Format(SR.CannotEncodeInvalidUTF16, $"0x{charAsInt:X2}"));
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when an invalid UTF-16 character is encountered during reading.
        /// </summary>
        /// <param name="charAsInt">The invalid character represented as an integer.</param>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ReadInvalidUTF16(int charAsInt)
        {
            throw GetInvalidOperationException(SR.Format(SR.CannotReadInvalidUTF16, $"0x{charAsInt:X2}"));
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when an incomplete UTF-16 sequence is encountered during reading.
        /// </summary>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowInvalidOperationException_ReadIncompleteUTF16()
        {
            throw GetInvalidOperationException(SR.CannotReadIncompleteUTF16);
        }

        /// <summary>
        /// Creates an <see cref="ArgumentException"/> for invalid UTF-16 encoding during reading operations.
        /// </summary>
        /// <param name="innerException">The inner encoder fallback exception that caused this error.</param>
        /// <returns>An argument exception with the inner exception details.</returns>
        public static ArgumentException GetArgumentException_ReadInvalidUTF16(EncoderFallbackException innerException)
        {
            return new ArgumentException(SR.CannotTranscodeInvalidUtf16, innerException);
        }

        /// <summary>
        /// Throws an <see cref="OutOfMemoryException"/> when buffer capacity exceeds maximum allowed size.
        /// </summary>
        /// <param name="capacity">The requested capacity that exceeded the maximum.</param>
        /// <exception cref="OutOfMemoryException">Always thrown.</exception>
        [CLSCompliant(false)]
        [DoesNotReturn]
        public static void ThrowOutOfMemoryException(uint capacity)
        {
            throw new OutOfMemoryException(SR.Format(SR.BufferMaximumSizeExceeded, capacity));
        }

        /// <summary>
        /// Throws a generic <see cref="FormatException"/> for format-related errors.
        /// </summary>
        /// <exception cref="FormatException">Always thrown.</exception>
        [DoesNotReturn]
        public static void ThrowFormatException()
        {
            throw new FormatException { Source = ExceptionSourceValueToRethrowAsJsonException };
        }

        /// <summary>
        /// Throws a <see cref="FormatException"/> for numeric type formatting errors.
        /// </summary>
        /// <param name="numericType">The numeric type that failed to format.</param>
        /// <exception cref="FormatException">Always thrown.</exception>
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

        /// <summary>
        /// Throws a <see cref="FormatException"/> for data type formatting errors.
        /// </summary>
        /// <param name="dataType">The data type that failed to format.</param>
        /// <exception cref="FormatException">Always thrown.</exception>
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

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when a character was expected but a different token type was encountered.
        /// </summary>
        /// <param name="tokenType">The actual token type that was encountered.</param>
        /// <exception cref="InvalidOperationException">Always thrown.</exception>
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
