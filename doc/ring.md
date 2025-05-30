# ring
## FIFO

```evento
let ring_ADC_buffer`(u12;8)
```

- uses narrow index (arbitrary bits unsigned [[E/Integer|Integer]])
- size must be power of 2
	- read/write indexes autoincremented with `idx = (idx+1) & mask`
	- where `mask = 0b00000111` number of 1s relates to ring size
