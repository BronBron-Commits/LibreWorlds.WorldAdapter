# LibreWorlds.WorldAdapter

This repository implements the **World Adapter** that bridges the LibreWorlds SDK with a native world engine. Its role is to translate world state from the protocol layer into engine-neutral world events.

The adapter defines a stable interface and marshals world state across a C# to Rust foreign function interface (FFI). It contains **no rendering logic, protocol logic, or engine-specific code**.

## Purpose

The World Adapter takes decoded world facts from the LibreWorlds SDK — including object creation, updates, deletion, and terrain events — and converts them into calls that a native world engine can consume.

This design **decouples** the SDK from any particular rendering engine, allowing both layers to evolve independently.

This repository does **not** implement networking, authentication, rendering, camera systems, or asset downloading logic. Those concerns belong to other layers of the system.

## Architecture Overview

```
World Server
       ↓ (delivers protocol data)
LibreWorlds SDK
       ↓ (emits world facts)
World Adapter (this repository)
       ↓ (forwards events via FFI)
Native World Engine (e.g., realmlib)
       ↓
Renderer / Host (Godot, Unity, custom engines, etc.)
```

This approach keeps the adapter as a **pure translation layer** with no engine assumptions.

## Responsibilities

**WorldAdapter is responsible for:**

- Defining an engine-agnostic interface for world events
- Bridging SDK world state to engine calls without leaking SDK types
- Marshaling data via a stable FFI boundary between C# and Rust
- Forwarding world events based on in-memory data

**It is not responsible for:**

- Network protocols or login logic
- Asset downloading, caching, or file path resolution
- Mesh, terrain, or render logic
- UI, camera systems, or gameplay systems

## Current Status

- The adapter interface is implemented in C#
- The FFI boundary to Rust has been proven to work
- Initial functions such as initialization and object addition are in place
- DLL loading and native invocation are proven with test hosts
- Real engine integration and rendering remain pending upstream implementation

## Usage

1. Clone the repository
2. Build the C# project using the .NET SDK
3. Ensure the accompanying `realmlib_ffi` native library is built and placed in the output directory

The adapter can then be incorporated into clients that need to drive world events into a native engine.

## Future Work

Once the native engine (such as `realmlib`) implements full world semantics, this adapter will be expanded to handle:

- Additional world events
- Object transforms
- Terrain updates
- And more

The adapter interface is designed to remain **stable** to avoid coupling engine evolution with SDK logic.

## Related Projects

- [realmlib-ffi](https://github.com/BronBron-Commits/realmlib-ffi) – FFI wrapper providing the native Rust backend
- realmlib – Core Rust world/engine logic (upstream)

## License

MIT License – chosen for maximum compatibility across engines and platforms.
