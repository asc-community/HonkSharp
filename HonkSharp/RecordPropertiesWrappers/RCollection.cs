// WIP
/*

using HonkSharp.Fluency;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonkSharp.RecordPropertiesWrappers
{
    public struct RCollection<TEnumerable, T> : 
        IEquatable<RCollection<TEnumerable, T>>, 
        IEnumerable<T>
        where TEnumerable : IEnumerable<T>
    {
        private readonly TEnumerable collection;
        public RCollection(TEnumerable collection)
            => this.collection = collection;

        public TEnumerable Value => collection;

        public bool Equals(RCollection<TEnumerable, T> other)
            => (collection, other.collection) switch
            {
                (null, null) => true,
                (null, _) or (_, null) => false,
                (IReadOnlyList<T> a, IReadOnlyList<T> b) => CollectionComparers.ListsEqual<IReadOnlyList<T>, T>(a, b),
                (IReadOnlyDictionary<T> a, IReadOnlyDictionary<T> b) => CollectionComparers.ListsEqual<IReadOnlyList<T>, T>(a, b),
            };

        public IEnumerator<T> GetEnumerator()
            => collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)collection).GetEnumerator();
    }

    internal static class CollectionComparers
    {
        internal static bool ListsEqual<TList, T>(TList a, TList b) where TList : IReadOnlyList<T>
        {
            if (a.Count != b.Count) return false;
            foreach (var i in 0..(a.Count - 1))
            {
                if (a[i] is null && b[i] is not null) return false;
                if (a[i] is not null && b[i] is null) return false;
                if (a[i] is { } aNotNull && !aNotNull.Equals(b[i])) return false;
            }
            return true;
        }

        internal static bool DictsEqual<T>
    }
}
*/