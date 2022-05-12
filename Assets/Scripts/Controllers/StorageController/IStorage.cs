using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public interface IStorage
    {
        void SetProduct(Vector3 startPosition, IProduct product);
        List<IProduct> GetProduct(Vector3 position, Transform parent);
    }
}