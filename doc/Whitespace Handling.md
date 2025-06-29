# Whitespace Handling

The [[E/E|E]] programming language takes a pragmatic approach to whitespace handling, by using [[tabbed syntax]] as the readable variant of code formatting. The analisys of F#, OCaml and Rust syntax gives some inside that inforced code redability and avoiding [[syntax/noise]] is more important than some issues about [[Python]] syntax Considered Harmful.

- **Indentation is significant**
	- structural readability and [[syntax/noise]] avoiding is important
	- Indentation is used to denote code structure and enforcing clean and readable code
- **Line breaks can be optional**
	- but Statements can span multiple lines, or
	- can or be condensed with `;` delimiter
- **Whitespace is used to separate tokens**
	- Required between keywords/identifiers and operators
	- as a bit sparsed code can be readed more ease
- The pair of `{ }` curly parens prereserved for data structure literals formatting
- **Line Continuation**
	- Long expressions can be split across lines using backslash `\`
		- reserved for long line wrapping into classical 80 columns
		- also works for multiline strings
- **Trimming**
	- Leading/trailing whitespaces in lines and files is automatically removed
	- at least one space required between comment marker and its text
- **[[E/autoformat|autoformatter]]**
	- aligns adjacent comment blocks for consistency
	- aligns code and data structures fragments in multiline code if this alignment can be inferred from types and structural data metainformation (string start/end markers, data delimiters, matrix layout, etc) 

![[tabbed syntax]]
