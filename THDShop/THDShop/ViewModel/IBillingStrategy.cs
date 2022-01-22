using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel
{
    interface ISaleStrategy
    {
        int PriceOnSale(int value);
    }
    class Sale_Price : ISaleStrategy
    {
        public int PriceOnSale(int value)
        {        
            return value *2;
        }
    }
    class CalculateClient
    {
        private ISaleStrategy sale;
 
        public CalculateClient(ISaleStrategy strategy)
        {
            sale = strategy;
        }
 
        public int Calculate(int value)
        {
            return sale.PriceOnSale(value);
        }
    }
}