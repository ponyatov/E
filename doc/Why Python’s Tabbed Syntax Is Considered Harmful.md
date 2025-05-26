# Why Python’s Tabbed Syntax Is Considered Harmful?

The previous code sample in tabbed syntax can look like almost ideal:
- no any [[syntax/noise]] symbols
- syntax-forced structural alignment

```python
actor ADC:

	let mode  = StartStop
	mut delta = 0.0

	on signal change:
	    if change > 0.1 | delta > 0.2:
		    read sensor |> scale celsius |> send! SERVER
		else:
			delta += change
```

1. **Inconsistency Across Editors and Tools**:
    - **Issue**: [[Python]] relies on consistent indentation (spaces or tabs, typically 4 spaces), but different editors or IDEs may handle tabs and spaces inconsistently. Mixing tabs and spaces can lead to [[IndentationError]] or subtle bugs, especially in collaborative projects.
    - **Example**: Copying code from a website or text editor with different tab settings can break a Python script.
    - **Criticism**: This fragility makes Python code less portable across environments, requiring strict editor configuration (e.g., [[PEP#8]] recommends spaces only).
