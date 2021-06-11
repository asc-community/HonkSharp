using DeclarativeCSharp.Laziness;
using DeclarativeCSharp.Fluency;
using FluentAssertions;
using System.Collections.Concurrent;
using DeclarativeCSharp.Functional;
using Xunit;

namespace Tests
{
    public sealed class FieldCacheATest
    {
        [Fact]
        public void TestSimple1()
            => new FieldCacheA<int>()
                .Alias(out var container)
                .ReplaceWith(ref container)
                .Pipe(c => c.GetValue(_ => 4, this))
                .Should().Be(4)
                .ReplaceWith(ref container)
                .Pipe(c => c.GetValue(_ => 4, this))
                .Should().Be(4);


        [Fact]
        public void TestSimpleString()
            => new FieldCacheA<string>()
                .Alias(out var container)
                .ReplaceWith(ref container)
                .Pipe(a => a.GetValue(_ => "ss", this))
                .Should().Be("ss")
                .ReplaceWith(ref container)
                .Pipe(a => a.GetValue(_ => "ss", this))
                .Should().Be("ss");

        private record SomeTestRecord
        {
            public ConcurrentDictionary<string, string> Dict => dict.GetValue(_ => new(), this);
            private FieldCacheA<ConcurrentDictionary<string, string>> dict;
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
            public string FullName => fullName.GetValue(new(@this => @this.FirstName + " " + @this.LastName), this);
            private FieldCacheA<string> fullName;
        }

        [Fact]
        public void TestEqualityPure()
            => new Person("John", "Ivanov")
                .Should().Be(new Person("John", "Ivanov"));

        [Fact]
        public void TestEqualityOneInitted()
            => new Person("John", "Ivanov")
                .Alias(out var a)
                .Pipe(p => p.FullName)
                .Should().Be("John Ivanov")
                .ReplaceWith(a)
                .Should().Be(new Person("John", "Ivanov"));

        [Fact]
        public void TestEqualityBothInitted()
            => new Person("John", "Ivanov")
                .Alias(out var a)
                .Pipe(p => p.FullName)
                .Should().Be("John Ivanov")
                .ReplaceWith(new Person("John", "Ivanov"))
                .Alias(out var b)
                .Pipe(p => p.FullName)
                .Should().Be("John Ivanov")
                .ReplaceWith(b)
                .Should().Be(a);

        [Fact]
        public void TestUnequalityPure()
            => new Person("Peter", "Smith")
                .Should().NotBe(new Person("John", "Ivanov"));
        
        private record SomeTestRecord_static
        {
            public ConcurrentDictionary<string, string> Dict => dict.GetValue(_ => new ConcurrentDictionary<string, string>(), this);
            private FieldCacheA<ConcurrentDictionary<string, string>> dict;
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
                .Pipe(p => p.FullName)
                .Should().Be("John Smith")
                .ReplaceWith(personTonySmith)
                .Pipe(p => p.FullName)
                .Should().Be("Tony Smith");

        [Fact]
        public void WithAlsoShouldWork2()
            => new Person("John", "Smith")
                .Alias(out var personJohnSmith)
                .Pipe(p => p.FullName)
                .Should().Be("John Smith")
                .ReplaceWith(personJohnSmith)
                .Pipe(p => p with { FirstName = "Tony" })
                .Pipe(p => p.FullName)
                .Should().Be("Tony Smith");
    }
}