using Managers.BuildingsManager;
using Managers.ProductManager;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField] private BuildingsData _buildingsData;
    [SerializeField] private ProductData _productDatasData;
    public override void InstallBindings()
    {
        Container.Bind<BuildingsData>().FromInstance(_buildingsData).AsSingle().NonLazy();
        Container.Bind<ProductData>().FromInstance(_productDatasData).AsSingle().NonLazy();
    }
}