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
        [Inject] private BuildingsData _buildingsData;
        [Inject] private IProductManager _productManager;

        [SerializeField] private Image _timerIndicator;

        private float _timer;

        public override void Init(BuildingType type)
        {
            _buildingType = type;
            transform.position = _buildingsData.GetSpawnPosition(type);
            _body.material.color = _buildingsData.GetBodyColor(type);
            _stock.material.color = _buildingsData.GetStockColor(type);
            _storage.material.color = _buildingsData.GetStorageColor(type);
            _produceTime = _buildingsData.GetProduceTime(type);
            _productType = _buildingsData.GetProductType(type);
            _timer = 0.0f;
        }

        private void Update()
        {
            if (_storage.IsFull()) return;
            _timer += Time.deltaTime;
            _timerIndicator.fillAmount = _timer / _produceTime;
            if (_timer > _produceTime)
            {
                Produce();
                _timer = 0.0f;
            }
        }

        public override void Produce()
        {
            _storage.SetProduct(_productManager.Produce(_productType, _storage.transform));
        }
    }
}