# Keywords

- Reserved words with special meaning in the language
- all are lowercased (and case-sensitive)
- cannot be used as [[E/Identifiers|Identifiers]]
- cannot be redefined or shadowed

## [[E/Variable|Variable]]

- [[E/let|let]] - declares an immutable variable
- [[E/mut|mut]] - declares a mutable variable
- [[E/const|const]] - declares a compile-time constant

## [[E/Control Flow|Control Flow]]

- [[E/Conditional Branching|Conditional Branching]]
	- [[E/if|if]] - conditional statement
	- [[E/else|else]] - alternative branch
- [[E/Pattern Matching|Pattern Matching]]
	- [[E/match|match]] - pattern matching expression
- [[E/Loops|Loops]]
	- [[E/loop|loop]] - infinite loop
	- [[E/for|for]] - iteration loop
	- [[E/while|while]] - preconditional loop
	- [[E/do|do]] [[E/until|until]] - postcondition loop
- [[E/Control Transfer|Control Transfer]]
	- [[E/break|break]] - exit loop
	- [[E/continue|continue]] - skip to next iteration
	- [[E/return|return]] - exit function with optional value

## [[E/Functions|Functions]]

- [[E/fn|fn]] - function declaration
- [[E/async]] [[E/await]] - asynchronous function
- [[E/yield]] - generator function control

## [[E/Error Handling|Error Handling]]

- [[E/try|try]] - error handling block
- [[E/catch|catch]] - error handler
- [[E/raise|raise]] - raise exception
- [[E/panic|panic]] - unrecoverable error

## [[E/Types|Types]]

- [[E/struct|struct]] - define a structure
- [[E/enum|enum]] - define an enumeration
- [[E/type|type]] - type alias
- [[E/impl|impl]] - implement [[E/trait|trait]] functionality

## [[E/Concurrency|Concurrency]]

- [[E/spawn|spawn]] - create new thread (process)
- [[E/atomic|atomic]] - atomic operation
- [[E/lock|lock]] - mutual exclusion
- [[E/channel|channel]] - inter-thread communication

## [[E/Modules|Modules]]

- [[E/module|module]] - define module namespace
- [[E/use|use]] - import module
- [[E/export|export]] - make item publicly accessible

## [[E/Memory Management]]

- [[E/new|new]] - heap allocation
- [[E/drop|drop]] - explicit deallocation
- [[E/move|move]] - transfer ownership
