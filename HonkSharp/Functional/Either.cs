using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace HonkSharp.Functional
{


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                _ => case2(field2, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2)
            => index switch
            {
                1 => case1(field1),
                _ => case2(field2)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            field2 = value;
            index = 2;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                _ => case3(field3, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                _ => case3(field3)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            field3 = value;
            index = 3;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                _ => case4(field4, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                _ => case4(field4)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            field4 = value;
            index = 4;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                _ => case5(field5, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                _ => case5(field5)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            field5 = value;
            index = 5;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                _ => case6(field6, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                _ => case6(field6)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            field6 = value;
            index = 6;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                _ => case7(field7, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                _ => case7(field7)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            field7 = value;
            index = 7;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                _ => case8(field8, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                _ => case8(field8)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            field8 = value;
            index = 8;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                _ => case9(field9, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                _ => case9(field9)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            field9 = value;
            index = 9;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;
        private readonly T10 field10;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, Func<T10, TCapture, TOut> case10, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                9 => case9(field9, capture),
                _ => case10(field10, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9, Func<T10, TOut> case10)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                9 => case9(field9),
                _ => case10(field10)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field9 = value;
            index = 9;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T10 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            field10 = value;
            index = 10;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T10 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T10(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> t)
            => t.index is 10 ? t.field10 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T10))
            {
                if (index == 10)
                {
                    instance = (T)(object)field10!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;
        private readonly T10 field10;
        private readonly T11 field11;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, Func<T10, TCapture, TOut> case10, Func<T11, TCapture, TOut> case11, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                9 => case9(field9, capture),
                10 => case10(field10, capture),
                _ => case11(field11, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9, Func<T10, TOut> case10, Func<T11, TOut> case11)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                9 => case9(field9),
                10 => case10(field10),
                _ => case11(field11)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field9 = value;
            index = 9;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T10 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field10 = value;
            index = 10;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T11 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            field11 = value;
            index = 11;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T10 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T10(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 10 ? t.field10 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T11 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T11(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> t)
            => t.index is 11 ? t.field11 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T10))
            {
                if (index == 10)
                {
                    instance = (T)(object)field10!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T11))
            {
                if (index == 11)
                {
                    instance = (T)(object)field11!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;
        private readonly T10 field10;
        private readonly T11 field11;
        private readonly T12 field12;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, Func<T10, TCapture, TOut> case10, Func<T11, TCapture, TOut> case11, Func<T12, TCapture, TOut> case12, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                9 => case9(field9, capture),
                10 => case10(field10, capture),
                11 => case11(field11, capture),
                _ => case12(field12, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9, Func<T10, TOut> case10, Func<T11, TOut> case11, Func<T12, TOut> case12)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                9 => case9(field9),
                10 => case10(field10),
                11 => case11(field11),
                _ => case12(field12)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field9 = value;
            index = 9;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T10 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field10 = value;
            index = 10;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T11 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field11 = value;
            index = 11;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T12 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            field12 = value;
            index = 12;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T10 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T10(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 10 ? t.field10 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T11 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T11(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 11 ? t.field11 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T12 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T12(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> t)
            => t.index is 12 ? t.field12 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T10))
            {
                if (index == 10)
                {
                    instance = (T)(object)field10!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T11))
            {
                if (index == 11)
                {
                    instance = (T)(object)field11!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T12))
            {
                if (index == 12)
                {
                    instance = (T)(object)field12!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;
        private readonly T10 field10;
        private readonly T11 field11;
        private readonly T12 field12;
        private readonly T13 field13;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, Func<T10, TCapture, TOut> case10, Func<T11, TCapture, TOut> case11, Func<T12, TCapture, TOut> case12, Func<T13, TCapture, TOut> case13, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                9 => case9(field9, capture),
                10 => case10(field10, capture),
                11 => case11(field11, capture),
                12 => case12(field12, capture),
                _ => case13(field13, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9, Func<T10, TOut> case10, Func<T11, TOut> case11, Func<T12, TOut> case12, Func<T13, TOut> case13)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                9 => case9(field9),
                10 => case10(field10),
                11 => case11(field11),
                12 => case12(field12),
                _ => case13(field13)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field9 = value;
            index = 9;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T10 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field10 = value;
            index = 10;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T11 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field11 = value;
            index = 11;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T12 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field12 = value;
            index = 12;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T13 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            field13 = value;
            index = 13;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T10 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T10(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 10 ? t.field10 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T11 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T11(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 11 ? t.field11 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T12 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T12(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 12 ? t.field12 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T13 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T13(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> t)
            => t.index is 13 ? t.field13 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T10))
            {
                if (index == 10)
                {
                    instance = (T)(object)field10!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T11))
            {
                if (index == 11)
                {
                    instance = (T)(object)field11!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T12))
            {
                if (index == 12)
                {
                    instance = (T)(object)field12!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T13))
            {
                if (index == 13)
                {
                    instance = (T)(object)field13!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;
        private readonly T10 field10;
        private readonly T11 field11;
        private readonly T12 field12;
        private readonly T13 field13;
        private readonly T14 field14;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, Func<T10, TCapture, TOut> case10, Func<T11, TCapture, TOut> case11, Func<T12, TCapture, TOut> case12, Func<T13, TCapture, TOut> case13, Func<T14, TCapture, TOut> case14, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                9 => case9(field9, capture),
                10 => case10(field10, capture),
                11 => case11(field11, capture),
                12 => case12(field12, capture),
                13 => case13(field13, capture),
                _ => case14(field14, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9, Func<T10, TOut> case10, Func<T11, TOut> case11, Func<T12, TOut> case12, Func<T13, TOut> case13, Func<T14, TOut> case14)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                9 => case9(field9),
                10 => case10(field10),
                11 => case11(field11),
                12 => case12(field12),
                13 => case13(field13),
                _ => case14(field14)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field9 = value;
            index = 9;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T10 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field10 = value;
            index = 10;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T11 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field11 = value;
            index = 11;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T12 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field12 = value;
            index = 12;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T13 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field13 = value;
            index = 13;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T14 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            field14 = value;
            index = 14;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T10 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T10(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 10 ? t.field10 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T11 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T11(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 11 ? t.field11 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T12 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T12(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 12 ? t.field12 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T13 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T13(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 13 ? t.field13 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T14 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T14(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> t)
            => t.index is 14 ? t.field14 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T10))
            {
                if (index == 10)
                {
                    instance = (T)(object)field10!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T11))
            {
                if (index == 11)
                {
                    instance = (T)(object)field11!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T12))
            {
                if (index == 12)
                {
                    instance = (T)(object)field12!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T13))
            {
                if (index == 13)
                {
                    instance = (T)(object)field13!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T14))
            {
                if (index == 14)
                {
                    instance = (T)(object)field14!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;
        private readonly T10 field10;
        private readonly T11 field11;
        private readonly T12 field12;
        private readonly T13 field13;
        private readonly T14 field14;
        private readonly T15 field15;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, Func<T10, TCapture, TOut> case10, Func<T11, TCapture, TOut> case11, Func<T12, TCapture, TOut> case12, Func<T13, TCapture, TOut> case13, Func<T14, TCapture, TOut> case14, Func<T15, TCapture, TOut> case15, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                9 => case9(field9, capture),
                10 => case10(field10, capture),
                11 => case11(field11, capture),
                12 => case12(field12, capture),
                13 => case13(field13, capture),
                14 => case14(field14, capture),
                _ => case15(field15, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9, Func<T10, TOut> case10, Func<T11, TOut> case11, Func<T12, TOut> case12, Func<T13, TOut> case13, Func<T14, TOut> case14, Func<T15, TOut> case15)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                9 => case9(field9),
                10 => case10(field10),
                11 => case11(field11),
                12 => case12(field12),
                13 => case13(field13),
                14 => case14(field14),
                _ => case15(field15)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field9 = value;
            index = 9;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T10 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field10 = value;
            index = 10;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T11 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field11 = value;
            index = 11;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T12 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field12 = value;
            index = 12;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T13 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field13 = value;
            index = 13;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T14 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field14 = value;
            index = 14;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T15 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            field15 = value;
            index = 15;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T10 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T10(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 10 ? t.field10 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T11 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T11(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 11 ? t.field11 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T12 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T12(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 12 ? t.field12 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T13 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T13(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 13 ? t.field13 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T14 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T14(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 14 ? t.field14 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T15 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T15(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> t)
            => t.index is 15 ? t.field15 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T10))
            {
                if (index == 10)
                {
                    instance = (T)(object)field10!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T11))
            {
                if (index == 11)
                {
                    instance = (T)(object)field11!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T12))
            {
                if (index == 12)
                {
                    instance = (T)(object)field12!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T13))
            {
                if (index == 13)
                {
                    instance = (T)(object)field13!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T14))
            {
                if (index == 14)
                {
                    instance = (T)(object)field14!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T15))
            {
                if (index == 15)
                {
                    instance = (T)(object)field15!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;
        private readonly T5 field5;
        private readonly T6 field6;
        private readonly T7 field7;
        private readonly T8 field8;
        private readonly T9 field9;
        private readonly T10 field10;
        private readonly T11 field11;
        private readonly T12 field12;
        private readonly T13 field13;
        private readonly T14 field14;
        private readonly T15 field15;
        private readonly T16 field16;

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, Func<T5, TCapture, TOut> case5, Func<T6, TCapture, TOut> case6, Func<T7, TCapture, TOut> case7, Func<T8, TCapture, TOut> case8, Func<T9, TCapture, TOut> case9, Func<T10, TCapture, TOut> case10, Func<T11, TCapture, TOut> case11, Func<T12, TCapture, TOut> case12, Func<T13, TCapture, TOut> case13, Func<T14, TCapture, TOut> case14, Func<T15, TCapture, TOut> case15, Func<T16, TCapture, TOut> case16, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                4 => case4(field4, capture),
                5 => case5(field5, capture),
                6 => case6(field6, capture),
                7 => case7(field7, capture),
                8 => case8(field8, capture),
                9 => case9(field9, capture),
                10 => case10(field10, capture),
                11 => case11(field11, capture),
                12 => case12(field12, capture),
                13 => case13(field13, capture),
                14 => case14(field14, capture),
                15 => case15(field15, capture),
                _ => case16(field16, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4, Func<T5, TOut> case5, Func<T6, TOut> case6, Func<T7, TOut> case7, Func<T8, TOut> case8, Func<T9, TOut> case9, Func<T10, TOut> case10, Func<T11, TOut> case11, Func<T12, TOut> case12, Func<T13, TOut> case13, Func<T14, TOut> case14, Func<T15, TOut> case15, Func<T16, TOut> case16)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                4 => case4(field4),
                5 => case5(field5),
                6 => case6(field6),
                7 => case7(field7),
                8 => case8(field8),
                9 => case9(field9),
                10 => case10(field10),
                11 => case11(field11),
                12 => case12(field12),
                13 => case13(field13),
                14 => case14(field14),
                15 => case15(field15),
                _ => case16(field16)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T1 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T2 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T3 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T4 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field4 = value;
            index = 4;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T5 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field5 = value;
            index = 5;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T6 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field6 = value;
            index = 6;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T7 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field7 = value;
            index = 7;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T8 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field8 = value;
            index = 8;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T9 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field9 = value;
            index = 9;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T10 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field10 = value;
            index = 10;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T11 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field11 = value;
            index = 11;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T12 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field12 = value;
            index = 12;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T13 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field13 = value;
            index = 13;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T14 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field14 = value;
            index = 14;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T15 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field15 = value;
            index = 15;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        public Either(T16 value)
        {
            Unsafe.SkipInit(out field1);
            Unsafe.SkipInit(out field2);
            Unsafe.SkipInit(out field3);
            Unsafe.SkipInit(out field4);
            Unsafe.SkipInit(out field5);
            Unsafe.SkipInit(out field6);
            Unsafe.SkipInit(out field7);
            Unsafe.SkipInit(out field8);
            Unsafe.SkipInit(out field9);
            Unsafe.SkipInit(out field10);
            Unsafe.SkipInit(out field11);
            Unsafe.SkipInit(out field12);
            Unsafe.SkipInit(out field13);
            Unsafe.SkipInit(out field14);
            Unsafe.SkipInit(out field15);
            Unsafe.SkipInit(out field16);
            field16 = value;
            index = 16;
        }


        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T1(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 1 ? t.field1 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T2 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T2(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 2 ? t.field2 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T3 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T3(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 3 ? t.field3 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T4 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T4(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 4 ? t.field4 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T5 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T5(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 5 ? t.field5 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T6 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T6(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 6 ? t.field6 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T7 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T7(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 7 ? t.field7 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T8 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T8(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 8 ? t.field8 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T9 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T9(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 9 ? t.field9 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T10 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T10(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 10 ? t.field10 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T11 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T11(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 11 ? t.field11 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T12 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T12(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 12 ? t.field12 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T13 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T13(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 13 ? t.field13 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T14 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T14(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 14 ? t.field14 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T15 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T15(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 15 ? t.field15 : throw new InvalidCastException();
        // ReSharper disable once MemberCanBePrivate.Global
        public static implicit operator Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T16 t)
            => new(t);  

        // ReSharper disable once MemberCanBePrivate.Global
        public static explicit operator T16(Either<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> t)
            => t.index is 16 ? t.field16 : throw new InvalidCastException();

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Is<T>(out T instance)
        {
            if (typeof(T) == typeof(T1))
            {
                if (index == 1)
                {
                    instance = (T)(object)field1!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T2))
            {
                if (index == 2)
                {
                    instance = (T)(object)field2!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T3))
            {
                if (index == 3)
                {
                    instance = (T)(object)field3!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T4))
            {
                if (index == 4)
                {
                    instance = (T)(object)field4!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T5))
            {
                if (index == 5)
                {
                    instance = (T)(object)field5!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T6))
            {
                if (index == 6)
                {
                    instance = (T)(object)field6!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T7))
            {
                if (index == 7)
                {
                    instance = (T)(object)field7!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T8))
            {
                if (index == 8)
                {
                    instance = (T)(object)field8!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T9))
            {
                if (index == 9)
                {
                    instance = (T)(object)field9!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T10))
            {
                if (index == 10)
                {
                    instance = (T)(object)field10!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T11))
            {
                if (index == 11)
                {
                    instance = (T)(object)field11!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T12))
            {
                if (index == 12)
                {
                    instance = (T)(object)field12!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T13))
            {
                if (index == 13)
                {
                    instance = (T)(object)field13!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T14))
            {
                if (index == 14)
                {
                    instance = (T)(object)field14!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T15))
            {
                if (index == 15)
                {
                    instance = (T)(object)field15!;
                    return true;
                }
                instance = default!;
                return false;
            }
            if (typeof(T) == typeof(T16))
            {
                if (index == 16)
                {
                    instance = (T)(object)field16!;
                    return true;
                }
                instance = default!;
                return false;
            }
            instance = default!;
            return false;
        }
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }

}
