# measurement units

- Unit Annotation: Use angle brackets (`< >`) to attach units
```E
let distance = 5.0<m>      // 5 meters
let speed = 20.0<m/s>      // 20 meters per second
```
- Custom Units
```E
measure kg
measure N = kg * m / s^2  // Newtons
```
- Preserve unit safety in functions & expressions:
```E
let add (x: float<'u>) (y: float<'u>) = x + y  // Ensures same units
```

## time [[E/period|period]]

## data size & bit speed

- UART
	- `baud`
- `B` Bytes `buffer:[u32;256]`
- `K` Kilobytes `SDRAM:[u8;192K]`
	- `kbit`
- `M` Megabytes `let XRAM = 8M`
	- `mbit`
- `G` Gigabytes
	- `gbit`

## metric

- `m` meters
	- `km` kilometers
	- `cm` cantimeters
	- `mm` millimeters
- `in` inch
	- `mil` 1/100 inch (PCB design)

## graphic

- `px` pixels
- `pt` points (font size)

## weight

- `g` gramm
	- `mg` milligramm
	- `kg` kilogramm
