using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.BuildingController
{
    public abstract class Building : MonoBehaviour, IBuilding
    {
        public BuildingType Type => _buildingType;
        protected BuildingType _buildingType;
        protected ProductType _productType;
        protected List<ProductType> _consumableTypes = new List<ProductType>();
        protected float _produceTime;

        [SerializeField] protected MeshRenderer _body;
        [SerializeField] protected StorageController _storage;
        [SerializeField] protected StockController _stock;
        [SerializeField] protected Image _timerIndicator;
        protected float _timer;
        public abstract void Init(BuildingType type);
        public abstract void Consume();
        public abstract void Produce();
    }
    
    public enum BuildingType
    {
        Type1,
        Type2,
        Type3,
        Type4
    }
}