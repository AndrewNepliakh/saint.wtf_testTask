using Managers.BuildingsManager;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField] private BuildingsData _buildingsData;
    public override void InstallBindings()
    {
        Container.Bind<BuildingsData>().FromInstance(_buildingsData).AsSingle().NonLazy();
    }
}