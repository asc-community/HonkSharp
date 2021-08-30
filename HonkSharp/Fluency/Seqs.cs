using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HonkSharp.Functional;

namespace HonkSharp.Fluency
{
#pragma warning disable 1591
    public static class SeqsExtensions
#pragma warning restore 1591
    {
        /// <summary>
        /// Lets all elements of a sequence through a map,
        /// returning a sequence of mapped elements. Unlike Select,
        /// works non-lazily.
        /// </summary>
        public static IEnumerable<TOut> Pipe<TIn, TOut>(this IEnumerable<TIn> @this, Func<TIn, TOut> map)
        {
            foreach (var el in @this)
                yield return map(el);
        }

        /// <summary>
        /// Lets all elements of a sequence through an action.
        /// Returns a Unit, since nothing else makes sense to be returned.
        /// </summary>
        public static Unit Pipe<TIn>(this IEnumerable<TIn> @this, Action<TIn> action)
        {
            foreach (var el in @this)
                action(el);
            return Unit.Void;
        }

        /// <summary>
        /// Zips two sequences of a tuple. Returns
        /// a sequence of tuples.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the lengths of tuples does not match
        /// </exception>
        public static IEnumerable<(T1 left, T2 right)> Zip<T1, T2>(this (IEnumerable<T1>, IEnumerable<T2>) seqs)
        {
            using var iterLeft = seqs.Item1.GetEnumerator();
            using var iterRight = seqs.Item2.GetEnumerator();
            bool leftAdv, rightAdv;
            while ((leftAdv = iterLeft.MoveNext()) & (rightAdv = iterRight.MoveNext()))
                yield return (iterLeft.Current, iterRight.Current);

            if (leftAdv != rightAdv)
                throw new InvalidOperationException("Collections should have the same size");
        }

        /// <summary>
        /// Returns a sequence of tuples in the
        /// each for each format. The length of
        /// the sequence is the product of
        /// the lengths of the two given
        /// sequences.
        /// </summary>
        public static IEnumerable<(T1 left, T2 right)> Cartesian<T1, T2>(this (IEnumerable<T1>, IEnumerable<T2>) seqs)
        {
            foreach (var a in seqs.Item1)
                foreach (var b in seqs.Item2)
                    yield return (a, b);
        }

        /// <summary>
        /// Returns a sequence of tuples in the
        /// each for each format. The length of
        /// the sequence is the product of
        /// the lengths of the two given
        /// sequences.
        /// </summary>
        public static IEnumerable<(T1 left, T2 right)> Cartesian<T1, T2>(this IEnumerable<T1> left, IEnumerable<T2> right)
            => (left, right).Cartesian();
        
        private static IEnumerable<int> InfiniteSequence(int start)
        {
            while (true)
                yield return start++;
        }
        
        /// <summary>
        /// Interprets range as a sequence of integers
        /// </summary>
        public static IEnumerable<int> AsRange(this Range @this)
            => @this.GetEnumerator() switch
            {
                RangeEnumerator(var from, var to, 1) => Enumerable.Range(from, to - from + 1),
                RangeEnumerator(var from, var to, _) => Enumerable.Range(to, from - to + 1).Reverse()
            };
        
        /// <summary>
        /// Gets a enumerator. Useful for
        /// foreach loops
        /// </summary>
        public static RangeEnumerator GetEnumerator(this Range @this)
            => (@this.Start, @this.End) switch
                {
                    ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: true, Value: 0 }) => new RangeEnumerator(0, int.MaxValue, 1),
                    ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: false, Value: var to }) => new RangeEnumerator(0, to + 1, 1),
                    ({ IsFromEnd: false, Value: var from }, { IsFromEnd: true, Value: 0 }) => new RangeEnumerator(from, int.MaxValue, 1),
                    ({ IsFromEnd: false, Value: var from }, { IsFromEnd: false, Value: var to })
                        => (from < to) switch
                        {
                            true => new RangeEnumerator(from, to, 1),
                            false => new RangeEnumerator(from, to, -1),
                        },
                    _ => throw new InvalidOperationException("Invalid range")
                };

        /// <summary>
        /// A struct (stack-allocated) enum
        /// </summary>
        public struct RangeEnumerator : IEnumerator<int>
        {
            private readonly int to;
            private readonly int step;

            private int curr;

            internal void Deconstruct(out int @from, out int to, out int step)
                => (@from, to, step) = (curr, this.to, this.step);

            /// <summary></summary>
            public RangeEnumerator(int @from, int to, int step)
            {
                this.to = to + step;
                this.step = step;
                this.curr = @from - step;
            }

            /// <summary>
            /// Moves to the next element. There
            /// should be at least one call of this
            /// method before getting Current
            /// </summary>
            public bool MoveNext()
            {
                curr += step;
                return curr != to;
            }

            /// <summary>
            /// The current element (undefined if MoveNext
            /// is not called).
            /// </summary>
            public int Current => curr;

            /// <summary></summary>
            public void Reset() => throw new NotSupportedException();

            object IEnumerator.Current => Current;

            /// <summary></summary>
            public void Dispose() { }
        }
        
        /// <summary>
        /// Analogue of Linq's Select for range
        /// </summary>
        public static IEnumerable<T> Select<T>(this Range range, Func<int, T> selector)
            => range.AsRange().Select(selector);
        
        /// <summary>
        /// Analogue of Linq's Where for range
        /// </summary>
        public static IEnumerable<int> Where(this Range range, Func<int, bool> predicate)
            => range.AsRange().Where(predicate);
        
        /// <summary>
        /// Analogue of Linq's Take
        /// </summary>
        public static IEnumerable<int> Take(this Range range, int count)
            => range.AsRange().Take(count);
        
        /// <summary>
        /// Analogue of Linq's TakeWhile
        /// </summary>
        public static IEnumerable<int> TakeWhile(this Range range, Func<int, bool> condition)
            => range.AsRange().TakeWhile(condition);
        
        /// <summary>
        /// Analogue of Linq's Reverse
        /// </summary>
        public static IEnumerable<int> Reverse(this Range range)
            => range.AsRange().Reverse();
        
        /// <summary>
        /// Maps the given sequence into a sequence of
        /// pairs of index and corresponding element.
        /// </summary>
        public static IEnumerable<(int Index, T Element)> Enumerate<T>(this IEnumerable<T> @this)
        {
            var index = 0;
            foreach (var el in @this)
            {
                yield return (Index: index, Element: el);
                index++;
            }
        }
    }
}
