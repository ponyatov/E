# pipe [[Operators]]

![[pipe sample code]]

`a |> func(b,..)` replaces `func(a,b,..)`

## Key Changes:

1. **Pipeline Stages**  
    Each transformation becomes a clear step:

```rust
read() |> preprocess() |> send!()
```
    
2. **Emphasized Dataflow**  
    The `|>` operator visually chains operations left-to-right.
    
3. **Retained Actor Semantics**  
    Side-effecting operations (`send!`, `print!`) remain at the end of pipelines.

## Benefits for Embedded Systems:

- **Explicit data transformation path** (helps optimize memory usage)
    
- **No intermediate variables** (reduces stack usage)
    
- **Readable sequencing** (critical for distributed logic)

![[Error handling in pipelines]]
