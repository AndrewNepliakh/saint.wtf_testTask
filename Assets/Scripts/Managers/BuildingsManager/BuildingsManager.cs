using System.Collections.Generic;
using Controllers.BuildingController;
using Controllers.SceneController;
using UnityEngine;
using Zenject;

namespace Managers.BuildingsManager
{
    public class BuildingsManager : IBuildingsManager
    {
        private List<IBuilding> _buildings = new List<IBuilding>();
        private BuildingController _buildingPrefab;
        [Inject] private DiContainer _diContainer;
        
        public void ConstructBuildings(List<Transform> spawnPoints)
        {
            _buildingPrefab = Resources.Load<BuildingController>(Constants.BUILDING_PATH);

            foreach (var point in spawnPoints)
            {
                var building = _diContainer.InstantiatePrefab(_buildingPrefab, point.position, Quaternion.identity,
                    null).GetComponent<BuildingController>();
                _buildings.Add(building);
            }
        }
    }
}