# Explicit type cast

[[Explicit type cast]]ing (also called type conversion) is a fundamental operation in programming where developers manually convert a value from one data type to another.

In E, type constructor call is used: type name followed by attribute calls corresponding type constructor:

```E
x = 10.5         // explicitly cast float to int using
y = int x        // `int::new float -> int` constructor function

a = "123"
b = int(a)       // `str` to `int` with optional parens

c = 65
d = c |> chr     // `int` to `char` using pipe operator

n = 123
f = n as float   // Rust-like keyword calls type constructor
```

If target type has multiple constructors, the [[Function signature matching]] is used to select constructor must be used for a cast.

## Code Safety

When performing explicit type casting, it's important to be aware of potential data loss (especially when converting from larger to smaller types, or using incorrect input data), and to handle possible exceptions that may occur during conversion.
