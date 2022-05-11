using System;
using System.Collections.Generic;
using Controllers.BuildingController;
using UnityEngine;

namespace Managers.BuildingsManager
{
    [Serializable]
    public class BuildingModel
    {
        public BuildingType Type;
        public Color BodyColor;
        public Color StockColor;
        public Color StorageColor;
    }

    [CreateAssetMenu(fileName = "BuildingsData", menuName = "Data/BuildingsData")]
    public class BuildingsData : ScriptableObject
    {
        public List<BuildingModel> _buildingModels = new List<BuildingModel>();

        public Color GetBodyColor(BuildingType type) => _buildingModels.Find(x => x.Type == type).BodyColor;
        public Color GetStockColor(BuildingType type) => _buildingModels.Find(x => x.Type == type).BodyColor;
        public Color GetBodyColor(BuildingType type) => _buildingModels.Find(x => x.Type == type).BodyColor;
    }
}