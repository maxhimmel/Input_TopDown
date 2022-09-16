using TopDown.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Gameplay.Player
{
    public class InputSubscriber : PlayerController,
		InputActions.IGameplayActions
    {
		protected override void Construct()
		{
			base.Construct();

			_input.Gameplay.SetCallbacks( this );
		}

		public void OnMove( InputAction.CallbackContext context )
		{
			var rawInput = context.ReadValue<Vector2>();
			rawInput = Vector2.ClampMagnitude( rawInput, 1 );

			_motor.SetDesiredVelocity( rawInput );
		}

        public void OnAim(InputAction.CallbackContext context)
        {
			var aimInput = context.ReadValue<Vector2>();
			if (aimInput != Vector2.zero)
			{
				var desiredFacing = Quaternion.LookRotation(Vector3.forward, aimInput);
				var facingSpeed = (_settings.TurnSpeed) * Time.deltaTime;

				transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredFacing, facingSpeed);
			}
        }
    }
}
