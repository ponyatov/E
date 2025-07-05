# Modules

- [[E/module|module]] - define module namespace
- [[E/use|use]] - import module
- [[E/pub|pub]] - make item publicly accessible

## Automatic Modules Definition

- every file with `module.e` extensions creates module with `module` name
	- `.e` can have internal submodules
	- defined by [[E/module|module]] keyword
- directories forms module trees
- modules defined as files is public by default
	- modules defined inside of code file prvate default
- add module contents is private by default
	- public elements must be explicitly exported with [[E/pub|pub]] keyword

## Visibility

```E
// Default is private to module
fn internal_helper() = ...

// Explicitly export
export fn public_api() = ...
```
