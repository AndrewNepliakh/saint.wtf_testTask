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
        [Inject] private BuildingsData _buildingsData;
        
        public void ConstructBuildings()
        {
            _buildingPrefab = Resources.Load<BuildingController>(Constants.BUILDING_PATH);

            foreach (var model in _buildingsData.buildingModels)
            {
                var building = _diContainer.InstantiatePrefab(_buildingPrefab, Vector3.zero, Quaternion.identity,
                    null).GetComponent<BuildingController>();
                building.Init(model.Type);
                
                _buildings.Add(building);
            }
        }
    }
}