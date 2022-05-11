using System.Collections.Generic;
using Managers.BuildingsManager;
using UnityEngine;
using Zenject;

namespace Controllers.SceneController
{
    public class SceneController : MonoBehaviour, ISceneController
    {
        [SerializeField] private List<Transform> _buildigsSpawnPositions;
        [Inject] private IBuildingsManager _buildingsManager;
        private void Start()
        {
            _buildingsManager.ConstructBuildings(_buildigsSpawnPositions);
        }
    }
}