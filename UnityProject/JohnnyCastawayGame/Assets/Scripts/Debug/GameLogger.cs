using UnityEngine;

namespace JohnnyGame.Debugging
{
    /// <summary>
    /// Thin wrapper around Debug.Log that prefixes messages with a category tag.
    /// Use this instead of raw Debug.Log so logs are filterable in the Console.
    /// See Docs/Debug.md for usage.
    /// </summary>
    public static class GameLogger
    {
        public enum Category { Core, Sim, Save, UI, WorldGen }

        private static readonly string[] Tags =
        {
            "[Core]", "[Sim]", "[Save]", "[UI]", "[WorldGen]",
        };

        public static void Log(Category category, string message)
        {
            Debug.Log($"{Tags[(int)category]} {message}");
        }

        public static void LogWarning(Category category, string message)
        {
            Debug.LogWarning($"{Tags[(int)category]} {message}");
        }

        public static void LogError(Category category, string message)
        {
            Debug.LogError($"{Tags[(int)category]} {message}");
        }
    }
}
