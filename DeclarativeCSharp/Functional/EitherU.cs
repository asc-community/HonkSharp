using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace DeclarativeCSharp.Functional
{
    [StructLayout(LayoutKind.Explicit)]
    public struct EitherU<T1, T2> where T1 : unmanaged where T2 : unmanaged
    {
        [FieldOffset(0)]
        private readonly byte index;
        [FieldOffset(1)]
        private readonly T1 field1;
        [FieldOffset(1)]
        private readonly T2 field2;
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, TCapture capture)
            => index is 1 ? case1(field1, capture) : case2(field2, capture);
        public EitherU(T1 value)
        {
            Unsafe.SkipInit(out field2);
            field1 = value;
            index = 1;
        }
        public EitherU(T2 value)
        {
            Unsafe.SkipInit(out field1);
            field2 = value;
            index = 2;
        }
    }
}
