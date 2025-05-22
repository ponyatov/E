# Langium
## [[Language Workbench]]

https://langium.org/

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
### 1. [[Yeoman#install]]
```shell
npm i yo generator-langium
```
### 2. Scaffold a Langium project

```shell
./node_modules/.bin/yo langium
```
- [[vscode/extensions|extensions]] name: evento
	- Will be used as the folder name of your extension and its `package.json`
- Your language name: Evento
- File extensions: .e
- Include VSCode extension? Y
- Include CLI? Y
	- add REPL
- Include Web worker? y
	- You can run the language server in your web browser.
- Include language tests? Yes
	- You can add the setup for language tests using [[Vitest]].

## build

```shell
tsc -b tsconfig.src.json && node esbuild.mjs
```

[[ts/TypeScript]]
[[ts/minimal project]]
