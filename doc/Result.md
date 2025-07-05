# Result

- [[E/Ok|Ok]] (T)
	- Successful computation with a `value:T`.
- [[E/Error|Error]] (E)
	- Contains an `error:E` description.

```E
// example: file reading
fn read_file path -> Result<string, string> =
    if file_exists(path) then
        Ok file_read(path)
    else
        Error "File not found: {path}"

match read_file "config.txt" with
| Ok content => parse_config content
| Error msg  => log_error msg 
```
