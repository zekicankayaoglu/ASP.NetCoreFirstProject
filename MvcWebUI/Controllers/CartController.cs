using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController:Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _sessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper sessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _sessionHelper = sessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            //ürün çek
            Product product = _productService.GetById(productId);
            var cart = _sessionHelper.GetCart("cart");
            _cartService.AddToCart(cart,product);
            _sessionHelper.SetCart(cart,"cart");
            TempData.Add("message", product.Productname + " sepete eklendi!");
            return RedirectToAction("Index","Product");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            var cart = _sessionHelper.GetCart("cart");
            _cartService.RemoveFromCart(cart,product);
            _sessionHelper.SetCart(cart,"cart");
            TempData.Add("message", product.Productname + " sepetten silindi!");
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Index()
        {
            var model = new CartListViewModel{
                Cart = _sessionHelper.GetCart("cart")
            };

            return View(model);
        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel{
                ShippingDetail = new ShippingDetail()
            };
            return View();
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", "Siparişiniz başarıyla tamamlandı");
            _sessionHelper.Clear();
            return RedirectToAction("Index", "Cart");
        }
    }
}
