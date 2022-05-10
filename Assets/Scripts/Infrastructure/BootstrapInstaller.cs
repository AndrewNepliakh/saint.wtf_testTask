using Managers;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStateManager>().To<StateManager>().AsSingle().NonLazy();
            Container.Bind<IUserManager>().To<UserManager>().AsSingle().NonLazy();
            
            Container.Bind<InitialState>().AsSingle().NonLazy();
            Container.Bind<GameState>().AsSingle().NonLazy();
        }
    }
}
