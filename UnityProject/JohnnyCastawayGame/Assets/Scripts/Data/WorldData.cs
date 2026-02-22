namespace JohnnyGame.Data
{
    [System.Serializable]
    public class WorldData
    {
        public int seed;

        // ID strategy: "category.name" (e.g. "biome.tropical", "biome.storm-belt")
        public string biomeId = "biome.tropical";

        // Tile/heightmap data — populated by IWorldGen in M1
    }
}
