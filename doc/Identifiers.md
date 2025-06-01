# Identifiers

names for variables, functions, actors, etc.
- Start with a letter (`a-z`, `A-Z`) or underscore `_`
- Subsequent characters can include letters, digits (`0-9`), and underscores.
- UTF-8 and national symbols prohibited for portability and MISRA/SIL compliance

```langium
terminal ID: /[_a-zA-Z][_a-zA-Z0-9]*/;
```

```PLY
def t_ID(t):
    r'[_a-zA-Z][_a-zA-Z0-9]*'
    t.value = Id(t.value); return t
```
