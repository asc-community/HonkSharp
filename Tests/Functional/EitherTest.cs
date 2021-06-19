using FluentAssertions;
using HonkSharp.Fluency;
using HonkSharp.Functional;
using Xunit;

namespace Tests
{
    public class EitherTest
    {
        [Fact] public void Either2Is1True()
            => new Either<int, string>(5)
                .Is<int>(out _).Should().BeTrue();
        
        [Fact] public void Either2Is1False()
            => new Either<int, string>(5)
                .Is<string>(out _).Should().BeFalse();
        
        [Fact] public void Either2Is2True()
            => new Either<int, string>("sdf")
                .Is<string>(out _).Should().BeTrue();
        
        [Fact] public void Either2Is2False()
            => new Either<int, string>("sdf")
                .Is<int>(out _).Should().BeFalse();
        
        
        
        [Fact] public void Either2As1True()
            => new Either<int, string>(5)
                .As<int>().AssumeBest().Should().Be(5);
        
        [Fact] public void Either2As1False()
            => new Either<int, string>(5)
                .As<string>().Is<Failure>(out _).Should().BeTrue();
        
        [Fact] public void Either2As2True()
            => new Either<int, string>("sdf")
                .As<string>().AssumeBest().Should().Be("sdf");
        
        [Fact] public void Either2As2False()
            => new Either<int, string>("sdf")
                .As<int>().Is<Failure>(out _).Should().BeTrue();
    }
}