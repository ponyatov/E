# Error Handling

## [[E/Exception|Exception]]

- [[E/try|try]] - error handling block
- [[E/catch|catch]] - error handler
- [[E/throw|throw]] - raise exception
- [[E/panic|panic]] - unrecoverable error

## [[E/Types|Types]]

- [[E/Result|Result]]
	- [[E/Ok|Ok]]
	- [[E/Error|Error]]
- [[E/Option|Option]]
	- [[E/Some|Some]]
	- [[E/None|None]]
- `?` suffix operator at end of expression
	- unpacks `Some(x)` and `Ok(x)` values
	- raises [[E/Exception|Exceptions]] in case of `Error`/`None`
