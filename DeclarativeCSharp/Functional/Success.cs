using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeCSharp.Functional
{
    public struct Option<T>
    {
        public T Value { get; }
        public bool HasValue { get; }
        public Option(T value) => (Value, HasValue) = (value, true);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Option(bool hasValue) => (Value, HasValue) = (default, hasValue);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        public static Option<T> Failure = new(false);
    }
}
