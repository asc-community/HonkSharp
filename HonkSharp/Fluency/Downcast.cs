using System;
using System.Collections.Generic;
using System.Text;

namespace DeclarativeCSharp.Fluency
{
    public static class ConvertExtensions
    {
        public static TTo Downcast<TTo>(this object o)
            => o switch
            {
                TTo res => res,
                _ => throw new InvalidCastException()
            };
    }
}
