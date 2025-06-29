# Why [[E/E|E]]?

There are no many embedded languages, and all of them have trade-offs:

- batch compilers are inconvenient for interactive development and experimentation
	- **C/C++**: 
		- lacks of effective data structures support & syntax in a language core
		- powerful but totally unsafe (both memory & concurrency issues)
		- no modern abstractions in a [[Cpp/std|Standard Library]]
	- **Rust**: 
		- safe but complex for embedded use.
		- the most difficult language even for experienced programmers, especially those with background in [[em/MCU|MCU]] firmware development
- interpreters are not suitable for industrial use due to the extremely high overhead costs
	- **[[Espruino]]**/[[eJS]]: Single vendor, bad internal design, unhandly syntax
	- **[[uPython]]**: Easy but slow, not for hard real-time.

E is designed for **developers who need a modern, safe, and portable language** for embedded systems, industrial automation, and [[IoT/IoT|IoT]] —without sacrificing performance or control.
