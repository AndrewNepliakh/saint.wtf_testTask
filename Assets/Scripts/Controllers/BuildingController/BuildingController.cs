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
            _buildingType = type;
            transform.position = _buildingsData.GetSpawnPosition(type);
            _body.material.color = _buildingsData.GetBodyColor(type);
            _storage.material.color = _buildingsData.GetStorageColor(type);
            _produceTime = _buildingsData.GetProduceTime(type);
            _productType = _buildingsData.GetProductType(type);
            _timer = 0.0f;
        }

        protected virtual void Update()
        {
            if (_storage.IsFull()) return;
            
            _timer += Time.deltaTime;
            
            if (_timer > _produceTime)
            {
                Produce();
                _timer = 0.0f;
            }
            
            UpdateIndicator();
        }

        protected virtual void UpdateIndicator()
        {
            _timerIndicator.fillAmount = _timer / _produceTime;
        }

        public override void Produce()
        {
            var product = _productManager.Produce(_productType, _storage.transform);
            _storage.SetProduct(transform.position, product);
        }
    }
}