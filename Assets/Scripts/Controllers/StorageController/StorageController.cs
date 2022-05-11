using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class StorageController : MonoBehaviour, IStorage
    {
        public Material material => _floor.material;
        
        [SerializeField] protected MeshRenderer _floor;
        protected Vector3 _startStoragePosition = new Vector3(-2.25f, 0.0f, 2.25f);
        protected float _positionStep = 0.5f;

        private Stack<IProduct> _storedProducts = new Stack<IProduct>();
        
        private int _limit = 200;

        public void SetProduct(IProduct product)
        {
            var xMultiplier = _storedProducts.Count % 10;
            var xPos = _startStoragePosition.x + (_positionStep *xMultiplier);
            
            var yMultiplier = _storedProducts.Count / 100;
            var yPos = _startStoragePosition.y + (_positionStep * yMultiplier);
            
            var zMultiplier = (_storedProducts.Count % 100) / 10;
            var zPos = _startStoragePosition.z - (_positionStep * zMultiplier);
            
            var position = new Vector3(xPos, yPos, zPos);
            
            product.Move(position);
            _storedProducts.Push(product);
        }

        public IProduct GetProduct(Vector3 position)
        {
            if (_storedProducts.Count <= 0) return null;
            var product = _storedProducts.Pop();
            product.Move(position);
            return product;
        }

        public bool IsFull() => _storedProducts.Count >= _limit;
    }
}