using UnityEngine;
using JohnnyGame.Data;
using JohnnyGame.Debugging;

namespace JohnnyGame.Core
{
    /// <summary>
    /// Entry point and composition root. Owns the game state machine and wires
    /// all services together. Add this MonoBehaviour to the Bootstrap scene.
    /// </summary>
    [DefaultExecutionOrder(-100)]
    public sealed class GameRoot : MonoBehaviour
    {
        // Services — implementations injected in M1.
        private IRng _rng;
        private ITickSim _tickSim;
        private ISave _save;
        private IWorldGen _worldGen;

        private GameState _state = GameState.Boot;
        private int _tick;

        // ── Unity lifecycle ────────────────────────────────────────────────

        private void Awake()
        {
            // Composition root: wire service implementations here.
            // TODO M1: replace nulls with SeededRng, TickSimulator, JsonSave, IslandGen.
            _rng      = null;
            _tickSim  = null;
            _save     = null;
            _worldGen = null;

            GameLogger.Log(GameLogger.Category.Core, "GameRoot awakened.");
        }

        private void Start()
        {
            TransitionTo(GameState.Run);
        }

        private void Update()
        {
            if (_state != GameState.Run) return;

            if (Input.GetKeyDown(KeyCode.F5))
                ManualTick();

            if (Input.GetKeyDown(KeyCode.F6))
                DumpState();

            if (Input.GetKeyDown(KeyCode.Escape))
                TransitionTo(GameState.Pause);
        }

        // ── State machine ──────────────────────────────────────────────────

        public void TransitionTo(GameState next)
        {
            GameLogger.Log(GameLogger.Category.Core, $"State: {_state} -> {next}");
            _state = next;

            switch (next)
            {
                case GameState.Pause:
                    Time.timeScale = 0f;
                    break;
                case GameState.Run:
                    Time.timeScale = 1f;
                    break;
                case GameState.Exit:
                    Application.Quit();
                    break;
            }
        }

        // ── Dev commands (F5 / F6 / DevHUD buttons) ───────────────────────

        public void ManualTick()
        {
            _tick++;
            GameLogger.Log(GameLogger.Category.Sim, $"Tick {_tick}");
        }

        public void DumpState()
        {
            StateSnapshot.Dump(this);
        }

        // ── Public read-only state ─────────────────────────────────────────

        public GameState CurrentState => _state;
        public int CurrentTick        => _tick;
        public int Seed               => _rng?.Seed ?? 0;
    }
}
