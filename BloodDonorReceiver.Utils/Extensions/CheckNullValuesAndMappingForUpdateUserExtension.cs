using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Models;

namespace BloodDonorReceiver.Utils.Extensions
{
    public static class CheckNullValuesAndMappingForUpdateUserExtension
    {
        public static UserModel CheckNullValuesAndMapping(this UpdateUserDto userDto, UserModel user)
        {
            if (!string.IsNullOrEmpty(userDto.Name))
                user.Name = userDto.Name;
            if (!string.IsNullOrEmpty(userDto.Surname))
                user.Surname = userDto.Surname;
            if (!string.IsNullOrEmpty(userDto.PhoneNumber))
                user.PhoneNumber = userDto.PhoneNumber;
            if (!string.IsNullOrEmpty(userDto.Birthday))
                user.Birthday = userDto.Birthday;
            if (!string.IsNullOrEmpty(userDto.ConfirmPassword))
                user.ConfirmPassword = userDto.ConfirmPassword;
            if (!string.IsNullOrEmpty(userDto.Password))
                user.Password = userDto.Password;
            if (!string.IsNullOrEmpty(userDto.Email))
                user.Email = userDto.Email;

            return user;
        }
    }
}
