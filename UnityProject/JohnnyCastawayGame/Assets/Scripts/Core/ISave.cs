using JohnnyGame.Data;

namespace JohnnyGame.Core
{
    /// <summary>Persists and retrieves save data.</summary>
    public interface ISave
    {
        void Save(SaveData data);
        SaveData Load();
        bool HasSave();
        void DeleteSave();
    }
}
