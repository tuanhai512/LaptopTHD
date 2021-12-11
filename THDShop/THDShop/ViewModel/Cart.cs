using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace THDShop.ViewModel
{
    public class CartItem
    {
        public GIFT _gift { get; set; }
        public int _giftvalue { get; set; }
        public PRODUCT _product { get; set; }

        public int _quantity { get; set; }
    }
    public class Cart
    {
        QLLaptopShopEntities _db = new QLLaptopShopEntities();

        [NotMapped]
        public string ErrorRegister { get; set; }
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add_Product_Cart(PRODUCT prod, int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ID == prod.ID);
            if (item == null)
                items.Add(new CartItem
                {
                    _product = prod,
                    _quantity = _quan
                });
            else
                item._quantity += _quan;
        }

        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }
        public int Total_money()
        {
            var total = items.Sum(s => s._quantity * s._product.PRICE);
            return (int)total;
        }

        public int Total_money_USD()
        {
            var total = items.Sum(s => s._quantity * s._product.USD_PRICE);
            return (int)total;
        }
        public void Update_quantity(int id, int _quan)
        {
            var item = items.Find(s => s._product.ID == id);
            if (item != null)
            {
                item._quantity = _quan;
            }
        }
        public int Total_OriPrice()
        {
            var total = items.Sum(s => s._quantity * s._product.ORI_PRICE);
            return (int)total;
        }
        public int Total_money_GIFT()
        {
            int gift = Total_money() - Total_money() * _value / 100;
            return gift;
        }
        public int total_discound { get; set; }
        public int _value { get; set; }
        public void Update_gift(string id,int value)
        {
            var gift = _db.GIFTs.Where(s => s.ID == id);
            {
                _value = value;
            }
        }

        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._product.ID == id);
        }
        public void ClearCart()
        {
            items.Clear();
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s._quantity);
        }
    }
}