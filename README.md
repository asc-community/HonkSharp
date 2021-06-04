# Declarative C\#

We, C# programmers, also deserver beautiful code. We don't have duck typing, arbitrary operators, DUs,
currying, **but** instead we can have fluent coding, lazy properties, and many more.

This repo contains some wrappers and API and methods for fast and convenient declarative coding in C#,
including features from functional, fluent, and lazy programming.

Go to [examples](#examples) or [features](#features).

## Features

#### 1. Map

```cs
var a = Method(b);
```
<=>
```cs
b.Map(Method)
```

#### 2. Inject

```cs
a
.Inject(b)
.Map((a, b) => a + b)
```

#### 3. Alias

```cs
(1 + 2 + 3)
.Alias(out var someVar)
.Map(a => a * 2)
.Inject(someVar)
.Map((a, b) => a + b)
```

#### 4. NullIf

```cs
(a + 2)
.NullIf(a => a < 0)
?.Map(a => Math.Sqrt(a))
```

#### 5. Let

```cs
a
.Let(out var six, 1 + 2 + 3)
.Map(a => a + 4)
.Inject()
```

## Examples

Imperative C#:
```cs
var input = Console.ReadLine();
string output;
if (int.TryParse(input, out var valid))
    output = $"Valid number! {valid}";
else
    output = "Oops, invalid!";
Console.WriteLine($"Input: {input}\nOutput: {output}");
```

Declarative C#:
```cs
Console.ReadLine()
.Alias(out var input)
.Parse<int>()
.Match(
    valid => $"Valid number! {valid}",
    () => "Oops, invalid!"
)
.Inject(input)
.Map((output, input) => $"Input: {input}\nOutput: {output}")
.Execute(Console.WriteLine);
```