using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel
{
   
        abstract class LoaiSp
        {
            public abstract LoaiLaptop create();

        }
        abstract class LoaiLaptop { }

        class LaptopGM : LoaiLaptop
        {
            public int ID { get; set; }
            public int HOTPRODUCT { get; set; }
            public string NAME { get; set; }
            public int QUANTITY { get; set; }
            public int PRICE { get; set; }
            public int USD_PRICE { get; set; }
            public int ORI_PRICE { get; set; }
            public string DESCRIPTION { get; set; }
            public string DESCRIPTION_CPU { get; set; }
            public string DESCRIPTION_RAM { get; set; }
            public string DESCRIPTION_STORAGE { get; set; }
            public string DESCRIPTION_CARD { get; set; }
            public string DESCRIPTION_SCREEN { get; set; }
            public string DESCRIPTION_WEIGHT { get; set; }
            public string IMAGE { get; set; }
            public string CATEGORYNAME { get; set; }
            public string theloaiLapt { get; set; }
            public Nullable<int> IDCATEGORY { get; set; }
        }
        class LaptopVP : LoaiLaptop
        {
            public int ID { get; set; }
            public int HOTPRODUCT { get; set; }
            public string NAME { get; set; }
            public int QUANTITY { get; set; }
            public int PRICE { get; set; }
            public int USD_PRICE { get; set; }
            public int ORI_PRICE { get; set; }
            public string DESCRIPTION { get; set; }
            public string DESCRIPTION_CPU { get; set; }
            public string DESCRIPTION_RAM { get; set; }
            public string DESCRIPTION_STORAGE { get; set; }
            public string DESCRIPTION_CARD { get; set; }
            public string DESCRIPTION_SCREEN { get; set; }
            public string DESCRIPTION_WEIGHT { get; set; }
            public string IMAGE { get; set; }
            public string CATEGORYNAME { get; set; }
            public string theloaiLapt { get; set; }
            public Nullable<int> IDCATEGORY { get; set; }
        }

        class Gaming : LoaiSp
        {
            public override LoaiLaptop create()
            {
                return new LaptopGM();
            }
        }
        class VanPhong : LoaiSp
        {
            public override LoaiLaptop create()
            {
                return new LaptopVP();
            }
        }
        class Clientclass
        {
            public LaptopGM _laptopGM;

            public LaptopVP _laptopVP;
            public Clientclass (LoaiSp loaisp)
            {
                _laptopGM = (LaptopGM)loaisp.create();
            _laptopVP = (LaptopVP)loaisp.create();
        }
    }
    }

