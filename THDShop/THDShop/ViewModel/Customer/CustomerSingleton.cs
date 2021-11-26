
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Customer
{
    public class CustomerSingleton
    {
        public static CustomerSingleton Instance { get; } = new CustomerSingleton();
        public List<CustomerDTO> listCustomer { get; } = new List<CustomerDTO>();
        private CustomerSingleton() { }

        public void Init(QLLaptopShopEntities _context)
        {
            if (listCustomer.Count == 0)
            {
                var query = from c in _context.CUSTOMERs
                            select new CustomerDTO
                            {
                                ID = c.ID,
                                NAME = c.NAME
                            };
                foreach (var item in query)
                {
                    listCustomer.Add(item);
                }
            }
        }
    }
}