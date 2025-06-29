# Literals

- Fixed values written directly in code

## [[E/Primitive Types|Primitive Types]]

- [[E/byte|byte]] single byte
	```E
	            // E is a language for embedded, so need specials:
	#AA         // single byte (hex)
	#[1 2 3 4]  // binary fragment (Erlang-like, bytes in decimal)
	#'Hello\0'  // byte-sized string with optional C endline
	```
- [[E/int|int]] integer number
	```E
	42          // decimal
	0x2A        // hexadecimal
	0o750       // octal
	0b101010    // binary
	0b_1010_10  // underscore can be used in any positions
	```
- [[E/float|float]] floating-point number
	```E
	+3.14        // simple point notation
	-6.022e+23   // scientific notation
	```
- [[E/char|char]] single wide char
	```E
	'A'
	'\n'         // escape sequences supported
	```
- [[E/bool|bool]] boolean
	- `true`
	- `false`

## [[E/Composite Types|Composite Types]]

- [[E/string|string]] literal
	```E
	"Hello"

	"Multi-line
	strings"
	```
- [[E/array|array]]
	```E
	[1, 2, 3]                 // array of integers
	["a", "b", "c"]           // array of strings
	```
- [[E/tuple|tuple]]
	```E
	(42, "answer")            // heterogeneous tuple
	1,2,3                     // parens are optional
	(,)                       // empty tuple
	(1,)                      // single element tuple
	```
- [[E/struct|struct]]
	```E
	{x: 10, y: 20}            // structure with named fields
	```
