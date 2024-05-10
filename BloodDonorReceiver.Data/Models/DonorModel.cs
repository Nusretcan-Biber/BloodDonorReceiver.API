using BloodDonorReceiver.Data.Enums;

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
        public BloodTypeEnum BloodType{ get; set; }

    }
}
