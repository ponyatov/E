# [[Evento]] reference implementation in [[Fsh|F#]]

Evento language is defined as a reference implementation written in F#, and structured as a minimal interpreter that demonstrates the language's core features: actors, ownership, pipelining, and hardware interaction. This implementation focuses on semantics and ease of changes rather than performance. Also it does not include real embedded cross-targets such as [[hw/arch/Cortex-M|Cortex-M]], [[hw/ESP32|ESP32]] and [[RISC-V]] as its goal is making a balanced language prototype not a production compiler. So, the only one target is Linux and generic C/C++ code generation for testing purposes.

## Limited types
