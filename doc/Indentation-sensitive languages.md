# Indentation-sensitive languages
## [[Langium]]

https://langium.org/docs/recipes/lexing/indentation-sensitive-languages/

Some programming languages (such as Python, Haskell, and YAML) use indentation to denote nesting, as opposed to special non-whitespace tokens (such as `{` and `}` in C++/JavaScript). This can be difficult to express in the [[syntax/EBNF]] notation used for defining a language grammar in [[Langium]], which is context-free. To achieve that, you can make use of synthetic tokens in the grammar which you would then redefine in a custom token builder.

Starting with Langium 3.2.0, such [[token builder]] (and an accompanying [[lexer]]) are provided for easy plugging into your language. They work by modifying the underlying token type generated for your indentation terminal tokens to use a custom matcher function instead that has access to more context than simple Regular Expressions, allowing it to store state and detect _changes_ in indentation levels.
