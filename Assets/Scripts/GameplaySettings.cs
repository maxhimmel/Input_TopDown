using TopDown.Gameplay.Movement;
using UnityEngine;
using Zenject;

namespace TopDown.Gameplay
{
    [CreateAssetMenu]
    public class GameplaySettings : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerSettings _playerSettings;

        [System.Serializable]
		public class PlayerSettings
		{
			public float TurnSpeed;
            public CharacterMotor.Settings Movement;
		}

		public override void InstallBindings()
		{
			Container.BindInstance( _playerSettings );
		}
	}
}
