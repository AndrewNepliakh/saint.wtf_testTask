using System;
using TMPro;
using UnityEngine;

namespace Controllers.BuildingController
{
    public abstract class Building : MonoBehaviour, IBuilding
    {
        public BuildingType Type => _buildingType;
        protected BuildingType _buildingType;

        [SerializeField] protected MeshRenderer _body;
        [SerializeField] protected MeshRenderer _stock;
        [SerializeField] protected MeshRenderer _storage;
        public abstract void Init(BuildingType type);
    }
    
    public enum BuildingType
    {
        Type1,
        Type2,
        Type3
    }
}