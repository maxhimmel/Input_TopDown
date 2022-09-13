using UnityEngine;

namespace TopDown.Gameplay.Movement
{
	public class CharacterMotor
	{
		private readonly Rigidbody2D _body;
		private readonly Settings _settings;

		private Vector3 _velocity;
		private Vector3 _desiredVelocity;

		public CharacterMotor( Rigidbody2D body,
			Settings settings )
		{
			_body = body;
			_settings = settings;
		}

		public void SetDesiredVelocity( Vector3 direction )
		{
			_desiredVelocity = direction * _settings.MaxSpeed;
		}

		public void FixedTick()
		{
			_velocity = _body.velocity;

			float speedDelta = Time.deltaTime * _settings.Acceleration;
			_velocity = Vector3.MoveTowards( _velocity, _desiredVelocity, speedDelta );

			_body.velocity = _velocity;
		}


		[System.Serializable]
		public struct Settings
		{
			public float MaxSpeed;
			public float Acceleration;
		}
	}
}