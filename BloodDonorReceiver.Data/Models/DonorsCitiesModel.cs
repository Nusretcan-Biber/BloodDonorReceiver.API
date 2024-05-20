namespace BloodDonorReceiver.Data.Models
{
    public class DonorsCitiesModel
    {
        public Guid Guid { get; set; }
        public Guid DonorsGuid { get; set; }
        public int CitysId { get; set; }


        public virtual DonorModel Donor { get; set; }
        public virtual CityModel City { get; set; }
    }
}
