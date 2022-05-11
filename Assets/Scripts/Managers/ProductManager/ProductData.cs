using System;
using System.Collections.Generic;
using Controllers;
using Controllers.BuildingController;
using Managers.BuildingsManager;
using UnityEngine;

namespace Managers.ProductManager
{
    [Serializable]
    public class ProductModel
    {
        public ProductType Type;
        public Color BodyColor;
    }

    [CreateAssetMenu(fileName = "ProductData", menuName = "Data/ProductData")]
    public class ProductData : ScriptableObject 
    {
        public List<ProductModel> productModels = new List<ProductModel>();

        public Color GetBodyColor(ProductType type) => productModels.Find(x => x.Type == type).BodyColor;
    }
}