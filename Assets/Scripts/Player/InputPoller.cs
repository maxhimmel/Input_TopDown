using UnityEngine;

namespace TopDown.Gameplay.Player
{
    public class InputPoller : PlayerController
    {
        private void Update()
        {
            HandleMovement();
            HandleAiming();
        }

        private void HandleMovement()
        {
            var moveInput = _input.Gameplay.Move.ReadValue<Vector2>();
            moveInput = Vector2.ClampMagnitude(moveInput, 1);

            _motor.SetDesiredVelocity(moveInput);
        }

        private void HandleAiming()
        {
            var aimInput = _input.Gameplay.Aim.ReadValue<Vector2>();
            if (aimInput != Vector2.zero)
            {
                var desiredFacing = Quaternion.LookRotation(Vector3.forward, aimInput);
                var facingSpeed = (_settings.TurnSpeed) * Time.deltaTime;

                transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredFacing, facingSpeed);
            }
        }
    }
}
