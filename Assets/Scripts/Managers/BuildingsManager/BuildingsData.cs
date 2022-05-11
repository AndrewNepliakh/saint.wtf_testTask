using System;
using System.Collections.Generic;
using Controllers.BuildingController;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers.BuildingsManager
{
    [Serializable]
    public class BuildingModel
    {
        public BuildingType Type;
        public Vector3 SpawnPosition;
        public Color BodyColor;
        public Color StockColor;
        public Color StorageColor;
    }

    [CreateAssetMenu(fileName = "BuildingsData", menuName = "Data/BuildingsData")]
    public class BuildingsData : ScriptableObject
    {
         public List<BuildingModel> buildingModels = new List<BuildingModel>();

        public Color GetBodyColor(BuildingType type) => buildingModels.Find(x => x.Type == type).BodyColor;
        public Color GetStockColor(BuildingType type) => buildingModels.Find(x => x.Type == type).StockColor;
        public Color GetStorageColor(BuildingType type) => buildingModels.Find(x => x.Type == type).StorageColor;
        public Vector3 GetSpawnPosition(BuildingType type) => buildingModels.Find(x => x.Type == type).SpawnPosition;
    }
}