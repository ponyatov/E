# Canadian Cross [[compiler/cross-compiler|cross-compiler]]

The [[Canadian Cross]] is a technique for building cross compilers for machines/architectures too much slower or less convenient to build cross-compiler itself.

Given three [[target triplet]]s A, B, and C, 
- [[E/BUILD|BUILD]]: A
	- one uses powerful build server or developer's machine A
		- (e.g. running Linux on an modern processor)
- [[E/HOST|HOST]]: B
	- to build a [[compiler/cross-compiler|cross-compiler]] that runs on machine B 
		- (e.g. [[Raspberry Pi]] or retro-class notebook running [[Windows#XP]])
- [[E/TARGET|TARGET]]: C
	- to create firmwares for machine C
		- (e.g. [[esp/ESP8266|ESP8266]]/[[esp/ESP32|ESP32]] & Cortex-M microcontrollers)
