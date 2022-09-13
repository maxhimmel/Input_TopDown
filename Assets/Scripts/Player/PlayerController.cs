using TopDown.Gameplay.Movement;
using TopDown.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDown.Gameplay.Player
{
    public class PlayerController : MonoBehaviour,
		InputActions.IGameplayActions
    {
        private CharacterMotor _motor;
		private InputActions _input;

        [Inject]
		public void Construct( GameplaySettings.PlayerSettings settings,
            Rigidbody2D body )
		{
            _motor = new CharacterMotor( body, settings.Movement );

			_input = new InputActions();
			_input.Gameplay.SetCallbacks( this );
			_input.Enable();
		}

		private void OnDestroy()
		{
			_input.Dispose();
		}

		public void OnHorizontal( InputAction.CallbackContext context )
		{
			_motor.SetDesiredVelocity( new Vector2()
			{
				x = context.ReadValue<float>()
			} );
		}

		private void FixedUpdate()
		{
			_motor.FixedTick();
		}
	}
}
