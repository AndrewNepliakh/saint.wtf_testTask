using System;
using UnityEngine;

namespace Controllers.BuildingController
{
    public abstract class Building : MonoBehaviour, IBuilding
    {
        [SerializeField] private GameObject _body;
        [SerializeField] private GameObject _stock;
        [SerializeField] private GameObject _storage;

        protected void Start()
        {
            _body.GetComponent<MeshRenderer>().material.color = Color.blue;
            _stock.GetComponent<MeshRenderer>().material.color = Color.red;
            _storage.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}