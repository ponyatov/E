# unsafe

- unsafe [[E/Code Block|Code Block]]

```E
unsafe {
    // Bypass type/memory safety
    let ptr = raw_address as *mut u8
    *ptr = 0xFF
}
```

- bypass some language safety for code requires direct hardware access
- or in same cases where type check unable to infer code safety in automatic manner
