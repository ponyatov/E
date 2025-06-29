# Shebang (Script Header)

[[E/E|E]] is optimized for a fast cold start, so it is suitable for using E-lang as a general-purpose script language to run scripts starts with a [[shebang]]:

`lib/hello.e`:
```E
#!/usr/bin/env e

log 'Hello World!'
```
