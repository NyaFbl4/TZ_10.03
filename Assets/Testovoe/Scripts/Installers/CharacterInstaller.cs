using UnityEngine;
using Zenject;

namespace Testovoe
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private PickupItem _pickupItem;
        [SerializeField] private JoystickForMovement _joystick;
        [SerializeField] private FixedTouchField _touchField;
        
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private CharacterController _characterController;
        
        public override void InstallBindings()
        {
            CharacterBingings();
        }

        private void CharacterBingings()
        {
            Container
                .Bind<CharacterController>()
                .FromInstance(_characterController)
                .AsSingle();
            
            Container
                .Bind<CharacterMovement>()
                .FromInstance(_characterMovement)
                .AsSingle();

            Container
                .BindInterfacesTo<IMovementController>()
                .AsSingle()
                .WithArguments(_characterTransform);
            
            Container
                .Bind<CameraController>()
                .FromInstance(_cameraController)
                .AsSingle();
            
            Container
                .Bind<PickupItem>()
                .FromInstance(_pickupItem)
                .AsSingle();
            
            Container
                .Bind<JoystickForMovement>()
                .FromInstance(_joystick)
                .AsSingle();
            
            Container
                .Bind<FixedTouchField>()
                .FromInstance(_touchField)
                .AsSingle();
        }
    }
}