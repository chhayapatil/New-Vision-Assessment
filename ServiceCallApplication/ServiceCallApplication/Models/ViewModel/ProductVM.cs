using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceCallApplication.Models.ViewModel
{
    public class ProductVM
    {
       private ExpenseEntities db;
       private Product product;
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ProductDescription { get; set; }
        public SelectList ProductList { get; set; }
        public List<ProductVM> AttachmentVMList { get; set; }
        public List<ProductVM> AttachmentVM { get; set; }

        public Product ModelObj { get; set; }

        public object ProductVMList { get; set; }

         public ProductVM(Product ModelObj, ExpenseEntities db)
        {
            // TODO: Complete member initialization
            this.ModelObj = ModelObj;
            this.db = db;
        }
        
        public ProductVM()
        {
            ExpenseEntities db = new ExpenseEntities();
            this.ProductList = new SelectList(db.Products.Where(p => p.ProductID == 1).ToList(), "ProductName", "ProductDescription");
        }

        public ProductVM(ExpenseEntities db, Product product)
        {
            // TODO: Complete member initialization
            this.db = db;
            this.product = product;
            this.ProductList = new SelectList(db.Products.Where(p => p.ProductID == 1).ToList(), "ProductName", "ProductDescription");

        }
       
    }
    
        
}