using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCallApplication.Models.ViewModel
{
    public class ServiceCompanyVM
    {

        private Service_Company ModelObj;
        private Service_Company scomapny;
        private ServiceCallEntities db1;
        public int Company_id { get; set; }
        public string Company_Name { get; set; }
        public string Address { get; set; }
        public string Email_ID_For_Display { get; set; }
        public byte[] Logo { get; set; }

        public ServiceCompanyVM(Service_Company ModelObj, ServiceCallEntities db)
        {
            // TODO: Complete member initialization
            this.ModelObj = ModelObj;
            this.db = db;
        }

        public ServiceCompanyVM(ServiceCallEntities db1, Service_Company scomapny)
        {
            // TODO: Complete member initialization
            this.db1 = db1;
            this.scomapny = scomapny;
        }



        public ServiceCallEntities db { get; set; }
    }
}