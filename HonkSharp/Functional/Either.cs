using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace HonkSharp.Functional
{
    /// <summary>
    /// Represents an anonymous type union.
    /// All types must be different.
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2> : IEither
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Switchers over the given types
        /// in the same order as they are declared
        /// in type args. Use this version when you
        /// want to avoid capture: just pass the variables
        /// as the last argument, and it will be passed as the second argument
        /// of each case.
        /// </summary>
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                _ => case2(field2, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Switchers over the given types
        /// in the same order as they are declared
        /// in type args.
        /// </summary>
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2)
            => index switch
            {
                1 => case1(field1),
                _ => case2(field2)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T1.
        /// </summary>
        public Either(T1 value)
        {
            field1 = default!;
            field2 = default!;
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T2.
        /// </summary>
        public Either(T2 value)
        {
            field1 = default!;
            field2 = default!;
            field2 = value;
            index = 2;
        }


#pragma warning disable 1591
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
#pragma warning restore 1591

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Checks if either has the type of T.
        /// If it is not, the value of res
        /// is undefined.
        /// </summary>
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
        /// <summary>
        /// Upcasts the current value of
        /// an either instance to object.
        /// </summary>
        public object? ToObject()
            => index switch
            {
                1 => field1,
                _ => field2
            };

        /// <summary>
        /// Returns ToString of the underlying value.
        /// </summary>
        public override string? ToString()
            => index switch
            {
                1 => field1?.ToString(),
                _ => field2?.ToString()
            };
        
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Casts an either to T. Returns
        /// a failure if cannot cast
        /// </summary>
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }
    /// <summary>
    /// Represents an anonymous type union.
    /// All types must be different.
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3> : IEither
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Switchers over the given types
        /// in the same order as they are declared
        /// in type args. Use this version when you
        /// want to avoid capture: just pass the variables
        /// as the last argument, and it will be passed as the second argument
        /// of each case.
        /// </summary>
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                _ => case3(field3, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Switchers over the given types
        /// in the same order as they are declared
        /// in type args.
        /// </summary>
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                _ => case3(field3)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T1.
        /// </summary>
        public Either(T1 value)
        {
            field1 = default!;
            field2 = default!;
            field3 = default!;
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T2.
        /// </summary>
        public Either(T2 value)
        {
            field1 = default!;
            field2 = default!;
            field3 = default!;
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T3.
        /// </summary>
        public Either(T3 value)
        {
            field1 = default!;
            field2 = default!;
            field3 = default!;
            field3 = value;
            index = 3;
        }


#pragma warning disable 1591
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
#pragma warning restore 1591

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Checks if either has the type of T.
        /// If it is not, the value of res
        /// is undefined.
        /// </summary>
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
        /// <summary>
        /// Upcasts the current value of
        /// an either instance to object.
        /// </summary>
        public object? ToObject()
            => index switch
            {
                1 => field1,
                2 => field2,
                _ => field3
            };

        /// <summary>
        /// Returns ToString of the underlying value.
        /// </summary>
        public override string? ToString()
            => index switch
            {
                1 => field1?.ToString(),
                2 => field2?.ToString(),
                _ => field3?.ToString()
            };
        
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Casts an either to T. Returns
        /// a failure if cannot cast
        /// </summary>
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }
    /// <summary>
    /// Represents an anonymous type union.
    /// All types must be different.
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public readonly struct Either<T1, T2, T3, T4> : IEither
    {
        private readonly byte index;
        private readonly T1 field1;
        private readonly T2 field2;
        private readonly T3 field3;
        private readonly T4 field4;

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Switchers over the given types
        /// in the same order as they are declared
        /// in type args. Use this version when you
        /// want to avoid capture: just pass the variables
        /// as the last argument, and it will be passed as the second argument
        /// of each case.
        /// </summary>
        public TOut Switch<TCapture, TOut>(Func<T1, TCapture, TOut> case1, Func<T2, TCapture, TOut> case2, Func<T3, TCapture, TOut> case3, Func<T4, TCapture, TOut> case4, TCapture capture)
            => index switch
            {
                1 => case1(field1, capture),
                2 => case2(field2, capture),
                3 => case3(field3, capture),
                _ => case4(field4, capture)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Switchers over the given types
        /// in the same order as they are declared
        /// in type args.
        /// </summary>
        public TOut Switch<TOut>(Func<T1, TOut> case1, Func<T2, TOut> case2, Func<T3, TOut> case3, Func<T4, TOut> case4)
            => index switch
            {
                1 => case1(field1),
                2 => case2(field2),
                3 => case3(field3),
                _ => case4(field4)
            };

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T1.
        /// </summary>
        public Either(T1 value)
        {
            field1 = default!;
            field2 = default!;
            field3 = default!;
            field4 = default!;
            field1 = value;
            index = 1;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T2.
        /// </summary>
        public Either(T2 value)
        {
            field1 = default!;
            field2 = default!;
            field3 = default!;
            field4 = default!;
            field2 = value;
            index = 2;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T3.
        /// </summary>
        public Either(T3 value)
        {
            field1 = default!;
            field2 = default!;
            field3 = default!;
            field4 = default!;
            field3 = value;
            index = 3;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Constructor, which initializes the
        /// Either with the type of T4.
        /// </summary>
        public Either(T4 value)
        {
            field1 = default!;
            field2 = default!;
            field3 = default!;
            field4 = default!;
            field4 = value;
            index = 4;
        }


#pragma warning disable 1591
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
#pragma warning restore 1591

        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Checks if either has the type of T.
        /// If it is not, the value of res
        /// is undefined.
        /// </summary>
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
        /// <summary>
        /// Upcasts the current value of
        /// an either instance to object.
        /// </summary>
        public object? ToObject()
            => index switch
            {
                1 => field1,
                2 => field2,
                3 => field3,
                _ => field4
            };

        /// <summary>
        /// Returns ToString of the underlying value.
        /// </summary>
        public override string? ToString()
            => index switch
            {
                1 => field1?.ToString(),
                2 => field2?.ToString(),
                3 => field3?.ToString(),
                _ => field4?.ToString()
            };
        
        // ReSharper disable once MemberCanBePrivate.Global
        /// <summary>
        /// Casts an either to T. Returns
        /// a failure if cannot cast
        /// </summary>
        public Either<T, Failure> As<T>()
            => Is<T>(out var res) ? new(res) : new(new Failure()); 
    }


}
