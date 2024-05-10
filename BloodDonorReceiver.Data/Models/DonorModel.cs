using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorReceiver.Data.Models
{
    public class DonorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public  MyProperty { get; set; }

    }
}
