using ServiceCallApplication.Models;
using ServiceCallApplication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ServiceCallApplication.DAO
{
    public class ProductDAO
    {
        int flag = 0;
        public ExpenseEntities db = null;
        public void saveProduct(ProductVM productVM, ExpenseEntities db)
        {
            Product product = new Product();
            product.ProductID = productVM.ProductID;
            product.ProductName = productVM.ProductName;
            product.Price = productVM.Price;
            product.ProductDescription = productVM.ProductDescription;

            //residentialVerification.Resi_Final_Remarks = getResidentialVerificationRemarks(productVM, db);
            db.Products.Add(product);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
               // throw;
            }


        }


        public Product ProductVMToProductModel(ProductVM VMObj,ExpenseEntities db)
        {

            Product ModelObj = null;

            ModelObj = new Product();
            ModelObj.ProductID = VMObj.ProductID;
            ModelObj.ProductName = VMObj.ProductName;
            ModelObj.Price = VMObj.Price;
            ModelObj.ProductDescription = VMObj.ProductDescription;
           
           
            return ModelObj;
        }


        public ProductVM ProductModelToProductVM(Product ModelObj, ExpenseEntities db)
        {
           // ProductVM VMObj = new ProductVM();
            ProductVM VMObj = new ProductVM(ModelObj, db);
           return VMObj;
          /*  VMObj.ProductID = ModelObj.ProductID;
            VMObj.ProductName = ModelObj.ProductName;
            VMObj.Price = ModelObj.Price;
            VMObj.ProductDescription = ModelObj.ProductDescription;
           */
            // VMObj.AttachmentVMList = ModelObj.AttachmentVMList;
            // VMObj.Resi_Final_Remarks = getResidentialVerificationRemarks(residentialVerificationVM, db);
            //db.ResidentialVerificationVM.Add(VMObj);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                // throw;
            }

            return VMObj;
        }

        public int Update(ProductVM ProductVMObj, ExpenseEntities db)
        {
            try
            {
                Product ProductObj = ProductVMToProductModel(ProductVMObj, db);
                db.Entry(ProductObj).State = EntityState.Modified;
                db.SaveChanges();
                flag = 1;
            }
            catch (Exception ex)
            {
                flag = 0;
                //new ErrorController().ErrorWithData(ex, " Error while editing Purchase Requiition");

            }
            return flag;
        }
    }
}