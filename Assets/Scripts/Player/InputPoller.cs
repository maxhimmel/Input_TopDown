using UnityEngine;

namespace TopDown.Gameplay.Player
{
    public class InputPoller : PlayerController
    {
        private void Update()
        {
            var moveInput = _input.Gameplay.Move.ReadValue<Vector2>();
            moveInput = Vector2.ClampMagnitude( moveInput, 1 );

            _motor.SetDesiredVelocity( moveInput );
        }
    }
}
