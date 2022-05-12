using Managers.BuildingsManager;
using UnityEngine;
using Zenject;

namespace Controllers.SceneController
{
    public class SceneController : MonoBehaviour, ISceneController
    {
        [Inject] private IBuildingsManager _buildingsManager;
        private void Start()
        {
            _buildingsManager.ConstructBuildings();
        }
    }
}