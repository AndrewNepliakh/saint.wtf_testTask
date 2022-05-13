using System;
using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Controllers
{
    public abstract class Product : MonoBehaviour, IProduct
    {
        public bool IsConsume { get; set; }
        public ProductType Type => _productType;
        public Transform Transform => transform;
        public GameObject GameObject => gameObject;
        protected ProductType _productType;

        [SerializeField] protected MeshRenderer _body;

        protected Coroutine _moveRoutine;
        protected float _speed = 4.0f;

        public abstract void Init(ProductType type);
        public abstract void Move(Vector3 startPosition, Vector3 endPosition);

    }

    public enum ProductType
    {
        Free,
        ForOne,
        ForTwo,
        ForThree
    }
}