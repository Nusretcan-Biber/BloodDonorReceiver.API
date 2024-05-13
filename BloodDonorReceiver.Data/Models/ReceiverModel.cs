using BloodDonorReceiver.Core.BaseModel;
using BloodDonorReceiver.Data.Enums;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonorReceiver.Data.Models
{
    public class ReceiverModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public string? Description { get; set; }


        public virtual UserModel Users { get; set; }

        public ReceiverModel([NotNull] string name,
                             [NotNull] string surname,
                             [NotNull] string birthday,
                             [NotNull] string gender,
                             [NotNull] string phoneNumber,
                             [NotNull] string email,
                             [NotNull] BloodTypeEnum bloodType,
                             string description)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            BloodType = bloodType;
            Description = description;
        }
    }
}
