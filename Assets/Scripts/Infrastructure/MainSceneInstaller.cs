using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private MainManager _mainManager;

        public override void InstallBindings()
        {
            Container.Bind<IUIManager>().FromInstance(_uiManager).AsSingle().NonLazy();
            Container.Bind<IMainManager>().FromInstance(_mainManager).AsSingle().NonLazy();
        }
    }
}
