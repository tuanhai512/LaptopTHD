using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
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

        //Buttons cập nhật voucher
        public ActionResult UpdateGift(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string id_gift = form["ID_Gift"];
            var gift = _db.GIFTs.Where(s => s.ID == id_gift).FirstOrDefault();
            int value = gift.G_VALUE;
            if(gift != null)
            {
                Session["ID_GIFT"] = gift.ID;
                cart.Update_gift(id_gift,value);
            }
            return RedirectToAction("ShowToCart", "Cart");
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
        //Thanh Toan That Bai
        public ActionResult CheckOutFail()
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
                //Không khuyến mãi
                //Form Địa Chỉ
                if (Session["ID_Gift"] == null)
                {
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
                        ORI_PRICE=cart.Total_OriPrice()
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
                            QUANTITY = item._quantity,
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

                //Không đăng nhập
                //Có khuyến mãi
                //Form Địa Chỉ
                else if (Session["ID_Gift"] != null)
                {
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
                        TOTALMONEY = cart.Total_money_GIFT(),
                        ORI_PRICE = cart.Total_OriPrice()

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
                            QUANTITY = item._quantity,
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
            }
            else
            {
                ModelState.AddModelError("", "Vui Long nhap du du lieu.");
            }
            return View(model);
        }


        //PayPal

        public ActionResult DeliveryFormPayPal()
        {
            var Cart = GetCart();
            if (Cart.Total_quantity() == 0)
            {
                return RedirectToAction("Index", "HomeUser");
            }

            return View();
        }
        // Work with Paypal Payment
        private Payment payment;

        // Create a paypment using an APIContext
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList() { items = new List<Item>() };

            Cart cart = Session["Cart"] as Cart;
            foreach (var carT in cart.Items)
            {
                listItems.items.Add(new Item()
                {
                    name = carT._product.NAME,
                    currency = "USD",
                    price = carT._product.USD_PRICE.ToString(),
                    quantity = carT._quantity.ToString(),
                    sku = "sku"
                });
            }

            var payer = new Payer() { payment_method = "paypal" };

            // Do the configuration RedirectURLs here with redirectURLs object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            // Create details object
            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = cart.Total_money_USD().ToString(),
            };

            // Create amount object
            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),// tax + shipping + subtotal
                details = details
            };

            // Create transaction
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "TDHShop transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return payment.Create(apiContext);
        }
        // Create ExecutePayment method
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult PaymentWithPaypal(DELI_ADDRESS model)
        {
            var guidParam = Request.Params["guid"];
            if ((model.NAME?.Trim().Length > 0
                && model.WARD?.Trim().Length > 0
                && model.DISTRICT?.Trim().Length > 0
                && model.ADDRESS?.Trim().Length > 0
                ) || Session[guidParam] != null)
            {
                if (Session[guidParam] == null)
                {
                    var cart = GetCart();
                    if (cart.Total_quantity() == 0)
                    {
                        ModelState.AddModelError("", "Gio Hang ko duoc de trong");
                    }
                    if (ModelState.IsValid)
                    {
                        var deliaddress = new DELI_ADDRESS()
                        {
                            NAME = model.NAME,
                            PHONE = model.PHONE,
                            ADDRESS = model.ADDRESS,
                            WARD = model.WARD,
                            DISTRICT = model.DISTRICT,
                        };

                        _db.DELI_ADDRESS.Add(deliaddress);
                        _db.SaveChanges();

                        int methods = 1;
                        var order = new ORDER()
                        {
                            IDDELIADDRESS = deliaddress.ID,
                            DAY = DateTime.Now,
                            TOTALMONEY = cart.Total_money(),
                            ORI_PRICE=cart.Total_OriPrice(),
                            METHODS = methods,
                        };
                        _db.ORDERS.Add(order);
                        _db.SaveChanges();

                        var de_order = new List<DE_ORDER>();
                        foreach (var item in cart.Items)
                        {
                            var detail = new DE_ORDER()
                            {
                                IDPRODUCT = item._product.ID,
                                IDORDER = order.ID,
                                QUANTITY = item._quantity,
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
                    }
                }

                // Gettings context from the paypal bases on clientId and clientSecret for payment
                APIContext apiContext = PaypalConfiguration.GetAPIContext();

                try
                {
                    string payerId = Request.Params["PayerID"];
                    if (string.IsNullOrEmpty(payerId))
                    {
                        // Creating a payment
                        string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Cart/PaymentWithPaypal?";
                        var guid = Convert.ToString((new Random()).Next(100000));
                        var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);

                        // Get links returned from paypal response to create call funciton
                        var links = createdPayment.links.GetEnumerator();
                        string paypalRedirectUrl = string.Empty;

                        while (links.MoveNext())
                        {
                            Links link = links.Current;
                            if (link.rel.ToLower().Trim().Equals("approval_url"))
                            {
                                paypalRedirectUrl = link.href;
                            }
                        }

                        Session.Add(guid, createdPayment.id);
                        return Redirect(paypalRedirectUrl);
                    }
                    else
                    {
                        var executedPayment = ExecutePayment(apiContext, payerId, Session[guidParam] as string);
                        if (executedPayment.state.ToLower() != "approved")
                        {
                            Session.Remove("Cart");
                            return View("CheckOutFail");
                        }
                    }
                }
                catch (Exception ex)
                {
                    PaypalLogger.Log("Error: " + ex.Message);
                    Session.Remove("Cart");
                    return View("CheckOutFail");
                }
                Session.Remove("Cart");
                return View("CheckoutSuccess");
            }
            Session.Remove("Cart");
            return View("CheckoutSuccess");
        }
    }
}