using System;
using System.Collections.Generic;
using System.Text;

namespace HonkSharp.Fluency
{
#pragma warning disable 1591
    public static class ConvertExtensions
#pragma warning restore 1591
    {
        /// <summary>
        /// Downcasts the given instance to the specified type,
        /// that is, casts to its derived type, if can. Otherwise,
        /// an exception is thrown.
        /// </summary>
        /// <exception cref="InvalidCastException">
        /// Is thrown if downcasting is not possible.
        /// </exception>
        public static TTo Downcast<TTo>(this object o)
            => o switch
            {
                TTo res => res,
                _ => throw new InvalidCastException()
            };
    }
}
