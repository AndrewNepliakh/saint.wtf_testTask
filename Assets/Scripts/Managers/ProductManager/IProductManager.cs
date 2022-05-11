using Controllers;
using UnityEngine;

namespace Managers.ProductManager
{
    public interface IProductManager
    {
        IProduct Produce(ProductType type, Transform parent);
    }
}