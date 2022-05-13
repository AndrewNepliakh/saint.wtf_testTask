using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class InventoryController : MonoBehaviour
    {
        private const string STORAGE = "Storage";
        private const string STOCK = "Stock";
        
        [SerializeField] private Transform _inventory;
        private readonly List<IProduct> _inventoryProducts = new List<IProduct>();
        private int _inventoryLimit = 10;
        private float _startYPos = 0.0f;
        private float _positionStep = 0.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<StorageController>(out var storage))
            {
                if (other.CompareTag(STORAGE))
                {
                    if (_inventoryProducts.Count >= _inventoryLimit) return;
                
                    var products = storage.ProductsCount;
                    if (products > _inventoryLimit) products = _inventoryLimit;

                    for (var i = 0; i < products; i++)
                    {
                        var position =
                            new Vector3(_inventory.localPosition.x,
                                _startYPos,
                                _inventory.localPosition.z);
                    
                        if (_inventoryProducts.Count >= _inventoryLimit) return;
                        foreach (var product in storage.GetProduct(position, _inventory))
                            _inventoryProducts.Add(product);
                    
                        _startYPos += _positionStep;
                    }
                }

                if (other.CompareTag(STOCK))
                {
                    for (var i = _inventoryProducts.Count - 1; i >= 0; i--)
                    {
                        if (storage.IsFull()) return;
                        _inventoryProducts[i].Transform.SetParent(storage.transform);
                        var modPos = storage.transform.InverseTransformPoint(_inventoryProducts[i].Transform.position);
                        storage.SetProduct(modPos, _inventoryProducts[i]);
                        _inventoryProducts.Remove(_inventoryProducts[i]);
                    }

                    _startYPos = 0.0f;
                }

            }
        }
    }
}