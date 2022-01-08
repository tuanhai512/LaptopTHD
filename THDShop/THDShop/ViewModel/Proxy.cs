using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel
{
    public class Proxy
    {
        public interface IMath
        {
            int USD_PRICE(int? x);
        }
        public class Math : IMath
        {
            public int USD_PRICE(int? x) { return (int)x; }
            
        }
    }
}