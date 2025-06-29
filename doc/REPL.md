# REPL
## Driven Development

The [[E/REPL|REPL]] [[#Driven Development]] is that there is a particular kind of programming approach in which you build a program by interacting with it as it runs in a language shell, and there are certain languages and runtimes that were designed from the ground up to support that kind of programming.

As [[E/E|E]] is a [[cross-compile first]] language, you always have a deal with both [[E/HOST|HOST]] and [[E/TARGET|TARGET]] system simultaneously, so we need a way to differ what side should run the entered code, and how this code can be [[E/Iterative Compilation|iteratively compiled]], and maybe sent to remote hardware (over [[gdb]]/[[OpenOCD]]/etc).
