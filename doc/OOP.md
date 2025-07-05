# OOP

## Object

- root class for all objects (hidden inheritance)
- destructor can be run manually with `delete` keyword
- `&self` instance reference
- `&Self` class name alias

```E
class Object =

	// default constructor
	fn __new -> &Self = sizeof(Self) |> _alloc

	// default destructor
	fn __delete &self = self |> _free

	// default allocator
	fn __alloc size:uint -> &Self = libc::alloc(size)? as &Self

	// default deallocator
	fn __free &self = libc::free(self)
```

## Class Definition

```E
/// Base class for geometric shapes
class Shape =

	// Instance field (mutable)
    mut id: int

	// constructor
    fn __new id:int -> Self = Self { id }

	// destructor
    fn __delete = ()
```
- class definition can be expanded if full definition too large or in other module
```E
class Shape += // extend in other code fragment

	// Method
    fn area -> float = 0.0  // Default implementation

    // Abstract method (must be implemented by subclasses)
    fn perimeter -> float
```

## Inheritance

- all classes inherits from [[#Object]]
- multiple inheritance (using mixins)
- items overload in order of inheritance list

```E
class Colored =
	fill: color = Color::WHITE  // field with default value
	fn draw = log "Painting..."
```
```E
class Circle : Shape,Colored =

	radius: float

	// Constructor with base class initialization
    fn __new id:int radius:float fill:color=Colored::fill -> Self =
	    let self = super id     // Call base constructors
        self.radius = radius    // assign new field
        self.fill = fill        // in-mixed field with default color
        self                    // return constructed object

	// Method override
    fn area -> float = Pi * self.radius ^ 2

	// Implement abstract method
    fn perimeter -> float = 2 * Pi * self.radius
```

## Instantiation and Usage

- instantiation by class name calling
	- parameters selects appropriate constructors

```E
let circle           = Circle id:1 5.0<mm>
log circle.area      // 78.54<mm2>
log circle.perimeter // 31.42<mm>
```

## Operator Overloading

```E
class Vector2D {
    x: float ; y: float
    
    /// overload `+` operator
    fn __add self other:&Self -> Self =
        Vector2D x:(self.x + other.x) y:(self.y + other.y)
}
```
