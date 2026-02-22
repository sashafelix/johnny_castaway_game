# Architecture

## Game Loop

```
Awake  →  Boot  →  Run  ←→  Pause
                    ↓
                   Exit
```

`GameRoot` owns the state machine and runs inside `SampleScene` (bootstrap scene). On `Awake` it creates and wires all services. On `Start` it transitions from `Boot → Run`. `Escape` toggles pause; `Application.Quit()` handles `Exit`.

## Services

| Interface   | Responsibility                                   | Implemented in |
|-------------|--------------------------------------------------|----------------|
| `IRng`      | Seeded, deterministic RNG                        | M1             |
| `ITickSim`  | Advance simulation one tick given `RunData`      | M1             |
| `ISave`     | Persist/restore `SaveData` to disk               | M1             |
| `IWorldGen` | Generate `WorldData` from a seed                 | M1             |

Services are null in M0 (stubs). Wire real implementations in `GameRoot.Awake()`.

## State Models

| Class        | Contains                                      |
|--------------|-----------------------------------------------|
| `PlayerData` | playerId, resource floats (food/wood/stone)   |
| `WorldData`  | seed, biomeId                                 |
| `RunData`    | tick counter, PlayerData, WorldData           |
| `SaveData`   | schemaVersion, RunData                        |

## ID Strategy

All content uses **string IDs** in `category.name` format:

```
resource.food       biome.tropical      building.shelter
resource.wood       biome.storm-belt    event.storm-warning
resource.stone      biome.volcanic      upgrade.better-axe
```

String IDs are stable across schema versions, readable in save files, and safe to log.

## Config Format

Runtime config uses **ScriptableObjects** (`GameConfigSO`).
Create instances via `Assets → Create → JohnnyGame → Game Config`.
Reference the SO from `GameRoot` to tune values without recompiling.

## Save Schema Versioning

`SaveData.CurrentVersion` is the authoritative schema version (`const int = 0`).
When the schema changes:
1. Bump `CurrentVersion`
2. Implement `ISaveMigration` (from/to versions + `Migrate()` method)
3. Register in the save service's migration chain

`SaveMigrationV0` is a no-op stub that documents the pattern.

## Namespaces

| Namespace            | Folder              | Contents                          |
|----------------------|---------------------|-----------------------------------|
| `JohnnyGame.Core`    | Scripts/Core/       | GameRoot, GameState, interfaces   |
| `JohnnyGame.Data`    | Scripts/Data/       | State models, SaveData, config SO |
| `JohnnyGame.Debugging` | Scripts/Debug/    | GameLogger, StateSnapshot         |
| `JohnnyGame.UI`      | Scripts/UI/         | DevHUD                            |
