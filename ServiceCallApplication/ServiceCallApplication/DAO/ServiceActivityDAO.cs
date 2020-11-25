using ServiceCallApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceCallApplication.DAO
{
    public class ServiceActivityDAO
    {
        int flag = 0;
        public ServiceCallEntities db = null;
        public int AddActivity(Service_Activity serviceActivity, ServiceCallEntities db)
        {
            Service_Activity addOBj = new Service_Activity();
            Service_Activity addActivity = db.Service_Activity.Add(addOBj);

            if (addActivity != null)
            {
                db.SaveChanges();
                flag = 1;
            }
            return (flag);
        }
    }
}