using BloodDonorReceiver.Data.Enums;
using BloodDonorReceiver.Core.BaseModel;
using System.Diagnostics.CodeAnalysis;

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

        public DonorModel([NotNull] string name,
                          [NotNull] string surname,
                          [NotNull] string birthday,
                          [NotNull] string gender,
                          [NotNull] string phoneNumber,
                          [NotNull] string email,
                          [NotNull] BloodTypeEnum bloodType)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            BloodType = bloodType;
        }

    }
}
