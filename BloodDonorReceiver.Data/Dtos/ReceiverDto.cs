using BloodDonorReceiver.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorReceiver.Data.Dtos
{
    public class ReceiverDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public string? Description { get; set; }
    }
}
