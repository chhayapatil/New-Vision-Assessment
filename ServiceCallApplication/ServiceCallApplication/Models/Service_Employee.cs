//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceCallApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service_Employee
    {
        public Service_Employee()
        {
            this.Service_Location_Tracking = new HashSet<Service_Location_Tracking>();
            this.Service_Ticket = new HashSet<Service_Ticket>();
        }
    
        public int Employee_id { get; set; }
        public string Emplyoyee_Name { get; set; }
        public string User_id { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> Date_Of_Joining { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Soft_Delete { get; set; }
        public string Phone_No { get; set; }
        public string Email_ID { get; set; }
        public byte[] Photo { get; set; }
        public string User_Type { get; set; }
    
        public virtual ICollection<Service_Location_Tracking> Service_Location_Tracking { get; set; }
        public virtual ICollection<Service_Ticket> Service_Ticket { get; set; }
    }
}
