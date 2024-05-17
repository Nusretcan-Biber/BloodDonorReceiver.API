using BloodDonorReceiver.Data.Dtos;
using BloodDonorReceiver.Data.Enums;
using BloodDonorReceiver.Data.Models;
using System.Diagnostics.CodeAnalysis;

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
        public static DonorModel CheckNullValuesAndMapping(this UpdateDonorDto donorDto, DonorModel donorModel)
        {
            if (!string.IsNullOrEmpty(donorDto.Name))
                donorModel.Name = donorDto.Name;
            if (!string.IsNullOrEmpty(donorDto.Surname))
                donorModel.Surname = donorDto.Surname;
            if (!string.IsNullOrEmpty(donorDto.Birthday))
                donorModel.Birthday = donorDto.Birthday;
            if (!string.IsNullOrEmpty(donorDto.Gender))
                donorModel.Gender = donorDto.Gender;
            if (!string.IsNullOrEmpty(donorDto.Description))
                donorModel.Description = donorDto.Description;
            if (donorDto.IsCronicIllness.HasValue)
                donorModel.IsCronicIllness = bool.Parse(donorDto.IsCronicIllness.ToString());
            if (donorDto.BloodType.HasValue)
                donorModel.BloodType = Enum.Parse<BloodTypeEnum>(donorDto.BloodType.ToString());

            return donorModel;
        }
    }
}
