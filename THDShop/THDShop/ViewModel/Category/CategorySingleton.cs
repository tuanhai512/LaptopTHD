using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Category
{
    public class CategorySingleton
    {
        public static CategorySingleton Instance { get; } = new CategorySingleton();
        public List<CategoryDTO> listCategory { get; } = new List<CategoryDTO>();
        private CategorySingleton() { }

        public void Init(QLLaptopShopEntities _context)
        {
            if (listCategory.Count == 0)
            {
                var query = from c in _context.CATEGORIES
                            select new CategoryDTO
                            {
                                ID = c.ID,
                                NAME = c.NAME
                            };
                foreach (var item in query)
                {
                    listCategory.Add(item);
                }
            }
        }
    }
}