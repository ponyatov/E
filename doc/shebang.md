# shebang

```evento
#!/usr/bin/env evento
// ^^^^ shebang for using E in script or REPL mode
```

```langium
       terminal       SHEBANG: /#![^\r\n]+/;
```

- Purpose: Defines a [[shebang]] line, typically used at the start of a script to specify
	- the interpreter or runtime environment
	- optional parameters (the last will be the full path for this script)

- This [[Langium]] rule allows [[shebang]] only on the first line:
```langium
entry Module: SHEBANG? (defs+=Def)*;
```

The [[shebang]] support allows [[Evento]] scripts to be executable on systems like Linux directly, without AOT compilation (using in-memory JIT, simpler interpreter, or using [[CTFE]]). [[Evento]] must be designed enough comfortable, to be used in place of Python for any automations and simple programs. If you promote some cool & power programming language, it looks ugly strange that your build scripts uses Python, or some side tools. If you can't use your super language for regular every day tasks like project build, firmware programming, [[CI]]/CD etc that something goes a wrong way.
