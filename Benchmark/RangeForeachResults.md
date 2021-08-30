```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.6.21355.2
  [Host]     : .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```

|                                      Method |     N |         Mean |        Error |       StdDev | Ratio | RatioSD | Code Size |
|-------------------------------------------- |------ |-------------:|-------------:|-------------:|------:|--------:|----------:|
|                                     LoopFor |   100 |     44.27 ns |     0.924 ns |     1.519 ns |  1.00 |    0.00 |      27 B |
|                       LoopForeachEnumerable |   100 |    503.95 ns |     9.963 ns |    22.892 ns | 11.56 |    0.62 |     338 B |
|                        LoopForeachHonkRange |   100 |    200.20 ns |     3.304 ns |     3.090 ns |  4.44 |    0.14 |     359 B |
|                     LoopForeachHonkRangeRaw |   100 |    200.12 ns |     1.822 ns |     1.615 ns |  4.44 |    0.15 |     357 B |
| LoopForeachHonkRangeRawWithEnumeratorHidden |   100 |     62.06 ns |     1.275 ns |     2.131 ns |  1.40 |    0.07 |     357 B |
|                                             |       |              |              |              |       |         |           |
|                                     LoopFor |  1000 |    371.01 ns |     7.461 ns |    17.587 ns |  1.00 |    0.00 |      27 B |
|                       LoopForeachEnumerable |  1000 |  5,272.56 ns |   105.459 ns |   200.646 ns | 14.23 |    0.79 |     338 B |
|                        LoopForeachHonkRange |  1000 |  1,840.57 ns |    21.230 ns |    19.859 ns |  4.92 |    0.26 |     359 B |
|                     LoopForeachHonkRangeRaw |  1000 |  1,829.91 ns |    15.183 ns |    14.202 ns |  4.89 |    0.27 |     357 B |
| LoopForeachHonkRangeRawWithEnumeratorHidden |  1000 |    393.13 ns |     7.908 ns |    19.399 ns |  1.06 |    0.08 |     357 B |
|                                             |       |              |              |              |       |         |           |
|                                     LoopFor | 10000 |  3,680.45 ns |    77.471 ns |   223.522 ns |  1.00 |    0.00 |      27 B |
|                       LoopForeachEnumerable | 10000 | 51,388.56 ns | 1,024.852 ns | 1,899.629 ns | 13.79 |    0.89 |     338 B |
|                        LoopForeachHonkRange | 10000 | 18,187.58 ns |   196.092 ns |   173.830 ns |  4.81 |    0.24 |     359 B |
|                     LoopForeachHonkRangeRaw | 10000 | 18,125.99 ns |   169.360 ns |   150.133 ns |  4.79 |    0.24 |     357 B |
| LoopForeachHonkRangeRawWithEnumeratorHidden | 10000 |  3,664.85 ns |    72.962 ns |   140.574 ns |  0.99 |    0.07 |     357 B |