using BloodDonorReceiver.Core.BaseModel;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonorReceiver.Data.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNO {  get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public UserModel([NotNull] string name,
                         [NotNull] string surname,
                         [NotNull] string tCNO,
                         [NotNull] string birthday,
                         [NotNull] string email,
                         [NotNull] string phoneNumber,
                         [NotNull] string password,
                         [NotNull] string confirmPassword)
        {
            Name = name;
            Surname = surname;
            TCNO = tCNO;
            Birthday = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

    }
}
