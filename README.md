# Declarative C\#

We, C# programmers, also deserve beautiful code like in F#. We don't have duck typing, arbitrary operators, DUs,
currying, **but** instead we can have fluent coding, lazy properties, and many more.

This repo contains some wrappers and API and methods for fast and convenient declarative coding in C#,
including features from functional, fluent, and lazy programming.

Go to [examples](#examples) or [features](#features).

## Features

#### 1. Pipe

```cs
Method(b)
```
<=>
```cs
b.Pipe(Method)
```

Equivalent to F#:
```fs
Method b
```
<=>
```fs
b |> Method
```

#### 2. Inject

```cs
a
.Inject(b)
.Pipe((a, b) => a + b)
```

Equivalent to F#:
```fs
(a, b)
||> fun a b -> a + b
// or
(a, b) ||> (+)
```

#### 3. Alias

```cs
(1 + 2 + 3)
.Alias(out var someVar)
.Pipe(a => a * 2)
.Inject(someVar)
.Pipe((a, b) => a + b)
```

Equivalent to F#:
```fs
1 + 2 + 3
|> fun someVar ->
(someVar * 2
, someVar)
||> (+)
```

#### 4. NullIf

```cs
(a + 2)
.NullIf(a => a < 0)
?.Pipe(a => Math.Sqrt(a))
```

Equivalent to F#:
```fs
a + 2.
|> fun a -> if a < 0. then None else Some a
|> Option.map sqrt
```

#### 5. Let

```cs
a
.Pipe(a => a + 2)
.Let(out var six, 1 + 2 + 3)
.Pipe(a => a + 4)
.Inject(six)
```

Equivalent to F#:
```fs
a
|> (+) 2 |> fun a -> // Can't just let between pipes without aliasing first
let six = 1 + 2 + 3
a + 4,
six
```

#### 6. LetLazy

```cs
a
.Pipe(a => a + 2)
.LetLazy(out var big, _ => Console.ReadLine().Parse<int>().AssumeBest())
.Pipe(a => a - 1)
.Inject(big)
.Pipe((a, big) => a switch
{
    > 0 => 4,
    -3 => big
    _ => big + a
})
.Execute(Console.WriteLine)
```

Equivalent to F#:
```fs
a
|> (+) 2 |> fun a ->
let big = lazy (Console.ReadLine() |> int)
(a - 1
, big)
||> function
| a when a > 0 -> fun _ -> 4
| -3 -> (|Lazy|)
| a -> (|Lazy|) >> (+) a
|> printfn "%d"
```

## Examples

Imperative C#:
```cs
using System;
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
using System;
Console.ReadLine().Alias(out var input)
.Parse<int>()
.Match(valid => $"Valid number! {valid}",
       () => "Oops, invalid!")
.Inject(input)
.Pipe((output, input) => $"Input: {input}\nOutput: {output}")
.Execute(Console.WriteLine);
```

F# equivalent of imperative:
```fs
open System
let input = Console.ReadLine()
let mutable output = Unchecked.defaultof<_>
let mutable valid = Unchecked.defaultof<_>
if Int32.TryParse(input, &valid) then
    output <- $"Valid number! {valid}";
else
    output <- "Oops, invalid!";
printfn $"Input: {input}\nOutput: {output}"
```

F# equivalent of declarative:
```fs
open System
Console.ReadLine() |> fun input ->
(input |> Int32.TryParse
|> function true, valid -> $"Valid number! {valid}"
          | _ -> "Oops, invalid!"
, input)
||> fun output input -> $"Input: {input}\nOutput: {output}"
|> printfn "%s"
```
