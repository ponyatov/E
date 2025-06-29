# REPL
## Driven Development

The [[E/REPL|REPL]] [[#Driven Development]] is that there is a particular kind of programming approach in which you build a program by interacting with it as it runs in a language shell, and there are certain languages and runtimes that were designed from the ground up to support that kind of programming.

[[Python]] and [[Ruby]] are not examples of such languages. Why not?

The word **[[E/REPL|REPL]]** is an acronym that stands for **read-eval-print loop**. The term comes from the history of [[Lisp]]. From the start, sixty years ago, the standard way of working with a Lisp system has been to start a language processor, type expressions at its prompt, and wait for it to evaluate the expressions and print their results. Read your code, evaluate it, and print results. In a loop.

So what’s the difference? What do [[Lisp]] and [[Smalltalk]] have that Python and Ruby don’t?

The REPL-oriented language and runtime system that are designed from the ground up with the assumption that
- you’re going to develop programs by starting the language engine and talking to it, teaching it how to be your program _interactively_, by changing it _while it runs_.
- there are no any IDE, editors, side panels, that's only the CLI console you put you code fragments in, and give commands to compile, run, read output, maybe manipulate files, run OS commands and process their output.

Yes, almost every modern language with a repl can do some things in the repl. But, Being able to do _some_ things in the repl does not make a language engine into a repl-driven programming environment. What distinguishes old-fashioned Lisp and Smalltalk environments is that you can do _everything_ in the REPL.

For example, you can ask the current version of [[E/E|E]] to rebuild itself from scratch for some specific [[E/TARGET|TARGET]] with your own changes done into a language, with this command:
```E
let TARGET = 'wasm32-browser-js'
E.rebuild TARGET
```

## [[compiler/cross-compiler|cross-compiler]] issues

As [[E/E|E]] is a [[cross-compile first]] language, you always have a deal with both [[E/HOST|HOST]] and [[E/TARGET|TARGET]] system simultaneously, so we need a way to differ what side should run the entered code, and how this code can be [[E/Iterative Compilation|iteratively compiled]], and maybe sent to remote hardware (over [[gdb]]/[[OpenOCD]]/etc).
