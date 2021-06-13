using HonkSharp.Laziness;
using HonkSharp.Fluency;
using FluentAssertions;
using System.Collections.Concurrent;
using HonkSharp.Functional;
using Xunit;

namespace Tests
{
    public sealed class FieldCacheBTest
    {
        [Fact]
        public void TestSimple1()
            => new FieldCacheB<FieldCacheBTest, int>(_ => 4)
                .Alias(out var container)
                .ReplaceWith(ref container)
                .Pipe(c => c.GetValue(this))
                .Should().Be(4)
                .ReplaceWith(ref container)
                .Pipe(c => c.GetValue(this))
                .Should().Be(4);


        [Fact]
        public void TestSimpleString()
            => new FieldCacheB<FieldCacheBTest, string>(_ => "ss")
                .Alias(out var container)
                .ReplaceWith(ref container)
                .Pipe(a => a.GetValue(this))
                .Should().Be("ss")
                .ReplaceWith(ref container)
                .Pipe(a => a.GetValue(this))
                .Should().Be("ss");

        private record SomeTestRecord
        {
            public ConcurrentDictionary<string, string> Dict => dict.GetValue(this);
            private FieldCacheB<SomeTestRecord, ConcurrentDictionary<string, string>> dict = new(_ => new());
        }

        [Fact]
        public void TestThreadSafety()
        {
            SomeTestRecord someInstance = new SomeTestRecord();

            void ChangeADict(int threadId)
            {
                someInstance.Dict["someSpecificKey"] = threadId.ToString();
            }

            new ThreadingChecker(ChangeADict).Run(iterCount: 10000);
        }

        private record Person(string FirstName, string LastName)
        {
            public string FullName => fullName.GetValue(this);
            private FieldCacheB<Person, string> fullName = new(@this => @this.FirstName + " " + @this.LastName);
        }

        [Fact]
        public void TestEqualityPure()
            => new Person("John", "Ivanov")
                .Should().Be(new Person("John", "Ivanov"));

        [Fact]
        public void TestEqualityOneInitted()
            => new Person("John", "Ivanov")
                .Alias(out var a)
                .FullName
                .Should().Be("John Ivanov")
                .ReplaceWith(a)
                .Should().Be(new Person("John", "Ivanov"));

        [Fact]
        public void TestEqualityBothInitted()
            => new Person("John", "Ivanov")
                .Alias(out var a)
                .FullName
                .Should().Be("John Ivanov")
                .ReplaceWith(new Person("John", "Ivanov"))
                .Alias(out var b)
                .FullName
                .Should().Be("John Ivanov")
                .ReplaceWith(b)
                .Should().Be(a);

        [Fact]
        public void TestUnequalityPure()
            => new Person("Peter", "Smith")
                .Should().NotBe(new Person("John", "Ivanov"));
        
        private record SomeTestRecord_static
        {
            public ConcurrentDictionary<string, string> Dict => dict.GetValue(this);
            private FieldCacheB<SomeTestRecord_static, ConcurrentDictionary<string, string>> dict = new(_ => new());
        }

        [Fact]
        public void TestThreadSafety_static()
        {
            SomeTestRecord_static someInstance = new SomeTestRecord_static();

            void ChangeADict(int threadId)
            {
                someInstance.Dict["someSpecificKey"] = threadId.ToString();
            }

            new ThreadingChecker(ChangeADict).Run(iterCount: 10000);
        }

        [Fact]
        public void WithAlsoShouldWork1()
            => new Person("John", "Smith")
                .Alias(out var personJohnSmith)
                .Let(out var personTonySmith, personJohnSmith with { FirstName = "Tony" })
                .FullName
                .Should().Be("John Smith")
                .ReplaceWith(personTonySmith)
                .FullName
                .Should().Be("Tony Smith");

        [Fact]
        public void WithAlsoShouldWork2()
            => new Person("John", "Smith")
                .Alias(out var personJohnSmith)
                .FullName
                .Should().Be("John Smith")
                .ReplaceWith(personJohnSmith)
                .Pipe(p => p with { FirstName = "Tony" })
                .FullName
                .Should().Be("Tony Smith");
    }
}