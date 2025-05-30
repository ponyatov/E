# bitfield

`[ui]1..64` besides [[E/Integer|Integers]]

```evento
struct Name`type [little|big] {
  _: u1     // padding
  name`u2   // bits 15..13
  mode`u3   // bits 2..0
}
```
- special type for [[E/struct|struct]]
- analog to [[E/Integer|Integers]] with arbitrary bits count

