## FieldCacheB

A good replacement for the `Lazy<T>` class for some rare cases. If you already hate it, go to [FAQ](#FAQ). You can also read an [article](https://habr.com/en/post/545936/) about it.

[![Nuget](https://img.shields.io/nuget/dt/FieldCache)](https://www.nuget.org/packages/FieldCache/)

## Usage

Consider an immutable record `Person`, which has `FirstName` and `LastName`. It also has a property
`FullName` which should be computed once (assume it's too expensive otherwise). Then, that is how
you use `FieldCache`:
```cs
public record Person(string FirstName, string LastName)
{
    public string FullName => fullName.GetValue(@this => @this.FirstName + " " + @this.LastName, this);
    private FieldCache<string> fullName;
}
```

Since Roslyn overrides records' `Equals`, unless you use `FieldCache`, you either need to dynamically attach your fields,
or override `Equals` for all records which have cached fields.

## FAQ

#### 1. Why not use `Lazy<T>`?
> For many reasons.
> 1. It takes the factory in its constructor. See question 3 why it's bad.
> 2. The comparison would be invalid, since `Lazy` are compared by references, which will always differ. See question 2.
> 3. Makes an allocation we don't need in our case.

#### 2. Why are `Equals` and `GetHashCode` overrided to true and 0?
> The values obtained by `FieldCache`'s factory must be *secondary* properties of the record. For example, for `MyInteger` the primary property is `int Value`. One of its secondary properties might be `MyInteger Tripled` defined as `Tripled => tripled.GetValue(@this => new MyInteger(@this.Value * 3), this)`. You can see, the comparison remains absolutely valid, since you don't want to compare by their secondary properties, only by those primary.

#### 3. Why do we pass the factory into `GetValue`, not in the ctor?
> Because if you needed to pass it in the constructor, you would need to have a record's constructor, where you would be creating all those `FieldCache` for each field. This is not a good code, poorly maintainable and non-obvious. Your initialization will be separated from the properties to which your values are exposed. While here this delegate is passed right in the secondary property.

#### 4. Why do we depend on the "holder"?
> Because we want to recreate the cache if the owner changed. It is useful for the `with` operator, which *copies* all the fields of a record and assign them all to a new one. To avoid rewriting member copy method, we can simply invalidate it automatically.

## Benchmarks

Running info:
```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
```

Results:

|                                                          Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|---------------------------------------------------------------- |----------:|----------:|----------:|------:|--------:|
|       'This overhead is a tradeoff to perform a microbenchmark' |  1.594 ns | 0.0304 ns | 0.0284 ns |  0.38 |    0.01 |
|         'The time needed for standard Lazy<> to return a value' |  4.220 ns | 0.0670 ns | 0.0627 ns |  1.00 |    0.00 |
|           'The time needed for FieldCache<,> to return a value' |  3.462 ns | 0.0435 ns | 0.0407 ns |  0.82 |    0.02 |
| 'The time needed for ConditionalWeakTable<,> to return a value' | 27.723 ns | 0.5365 ns | 0.7162 ns |  6.54 |    0.19 |

So the conclusion is... that `FieldCache<,>` is slightly (15-20%) faster than `Lazy<>`. It is by far a better solution,
than using `ConditionalWeakTable`. The total time to call `GetValue` is about 1.8ns on the machine.
