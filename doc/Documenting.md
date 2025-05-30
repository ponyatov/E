# Documenting
## docstring

```evento
//  Documentation comment: doxygen-like
/// @brief Computes temperature in Celsius.
/// @param[in] adc_value`i12 differential ADC input
/// @hw[STM32] Requires clock enabled first
/// @hw[ESP32] Pullups enabled by default
fn to_celsius adc_value`i12 = ... 
```
- `@brief` short-line description
- `@param` function parameters: ``name`type description``
- `@hw[name,..]` hardware-specific details
	- `@hw[STM32]` hardware group
	- `@hw[f429disco]` concrete board
	- `@cpu[stm32f3,stm32f4]` partial names separated with comma
	- `@arch[xtensa/riscv]` architecture subgroup
	- `@os[linux]`
- `@cfg[arch=i386,os=linux]` comment specific for build config features
