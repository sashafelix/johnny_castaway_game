using JohnnyGame.Data;

namespace JohnnyGame.Core
{
    /// <summary>Advances the simulation by one discrete tick.</summary>
    public interface ITickSim
    {
        int CurrentTick { get; }
        void Tick(RunData run);
    }
}
