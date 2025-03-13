using System;
using UnityEngine;

namespace Testovoe
{
    public class JoystickForMovement : JoystickHandler
    {
        /*
        private void Uupdate()
        {
            if (_inputVector.x != 0 || _inputVector.y != 0)
            {
                _characterMovement.MoveCharacter(
                    new Vector3(_inputVector.x, 0, _inputVector.y));
                //_characterMovement.RotateCharacter(new Vector3(_inputVector.x, 0, _inputVector.y));
            }
            else
            {
                _characterMovement.MoveCharacter(
                    new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
                //_characterMovement.RotateCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            }
        }
        */

        public Vector3 ReturnVectorDirection()
        {
            if (_inputVector.x != 0 || _inputVector.y != 0)
            {
                return new Vector3(_inputVector.x, 0, _inputVector.y);
            }
            else
            {
                return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
        }
    }
}