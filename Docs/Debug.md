# Debug Tools

## DevHUD

An IMGUI overlay that shows live game state and exposes quick debug actions.

**Setup:** Add `DevHUD` MonoBehaviour to a GameObject in the Bootstrap scene alongside `GameRoot`.

| Key / Control       | Action                               |
|---------------------|--------------------------------------|
| `` ` `` (backtick)  | Toggle HUD visibility                |
| F5 / "Manual Tick"  | Fire one simulation tick             |
| F6 / "Dump State"   | Print a state snapshot to the console|
| Escape              | Toggle Pause state                   |

The HUD displays: `State`, `Tick`, `Seed`, `Resources` (resources show `—` until M1 data flows through).

---

## GameLogger

`GameLogger` (in `JohnnyGame.Debugging`) wraps `Debug.Log` with a category prefix so logs are easy to filter in the Unity Console.

```csharp
// Usage:
GameLogger.Log(GameLogger.Category.Core, "GameRoot awakened.");
GameLogger.LogWarning(GameLogger.Category.Sim, "Tick delta is large.");
GameLogger.LogError(GameLogger.Category.Save, "Save file corrupt.");
```

**Categories:**

| Category   | Tag        | Use for                          |
|------------|------------|----------------------------------|
| `Core`     | `[Core]`   | Boot, state transitions, services|
| `Sim`      | `[Sim]`    | Tick loop, resources, hazards    |
| `Save`     | `[Save]`   | Save / load operations           |
| `UI`       | `[UI]`     | HUD, panels, toasts              |
| `WorldGen` | `[WorldGen]` | Island generation              |

Filter by tag in the Console search box (e.g. type `[Sim]` to see only simulation logs).

Do **not** use raw `Debug.Log` in game code — always go through `GameLogger`.

---

## StateSnapshot

`StateSnapshot.Dump(GameRoot root)` prints a formatted block to the console showing the current state, tick, and seed. Trigger it via:

- **F6** in Play Mode
- The **"Dump State"** button in the DevHUD
- `gameRoot.DumpState()` from any script

Example output:
```
[Core] === STATE SNAPSHOT ===
State : Run
Tick  : 42
Seed  : 0
======================
```
