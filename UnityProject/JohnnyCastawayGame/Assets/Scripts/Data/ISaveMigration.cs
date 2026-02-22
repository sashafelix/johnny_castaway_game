namespace JohnnyGame.Data
{
    /// <summary>
    /// One migration step that upgrades a SaveData from FromVersion to ToVersion.
    /// Register implementations in the save service's migration chain.
    /// </summary>
    public interface ISaveMigration
    {
        int FromVersion { get; }
        int ToVersion   { get; }
        SaveData Migrate(SaveData data);
    }
}
