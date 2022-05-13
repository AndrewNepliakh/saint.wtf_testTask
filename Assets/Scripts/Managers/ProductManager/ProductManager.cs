using System.Collections.Generic;
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
        private Queue<IProduct> _products = new Queue<IProduct>();

        public ProductManager()
        {
            _productPrefab = Resources.Load<ProductController>(Constants.PRODUCT_PATH);
        }

        public IProduct Produce(ProductType type, Transform parent)
        {
            IProduct product;
            
            if (_products.Count > 0)
            {
                product = _products.Dequeue();
                product.Transform.SetParent(parent);
                product.Transform.position = parent.position;
                product.GameObject.SetActive(true);
            }
            else
            {
                product = _diContainer.InstantiatePrefab(_productPrefab, parent.position, Quaternion.identity, parent)
                    .GetComponent<ProductController>();
            }
            
            product.Init(type);
            return product;
        }

        public void Hide(IProduct product)
        {
            product.GameObject.SetActive(false);
            _products.Enqueue(product);
        }
    }
}