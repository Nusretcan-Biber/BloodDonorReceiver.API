﻿using BloodDonorReceiver.Data.Enums;
using BloodDonorReceiver.Core.BaseModel;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonorReceiver.Data.Models
{
    public class DonorModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public BloodTypeEnum BloodType{ get; set; }
        public string Description { get; set; }
        public bool IsCronicIllness { get; set; }
        public string TCNO {  get; set; }
        public Guid UserGuid { get; set; }

        public virtual UserModel Users { get; set; }

        internal DonorModel()
        {
            
        }
        public DonorModel([NotNull] string name,
                          [NotNull] string surname,
                          [NotNull] string birthday,
                          [NotNull] GenderTypeEnum gender,
                          [NotNull] string phoneNumber,
                          [NotNull] string email,
                          [NotNull] BloodTypeEnum bloodType,
                          string description,
                          [NotNull] bool isCronicIllness,
                          string tCNO)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            BloodType = bloodType;
            Description = description;
            IsCronicIllness = isCronicIllness;
            TCNO = tCNO;
        }

    }
}
