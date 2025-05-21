```rust
// Distributed temperature monitor with pipe operators

const SERVER = MeshId(0x42)

actor SensorNode<S:TempSensor,P:Protocol> {

	let sensor      = S(P(PIN0));
    let server_addr = SERVER;

    on init() {
        loop {
            sensor.read()
                |> scale_to_celsius()     // Preprocess
                |> round_to_decimal(1)    // Transform
                |> send!(server_addr);    // Action
            
            sleep!(1s);
        }
    }
}

actor ServerNode {
    on receive(data: f32) {
        data 
            |> format!("Temp: {:.1}C")   // Formatting
            |> print!();                 // Side effect
    }
}
```
