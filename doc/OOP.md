# OOP

## Object

- root class for all objects (hidden inheritance)

```E
class Object {

	// default constructor
	fn _new -> &Self = sizeof(Self) |> _alloc

	// default destructor
	fn _del self:&Self = self |> _free

	// default allocator
	fn _alloc size:uint -> &Self = libc::alloc(size)? as &Self

	// default deallocator
	fn _free self:&Self = libc::free(ptr)
}
```

## Class Definition

```E
/// Base class for geometric shapes
class Shape {
    // Instance field (mutable)
    mut id: int
    
    // constructor
    fn _new id:int -> Self = Self { id }
    // destructor
    fn _del = ()
    
    // Method
    fn area -> float = 0.0  // Default implementation
    
    // Abstract method (must be implemented by subclasses)
    fn perimeter -> float = undef
}
```

## Inheritance

- all classes inherits from [[#Object]]
- multiple inheritance
- items overload in order of inheritance list

```E
class Circle : Shape {

	radius: float
	fill: color

	// Constructor with base class initialization
    fn _new id:int radius:float fill:color=white -> Self =
	    let self = super id     // Call base constructors
        self.radius = radius    // assign new field
        self.fill = fill        // parameter with default value
        self                    // return constructed object

	// Method override
    fn area -> float = Pi * self.radius ^ 2

	// Implement abstract method
    fn perimeter -> float = 2 * Pi * self.radius
}
```

## Instantiation and Usage

- instantiation by class name calling
	- parameters selects appropriate constructors

```E
let circle           = Circle id:1 5.0<mm>
log circle.area      // 78.54<mm2>
log circle.perimeter // 31.42<mm>
```
