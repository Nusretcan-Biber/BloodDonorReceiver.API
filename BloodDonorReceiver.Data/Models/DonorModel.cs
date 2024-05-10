using BloodDonorReceiver.Data.Enums;
using BloodDonorReceiver.Core.BaseModel;

namespace BloodDonorReceiver.Data.Models
{
    public class DonorModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public BloodTypeEnum BloodType{ get; set; }

    }
}
