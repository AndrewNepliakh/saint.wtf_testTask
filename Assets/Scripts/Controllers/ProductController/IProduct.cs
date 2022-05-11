using UnityEngine;

namespace Controllers
{
    public interface IProduct
    {
        ProductType Type { get; }
        
        void Init(ProductType type);

        void Move(Vector3 position);
    }
}