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
	}
}