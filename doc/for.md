# for
## loop over iterators

- Iterates over a range `0..10` or [[E/collection]]
```evento
for <var> in <iterator> {}

for i in 0..10 { print i }
```
- can be index-counted with optional start index value (default =0)
```evento
for <index>,<var> in <iterator>.count [0|1] {}

for i,c in 'string'.count 1 { print '{i}: {c}' }
```
