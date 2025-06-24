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

open System.IO

/// generate `hw/` subdirs
let hw_ () =
    Directory.CreateDirectory($"hw/src")
    Directory.CreateDirectory($"hw/inc")

    File.WriteAllText(
        "hw/inc/hw.hpp",
        "
/// @defgroup hw hw

/// @defgroup x86 x86
/// @ingroup hw

/// @defgroup rpi rpi
/// @ingroup hw

/// @defgroup stm32 stm32
/// @ingroup hw

/// @defgroup esp esp
/// @ingroup hw
"
    )

let hw (from: HW) =
    let d =
        match from with
        | X86 x ->
            match x with
            | PC -> "pc"
            | QEMU386 -> "qemu386"
        | _ -> failwith $"{from}"

    Directory.CreateDirectory($"hw/{d}/src") |> ignore
    Directory.CreateDirectory($"hw/{d}/inc") |> ignore
    File.WriteAllText($"hw/{d}/inc/{d}.hpp", "") |> ignore
    File.WriteAllText($"hw/{d}/src/{d}.cpp", "") |> ignore
    File.WriteAllText($"hw/{d}/{d}.mk", "") |> ignore
    File.WriteAllText($"hw/{d}/{d}.cmake", "") |> ignore

hw (X86 PC)

type STM32 =
    | F030F6P6
    | F103C8T6
    | F429ZIT6

type CPU =
    | I5
    | STM32 of STM32
    | LX106

type CortexM =
    | CortexM3
    | CortexM4

type ARCH =
    | X86_64
    | I386
    | CortexM of CortexM
    | Xtensa

type OS =
    | Linux
    | BareMetal
    | FreeRTOS

type Target =
    | HW of HW
    | CPU of CPU
    | ARCH of ARCH
    | OS of OS
