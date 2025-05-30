# watch
## [[E/GPIO|GPIO]]

## pin change

```evento
enum Edge { Rising Falling Both }
enum WatcherStatus { Active Pause Error }
class Watcher { fn start ; fn stop ; fn status -> WatcherStatus }

let button_w'Watcher =
	watch pin`Pin repeat`bool:false edge`Edge:both debounce`u8:0 { 
		/* action code */
}
```
- optional parameters: repeat, edge, debounce
- optional `button_w` watcher object

```bnf
repeat: true | false
```
- Keep watching after first event (default: `false`)

```bnf
edge: rising | falling | both
```
- Trigger on 'rising', 'falling', or 'both' edges (default: `both`)

```bnf
debounce`u8:0 // milliseconds
```
- default:0 (don't use debounce)

## Recommended Debounce Delays

|Application|Debounce Delay|Notes|
|---|---|---|
|**Tactile buttons**|10-50 ms|Most common range for PCB-mounted push buttons|
|**Mechanical relays**|5-20 ms|Fast contacts with minimal bounce|
|**Rotary encoders**|1-5 ms|Requires faster response for accurate counting|
|**Membrane keypads**|20-100 ms|Longer delays for flexible contacts|
|**Industrial switches**|50-200 ms|Heavy-duty switches with significant bounce|

[[Espruino]] code:
```js
// Optimal for most tactile buttons
setWatch(function(e) {
  console.log("Button pressed");
}, BTN1, {
  edge: 'rising',
  debounce: 25,  // 25ms is a safe default
  repeat: true
});
```

the same [[Evento]] code:
```evento
watch BTN1 repeat:true edge:rising debounce:25 { "Button pressed" |> log }
```
