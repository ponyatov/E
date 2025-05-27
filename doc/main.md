# Main

An [[Evento]] executable program for POSIX systems has to have a `Main` actor. It’s kind of like the [[Cpp/main|main]] function in C or C++, or the `main` method in Java. In case you are using Evento for compiling side C/C++ components, some special init must be run from the [[Cpp/main|main]] to make our code works.

```evento
new main argc`i32 argv`str[] env`map<str,str> =
```

- This is a **constructor**. The keyword `new` means it’s a function that creates a new instance of the `Main`.
- `argc` number of command line parameters
- `argv` array of command line parameters
- `env` OS environment represented as stringed [[E/map]]
