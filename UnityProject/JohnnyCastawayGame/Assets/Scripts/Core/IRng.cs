namespace JohnnyGame.Core
{
    /// <summary>Seeded, deterministic random number generator.</summary>
    public interface IRng
    {
        int Seed { get; }
        int NextInt(int minInclusive, int maxExclusive);
        float NextFloat(float min, float max);
        bool NextBool(float trueProbability = 0.5f);
    }
}
