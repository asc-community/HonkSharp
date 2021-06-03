using System;
using System.Collections.Generic;
using System.Text;

namespace DeclarativeCSharp.Fluency
{
    public static class ConvertExtensions
    {
        public static TTo Downcast<TFrom, TTo>(this TFrom o) where TTo : TFrom
            => (TTo)(o ?? throw new ArgumentNullException());
    }
}
