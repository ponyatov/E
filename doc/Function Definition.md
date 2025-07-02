# [[E/Functions|Functions]] Definition

- [[E/fn|fn]] - single function declaration

```E
fn name <signature definition> [where <optional guard>] = <body>
<signature definition> := <arguments> [: return type]
```

- multiple function declaration (with [[Functional Polymorphism]])

```E
fn name <signature1> = ...
fn mame <signature2> = ...
```

- lambda form (anonymous function expression):
```E
 () => 1   // lambda without arguments (void=unit argument)
  x => x   // same
a b => a+b // sum (currying allowed)
```

[[E/signature]]