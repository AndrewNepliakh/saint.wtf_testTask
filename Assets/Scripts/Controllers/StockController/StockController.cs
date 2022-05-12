using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.BuildingController;
using Managers.BuildingsManager;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class StockController : StorageController
    {
        [Inject] private BuildingsData _buildingsData;
        private readonly List<List<IProduct>> _products = new List<List<IProduct>>();
        private BuildingType _buildingType;
        private List<ProductType> _consumableProductsTypes;

        public bool IsEmpty()
        {
            _buildingType = transform.parent.GetComponent<Building>().Type;
            _consumableProductsTypes = _buildingsData.GetConsumableProducts(_buildingType).Distinct().ToList();

            if (_consumableProductsTypes.Count == 0)
            {
                return false;
            }

            _products.Clear();
            foreach (var productType in _consumableProductsTypes)
            {
                var productsType = _storedProducts.Where(x => x.Type == productType).ToList();
                _products.Add(productsType);
            }
  
            if (_products.Count == 0)
            {
                return false;
            }

            foreach (var products in _products)
            {
                if (products.Count == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public override List<IProduct> GetProduct(Vector3 position, Transform parent)
        {
            var consumedProducts = new List<IProduct>();

            foreach (var products in _products)
            {
                var product = products[products.Count - 1];
                _storedProducts.Remove(product);
                product.Move(product.Transform.position, position);
                consumedProducts.Add(product);
            }

            return consumedProducts;
        }
    }
}