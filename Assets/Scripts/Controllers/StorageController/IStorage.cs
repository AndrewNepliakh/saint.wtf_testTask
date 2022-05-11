using UnityEngine;

namespace Controllers.StorageController
{
    public interface IStorage
    {
        void SetProduct(IProduct product);
        IProduct GetProduct(Vector3 position);
    }
}