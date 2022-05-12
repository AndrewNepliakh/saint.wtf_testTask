using UnityEngine;

namespace Controllers
{
    public class StockController : StorageController
    {
        public bool IsEmpty() => _storedProducts.Count == 0;

    }
}