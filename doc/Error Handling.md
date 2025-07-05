# Error Handling

## [[E/Exception|Exception]]

- [[E/try|try]] - error handling block
- [[E/catch|catch]] - error handler
- [[E/raise|raise]] - raise exception
- [[E/panic|panic]] - unrecoverable error

## Error [[E/Types|Types]]

- [[E/Option|Option]] Represents an optional value that may or may not exist.
	- [[E/Some|Some]] Contains a valid value.
	- [[E/None|None]] No value exists.
- [[E/Result|Result]] Represents success or failure
	- [[E/Ok|Ok]] Successful computation with a `value:T`.
	- [[E/Error|Error]] Contains an `error:E` description.
- `?` suffix operator at end of expression
	- unpacks `Some(x)` and `Ok(x)` values
	- raises [[E/Exception|Exceptions]] in case of `Error`/`None`
	- [[E/panic|panics]]
