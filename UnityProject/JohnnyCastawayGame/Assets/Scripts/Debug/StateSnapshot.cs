using System.Text;
using JohnnyGame.Core;

namespace JohnnyGame.Debugging
{
    /// <summary>
    /// Dumps a human-readable snapshot of the current game state to the console.
    /// Trigger via F6, the DevHUD "Dump State" button, or GameRoot.DumpState().
    /// See Docs/Debug.md for usage.
    /// </summary>
    public static class StateSnapshot
    {
        public static void Dump(GameRoot root)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== STATE SNAPSHOT ===");
            sb.AppendLine($"State : {root.CurrentState}");
            sb.AppendLine($"Tick  : {root.CurrentTick}");
            sb.AppendLine($"Seed  : {root.Seed}");
            sb.AppendLine("======================");
            GameLogger.Log(GameLogger.Category.Core, sb.ToString());
        }
    }
}
