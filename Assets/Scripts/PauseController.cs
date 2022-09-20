using TopDown.Input;
using UnityEngine;

namespace TopDown.Gameplay
{
    public class PauseController
    {
        public bool IsPaused { get; private set; }

        private readonly TopDownInput _input;

        private float _prevTimeScale = 1;

        public PauseController(TopDownInput input)
        {
            _input = input;
        }

        public void Pause()
        {
            if (IsPaused)
            {
                return;
            }

            IsPaused = true;

            _input.Gameplay.Disable();
            _input.UI.Enable();

            _prevTimeScale = Time.timeScale;
            Time.timeScale = 0;

            Debug.LogWarning($"<color=red>Paused</color>");
        }

        public void Resume()
        {
            if (!IsPaused)
            {
                return;
            }

            IsPaused = false;

            _input.UI.Disable();
            _input.Gameplay.Enable();

            Time.timeScale = _prevTimeScale;

            Debug.LogWarning($"<color=lime>Resumed</color>");
        }
    }
}
