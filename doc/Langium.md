# Langium
## [[Language Workbench]]

- @pluralia_pluralia (Magenta)
	- https://t.me/LanguageDev/211902
	- https://youtu.be/mwqE29LBNjI

https://www.typefox.io/blog/code-generation-for-langium-based-dsls-3/

- Paradigm
	- Language Server Protocol ([[LSP]])
- Grammar Syntax
	- [[Chevrotain]] (JS-like)

## install

### 0. [[Node.js#install]]
```shell
sudo apt install npm nodejs
```
### 1. [[Yeoman#install]]
![[js/setenv]]
```shell
npm i -g yo generator-langium
```
### 2. Scaffold a Langium project

```shell
yo langium
```
- [[vscode/extensions|extensions]] name: evento
- Your language name: Evento
- File extensions: .e
- Include VSCode extension? Y
- Include CLI? Y
	- add REPL
- Include Web worker? y
	- You can run the language server in your web browser.
- Include language tests? Yes
	- You can add the setup for language tests using [[Vitest]].

## Langium-powered specification

https://langium.org/

For the first time we'll use [[Langium]] [[Language Workbench]] to write machine-readable [[Evento]] language specification. This tool also allows to run language online to let you practise with it before you'll be impressed enough to setup your own full-sized compiler (it is not so easy, as it goes in a source-only form and require Linux and some set of side compilers and tools to run).

- [typefox901 intro playlist](https://www.youtube.com/playlist?list=PLmmNK7CRoSWuUejGnfoY5_w7C-AbNU-mk)
	- [install](https://youtu.be/PtCUafeZi1E?si=-Wu8dNSkzyFxzKXf)
	- [write grammar](https://youtu.be/bNoRO-DLvAA?si=QgDBJqwBMO-E3Sds)

So, while you pass the first step on installing and running Langium, it's time to write the first (empty) grammar:

`~/E/evento/src/language/evento.langium`

```ts
grammar Evento
```

grammar entry point means the topmost level production that includes all other rules as a tree root:

```ts
entry Program: ( names+=ID | numbers+=INT )*;
```
- `()*` corresponds to 0+ times, so `Program` can be empty

also we should ignore all whitespace characters:

```ts
hidden terminal WS: /\s+/;
```

- grammar [[syntax/terminal|terminals]] means minimal language elements mostly defined as literal values or [[syntax/regular expression|regular expressions]]

Finally, we need to see two the most required language elements:
- alphanumeric identifiers
	- `\w` metacharacter matches word characters: `[a-zA-Z0-9_]`
	- so, anything starts with `_` or latin letter can point something with name

```ts
terminal ID: /[_a-zA-Z][\w_]*/;
```
- and simple integer numbers (we'll limit number types a while, WASM spec says `int` is enought for everything)
```ts
terminal INT returns number: /[+\-]?[0-9]+/;
```
- signed char is optional `?`
- followed by some decimal digits

Resulting grammar surprisingly looks like the first page of any book about the FORTH language:
- anything is a word,
	- looks like a group of any non-space characters, and
	- can do something is case the system known what action bound to this name (word exists in a vocabulary)
- besides signed integers numbers that looks like integers numbers

So, there is nothing else, besides maybe C-style comments to let us mark some code as ignored, and write some cool comments (as syntax so primitive and unreadable that we can't understand our FORTH code even after few days later).

![[E/comment]]

If you still want FORTH, the parentheses for stack effects can be used:
```ts
hidden terminal FORTH_COMMENT: /\([\s\S]*\)/;
```

Time to check:
```shell
npm run langium:generate
```
```
> evento@0.0.1 langium:generate
> langium generate

Reading config from /home/dponyatov/E/evento/langium-config.json
Writing generated files to /home/dponyatov/E/evento/src/language/generated
Writing textmate grammar to /home/dponyatov/E/evento/syntaxes/evento.tmLanguage.json
Writing monarch grammar to /home/dponyatov/E/evento/src/syntaxes/evento.monarch.ts
[23:45:32] Langium generator finished successfully in 545ms
```