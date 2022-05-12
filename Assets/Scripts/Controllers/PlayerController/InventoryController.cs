using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.PlayerController
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private Transform _inventory;
        private List<IProduct> _products = new List<IProduct>();
        private int _inventoryLimit = 10;
        private float _startYPos = 0.0f;
        private float _positionStep = 0.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (_products.Count >= _inventoryLimit) return;
            if (other.TryGetComponent<StorageController>(out var storage))
            {
                var products = storage.ProductsCount;
                if (products > _inventoryLimit) products = _inventoryLimit;

                for (var i = 0; i < products; i++)
                {
                    var position =
                        new Vector3(_inventory.localPosition.x,
                            _startYPos,
                            _inventory.localPosition.z);
                    
                    if (_products.Count >= _inventoryLimit) return;
                    foreach (var product in storage.GetProduct(position, _inventory))
                        _products.Add(product);
                    
                    _startYPos += _positionStep;
                }
            }
        }
    }
}