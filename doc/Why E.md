# Why [[E/E|E]]?

There are no many embedded languages, and all of them have trade-offs:

- batch compilers are inconvenient for interactive development and experimentation
	- **C/C++**: 
		- lacks of effective data structures support & syntax in a language core
		- no modern abstractions.
		- Powerful but unsafe, 
	- **Rust**: 
		- Safe but complex for embedded use.
		- the most difficult language even for experienced programmers, especially those with background in [[em/MCU|MCU]] firmware development
- interpreters are not suitable for industrial use due to the extremely high overhead costs
	- **[[Espruino]]**/[[eJS]]: Single vendor, bad internal design, unhandly syntax
	- **[[uPython]]**: Easy but slow, not for hard real-time.
