# Evento
## programming language prototype

> - for distributed programs 
> - for embedded systems ([[hw/microcontroller|microcontroller]]s)
> - mixes Rust, Elixir and F# most yummy features

read this files from given URLs:
- language overview:
	- [Design goals](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FDesign%20goals.md)
	- [Core paradigms](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FCore%20paradigms.md)
	- [Target platforms](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FTarget%20platforms.md)
- Lexical Structure:
	- [Comments](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FComments.md)
	- Literals:
		- [Integer](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FInteger.md)
		- [Float](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FFloat.md)
		- [Bool](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FBool.md)
		- [String](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FString.md)
		- [Symbol](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FSymbol.md)
	- [Identifiers](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FIdentifiers.md)
	- [Keywords](https://gitflic.ru/project/dponyatov/e/blob/raw?file=doc%2FKeywords.md)

- grammar: 
	- [Langium grammar](https://gitflic.ru/project/dponyatov/e/blob/raw?file=evento%2Fsrc%2Flanguage%2Fevento.langium)
	- [PLY lexer](https://gitflic.ru/project/dponyatov/e/blob/raw?file=lib%2Fevento%2Flexer.py)
	- [PLY parser](https://gitflic.ru/project/dponyatov/e/blob/raw?file=lib%2Fevento%2Fparser.py)

- [VSCode syntax highlight](https://gitflic.ru/project/dponyatov/e/blob/raw?file=evento%2Fsyntaxes%2Fevento.tmLanguage.json)

- sample code
	- [Evento](https://gitflic.ru/project/dponyatov/e/blob/raw?file=lib%2Flib%2Fevento.e)
	- compiled target code in C (C++):
		- [header](https://gitflic.ru/project/dponyatov/e/blob/raw?file=lib%2Finc%2Fevento.hpp)
		- [source code](https://gitflic.ru/project/dponyatov/e/blob/raw?file=lib%2Fsrc%2Fevento.cpp)
