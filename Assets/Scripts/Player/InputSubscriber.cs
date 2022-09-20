using TopDown.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDown.Gameplay.Player
{
    public class InputSubscriber : PlayerController,
		InputActions.IGameplayActions,
		InputActions.IUIActions
    {
		protected override void Construct()
		{
			base.Construct();

			_input.Gameplay.SetCallbacks( this );

			_input.UI.SetCallbacks(this);
			_input.UI.Disable();
		}

		public void OnMove( InputAction.CallbackContext context )
		{
			// This input doesn't have any processors, so we need to clamp the value.
			var rawInput = context.ReadValue<Vector2>();
			_moveInput = Vector2.ClampMagnitude( rawInput, 1 );
		}

        public void OnAim(InputAction.CallbackContext context)
		{
			// This input has a "normalize" processor.
			var aimInput = context.ReadValue<Vector2>();
			if (aimInput != Vector2.zero)
			{
				_aimInput = aimInput;
			}
        }

        public void OnPause(InputAction.CallbackContext context)
        {
			// This ensures this value is only set once when the button is initially pressed.
			if (context.performed)
			{
				_isPaused = true;
			}
        }

        public void OnResume(InputAction.CallbackContext context)
		{
			// This ensures this value is only set once when the button is initially pressed.
			if (context.performed)
            {
				_isPaused = false;
			}
        }

        public void OnConfirm(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
