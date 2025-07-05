# Exception

- [[E/try|try]] - error handling block
- [[E/catch|catch]] - error handler
- [[E/raise|raise]] - raise exception
- [[E/panic|panic]] - unrecoverable error

While [[E/E|E]]
- prefers `Result`/`Option` in small amount of code (functions),
- it uses exceptions for error processing in larger components (threads, nodes)

## [[E/raise|raise]]

```E
fn connect_device addr -> bool =
    if ! validate addr then
        throw Error.InvalidAddress(addr)
    else
        let conection = async connect(addr)
        await connection
```

## [[E/try|try]]/[[E/catch|catch]]

```E
try
	let remote = connect_device "192.168.1.100"
    log @"Connected: {remote}"
| catch Error.InvalidAddress addr =>
    log @"Invalid address: {addr}"
| catch _ =>
    log "Unknown error occurred!"
```
