using UnityEngine;
using Zenject;

namespace Testovoe
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] 
        private Transform _characterTransform;

        private CharacterController _characterController;
        private IMovementController _movementController;

        [Inject]
        public void Construct(CharacterController characterController, CharacterConfig config)
        {
            _characterController = characterController;
            
            _movementController = new CharacterMovementLogic(
                _characterTransform,
                _characterController,
                config
            );
        }

        private void Update()
        {
            _movementController.UpdateGravity();
        }

        public void MoveCharacter(Vector3 moveDirection)
        {
            _movementController.Move(moveDirection);
        }
    }
}
