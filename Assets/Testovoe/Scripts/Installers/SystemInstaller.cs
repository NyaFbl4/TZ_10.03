using Zenject;

namespace Testovoe
{
    public class SystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SystemBingings();
        }

        private void SystemBingings()
        {
            Container
                .BindInterfacesAndSelfTo<InputSystem>()
                .AsSingle();
        }
    }
}