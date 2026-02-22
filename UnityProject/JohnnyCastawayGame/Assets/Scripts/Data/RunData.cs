namespace JohnnyGame.Data
{
    [System.Serializable]
    public class RunData
    {
        public int tick;
        public PlayerData player = new PlayerData();
        public WorldData world   = new WorldData();
    }
}
