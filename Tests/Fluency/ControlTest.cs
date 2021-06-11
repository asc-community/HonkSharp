using System;
using Xunit;
using DeclarativeCSharp.Fluency;
using DeclarativeCSharp.Functional;
using FluentAssertions;

namespace Tests
{
    public class ControlTest
    {
        [Fact]
        public void TestPipe1()
            => 3.Pipe(a => a + 7).Should().Be(10);

        [Fact]
        public void TestPipe2()
            => "a".Pipe(a => a + "6")
                .Pipe(b => "7" + b)
                .Should().Be("7a6");

        [Fact]
        public void TestNullIf1()
            => 5.NullIf(a => a < 0).Should().Be(5);

        [Fact]
        public void TestNullIf2()
            => (-3).NullIf(a => a < 0).Should().BeNull();

        [Fact]
        public void TestAlias1()
            => 3.Alias(out var three)
                .Pipe(a => a + 5)
                .Inject(three)
                .Should().Be((8, 3));

        [Fact]
        public void TestLet1()
            => 5.Let(out var myVar, 8)
                .Should().Be(5);

        private static int counter = 0;

        [Fact]
        public void TestLetLazy1()
            => Unit.Flow
                .LetLazy(out var v, _ => counter += 1)
                .ReplaceWith(v)
                .Pipe(a => a.Value + 10)
                .Inject(v)
                .Pipe((a, v) => a + v.Value)
                .ReplaceWith(counter)
                .Should().Be(1);

    }
}