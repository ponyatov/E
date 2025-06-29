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

The point is not that you would want to do something in REPL. The point is that there are no artificial limitations, and you have a full range of the development system’s capabilities is accessible from the repl.

Proper support for [[interactive programming]] means that the language and its runtime have positive features that support changing your program _while it runs_.

## Some samples

- Define a function, `foo`, that calls some other function, `bar`, that is not yet defined. Now call `foo`. What happens?

Obviously, the call to `foo` breaks, because `bar` is not defined. But what happens when it breaks? What happens next?

Most languages repls just prints an error message and returns to its prompt. In worst cases, it just crashes.

In a right-done REPL, the break in `foo` drops you into a **[[breakloop]]** or [[interactive debugger]], and asks what you want to do next to fix a problem.

![[breakloop]]

Moreover, because the entire language and development system are available, unrestricted, in the [[breakloop]], you can define the missing function `bar`, resume `foo`, and get a sensible result.

In fact, there’s a style of programming, well known in Lisp and Smalltalk circles, in which you define a toplevel function with calls to other functions that don’t yet exist, and then define those functions as you go in the resulting breakloops. It’s a fast way to implement a procedure when you already know how it should work.

- Now change the definition of the type. What happens?

Does your language runtime notice that the definition of the type has changed? Does it realize that the existing instances have a new definition? When something touches one of them, does it automatically reinitialize it to conform to the new definition, or, if it doesn’t know how to do that, does it start a breakloop and ask you what to do about it? If the answers is “no,” then you’re missing a crucial element of repl-driven development.

## [[compiler/cross-compiler|cross-compiler]] issues

As [[E/E|E]] is a [[cross-compile first]] language, you always have a deal with both [[E/HOST|HOST]] and [[E/TARGET|TARGET]] system simultaneously, so we need a way to differ what side should run the entered code, and how this code can be [[E/Iterative Compilation|iteratively compiled]], and maybe sent to remote hardware (over [[gdb]]/[[OpenOCD]]/etc).

## [[compiler as a library]]

## 
> Remember: the point is to support programming _interactively_. You don’t want to have to kill your program and rebuild it from scratch just because you changed a definition. That’s silly; adding and changing definitions is most of what you do! If your development environment is going to support interactive development, then it had better know how to keep your program running when you change some definitions.
