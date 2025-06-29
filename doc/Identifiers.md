# Identifiers

- regexp: `[_a-zA-Z][_a-zA-Z0-9]*`
	- must begin with a letter or underscore
	- optionally followed by letters, digits, or underscores
- limited to ASCII range for portability
- case-sensitive (e.g., `myVar` != `myvar`)
- must not conflict with [[E/E|E]] language reserved [[E/Keywords|Keywords]]
- unstrictly preferred:
	- [[E/const|const]]: all uppercase, screaming snake case
	- [[E/let|let]]/[[E/mut|mut]]: all lowercase, snake-case
	- type names: first uppercase latter, camel-case
