using BloodDonorReceiver.Data.Enums;

namespace BloodDonorReceiver.Data.Dtos
{
    public class ReceiverDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public GenderTypeEnum Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public BloodTypeEnum BloodType { get; set; }
        public string? Description { get; set; }
        public string TCNO { get; set; }
        public int CityId { get; set; }
    }
}
