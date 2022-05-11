using UnityEngine;

namespace Controllers
{
    public interface IStorage
    {
        void SetProduct(IProduct product);
        IProduct GetProduct(Vector3 position);
    }
}