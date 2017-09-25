using System;
using System.Collections.Generic;
using System.Text;

namespace XFormMD_Deploy.Models
{
    class CustomerInfo
    {
        public string Fullname { get; set; }
        public string BirthDay { get; set; }
        public string Gender { get; set; }
        public string CustomerVIPType { get; set; }
        public IDInfo IDInfo { get; set; }
        public Address Address { get; set; }
        public JobInfo JobInfo { get; set; }
        public string ManageStaffID { get; set; }
        public string RowOrder { get; set; }
    }
}
