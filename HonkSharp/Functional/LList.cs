using HonkSharp.Fluency;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HonkSharp.Functional
{
    /// <summary>
    /// This class has a number of functions
    /// for singly linked list object.
    /// </summary>
    public static class LList
    {
        /// <summary>
        /// Converts the given sequence into a list.
        /// The first element of the sequence
        /// corresponds to the head element of the list.
        /// </summary>
        public static LList<T> Of<T>(IEnumerable<T> seq)
        {
            LList<T> last = LList<T>.Empty;
            foreach (var s in seq.Reverse())
                last = new(s, last);
            return last;
        }

        /// <summary>
        /// Converts the given sequence into a list.
        /// The first element of the sequence
        /// corresponds to the head element of the list.
        /// </summary>
        public static LList<T> Of<T>(params T[] arr)
            => arr.Length is 0
            ? LList<T>.Empty
            : Of((IEnumerable<T>)arr);

        /// <summary>
        /// Returns a new list with the element added to head
        /// </summary>
        public static LList<T> Add<T>(this LList<T> tail, T element)
            => element + tail;

        /// <summary>
        /// Non-lazily maps all elements from a list
        /// to a new list
        /// </summary>
        public static LList<U> Map<T, U>(this LList<T> list, Func<T, U> transform)
            => list switch
            {
                LEmpty<T> => LList<U>.Empty,
                (var head, var tail) => transform(head) + tail.Map(transform)
            };

        /// <summary>
        /// Non-lazily filters and returns a new list
        /// </summary>
        public static LList<T> Where<T>(this LList<T> list, Func<T, bool> predicate)
            => list switch
            {
                LEmpty<T> e => e,
                (var head, var tail) =>
                    predicate(head)
                    ? head + tail.Where(predicate)
                    : tail.Where(predicate)
            };

        /// <summary>
        /// Non-lazily Concatenates all inner lists
        /// into one list.
        /// </summary>
        public static LList<T> Flatten<T>(this LList<LList<T>> list)
            => list.SelectMany(a => a).ToLList();

        /// <summary>
        /// Converts a given sequence into a list
        /// </summary>
        public static LList<T> ToLList<T>(this IEnumerable<T> seq)
            => Of(seq);

        /// <summary>
        /// Non-lazily reverses a list
        /// </summary>
        public static LList<T> Reverse<T>(this LList<T> list)
        {
            static LList<T> ReverseInner(LList<T> s, LList<T> res)
                => s switch
                {
                    LEmpty<T> => res,
                    (var head, var tail) => ReverseInner(tail, head + res)
                };
            return ReverseInner(list, LList<T>.Empty);
        }
    }

    /// <summary>
    /// Represents an immutable singly-linked list object.
    /// Is LEmpty{T} when empty.
    /// <example>
    /// <code>
    /// myList switch
    /// {
    ///     LEmpty<T> => "Contains no element",
    ///     (var head, LEmpty<T>) => "Contains one element",
    ///     (var h1, (var h2, _)) => "Contains more than one element"
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public record LList<T>(T Head, LList<T> Tail) : IEnumerable<T>
    {
        /// <summary>
        /// Adds an element to the list
        /// Returns a new list without
        /// modification the old one
        /// </summary>
        public static LList<T> operator +(T next, LList<T> tail)
            => new(next, tail);


        public override string ToString()
            => this.Pipe(", ".Join).Pipe(c => $"[ {c} ]");

        public Enumerator GetEnumerator()
            => new Enumerator(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        /// This is just an empty list of the given type.
        /// </summary>
        public static readonly LEmpty<T> Empty = new();

        /// <summary>
        /// Linear indexer
        /// </summary>
        public T this[int index]
        {
            get 
            {
                if (index < 0) throw new IndexOutOfRangeException($"Invalid index: {index}");
                var curr = this;
                while (index > 0 && curr is not LEmpty<T>)
                {
                    curr = curr.Tail;
                    index--;
                }
                if (curr is LEmpty<T>)
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                return curr.Head;
            }
        }

        /// <summary>
        /// Enumerating struct for llist
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            private LList<T>? curr;
            private readonly LList<T> list;
            public Enumerator(LList<T> list)
                => (this.list, this.curr) = (list, null);

            public T Current =>
                curr is null or LEmpty<T>
                ? throw new InvalidOperationException() 
                : curr.Head;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (curr is null)
                    curr = list;
                else
                    curr = curr.Tail;
                return curr is not LEmpty<T>;
            }

            public void Reset()
                => curr = null;

            object IEnumerator.Current => Current!;
        }
    }

    public record LEmpty<T> : LList<T>
    {
        internal LEmpty() : base(default!, default!) { }

        public override string ToString() => "[]";
    }
}