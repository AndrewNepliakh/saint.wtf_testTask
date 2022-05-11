using Controllers;
using UnityEditorInternal;
using UnityEngine;
using Zenject;

namespace Managers.ProductManager
{
    public class ProductManager : IProductManager
    {
        private ProductController _productPrefab;
        [Inject] private DiContainer _diContainer;

        public ProductManager()
        {
            _productPrefab = Resources.Load<ProductController>(Constants.PRODUCT_PATH);
        }

        public IProduct Produce(ProductType type, Transform parent)
        {
            var product = _diContainer.InstantiatePrefab(_productPrefab, parent.position, Quaternion.identity, parent)
                .GetComponent<ProductController>();
            product.Init(type);
            return product;
        }
    }
}