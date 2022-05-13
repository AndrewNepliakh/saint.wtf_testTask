using System;
using UnityEngine;

namespace Controllers
{
    public interface IProduct
    {
        bool IsConsume { get; set; }
        ProductType Type { get; }

        Transform Transform { get;}
        GameObject GameObject { get;}

        void Init(ProductType type);

        void Move(Vector3 startPosition, Vector3 endPosition);
    }
}