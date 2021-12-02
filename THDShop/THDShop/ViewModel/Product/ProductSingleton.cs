using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Product
{
    public class ProductSingleton
    {
        public static ProductSingleton Instance { get; } = new ProductSingleton();
        public List<ProductDTO> listProduct { get; } = new List<ProductDTO>();
        private ProductSingleton() { }

        public void Init(QLLaptopShopEntities _context)
        {
            if (listProduct.Count == 0)
            {
                var query = from c in _context.PRODUCTS
                            select new ProductDTO
                            {
                                ID = c.ID,
                                HOTPRODUCT = c.HOTPRODUCT,
                                NAME = c.NAME,
                                PRICE = c.PRICE,
                                ORI_PRICE = c.ORI_PRICE,
                                DESCRIPTION = c.DESCRIPTION,
                                CATEGORYNAME = c.CATEGORy.NAME,
                                IDCATEGORY = c.IDCATEGORY,
                                QUANTITY = c.QUANTITY,
                                IMAGE = c.IMAGE,
                                DESCRIPTION_CPU = c.DESCRIPTION_CPU,
                                DESCRIPTION_RAM = c.DESCRIPTION_RAM,
                                DESCRIPTION_STORAGE = c.DESCRIPTION_STORAGE,
                                DESCRIPTION_CARD = c.DESCRIPTION_CARD,
                                DESCRIPTION_SCREEN = c.DESCRIPTION_SCREEN,
                                DESCRIPTION_WEIGHT = c.DESCRIPTION_WEIGHT
                            };
                foreach (var item in query)
                {
                    listProduct.Add(item);
                }
            }
        }

    }
}