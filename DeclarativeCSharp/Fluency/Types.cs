using DeclarativeCSharp.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeclarativeCSharp.Fluency
{
    public sealed class WorstHappenedException : Exception { }

    public static class TypesExtensions
    {
        public static bool Invert(this bool b) => !b;

        public static T AssumeBest<T>(this Option<T> option)
            => option switch
            {
                { HasValue: true } => option.Value,
                _ => throw new WorstHappenedException()
            };

        public static TOut Match<T, TOut>(this Option<T> option, Func<T, TOut> hasValueCase, Func<TOut> noValueCase)
            => option switch
            {
                { HasValue: true } => hasValueCase(option.Value),
                _ => noValueCase()
            };

        public static T Execute<T>(this T @this, Action<T> act)
        {
            act(@this);
            return @this;
        }

        public static Option<T> Parse<T>(this string s)
        {
            if (typeof(T) == typeof(byte))
                return byte.TryParse(s, out var res) ? new((T)(object)res) : Option<T>.Failure;
            return Option<T>.Failure;
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

        public static Option<IEnumerable<int>> AsRange(this Range @this)
            => @this.Start
                .Inject(@this.End)
                .Let(out var failure, Option<IEnumerable<int>>.Failure)
                .Inject(failure)
                .Map((startEnd, failure) => 
                    startEnd switch 
                    {
                        ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: true, Value: 0 }) => new(InfiniteSequence(0)),
                        ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: false, Value: var to }) => new(InfiniteSequenceBackward(to)),
                        ({ IsFromEnd: false, Value: var from }, { IsFromEnd: true, Value: 0 }) => new(InfiniteSequence(from)),
                        ({ IsFromEnd: false, Value: var from }, { IsFromEnd: false, Value: var to }) => new(Enumerable.Range(from, to)),
                        _ => failure
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
