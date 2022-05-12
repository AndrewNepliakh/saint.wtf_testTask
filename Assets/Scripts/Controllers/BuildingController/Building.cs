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
        protected float _produceTime;
        protected ProductType _productType;

        [SerializeField] protected MeshRenderer _body;
        [SerializeField] protected StorageController _storage;
        [SerializeField] protected Image _timerIndicator;
        protected float _timer;

        protected List<ProductType> _consumables = new List<ProductType>();
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