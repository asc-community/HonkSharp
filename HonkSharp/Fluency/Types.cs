using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using HonkSharp.Functional;


namespace HonkSharp.Fluency
{
    /// <summary>
    /// Happens when assuming the best case,
    /// and it doesn't happen.
    /// </summary>
    public sealed class WorstHappenedException : Exception { }

#pragma warning disable 1591
    public static class TypesExtensions
#pragma warning restore 1591
    {
        /// <summary>
        /// Returns an inverted boolean
        /// </summary>
        public static bool IsFalse(this bool b) => !b;

        /// <summary>
        /// Unconditionally casts an either to T.
        /// If it cannot, it throws an exception
        /// </summary>
        /// <exception cref="WorstHappenedException">
        /// Is thrown when either is failure.
        /// </exception>
        public static T AssumeBest<T>(this Either<T, Failure> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();
        
        
        /// <summary>
        /// Unconditionally casts an either to T.
        /// If it cannot, it throws an exception
        /// </summary>
        /// <exception cref="WorstHappenedException">
        /// Is thrown when either is failure.
        /// </exception>
        public static T AssumeBest<T>(this Either<Failure, T> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();

        /// <summary>
        /// Unconditionally casts an either to T.
        /// If it cannot, it throws an exception
        /// </summary>
        /// <exception cref="WorstHappenedException">
        /// Is thrown when either is failure.
        /// </exception>
        public static T AssumeBest<T, TReason>(this Either<T, Failure<TReason>> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();
        
        /// <summary>
        /// Unconditionally casts an either to T.
        /// If it cannot, it throws an exception
        /// </summary>
        /// <exception cref="WorstHappenedException">
        /// Is thrown when either is failure.
        /// </exception>
        public static T AssumeBest<T, TReason>(this Either<Failure<TReason>, T> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();
        
        /// <summary>
        /// Unconditionally casts a nullable to non-nullable.
        /// If it cannot, it throws an exception
        /// </summary>
        /// <exception cref="WorstHappenedException">
        /// Is thrown when the instance is null.
        /// </exception>
        public static T AssumeBest<T>(this T? type)
            => type switch
            {
                { } valid => valid,
                _ => throw new WorstHappenedException()
            };

        /// <summary>
        /// Parses a string into one of numeric types
        /// </summary>
        /// <returns>
        /// An either of the result and failure.
        /// Does not throw an exception.
        /// </returns>
        public static Either<T, Failure> Parse<T>(this string s, NumberStyles numberStyles, IFormatProvider? provider)
        {
            if (typeof(T) == typeof(byte))
                return byte.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(sbyte))
                return sbyte.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(ushort))
                return ushort.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(short))
                return short.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(uint))
                return uint.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(int))
                return int.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(ulong))
                return ulong.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(long))
                return long.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(float))
                return float.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(double))
                return double.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(decimal))
                return decimal.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(BigInteger))
                return BigInteger.TryParse(s, numberStyles, provider, out var res) ? (T)(object)res : new Failure();
            return new Failure();
        }
        
        /// <summary>
        /// Parses a string into one of numeric types
        /// </summary>
        /// <returns>
        /// An either of the result and failure.
        /// Does not throw an exception.
        /// </returns>
        public static Either<T, Failure> Parse<T>(this string s)
            => s.Parse<T>(NumberStyles.Any, CultureInfo.InvariantCulture);

        

        /// <summary>
        /// Performs joining over the current
        /// flow-end object as a delimiter
        /// </summary>
        public static string Join<T>(this string @this, IEnumerable<T> collection)
            => string.Join(@this, collection);
        
        /// <summary>
        /// Joins all chars into a string
        /// from a sequence of characters
        /// </summary>
        public static string AsString(this IEnumerable<char> chars)
            => "".Join(chars);
    }
}
