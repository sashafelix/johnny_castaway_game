using UnityEngine;
using JohnnyGame.Core;

namespace JohnnyGame.UI
{
    /// <summary>
    /// Developer overlay HUD. Shows live game state and exposes quick debug actions.
    /// Add this MonoBehaviour to a GameObject in the Bootstrap scene alongside GameRoot.
    /// Toggle visibility with backtick (`). See Docs/Debug.md for full usage.
    /// </summary>
    public sealed class DevHUD : MonoBehaviour
    {
        private bool _visible = true;
        private GameRoot _root;

        private void Awake()
        {
            _root = FindFirstObjectByType<GameRoot>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
                _visible = !_visible;
        }

        private void OnGUI()
        {
            if (!_visible) return;

            GUILayout.BeginArea(new Rect(10, 10, 260, 185), GUI.skin.box);
            GUILayout.Label("DEV HUD  [` to toggle]");
            GUILayout.Space(4);

            if (_root != null)
            {
                GUILayout.Label($"State:     {_root.CurrentState}");
                GUILayout.Label($"Tick:      {_root.CurrentTick}");
                GUILayout.Label($"Seed:      {_root.Seed}");
                GUILayout.Label($"Resources: —");
                GUILayout.Space(4);

                if (GUILayout.Button("Manual Tick  [F5]"))
                    _root.ManualTick();

                if (GUILayout.Button("Dump State   [F6]"))
                    _root.DumpState();
            }
            else
            {
                GUILayout.Label("(no GameRoot found in scene)");
            }

            GUILayout.EndArea();
        }
    }
}
