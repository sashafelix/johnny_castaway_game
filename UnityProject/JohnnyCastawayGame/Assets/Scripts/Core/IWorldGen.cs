using JohnnyGame.Data;

namespace JohnnyGame.Core
{
    /// <summary>Generates a world from a seed.</summary>
    public interface IWorldGen
    {
        WorldData Generate(int seed);
    }
}
