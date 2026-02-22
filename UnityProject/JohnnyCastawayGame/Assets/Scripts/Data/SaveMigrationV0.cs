namespace JohnnyGame.Data
{
    /// <summary>
    /// v0 → v0 migration stub. Replace this class with a real migration when
    /// SaveData.CurrentVersion is bumped to 1.
    /// </summary>
    public class SaveMigrationV0 : ISaveMigration
    {
        public int FromVersion => 0;
        public int ToVersion   => 0;
        public SaveData Migrate(SaveData data) => data;
    }
}
