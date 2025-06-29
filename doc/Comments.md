# Comments

> Syntax for single-line and multi-line comments

- **Purpose**:
    - Documentation (e.g., function headers, TODOs).
	    - [[E/code documenting|code documenting]]
	    - local comments not exports to documentation
    - Debugging (temporarily disabling code).
    - Metadata (shebang for scripts, etc).
- **Whitespace Handling**:
    - Indentation is **not significant** (unlike Python), avoiding issues with mixed tabs/spaces.
- **Autoformatting**:
    - The toolchain includes an [[E/autoformat|autoformatter]] to standardize comment placement and style.

![[shebang]]

## line comment

- Use `//` for single-line comments.

```E
// This is a single-line comment
let x = 10;  // Explanation for variable
```

## block comment

- Use `/* ... */` for block comments.

```E
/*
This is a multi-line comment.
It can span multiple lines.
*/
```

## [[E/code documenting|code documenting]]
