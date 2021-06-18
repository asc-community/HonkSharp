using System;
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
    }
}