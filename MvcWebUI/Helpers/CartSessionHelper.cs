using Entities.DomainModels;
using MvcWebUI.Extensions;

namespace MvcWebUI.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
        private IHttpContextAccessor _contextAccessor;

        public CartSessionHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public void Clear()
        {
            _contextAccessor.HttpContext.Session.Clear();
        }

        public Cart GetCart(string key)
        {
            Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(key);
            if(cartToCheck == null) {
                SetCart(new Cart(), key);
                cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(key);
            }

            return cartToCheck;
        }

        public void SetCart(Cart cart, string key)
        {
            _contextAccessor.HttpContext.Session.SetObject(key, cart);
        }
    }
}
