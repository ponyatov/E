# [[lang/Actor|Actor]]

[[Pony]] lang code sample:
```pony
actor Main
  new create(env: Env) =>
    env.out.print("Hello, world!")
```

[[Evento]] makes it more redable:

```evento
actor Main
```
- This is a **type declaration**. The keyword [[E/Actor|actor]] means we are going to define an actor, which is a bit like a [[E/class|class]]. Evento has classes too, which we’ll see later.
- The difference between an [[E/Actor|Actor]] and a [[E/class|class]] is that an actor can have **asynchronous** methods, treated as typed messages handlers.
