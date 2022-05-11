using Controllers.SceneController;
using Managers;
using Managers.BuildingsManager;
using Managers.ProductManager;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBuildingsManager>().To<BuildingsManager>().AsSingle().NonLazy();
            Container.Bind<IProductManager>().To<ProductManager>().AsSingle().NonLazy();
            Container.Bind<IStateManager>().To<StateManager>().AsSingle().NonLazy();
            Container.Bind<IUserManager>().To<UserManager>().AsSingle().NonLazy();

            Container.Bind<InitialState>().AsSingle().NonLazy();
            Container.Bind<GameState>().AsSingle().NonLazy();
        }
    }
}
