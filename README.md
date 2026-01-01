\# LibreWorlds World Adapter



This repository provides a language-agnostic \*\*world adapter\*\* between

LibreWorlds SDK (C#) and realmlib (Rust).



\## Purpose



\- Decouple AW-style protocol logic from rendering

\- Feed decoded world state into a modern engine

\- Maintain a clean C# ↔ Rust boundary via FFI

\- Support Godot / VR / future engines without rewriting protocol code



\## Architecture



LibreWorlds SDK → World Adapter (C#) → realmlib FFI (Rust) → Engine



\## Status



\- ✅ World adapter implemented

\- ✅ C# → Rust FFI working

\- ⏳ realmlib world state integration

\- ⏳ RWX parsing and rendering

\- ⏳ Godot host



\## Non-Goals



\- Netcode

\- Authentication

\- Asset download policy

\- UI / HUD



Those remain the responsibility of the client.



