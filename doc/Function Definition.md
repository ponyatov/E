# [[E/Functions|Functions]] Definition

- [[E/fn|fn]] - single function declaration

```E
fn name <arguments> [: return_type] [where <guard>] = <body>
```
```E
// Simple function
fn add x y = x + y
```
```E
// With arguments and return type annotation
fn factorial n:int -> int = 
    if n == 0 then 1 else n * factorial (n - 1)
```

- multiple function declaration (with [[Functional Polymorphism]])
	- function [[E/signature|signature]] includes both arguments and return value
		- so compiler can find polymorphic function has return type most close to required

```E
fn name <signature1> = ...
fn mame <signature2> = ...
```
```E
// With guards (conditional dispatch)
fn factorial 0 = 1
fn factorial n when n > 0 = n * factorial (n - 1)
fn factorial _ = error "Negative input"
```
```E
// Multiple clauses with pattern matching
fn length []     = 0
fn length [_::xs] = 1 + length xs
```

- lambda form (anonymous function expression):
```E
 () => 1   // lambda without arguments (void=unit argument)
  x => x   // same
a b => a+b // sum (currying allowed)
```

- Currying & Partial application
- Lambdas (Anonymous Functions)
	- also can be assigned to variables

```E
// Compact syntax with =>
let square =   x => x * x
let sum    = a b => a + b
```

![[E/signature]]
