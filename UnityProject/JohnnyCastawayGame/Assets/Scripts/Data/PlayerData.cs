namespace JohnnyGame.Data
{
    [System.Serializable]
    public class PlayerData
    {
        // ID strategy: "category.name" strings (stable across schema versions)
        public string playerId = "player.default";

        // Resources — driven by TickSim in M1
        public float food;
        public float wood;
        public float stone;
    }
}
