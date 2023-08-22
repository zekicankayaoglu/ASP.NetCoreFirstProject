using Entities.DomainModels;

namespace MvcWebUI.Helpers
{
    public interface ICartSessionHelper
    {
        Cart GetCart(string key);
        void SetCart(Cart cart,string key);
        void Clear();
    }
}
