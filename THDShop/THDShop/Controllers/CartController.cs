using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel;
using THDShop.ViewModel.DeliAddress;

namespace THDShop.Controllers
{
    public class CartController : Controller
    {
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        //Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int id)
        {
            var product = _db.PRODUCTS.SingleOrDefault(s => s.ID == id);
            if (product != null)
            {
                GetCart().Add_Product_Cart(product);
            }
            return RedirectToAction("ShowToCart", "Cart");
        }

        //Show giỏ hàng
        public ActionResult ShowToCart()
        {
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        //Buttons cập nhật giỏ hàng
        public ActionResult UpdateCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_product = int.Parse(form["ID_PRODUCT"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_quantity(id_product, quantity);
            return RedirectToAction("ShowToCart", "Cart");
        }

        //Buttons xóa giỏ hàng
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "Cart");
        }
        
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }

        //Thanh toán thành công
        public ActionResult CheckOutSuccess()
        {
            return View();
        }    

        //Đơn giao hàng
        public ActionResult DeliveryForm()
        {
            var Cart = GetCart();
            if (Cart.Total_quantity() == 0)
            {
                return RedirectToAction("Index", "HomeUser");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeliveryForm(CreateDeliAddressInput model)
        {
            var cart = GetCart();
            if (cart.Total_quantity() == 0)
            {
                ModelState.AddModelError("", "Gio Hang ko duoc de trong");
            }
            if (ModelState.IsValid)
            {
                //Không đăng nhập
                
                //Form Địa Chỉ
                var deliaddr = new DELI_ADDRESS()
                {
                    NAME = model.NAME,
                    PHONE = model.PHONE,
                    ADDRESS = model.ADDRESS,
                    DISTRICT = model.DISTRICT,
                    WARD = model.WARD,
                    NOTE = model.NOTE,
                };
                _db.DELI_ADDRESS.Add(deliaddr);
                _db.SaveChanges();

                //Order
                var order = new ORDER()
                {
                    DAY = DateTime.Now,
                    IDDELIADDRESS = deliaddr.ID,
                    TOTALMONEY = cart.Total_money(),
                };
                _db.ORDERS.Add(order);
                _db.SaveChanges();

                //Chi Tiết Order
                var de_order = new List<DE_ORDER>();
                foreach (var item in cart.Items)
                {
                    var detail = new DE_ORDER()
                    {
                        IDORDER = order.ID,
                        IDPRODUCT = item._product.ID,
                        QUANTITY= item._quantity,
                        PRICE = item._product.PRICE,
                    };
                    de_order.Add(detail);
                }
                foreach (var detail in de_order)
                {
                    _db.DE_ORDER.Add(detail);
                    foreach (var p in _db.PRODUCTS.Where(s => s.ID == detail.IDPRODUCT))
                    {
                        var update_quan_pro = p.QUANTITY - detail.QUANTITY;
                        p.QUANTITY = update_quan_pro;
                    }
                }
                _db.SaveChanges();
                cart.ClearCart();

                return RedirectToAction("CheckOutSuccess");
            }   
            else
            {
                ModelState.AddModelError("", "Vui Long nhap du du lieu.");
            }
            return View(model);
        }
    }
}