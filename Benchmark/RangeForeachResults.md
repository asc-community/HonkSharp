```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.6.21355.2
  [Host]     : .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```

|                  Method |    N |         Mean |      Error |     StdDev | Ratio | RatioSD | Code Size |
|------------------------ |----- |-------------:|-----------:|-----------:|------:|--------:|----------:|
|                 LoopFor |   10 |     4.470 ns |  0.1282 ns |  0.2070 ns |  1.00 |    0.00 |      27 B |
|   LoopForeachEnumerable |   10 |    69.410 ns |  1.4166 ns |  2.6258 ns | 15.55 |    0.73 |     338 B |
|    LoopForeachHonkRange |   10 |    29.935 ns |  0.3662 ns |  0.3426 ns |  6.46 |    0.27 |     359 B |
| LoopForeachHonkRangeRaw |   10 |    27.676 ns |  0.2995 ns |  0.2655 ns |  5.94 |    0.19 |     357 B |
|                         |      |              |            |            |       |         |           |
|                 LoopFor |  100 |    45.781 ns |  0.9516 ns |  1.9439 ns |  1.00 |    0.00 |      27 B |
|   LoopForeachEnumerable |  100 |   477.624 ns |  9.4644 ns | 17.0663 ns | 10.41 |    0.53 |     338 B |
|    LoopForeachHonkRange |  100 |   199.509 ns |  2.3159 ns |  1.9339 ns |  4.23 |    0.19 |     359 B |
| LoopForeachHonkRangeRaw |  100 |   199.366 ns |  3.8053 ns |  3.5595 ns |  4.27 |    0.23 |     357 B |
|                         |      |              |            |            |       |         |           |
|                 LoopFor | 1000 |   351.629 ns |  7.0631 ns | 11.8009 ns |  1.00 |    0.00 |      27 B |
|   LoopForeachEnumerable | 1000 | 4,978.187 ns | 93.4679 ns | 95.9847 ns | 14.14 |    0.54 |     338 B |
|    LoopForeachHonkRange | 1000 | 1,811.877 ns | 31.6423 ns | 29.5983 ns |  5.15 |    0.20 |     359 B |
| LoopForeachHonkRangeRaw | 1000 | 1,821.561 ns | 20.1040 ns | 18.8052 ns |  5.17 |    0.19 |     357 B |