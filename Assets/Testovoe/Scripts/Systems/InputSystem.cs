using System;
using UnityEngine;
using Zenject;

namespace Testovoe
{
    public class InputSystem : ITickable
    {
        private readonly CharacterMovement _characterMovement;
        private readonly CameraController _cameraController;
        private readonly PickupItem _pickupItem;
        
        private readonly JoystickForMovement _joystickForMovement;
        private readonly FixedTouchField _fixedTouchField;

        public InputSystem(CharacterMovement characterMovement, CameraController cameraController,
                    PickupItem pickupItem, JoystickForMovement joystick, FixedTouchField touchField)
        {
            _characterMovement = characterMovement;
            _cameraController = cameraController;
            _pickupItem = pickupItem;

            _joystickForMovement = joystick;
            _fixedTouchField = touchField;
        }
        
        public void Tick()
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
    }
}