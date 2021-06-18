using System;
using System.Collections.Generic;
using System.Linq;
using HonkSharp.Functional;

namespace HonkSharp.Fluency
{
    public static class SeqsExtensions
    {
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

        private static IEnumerable<int> InfiniteSequenceBackward(int start)
        {
            while (true)
                yield return start--;
        }

        /// <summary>
        /// Interprets range as a sequence of integers
        /// </summary>
        public static IEnumerable<int> AsRange(this Range @this)
            => @this.Start
                .Inject(@this.End)
                .Pipe(startEnd => 
                    startEnd switch 
                    {
                        ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: true, Value: 0 }) => InfiniteSequence(0),
                        ({ IsFromEnd: true, Value: 0 }, { IsFromEnd: false, Value: var to }) => InfiniteSequenceBackward(to),
                        ({ IsFromEnd: false, Value: var from }, { IsFromEnd: true, Value: 0 }) => InfiniteSequence(from),
                        ({ IsFromEnd: false, Value: var from }, { IsFromEnd: false, Value: var to }) => Enumerable.Range(from, to),
                        _ => throw new InvalidOperationException("Invalid range")
                    }
                );
        
        /// <summary>
        /// Gets a enumerator. Useful for
        /// foreach loops
        /// </summary>
        public static IEnumerator<int> GetEnumerator(this Range range)
            => range.AsRange().GetEnumerator();
        
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
        /// Analogue of Linq's OrderBy for range
        /// </summary>
        public static IEnumerable<int> OrderBy<T>(this Range range, Func<int, T> order)
            => range.AsRange().OrderBy(order);

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
        /// Non-lazily goes over the whole sequence
        /// (which might be useful if you need to execute them
        /// all because selectors have side effects, but
        /// at the same time don't want to waste resources
        /// on allocating an array with .ToArray())
        /// </summary>
        public static Unit DoIt<T>(this IEnumerable<T> @this)
        {
            foreach (var v in @this)
                v.Discard();
            return new Unit();
        }
    }
}
