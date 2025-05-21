# flow variable

**Data[[flow variable]]s** are a programming construct used in **concurrent** and **parallel programming**, where variables are bound to values _asynchronously_ and automatically trigger computations when their values become available. They are a key feature in **dataflow programming** and are designed to simplify synchronization in distributed or parallel systems.

- Dataflow variables (automatically propagate changes).  
- Threads waiting on variable **pause** until the variable gets a next value: [[flow variable]] looks like a named channel

## **How Dataflow Variables Work**

- **Unbound** → No value yet (threads block if they try to read it).
- **Bound** → Value is set (all waiting threads resume).

```
flow X               // unbound dataflow variable
                     // (looks like named async channel)
thread X = 42        // sender makes var bound to 42
thread print "X={X}" // waits until X become
```

- In Elixir-like language it can be be rewritten as:

```elixir
# Create a dataflow-like variable (Agent)
{:ok, x} = Agent.start_link(fn -> nil end)  # Unbound state
```
```elixir
# Thread 1: Binds the value (like X = 42)
spawn(fn ->
	Agent.update(x, fn _ -> 42 end)  # Bind X to 42
end)
```
```elixir
# Thread 2: Waits and reads (like print "X={X}")
spawn(fn ->
  # Poll until value is bound (not ideal, but simulates blocking)
  value = 
    Enum.reduce_while(1..100, nil, fn _, _ ->
      case Agent.get(x, & &1) do
        nil -> {:cont, nil}          # Keep waiting
        val -> {:halt, val}          # Got value!
      end
    end)
  
  IO.puts("X=#{value}")
end)
```
- The same with Task:
```elixir
# Simulate a dataflow variable with a Task
x_task = Task.async(fn ->
  receive do
    {:bind, value} -> value  # Waits until someone sends a value
  end
end)

# Thread 1: Binds the value
spawn(fn ->
  send(x_task.pid, {:bind, 42})
end)

# Thread 2: Awaits and prints
spawn(fn ->
  x = Task.await(x_task)  # Blocks until x is bound
  IO.puts("X=#{x}")
end)
```

### **Key Differences from True Dataflow Variables**

1. **[[Elixir]] is async message-passing-based**, so we simulate blocking with `Task.await` or polling.
2. **No native single-assignment** – you must enforce immutability manually.
3. **Processes are cheap**, so this pattern is still practical.
