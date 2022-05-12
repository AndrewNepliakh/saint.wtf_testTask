using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.PlayerController
{
    public class InventoryController : MonoBehaviour
    {
        private const string STORAGE = "Storage";
        private const string STOCK = "Stock";
        
        [SerializeField] private Transform _inventory;
        private List<IProduct> _products = new List<IProduct>();
        private int _inventoryLimit = 10;
        private float _startYPos = 0.0f;
        private float _positionStep = 0.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<StorageController>(out var storage))
            {
                if (other.CompareTag(STORAGE))
                {
                    if (_products.Count >= _inventoryLimit) return;
                
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

                if (other.CompareTag(STOCK))
                {
                    for (var i = _products.Count - 1; i >= 0; i--)
                    {
                        if (storage.IsFull()) return;
                        _products[i].Transform.SetParent(storage.transform);
                        var position = _products[i].Transform.InverseTransformPoint(_products[i].Transform.position);
                        storage.SetProduct(position, _products[i]);
                        _products.Remove(_products[i]);
                    }

                    _startYPos = 0.0f;
                }

            }
        }
    }
}