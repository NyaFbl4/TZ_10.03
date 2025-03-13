using System;
using UnityEngine;
using Zenject;

namespace Testovoe
{
    public class InputSystem : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CameraController _cameraController;
        private PickupItem _pickupItem;
        
        private JoystickForMovement _joystickForMovement;
        private FixedTouchField _fixedTouchField;

        [Inject]
        public void Construct(CharacterMovement characterMovement, CameraController cameraController,
                    PickupItem pickupItem, JoystickForMovement joystick, FixedTouchField touchField)
        {
            _characterMovement = characterMovement;
            _cameraController = cameraController;
            _pickupItem = pickupItem;

            _joystickForMovement = joystick;
            _fixedTouchField = touchField;
        }
        
        private void Update()
        {
            MoveCharacter();
            RotationCharacter();
            
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Pickable"))
                    {
                        _pickupItem.TakeItem(hit.collider.gameObject);
                    }
                }
            }
        }

        private void MoveCharacter()
        {
            var moveDirection = _joystickForMovement.ReturnVectorDirection();
        
            _characterMovement.MoveCharacter(moveDirection);
        }

        private void RotationCharacter()
        {
            _cameraController.LockAxis = _fixedTouchField.TouchDist;
        }
        
        public void DropItem()
        {
            _pickupItem.DropItem();
        }
    }
}