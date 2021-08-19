using System;
using System.Numerics;
using FluentAssertions;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using Xunit;

namespace Tests
{
    public class LListTests
    {
        [Fact] public void AsSequence1()
            => LList.Of(1, 2, 3).Should().Equal(1, 2, 3);

        [Fact] public void AsSequence2()
            => (LList.Of(1, 2, 3) is (1, (2, (3, LEmpty<int>)))).Should().BeTrue();

        [Fact] public void Equal1()
            => LList.Of(1, 2, 3).Should().BeEquivalentTo(LList.Of(1, 2, 3));

        [Fact] public void Rev1()
            => LList.Of(1, 2, 3, 4).Reverse().Should().Equal(4, 3, 2, 1);

        [Fact] public void Map1()
            => LList.Of(1, 2, 3, 4).Map(a => a * 2).Should().BeEquivalentTo(LList.Of(2, 4, 6, 8));

        [Fact] public void Map2()
            => LList.Of(1, 2, 3, 4)
                .Map(a => a.ToString())
                .Should()
                .BeEquivalentTo(LList.Of("1", "2", "3", "4"));

        [Fact] public void Where1()
            => LList.Of(1, 2, 3, 4, 5, 6)
                .Where(a => a % 2 is 0)
                .Should()
                .BeEquivalentTo(LList.Of(2, 4, 6));

        [Fact] public void Flatten1()
                    => LList.Of(LList.Of(1, 2), LList.Of(3, 4, 5), LList<int>.Empty, LList.Of(6, 7, 8, 9))
                        .Flatten()
                        .Should()
                        .BeEquivalentTo(
                            LList.Of(1, 2, 3, 4, 5, 6, 7, 8, 9)
                            );

        static LList<(T, T)> GroupByPairs<T>(LList<T> list)
                    => list switch
                    {
                        LEmpty<T> => LList<(T, T)>.Empty,
                        (var h1, (var h2, var tail)) => (h1, h2) + GroupByPairs(tail),
                        _ => throw new()
                    };

        [Fact] public void CustomTraverse1()
            => LList.Of(1, 2, 3, 4, 5, 6)
                .Pipe(GroupByPairs)
                .Should()
                .BeEquivalentTo(LList.Of((1, 2), (3, 4), (5, 6)));

        [Fact] public void CustomTraverse2()
            => Assert.Throws<Exception>(() => LList.Of(1, 2, 3).Pipe(GroupByPairs));
        
        [Fact] public void ToString1()
            => LList.Of(1, 2, 3).ToString().Should().Be("[ 1, 2, 3 ]");

        [Fact] public void ToString2()
            => LList.Of<int>().ToString().Should().Be("[]");

        [Fact] public void Index1()
            => LList.Of(1, 2)[0].Should().Be(1);

        [Fact] public void Index2()
        => LList.Of(1, 2)[1].Should().Be(2);

        [Fact] public void Index3()
            => LList.Of(1, 2, 4, 5, 6)[2].Should().Be(4);

        [Fact] public void Index4()
            => Assert.Throws<ArgumentOutOfRangeException>(
                () => LList.Of(1, 2, 3)[-1]);

        [Fact] public void Index5()
            => Assert.Throws<ArgumentOutOfRangeException>(
                () => LList.Of(1, 2, 3)[-3]);

        [Fact] public void Index6()
            => Assert.Throws<ArgumentOutOfRangeException>(
                () => LList.Of(1, 2, 3)[3]);

        [Fact] public void Index7() 
            => LList.Of(1, 2, 3, 4)
                .Alias(out var list)
                .ReplaceWith(list[0] + list[1] + list[2] + list[3])
                .Should().Be(10);
    }
}
