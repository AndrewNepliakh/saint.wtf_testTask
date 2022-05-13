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
        private readonly List<List<IProduct>> _presentProducts = new List<List<IProduct>>();
        private BuildingType? _buildingType;
        private List<ProductType> _consumableProductsTypes;

        public bool IsEmpty()
        {
            _buildingType ??= transform.parent.GetComponent<Building>().Type;
            _consumableProductsTypes ??= _buildingsData.GetConsumableProducts(_buildingType.Value).Distinct().ToList();

            if (_consumableProductsTypes.Count == 0) return false;
            
            _presentProducts.Clear();
            foreach (var productType in _consumableProductsTypes)
            {
                var productsType = _storedProducts.Where(x => x.Type == productType).ToList();
                _presentProducts.Add(productsType);
            }
  
            if (_presentProducts.Count == 0)  return false;
            
            foreach (var products in _presentProducts)
            {
                if (products.Count == 0) return true;
            }

            return false;
        }

        public override List<IProduct> GetProduct(Vector3 endPos, Transform parent)
        {
            var consumedProducts = new List<IProduct>();

            foreach (var products in _presentProducts)
            {
                var product = products[products.Count - 1];
                var modPos = parent.InverseTransformPoint(product.Transform.position);
                product.Transform.SetParent(parent);
                product.Move(modPos, endPos);
                _storedProducts.Remove(product);
                consumedProducts.Add(product);
            }

            for (var i = 0; i < _storedProducts.Count; i++)
            {
                var xMultiplier = i % 10;
                var xPos = _startStoragePosition.x + (_positionStep *xMultiplier);
            
                var yMultiplier = i / 100;
                var yPos = _startStoragePosition.y + (_positionStep * yMultiplier);
            
                var zMultiplier = (i % 100) / 10;
                var zPos = _startStoragePosition.z - (_positionStep * zMultiplier);
            
                _storedProducts[i].Transform.localPosition = new Vector3(xPos, yPos, zPos);
            }

            return consumedProducts;
        }
    }
}