using UnityEngine;

namespace Controllers
{
    public abstract class Product : MonoBehaviour, IProduct
    {
        public ProductType Type => _productType;
        protected ProductType _productType;

        [SerializeField] protected MeshRenderer _body;

        public abstract void Init(ProductType type);
        public void Move(Vector3 position)
        {
            transform.position = position;
        }
    }

    public enum ProductType
    {
        Free,
        ForOne,
        ForTwo
    }
}