using TopDown.Gameplay.Movement;
using TopDown.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace TopDown.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        protected CharacterMotor _motor;
		protected InputActions _input;
		protected GameplaySettings.PlayerSettings _settings;

        [Inject]
		public void Construct( GameplaySettings.PlayerSettings settings,
			InputActions input,
            Rigidbody2D body )
		{
			_settings = settings;
            _motor = new CharacterMotor( body, settings.Movement );

			_input = input;
			_input.Enable();

			Construct();
		}

		protected virtual void Construct()
		{

		}

		protected virtual void OnDestroy()
		{
			_input.Dispose();
		}

		protected virtual void FixedUpdate()
		{
			_motor.FixedTick();
		}

		protected virtual void Start()
		{

		}
	}
}
