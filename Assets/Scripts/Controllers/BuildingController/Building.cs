using System;
using TMPro;
using UnityEngine;

namespace Controllers.BuildingController
{
    public abstract class Building : MonoBehaviour, IBuilding
    {
        public BuildingType Type => _buildingType;
        protected BuildingType _buildingType;
        protected float _produceTime;
        protected ProductType _productType;

        [SerializeField] protected MeshRenderer _body;
        [SerializeField] protected StockController _stock;
        [SerializeField] protected StorageController _storage;
        public abstract void Init(BuildingType type);
        public abstract void Produce();
    }
    
    public enum BuildingType
    {
        Type1,
        Type2,
        Type3
    }
}