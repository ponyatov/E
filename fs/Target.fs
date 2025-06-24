//! cross: target systems specification
//! (cross-compiler project template & config options)

/// x86 PC variants
type X86 =
    | PC
    | QEMU386

/// Raspberry Pi variants
type RPi =
    | RPi3
    | RPi4
    | RPi5
    | Orange800

/// Cortex-M
type Pill =
    | PillF030
    | PillF103

/// STM32DISCOVERY*
type Discovery =
    | F4DISCO
    | F429DISCO

/// ESP variants
type ESP =
    | ESP8266
    | ESP32
    | ESP32C6

/// HardWare
type HW =
    | X86 of X86
    | RPi of RPi
    | Pill of Pill
    | Discovery of Discovery
    | IskraJS
    | ESP of ESP

type STM32 =
    | STM32F030F6P6
    | STM32F103C8T6
    | stm32f429ZIT6

type CPU =
    | I5
    | STM32 of STM32

type CortexM =
    | CortexM3
    | CortexM4

type ARCH =
    | X86_64
    | I386
    | CortexM of CortexM

type OS =
    | Linux
    | BareMetal
    | FreeRTOS

type Target =
    | HW of HW
    | CPU of string
    | ARCH of string
    | OS of OS
