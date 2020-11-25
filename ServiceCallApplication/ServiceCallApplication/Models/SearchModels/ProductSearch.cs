using ServiceCallApplication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCallApplication.Models
{
    public class ProductSearch
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ProductDescription { get; set; }
        public List<ProductVM> ProductVMList { get; set; }
    }
}