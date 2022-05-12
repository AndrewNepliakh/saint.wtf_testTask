using Managers.ProductManager;
using Zenject;

namespace Controllers
{
    public class ProductController : Product
    {
        [Inject] private ProductData _productData;
        public override void Init(ProductType type)
        {
            _productType = type;
            _body.material.color = _productData.GetBodyColor(type);
        }
    }
}