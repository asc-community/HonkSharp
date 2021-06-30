using System;
using Xunit;
using HonkSharp.Fluency;
using HonkSharp.Functional;
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
        public void TestDoublePipe1()
            => 3.5m.Pipe(a => a.ToString(), a => a.Split(".")[1]).Should().Be("5");

        [Fact]
        public void TestTriplePipe1()
            => 3.5m.Pipe(a => a.ToString(), a => a.Split("."), a => a[1]).Should().Be("5");

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

        [Fact]
        public void TestTry1()
            => "sss"
                .Dangerous()
                .Try<FormatException, int>(int.Parse)
                .Switch(_ => "parsed", _ => "not parsed")
                .Should().Be("not parsed");
        
        [Fact]
        public void TestTry2()
            => "666"
                .Dangerous()
                .Try<FormatException, int>(int.Parse)
                .Switch(_ => "parsed", _ => "not parsed")
                .Should().Be("parsed");

        [Fact]
        public void TestThrow()
            => Unit.Flow
                .Dangerous()
                .Try<Exception, Unit>(u => u.Throw(new Exception()))
                .Switch(
                    valid => "no thrown",
                    thrown => "thrown"
                    )
                .Should().Be("thrown");

        
        private class BaseClass { }
        private class DerivedClass1 : BaseClass { }
        private class DerivedClass2 : BaseClass { }
        
        [Fact] public void DowncastSuccess()
            => new DerivedClass1()
                .Alias(out var derived)
                .Pipe(a => (BaseClass)a)
                .Downcast<DerivedClass1>()
                .Should().BeSameAs(derived);
        
        [Fact] public void DowncastFailure()
            => Assert.Throws<InvalidCastException>(
                () => new DerivedClass1()
                    .Alias(out var derived)
                    .Pipe(a => (BaseClass)a)
                    .Downcast<DerivedClass2>() // not the same class
                    .Should().BeSameAs(derived)
                );

        [Fact] public void NullIfConst()
            => 6.NullIf(4 > 3).Should().BeNull();
    }
}