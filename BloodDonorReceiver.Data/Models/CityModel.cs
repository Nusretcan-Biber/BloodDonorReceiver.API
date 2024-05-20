namespace BloodDonorReceiver.Data.Models
{
    public class CityModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DonorsCitiesModel> DonorsCities { get; set; }
        public virtual ICollection<StateModel> States { get; set; }
        public virtual ICollection<BloodCenterModel> BloodCenters { get; set; }
        public virtual ICollection<ReceiversCitiesModel> ReceiversCities { get; set; }
    }
}
