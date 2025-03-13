using UnityEngine;

namespace Testovoe
{
    public class CharacterMovementLogic : IMovementController
    {
        private readonly Transform _characterTransform;
        private readonly CharacterController _characterController;
        private readonly float _moveSpeed;
        private readonly float _gravityForce;

        private float _currentAttractionCharacter;

        public CharacterMovementLogic(
            Transform characterTransform,
            CharacterController characterController,
            CharacterConfig config
            )
        {
            _characterTransform = characterTransform;
            _characterController = characterController;
            _moveSpeed = config.MoveSpeed;
            _gravityForce = config.GravityForce;
        }

        public void Move(Vector3 moveDirection)
        {
            moveDirection = _characterTransform.TransformDirection(moveDirection);
            moveDirection *= _moveSpeed;
            moveDirection.y = _currentAttractionCharacter;
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        public void UpdateGravity()
        {
            if (!_characterController.isGrounded)
            {
                _currentAttractionCharacter -= _gravityForce * Time.deltaTime;
            }
            else
            {
                _currentAttractionCharacter = 0;
            }
        }
    }
}