using System;
using UnityEngine;

namespace TopDown.Gameplay.Player
{
    public class InputPoller : PlayerController
    {
        protected override void Update()
        {
            base.Update();

            PollPausing();
            PollMoveInput();
            PollAimInput();
        }

        private void PollPausing()
        {
            // This will throw an exception if trying to read these pause/resume buttons as a <bool>.
                // Probably a good reason to NOT use this polling method and instead use the callback/subscription flow.

            if (_input.Gameplay.enabled)
            {
                if (_input.Gameplay.Pause.ReadValue<float>() != 0)
                {
                    _isPaused = true;
                }
            }
            else if (_input.UI.enabled)
            {
                if (_input.UI.Resume.ReadValue<float>() != 0)
                {
                    _isPaused = false;
                }
            }
        }

        private void PollMoveInput()
        {
            // This input doesn't have any processors, so we need to clamp the value.
            var moveInput = _input.Gameplay.Move.ReadValue<Vector2>();
            _moveInput = Vector2.ClampMagnitude(moveInput, 1);
        }

        private void PollAimInput()
        {
            // This input has a "normalize" processor.
            var aimInput = _input.Gameplay.Aim.ReadValue<Vector2>();
            if (aimInput != Vector2.zero)
            {
                _aimInput = aimInput;
            }
        }
    }
}
