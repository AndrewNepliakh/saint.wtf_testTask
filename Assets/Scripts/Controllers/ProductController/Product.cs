using System;
using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Controllers
{
    public abstract class Product : MonoBehaviour, IProduct
    {
        public ProductType Type => _productType;
        public Transform Transform => transform;
        protected ProductType _productType;

        [SerializeField] protected MeshRenderer _body;

        private Coroutine _moveRoutine;
        private float _speed = 4.0f;

        public abstract void Init(ProductType type);
        public void Move(Vector3 startPosition, Vector3 endPosition)
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
        }
    }

    public enum ProductType
    {
        Free,
        ForOne,
        ForTwo,
        ForThree
    }
}