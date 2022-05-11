using System.Collections.Generic;
using UnityEngine;

namespace Controllers.StorageController
{
    public class StorageController : MonoBehaviour, IStorage
    {
        private Vector3 _startStoragePosition = new Vector3(-2.25f, 0.0f, 2.25f);
        private float _positionStep = 0.5f;

        private Stack<IProduct> _storedProducts = new Stack<IProduct>();

        public void SetProduct(IProduct product)
        {
            var xMultiplier = _storedProducts.Count % 10;
            var xPos = _startStoragePosition.x + (_positionStep *xMultiplier);
            
            var yMultiplier = _storedProducts.Count / 100;
            var yPos = _startStoragePosition.y + (_positionStep * yMultiplier);
            
            var zMultiplier = _storedProducts.Count / 10;
            var zPos = _startStoragePosition.z + (_positionStep * zMultiplier);
            
            var position = new Vector3(xPos, yPos, zPos);
            
            product.Move(position);
            _storedProducts.Push(product);
        }

        public IProduct GetProduct(Vector3 position)
        {
           var product = _storedProducts.Pop();
           product.Move(position);
           return product;
        }
    }
}