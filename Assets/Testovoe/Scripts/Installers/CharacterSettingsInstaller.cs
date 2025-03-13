using Zenject;
using UnityEngine;

namespace Testovoe
{
    [CreateAssetMenu(fileName = "CharacterSettingsInstaller")]
    public class CharacterConfigInstaller : ScriptableObjectInstaller<CharacterConfigInstaller>
    {
        public CharacterConfig gameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(gameSettings);
        }
    }

    [System.Serializable]
    public class CharacterConfig
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _gravityForce;
        [SerializeField] private float _throwForce;
        [SerializeField] private float _maxPickupDistance;

        public float MoveSpeed => _moveSpeed;
        public float GravityForce => _gravityForce;
        public float ThrowForce => _throwForce;
        public float MaxPickupDistance => _maxPickupDistance;
    }
}