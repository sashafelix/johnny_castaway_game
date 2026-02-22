using UnityEngine;

namespace JohnnyGame.Data
{
    /// <summary>
    /// Runtime configuration asset. Create via Assets → Create → JohnnyGame → Game Config.
    /// Reference this SO from GameRoot to tune values without recompiling.
    /// </summary>
    [CreateAssetMenu(menuName = "JohnnyGame/Game Config", fileName = "GameConfig")]
    public class GameConfigSO : ScriptableObject
    {
        [Header("Tick")]
        public float tickIntervalSeconds = 1f;
        public int startingTick = 0;

        [Header("Starting Resources")]
        public float startingFood  = 10f;
        public float startingWood  = 5f;
        public float startingStone = 0f;
    }
}
