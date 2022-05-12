using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class StorageController : MonoBehaviour, IStorage
    {
        public Material material => _floor.material;
        public int ProductsCount => _storedProducts.Count;

        [SerializeField] protected MeshRenderer _floor;
        protected Vector3 _startStoragePosition = new Vector3(-2.25f, 0.0f, 2.25f);
        protected float _positionStep = 0.5f;

        protected List<IProduct> _storedProducts = new List<IProduct>();
        
        private int _limit = 200;

        public void SetProduct(Vector3 startPosition, IProduct product)
        {
            var xMultiplier = _storedProducts.Count % 10;
            var xPos = _startStoragePosition.x + (_positionStep *xMultiplier);
            
            var yMultiplier = _storedProducts.Count / 100;
            var yPos = _startStoragePosition.y + (_positionStep * yMultiplier);
            
            var zMultiplier = (_storedProducts.Count % 100) / 10;
            var zPos = _startStoragePosition.z - (_positionStep * zMultiplier);
            
            var position = new Vector3(xPos, yPos, zPos);
            
            product.Move(startPosition, position);
            _storedProducts.Add(product);
        }
        
        public virtual List<IProduct> GetProduct(Vector3 position, Transform parent)
        {
            if (_storedProducts.Count <= 0) return null;
            var product = _storedProducts[_storedProducts.Count - 1];
            _storedProducts.Remove(product);
            product.Transform.SetParent(parent);
            product.Move(product.Transform.position, position);
            return new List<IProduct>{product};
        }

        public bool IsFull() => _storedProducts.Count >= _limit;
    }
}