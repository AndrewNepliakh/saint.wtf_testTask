using UnityEngine;

namespace Controllers.BuildingController
{
    public class ConsumableBuildingController : BuildingController, IConsumable
    {
        [SerializeField] protected StockController _stock;

        public override void Init(BuildingType type)
        {
            base.Init(type);
            _stock.material.color = _buildingsData.GetStockColor(type);
        }

        private void Update()
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

        public void Produce()
        {
            if (Consume())
            {
                if (_stock.IsEmpty) return;
                base.Produce();
            }
        }

        protected override void UpdateIndicator()
        {
            if (_stock.IsEmpty) return;
            _timerIndicator.fillAmount = _timer / _produceTime;
        }

        public bool Consume()
        {
            return _stock.GetProduct(transform.position, transform)?.Count > 0;
        }
    }
}