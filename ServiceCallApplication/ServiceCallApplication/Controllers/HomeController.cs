using ServiceCallApplication.DAO;
using ServiceCallApplication.Models;
using ServiceCallApplication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceCallApplication.Controllers
{
    public class HomeController : Controller
    {
        ProductDAO productDAO = new ProductDAO();
        ProductDAO ProductMDAO = new ProductDAO();
        private ExpenseEntities db = new ExpenseEntities();
        int flag = 0;


        public ActionResult Index(ProductSearch searchObj)
        {
           // ProductList = db.Products.OrderBy(a => a.ProductName).ToList(); 
            List<Product>ProductList = db.Products.ToList();
            ProductList = db.Products.OrderBy(a => a.ProductName).ToList(); 
            List<ProductVM> ProductVMList = new List<ProductVM>();

            foreach (Product product in ProductList)
            {
                ProductVM productVM = new ProductVM(db, product);
               ProductVMList.Add(productVM);
            }

            ProductSearch ProductSearch = new ProductSearch();
            ProductSearch.ProductVMList = ProductVMList;
            return View(ProductSearch);
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        //Insert
        public ActionResult Create(int ProductID = 0)
        {
            Product product = db.Products.Find(ProductID);
            ProductVM productVM = new ProductVM(db, product);

            return View(product);

        }


        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                new ProductDAO().saveProduct(productVM, db);
            }
           // ProductVM productVM = new ProductVM();
           // ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productVM.ProductID);
              return RedirectToAction("Index");
        }

        //Update
        [HttpGet]
        public ActionResult Update(int ProductID = 0)
        {
            // this step is done for finding the object from database and then modifying the same object that is the same row of Residential verification table.
            // here you should not create a new verification object . Due to this it is creating the new object and thus row in the database
            Product product = db.Products.Where(p => p.ProductID == ProductID).FirstOrDefault();
            return View(ProductMDAO.ProductModelToProductVM(product, db));
            // return View(ModelObj);
        }


        [HttpPost]
        public ActionResult Update(ProductVM ModelObj)
        {
            flag = ProductMDAO.Update(ModelObj, db);
            if (flag == 1)
            {

                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMsg"] = "Something went wrong!";
                return View(ModelObj);
            }
        }









/*
        public ActionResult Create(int ProductID = 0)
        {
            // ViewBag.Message = "Your app description page.";

            // return View();

           

            Product product = db.Products.Find(ProductID);
            ProductVM productVM = new ProductVM(db, product);

            return View(productVM);

        }

        public ActionResult SaveCreate(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                new ProductDAO().saveProduct(productVM, db);
            }
          // ProductVM productVM = new ProductVM();
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", productVM.ProductID);
            
            return RedirectToAction("Index");
        }
        */
     
        
       /* public ActionResult Update()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }*/
      public ActionResult Delete()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        //Delete

      /* public ActionResult Delete(String ProductID)
     {
         var AMModelObj = db.Products.Find(ProductID);
         if (AMModelObj == null)
         {
             return HttpNotFound();
         }
         if (ModelState.IsValid)
         {
             int userId = Convert.ToInt32(Session["LogedUserID"]);
             //AMModelObj.Active = "N";
           //  AMModelObj.SoftDelete = "Y";
             db.SaveChanges();
             return RedirectToAction("Index");
         }

         return RedirectToAction("Index");
     }*/

      public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IEnumerable<Product> productList { get; set; }

        public ProductVM productVM { get; set; }
    }
}
