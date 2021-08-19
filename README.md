<p align="center">
  <a href="https://github.com/WhiteBlackGoose/HonkSharp">
    <img src="./HonkSharp/logo256.png" alt="Honk# logo" width="200" height="200">
  </a>
</p>


<h1 align=center>Honk#</h1>
<p align=center><i>Modern library for declarative programming in C#. Available on <a href="https://www.nuget.org/packages/HonkSharp">NuGet</a>.</i></p>

Honk in C#!

We, C# programmers, also deserve beautiful code like in F#. We don't have duck typing, arbitrary operators, discriminated unions,
currying, **but** instead we can have fluent coding, lazy properties, and many more.

This repo contains some wrappers and API and methods for fast and convenient declarative coding in C#,
including features from functional, fluent, and lazy programming.

- [Functional programming](#functional)
- [Fluent programming](#fluency)
- [Lazy programming](#laziness)
- [Convenient extensions](#convenient-extensions)

Go to [examples](#examples) or [features](#features).

## Functional

### Either

The purpose of this type is to mimic an anonymous DU. For example,
```cs
var a = new Either<string, int>(5);
var b = new Either<string, int>("Hello, world");
Either<string, int> f(bool test) => test ? a : b; // We can return either of them
```
are both valid, where in the first one `Either` is an `int`, and in the second one, it's a `string`. It may take up to 16 types.
It is equivalent to F#:
```fs
let a = Choice2Of2 5
let b = Choice1Of2 "Hello, world"
let f = function true -> a | false -> b // We can return either of them
```
or [F# in the future](https://github.com/dotnet/fsharp/pull/10896):
```fs
let a = 5
let b = "Hello, world"
let f : _ -> (int|string) = function true -> a | false -> b // We can return either of them
```
Assume
```cs
Either<string, int, (int quack, float duck)> a = ... // we don't care
```
which is equivalent to F#:
```fs
let a : Choice<string, int, {| quack:int; duck:float |}> a = ... // We don't care
```
```fs
let a : (string|int|{| quack:int; duck:float |}) a = ... // We don't care
```
Here is how we work with Either.

#### 1. Switch over all cases
```cs
var res = a.Switch(
    s => $"It's a string {s}!",
    i => $"It's an int {i}!",
    q => $"It's a tuple {q.quack}!"
)
```
Equivalent to F#:
```fs
let res = a |> function
    | Choice1Of3 s -> $"It's a string {s}!"
    | Choice2Of3 i -> $"It's an int {i}!"
    | Choice3Of3 q -> $"It's a tuple {q.quack}!"
```
```fs
let res = a |> function
    | :? string as s -> $"It's a string {s}!"
    | :? int as i -> $"It's an int {i}!"
    | :? {| quack:int; duck:float |} as q -> $"It's a tuple {q.quack}!"
```
If you would like to reorder branches, the argument names are `case1`, `case2`, `case3`, etc.
```cs
var res = a.Switch(
    case2: i => $"It's an int {i}!",
    case3: q => $"It's a tuple {q.quack}!",
    case1: s => $"It's a string {s}!"
)
```
Equivalent to F#:
```fs
let res = a |> function
    | Choice2Of3 i -> $"It's an int {i}!"
    | Choice3Of3 q -> $"It's a tuple {q.quack}!"
    | Choice1Of3 s -> $"It's a string {s}!"
```
```fs
let res = a |> function
    | :? int as i -> $"It's an int {i}!"
    | :? {| quack:int; duck:float |} as q -> $"It's a tuple {q.quack}!"
    | :? string as s -> $"It's a string {s}!"
```
#### 2. Check the type of the either
```cs
if (a.Is<int>(out var i))
    Console.WriteLine($"It's an int {i}!");
```

Equivalent to F#:
```fs
match a with Choice2Of3 i ->
             printfn $"It's an int {i}!" | _ -> ()
```
```fs
match a with :? int as i ->
             printfn $"It's an int {i}!" | _ -> ()
```
#### 3. Try casting
```cs
var res = a.As<int>().Switch(
    i => $"Cast successful! {i}"
    _ => "Cast failed :("
);
```

Equivalent to F#:
```fs
let res = a |> function
    | Choice2Of3 i -> $"Cast successful! {i}"
    | _ -> "Cast failed :("
```
```fs
let res = a |> function
    | :? int as i -> $"Cast successful! {i}"
    | _ -> "Cast failed :("
```
#### 4. Force casting
Since `As` returns an Either of result and failure, we can force the best case by
`AssumeBest`:
```cs
var res = a.As<int>().AssumeBest();
Console.WriteLine($"It's an int: {res}");
```
If `a` turns out to be a non-int, then `AssumeBest` will throw an exception (see fluent coding for more info).
Equivalent to F#:
```fs
let res = a |> function Choice2Of3 i -> i
printfn $"It's an int: {res}"
```
```fs
let res = a |> function :? int as i -> i
printfn $"It's an int: {res}"
```

### LList

It's a singly-linked immutable list with a head element and tail.

#### 1. Create it from sequence

```cs
var list = LList.Of(1, 2, 3);

IEnumerable<string> seq = MyCustomSequence();
var list = LList.Of(seq);
```

#### 2. Create empty list

```cs
var empty = LList.Of<int>();
var empty = LList<int>.Empty;
```

#### 3. Add elements

```cs
var list = LList.Of(1, 2, 3);

var newList = 0 + list; // <=> LList.Of(0, 1, 2, 3)
var newList = list.Add(0); // same
```

#### 4. Call ToString

```cs
var list = LList.Of(1, 2, 3);
Console.WriteLine(list);
>>> [ 1, 2, 3 ]
```

#### 5. Switch over elements

```cs
var list = LList.Of(1, 2, 3);

var res = list switch
{
    LEmpty<int> => "This list is empty!",
    (var head, LEmpty<int>) => $"This list has one element: {head}",
    (var h1, (var h2, var tail)) => $"This list has at least two elements!11!"
};
```

#### 6. Built-in fluent functions to work with list

```cs
var list = LList.Of(1, 2, 3);

list
    .Where(a => a > 2)
    .Map(a => 
        a.ToString()
        .ToArray()
    )
    .Flatten()
    .Reverse();
```

#### 7. Indexing

```cs
var list = LList.Of(1, 2, 3);

list[0] + list[2];
```

Indexing works slowly (linearly traversing the list).

## Fluency

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

#### 7. ReplaceWith
This is a very simple thing that replaces the current flow end with another object.
```cs
public static int SomeMethod()
    => "quack".ReplaceWith(5);
```
The method returns 5.

#### 8. Dangerous
This creates a block of code which can throw. `Try` returns an Either of result and failure.
```cs
"55".Dangerous().Try<FormatException, int>(int.Parse)
```
returns 55 in an either, but 

```cs
"quack".Dangerous().Try<FormatException, int>(int.Parse)
```
would return a `Failure<FormatException>`.

## Laziness
  
### Lazy property: what and how?

Detailed article is [here](https://habr.com/en/post/545936/), but let's go over the main points.

This type serves as a field inside your immutable records to represent a record's secondary property
that is only dependent on its primary properties.

Primary properties are those `init`-able (we don't consider setters in any way here). Secondary
properties are some results, consequences of the primary properties. For example, if we were to have
a type `Integer`, then its primary property is its `int` value, but its secondary property is its
`Tripled` value (since each integer has it), which only depends on its `int` value.

So to achieve that, we write
```cs
public sealed record Number(int Value)
{
    ... other code
    
    public Number Tripled => tripled.GetValue(...);
    private LazyProperty<Number> tripled = ...;
}
```

As you can see, the syntax is very concise. Other benefits is that
1. It does NOT affect the comparison. So even if one record has its `tripled` calculated and the other does not, the value of `tripled`
is not taken into account.
2. Copying is safe. For example, assume there's some `num` whose `Tripled` is already calculated. Then if you copy it with 
`num with { Value = 32 }`, `Tripled` will be calculated again for the new instance.
3. Is a struct.

A few rules working with `LazyProperty`:
1. Do NOT pass it by copy. Otherwise you risk the factory being called more than once.
2. Do provide `this` as the argument of `GetValue`, as it invalidates on the new holder, but is valid as long as the current holder
remains.
3. Do NOT use it on mutable primary properties.

Now, let's consider implementations of this type.

### LazyPropertyA
`A` stands for `after`: you pay a bit more time on accessing an instance of `LazyPropertyA` (after creating your record) but do not 
pay extra time before (on creating the instance).

The syntax:
```cs
public sealed record Number(int Value)
{
    ... other code
    
    public Number Tripled => tripled.GetValue(@this => new(@this.Value * 3), this);
    private LazyProperty<Number> tripled;
}
```

So as you can see, creating `tripled` is absolutely free.

### LazyPropertyB
`B` stands for `before`: you pay a bit more time on creating an instance of `LazyPropertyB`, but accessing it is a bit faster.

The syntax:
```cs
public sealed record Number(int Value)
{
    ... other code
    
    public Number Tripled => tripled.GetValue(this);
    private LazyProperty<Number> tripled = new(@this => new(@this.Value * 3));
}
```

The difference between the two is the time when you pass the factory (on creating your type or on accessing the property).


## Convenient extensions

#### 1. bool.Invert
```cs
true.Invert() // returns false
```

#### 2. string.Parse
Parses numeric types. Returns an either.
```cs
"55".Parse<int>()
"5.5".Parse<decimal>()
"23482948294892840928492842424242".Parse<BigInteger>()
```

#### 3. string.Join
Joins objects over a delimiter.
```cs
", ".Join(new [] { 1, 2, 3 }) // returns "1, 2, 3"
```

#### 4. AsString
Concats a sequence of chars into a string
```cs
new [] { 'a', 'b', 'c' }.AsString() // returns "abc"
```

#### 5. Zip
Given a tuple of sequences, zips them into one:
```cs
(new [] { 'a', 'b', 'c' }, new [] { 1, 2, 3 }).Zip().ToArray() // returns new [] { ('a', 1), ('b', 2), ('c', 3) }
```

#### 6. Cartesian
Given a tuple of sequences, finds their cartesian product (aka 'each for each'):
```cs
(new [] { 'a', 'b' }, new [] { 1, 2 }).Zip().ToArray() // returns new [] { ('a', 1), ('a', 2), ('b', 1), ('b', 2) }
```

#### 7. AsRange
Converts a `Range` into a sequence of natural numbers.
```cs
(2..4).AsRange().ToArray() // returns new [] { 2, 3, 4 }
```

Another Range-related feature is extended Enumerator:
```cs
foreach (var i in 2..5)
    Console.Write(i);
```
(outputs `2345`)

#### 8. Enumerate
Allows to go over a sequence keeping the current index of the element.
```cs
"abc".Enumerate().ToArray() // returns new [] { (0, 'a'), (1, 'b'), (2, 'c') }
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
