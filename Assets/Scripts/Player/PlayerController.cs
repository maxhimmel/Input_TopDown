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

		protected Vector2 _moveInput;
		protected Vector2 _aimInput;
		protected bool _isPaused;

		private bool _prevPauseState;
		private PauseController _pauseController;

		[Inject]
		public void Construct( GameplaySettings.PlayerSettings settings,
			InputActions input,
            Rigidbody2D body,
			PauseController pauseController )
		{
			_settings = settings;
			_pauseController = pauseController;
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

		protected virtual void Update()
        {
			HandlePause();
			HandleMovement();
			HandleAiming();
        }

		private void HandlePause()
        {
			if (_prevPauseState != _isPaused)
            {
                if (_isPaused)
				{
					_pauseController.Pause();
				}
				else
				{
					_pauseController.Resume();
				}

				_prevPauseState = _isPaused;
			}
        }

		private void HandleMovement()
		{
			_motor.SetDesiredVelocity(_moveInput);
		}

		private void HandleAiming()
		{
			if (_aimInput != Vector2.zero)
			{
				var desiredFacing = Quaternion.LookRotation(Vector3.forward, _aimInput);
				var facingSpeed = (_settings.TurnSpeed) * Time.deltaTime;

				transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredFacing, facingSpeed);
			}
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
