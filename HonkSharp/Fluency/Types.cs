using DeclarativeCSharp.Functional;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DeclarativeCSharp.Fluency
{
    public sealed class WorstHappenedException : Exception { }

    public static class TypesExtensions
    {
        public static bool Invert(this bool b) => !b;

        public static T AssumeBest<T>(this Either<T, Failure> either)
            => (T)either;
        
        public static T AssumeBest<T, TReason>(this Either<T, Failure<TReason>> either)
            => either.Switch(
                    t => t,
                    fail => throw new WorstHappenedException()
                );
        
        public static T AssumeBest<T>(this T? type)
            => type switch
            {
                { } valid => valid,
                _ => throw new WorstHappenedException()
            };

        public static T Execute<T>(this T @this, Action<T> act)
        {
            act(@this);
            return @this;
        }

        public static Either<T, Failure> Parse<T>(this string s)
        {
            if (typeof(T) == typeof(byte))
                return byte.TryParse(s, out var res) ? (T)(object)res : new Failure();
            if (typeof(T) == typeof(int))
                return int.TryParse(s, out var res) ? (T)(object)res : new Failure();
            return new Failure();
        }

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
    }
}
