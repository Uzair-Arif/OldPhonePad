# OldPhonePad Interpreter

A C# console application that simulates the behavior of an old mobile phone keypad. Given a string input (e.g., `4433555 555666#`), it decodes the sequence into human-readable text (e.g., `HELLO`).

---

## Technologies

- .NET 8
- C#
- xUnit (for unit testing)

---

## Features

- Multi-press keypad decoding
- Pause (`' '`) support for same-button inputs
- Backspace handling (`'*'`)
- Auto-truncates invalid inputs
- Ends on send key (`'#'`)

---

## How to Run

```bash
dotnet run --project OldPhonePad.Console
```

---

## Run Unit Tests

```bash
dotnet test
```

---

## Example Inputs & Outputs

| Input              | Output  |
|--------------------|---------|
| 33#                | E       |
| 227*#              | B       |
| 4433555 555666#    | HELLO   |
| 8 88777444666*664# | TURING  |

---

## Internal Documentation

### Project Structure

```
OldPhonePad.Console/         --> Entry point (Program.cs)
OldPhonePad.Core/            --> Business logic and service interfaces
├── Interfaces/              --> IKeyMapProvider, IOldPhoneInterpreter
├── Services/                --> OldPhoneInterpreter, OldPhoneKeyMap
OldPhonePad.Tests/           --> xUnit test cases for all scenarios
```

---

### Key Logic - OldPhoneInterpreter

- Uses a buffer to accumulate button presses (e.g., `222` → `C`)
- Flushes buffer on pause (`' '`), backspace (`'*'`), or end (`'#'`)
- Uses `IKeyMapProvider` to decouple character mappings from logic

---

### Unit Testing

- Implemented using xUnit
- Covers:
  - Single character inputs
  - Word phrases
  - Edge cases (`*`, invalid characters, empty string)
  - Backspace handling

---