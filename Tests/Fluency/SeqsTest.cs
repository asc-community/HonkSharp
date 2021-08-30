using System;
using System.Collections.Generic;
using FluentAssertions;
using HonkSharp.Fluency;
using Xunit;

namespace Tests
{
    public class SeqsTest
    {
        
        
        [Fact] public void Zip1()
            => (new[] { 1, 2, 3 }, new[] { 'a', 'b', 'c' })
                .Zip().Should()
                .Equal(new[]{ (1, 'a'), (2, 'b'), (3, 'c') });
        
        [Fact] public void Zip2()
            => Assert.Throws<InvalidOperationException>(
                () => (new[] { 1, 2, 3 }, new[] { 'a', 'b' /* only two params */ })
                    .Zip().Should()
                    .Equal(new[]{ (1, 'a'), (2, 'b'), (3, 'c') }) 
                    );
        
        [Fact] public void Zip3()
            => Assert.Throws<InvalidOperationException>(
                () => (new[] { 1, 2 /* only two params */ }, new[] { 'a', 'b', 'c' })
                    .Zip().Should()
                    .Equal(new[]{ (1, 'a'), (2, 'b'), (3, 'c') }) 
            );
        
        [Fact] public void Cartesian1()
            => (1..3).AsRange()
                .Cartesian((1..3).AsRange())
                .Should()
                .Equal((1, 1), (1, 2), (1, 3), (2, 1), (2, 2), (2, 3), (3, 1), (3, 2), (3, 3));
        
        [Fact] public void Cartesian2()
            => (1..2).AsRange()
                .Cartesian("ab")
                .Should()
                .Equal((1, 'a'), (1, 'b'), (2, 'a'), (2, 'b'));
        
        [Fact] public void RangeSelect()
            => (2..4).Select(c => c * c).Should().Equal(4, 9, 16);
        
        [Fact] public void RangeWhere()
            => (1..5).Where(c => c % 2 == 0).Should().Equal(2, 4);
        
        [Fact] public void RangeTake()
            => (2..7).Take(3).Should().Equal((2..4).AsRange());
        
        [Fact] public void Enumerate1()
            => "abcd".Enumerate().Should().Equal((0, 'a'), (1, 'b'), (2, 'c'), (3, 'd'));
        
        [Fact] public void RangeForEach()
        {
            var list = new List<int>();
            foreach (var i in 5..8)
                list.Add(i);
            list.Should().Equal(5, 6, 7, 8);
        }

        [Fact]
        public void RangeForEachReverse()
        {
            var list = new List<int>();
            foreach (var i in 8..5)
                list.Add(i);
            list.Should().Equal(8, 7, 6, 5);
        }

        [Fact] public void RangeTakeWhile()
            => (6..14).TakeWhile(x => x < 10).Should().Equal(6, 7, 8, 9);
        
        [Fact] public void RangeReverse()
            => (4..7).Reverse().Should().Equal(7, 6, 5, 4);
        
        [Fact] public void ReversedRange()
            => (7..4).AsRange().Should().Equal(7, 6, 5, 4);
        
        [Fact] public void InfiniteSeq()
            => (5..).Take(100).Should().Equal((5..104).AsRange());
        
        [Fact] public void FiniteSeq()
            => (..6).AsRange().Should().Equal((0..6).AsRange());

        [Fact] public void PipingSequence()
            => (..6).AsRange().Pipe(a => a * 2).Should().Equal(0, 2, 4, 6, 8, 10, 12);
    }
}