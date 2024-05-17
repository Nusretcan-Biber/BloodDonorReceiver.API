namespace BloodDonorReceiver.Data.Models
{
    public class BloodCenterModel
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string BloodDonationCenterName {  get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }



        public virtual CityModel City { get; set; }
        public virtual StateModel State { get; set;}

    }
}
