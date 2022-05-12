using System;
using Managers.BuildingsManager;
using Managers.ProductManager;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Controllers.BuildingController
{
    public class BuildingController : Building
    {
        [Inject] protected BuildingsData _buildingsData;
        [Inject] protected IProductManager _productManager;

        public override void Init(BuildingType type)
        {
            _timer = 0.0f;
            _buildingType = type;
            _produceTime = _buildingsData.GetProduceTime(type);
            _productType = _buildingsData.GetProductType(type);
            _consumableTypes = _buildingsData.GetConsumableProducts(type);
            _body.material.color = _buildingsData.GetBodyColor(type);
            _storage.material.color = _buildingsData.GetStorageColor(type);
            transform.position = _buildingsData.GetSpawnPosition(type);
            
            _stock.material.color = _buildingsData.GetStockColor(type);
            _stock.gameObject.SetActive(_consumableTypes.Count > 0);
        }
        
        private void Update()
        {
            if (_storage.IsFull()) return;
            if (_stock.IsEmpty()) return;
            
            _timer += Time.deltaTime;
            _timerIndicator.fillAmount = _timer / _produceTime;
            
            if (_timer > _produceTime)
            {
                Consume();
                _timer = 0.0f;
            }
        }

        public override void Consume()
        {
            _stock.GetProduct(transform.position, transform);
            Produce();
        }

        public override void Produce()
        {
            var product = _productManager.Produce(_productType, _storage.transform);
            var startPos = product.Transform.InverseTransformPoint(transform.position);
            _storage.SetProduct(startPos, product);
        }
    }
}