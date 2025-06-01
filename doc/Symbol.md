# `sym`
## Symbol

```langium
terminal ID: /[_a-zA-Z][_a-zA-Z0-9]*/;
terminal SYM: '#' ID;
```

```PLY
def t_SYM(t):
    r'\#[_a-zA-Z][_a-zA-Z0-9]*'
    t.value = Sym(t.value); return t
```

```evento
const Sym = #Bol;
```

```cpp
extern const char*   Sym        ;
const char*   Sym         = "#Bol";
```
