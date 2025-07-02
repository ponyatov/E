# Function signature matching

[[E/E|E]]'s pattern matching capabilities extend deeply into function signatures, making it one of the language's most powerful features. This language feature is not so known, and available only in the [[Elixir]] language, and it's [[Erlang]] predecessor.

Multiple functions with the same name can have multiple clauses that are distinguished by pattern matching on their arguments and return type: arguments and return types forms an entity called [[function signature]].

Comparing to most known programming languages, [[function signature]] in [[E/E|E]] also includes
- match patterns as arguments, that limit function application only on arguments, that matches that patterns
- function guard [[E/when|when]] keyword, followed by logic predicate, that do arbitrary prechecks before function application:
	- predicate is an expression that returns `true`/`false`
		- unlike [[Elixir]], there are no restrictions on function guards, and
		- there is no requirement for the guard to be a pure function.
	- function will run only in case of guard returns `true`
	- if guard returns `false`, the signature matching will be continued to find the next suitable function
