namespace JohnnyGame.Data
{
    /// <summary>
    /// Top-level save envelope. Always check schemaVersion before reading fields.
    /// Bump CurrentVersion and add an ISaveMigration when the schema changes.
    /// </summary>
    [System.Serializable]
    public class SaveData
    {
        public const int CurrentVersion = 0;

        public int schemaVersion = CurrentVersion;
        public RunData run = new RunData();
    }
}
