using System;
using TMPro;
using UnityEngine;

namespace Controllers.BuildingController
{
    public abstract class Building : MonoBehaviour, IBuilding
    {
        public BuildingType Type => _buildingType;
        protected BuildingType _buildingType;

        [SerializeField] protected GameObject _body;
        [SerializeField] protected GameObject _stock;
        [SerializeField] protected GameObject _storage;
        public abstract void Init(BuildingType type);
    }
    
    public enum BuildingType
    {
        Type1,
        Type2,
        Type3
    }
}