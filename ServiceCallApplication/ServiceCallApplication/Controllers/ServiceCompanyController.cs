using ServiceCallApplication.DAO;
using ServiceCallApplication.Models;
using ServiceCallApplication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;

namespace ServiceCallApplication.Controllers
{
    public class ServiceCompanyController : Controller
    {
        
         private ServiceCallEntities db = new ServiceCallEntities();
   
         public ActionResult Create(int Company_id = 0)
        {
            Service_Company scomapny = db.Service_Company.Find(Company_id);
            ServiceCompanyVM SCompanyVM = new ServiceCompanyVM(db, scomapny);

            return View(SCompanyVM);

        }

         ActionResult View(ServiceCompanyVM scVM)
         {
             throw new NotImplementedException();
         }

        // POST: /ResidentialVerification/Create

       // [HttpPost]
         public ActionResult Create(ServiceCompanyVM SCompanyVM)
        {
           if (ModelState.IsValid)
            {
                new ServiceCompanyDAO().saveServiceCompany(SCompanyVM, db);
            }
           return RedirectToAction("Index");
        }
        }

    }
