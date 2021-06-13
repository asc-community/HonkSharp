using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using HonkSharp.Functional;


namespace HonkSharp.Fluency
{
    public sealed class WorstHappenedException : Exception { }

    public static class TypesExtensions
    {
        public static bool Invert(this bool b) => !b;

        public static T AssumeBest<T>(this Either<T, Failure> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();
        
        public static T AssumeBest<T>(this Either<Failure, T> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();

        public static T AssumeBest<T, TReason>(this Either<T, Failure<TReason>> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();
        
        public static T AssumeBest<T, TReason>(this Either<Failure<TReason>, T> either)
            => either.Is<T>(out var res) ? res : throw new WorstHappenedException();
        
        public static T AssumeBest<T>(this T? type)
            => type switch
            {
                { } valid => valid,
                _ => throw new WorstHappenedException()
            };

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

        public static Either<T, Failure> Parse<T>(this string s)
            => s.Parse<T>(NumberStyles.Any, CultureInfo.InvariantCulture);

        private static IEnumerable<int> InfiniteSequence(int start)
        {
            while (true)
                yield return start++;
        }

        private static IEnumerable<int> InfiniteSequenceBackward(int start)
        {
            while (true)
                yield return start--;
        }

        public static Either<IEnumerable<int>, Failure> AsRange(this Range @this)
            => @this.Start
                .Inject(@this.End)
                .Pipe(startEnd => 
                    startEnd switch 
                    {
                        ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: true, Value: 0 }) => new(InfiniteSequence(0)),
                        ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: false, Value: var to }) => new(InfiniteSequenceBackward(to)),
                        ({ IsFromEnd: false, Value: var from }, { IsFromEnd: true, Value: 0 }) => new(InfiniteSequence(from)),
                        ({ IsFromEnd: false, Value: var from }, { IsFromEnd: false, Value: var to }) => new(Enumerable.Range(from, to)),
                        _ => new Either<IEnumerable<int>, Failure>(new Failure())
                    }
                );

        public static IEnumerable<T> ExecuteForAll<T>(this IEnumerable<T> @this, Action<T> lambda)
        {
            foreach (var l in @this)
                lambda(l);
            return @this;
        }

        /// <summary>
        /// Performs joining over the current
        /// flow-end object as a delimiter
        /// </summary>
        public static string Join(this string @this, IEnumerable<object> collection)
            => string.Join(@this, collection);
    }
}
