# pipe operator

```rust
// Distributed temperature monitor with pipe operators
actor SensorNode {
    let sensor      = TempSensor(PIN0);
    let server_addr = 0x42;

    on init() {
        loop {
            sensor.read()
                |> scale_to_celsius()      // Preprocess
                |> round_to_decimal(1)    // Transform
                |> send!(server_addr);    // Action
            
            sleep!(1s);
        }
    }
}
```
```rust
actor ServerNode {
    on receive(data: f32) {
        data 
            |> format!("Temp: {:.1}C")    // Formatting
            |> print!();                 // Side effect
    }
}
```
