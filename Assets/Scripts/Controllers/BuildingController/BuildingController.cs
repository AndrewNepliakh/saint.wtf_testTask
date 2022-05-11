using Managers.BuildingsManager;
using UnityEngine;
using Zenject;

namespace Controllers.BuildingController
{
    public class BuildingController : Building
    {
        [Inject] private BuildingsData _buildingsData;

        public override void Init(BuildingType type)
        {
            _buildingType = type;
            transform.position = _buildingsData.GetSpawnPosition(type);
            _body.GetComponent<MeshRenderer>().material.color = _buildingsData.GetBodyColor(type);
            _stock.GetComponent<MeshRenderer>().material.color = _buildingsData.GetStockColor(type);
            _storage.GetComponent<MeshRenderer>().material.color = _buildingsData.GetStorageColor(type);
        }
    }
}