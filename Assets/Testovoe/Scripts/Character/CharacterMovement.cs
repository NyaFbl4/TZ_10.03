using UnityEngine;
using Zenject;

namespace Testovoe
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] 
        private Transform _characterTransform;
        [SerializeField]
        private CharacterController _characterController;
        
        private float _moveSpeed;
        private float _currentAttractionCharacter;
        private float _gravityForce;

        [Inject]
        public void Construct(CharacterConfig config)
        {
            _moveSpeed = config.MoveSpeed;
            _gravityForce = config.GravityForce;
        }

        private void Update()
        {
            GravityHandling();
        }

        public void MoveCharacter(Vector3 moveDirection)
        {
            moveDirection = _characterTransform.TransformDirection(moveDirection);
            
            moveDirection = moveDirection * _moveSpeed;
            moveDirection.y = _currentAttractionCharacter;
            
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        private void GravityHandling()
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
