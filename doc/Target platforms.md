# Target platforms

## **Tier 1: Primary Bare-Metal Targets**

_(Full RTOS features, no dependencies, certified toolchains)_

### **1. ARM Cortex-M Series**

- **Cortex-M0/M0+** (STM32F0)
    - Example: `ec --target arm-none-eabi --hw pillF030 --cpu stm32f030f4p`
        
- **Cortex-M4/M7** (STM32F4)
    - DSP extensions, FPU, 150MHz+
    - Example: `ec --target arm-none-eabihf --hw f429disco --cpu stm32f429zit --feature lcd`

### **2. Classic ESP**
- ESP8266
- ESP32
	- `ec --target xtensa-lx106 --hw esp32`

### **3. RISC-V MCUs**

- **ESP32-C3/C6** (WiFi/BLE, 160MHz)
    - Example: `ec --target riscv32-esp-elf --hw esp32c6 --feature ble,lcd`

## **Tier 2: Embedded Linux**

_(POSIX compatibility, reduced determinism)_

### **1. Single-Board Computers**

- **Raspberry Pi** (ARMv7/aarch64)
	- original (rpi3, rpi4, rpi5, cm4, cm5)
	- Orange Pi series (opiOne, opi800)
- **x86 Embedded**
	- retro notebooks (arch:i386, cpu:i486..i686)
		- `ec --target i486-pc-elf --archi386 --cpu i486 --os none`
	- PC104 (Intel Atom, AMD G-Series)
		- `ec --cpu vortex86 --os linux`

### **2. Networked Devices**

- **Wireless Routers & Gateways** (Ethernet + BLE/WiFi)
- IoT Edge devices

### **3. Servers and Workstations**
- x86_64 (Linux, Windows)
- VDS & cloud instances

## **Tier 3: Experimental/Research**

- **ESP-nodes Mesh Networks**
- **LoRaWAN Endpoints**
- Arduino & AVR 8 bit (ATmega)
- WASM
