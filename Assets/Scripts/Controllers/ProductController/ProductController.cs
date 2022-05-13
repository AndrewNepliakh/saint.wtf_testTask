using System.Collections;
using Managers.ProductManager;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class ProductController : Product
    {
        [Inject] private ProductData _productData;
        [Inject] private IProductManager _productManager;
        public override void Init(ProductType type)
        {
            _productType = type;
            _body.material.color = _productData.GetBodyColor(type);
        }
        
        public override void Move(Vector3 startPosition, Vector3 endPosition)
        {
            if (_moveRoutine == null) 
                _moveRoutine = StartCoroutine(MoveRoutine(startPosition, endPosition));
            else
            {
                StopCoroutine(_moveRoutine);
                _moveRoutine = null;
                _moveRoutine = StartCoroutine(MoveRoutine(startPosition, endPosition));
            }
        }

        private IEnumerator MoveRoutine(Vector3 startPosition, Vector3 endPosition)
        {
            var t = 0.0f;
            
            while (t < 1.0f)
            {
                t += Time.deltaTime * _speed;
                transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);
                yield return null;
            }

            if (IsConsume)
            {
                _productManager.Hide(this);
                IsConsume = false;
            }
        }
    }
}