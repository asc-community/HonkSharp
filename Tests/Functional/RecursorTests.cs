using System;
using System.Collections.Generic;
using System.Numerics;
using FluentAssertions;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using Xunit;
using static HonkSharp.Functional.Recursors;

namespace Tests
{
    public class RecursorTests
    {
        [Fact]
        public void Factorial()
        {
            Assert.Equal(120, 
                prec<int, int>((i, fact) => i switch {
                    0 => 1,
                    var n => n * fact(n - 1)
                })(5));
        }
        
        [Fact]
        public void Fibonacci()
        {
            Assert.Equal(1318412525, 
                mrec<int, int>((i, fib) => i switch {
                    0 or 1 => 1,
                    var n => fib(n - 1) + fib(n - 2)
                })(1000));
        }
    }
}