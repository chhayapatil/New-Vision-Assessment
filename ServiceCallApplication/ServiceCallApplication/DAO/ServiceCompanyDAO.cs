using ServiceCallApplication.Models;
using ServiceCallApplication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ServiceCallApplication.DAO
{
    public class ServiceCompanyDAO
    {
        public void saveServiceCompany(ServiceCompanyVM SCompanyVM, ServiceCallEntities db)
        {
            Service_Company scompany = new Service_Company();
            scompany.Company_id = SCompanyVM.Company_id;
            scompany.Company_Name = SCompanyVM.Company_Name;
            scompany.Email_ID_For_Display = SCompanyVM.Email_ID_For_Display;
            scompany.Logo = SCompanyVM.Logo;

            db.Service_Company.Add(scompany);


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


            }


        }
    }
}