using TopDown.Gameplay;
using TopDown.Input;
using Zenject;

namespace TopDown.Installer
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TopDownInput>().AsSingle();
            Container.Bind<PauseController>().AsSingle();
        }
    }
}
