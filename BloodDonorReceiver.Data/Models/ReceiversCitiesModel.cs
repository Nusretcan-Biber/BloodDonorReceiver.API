namespace BloodDonorReceiver.Data.Models
{
    public class ReceiversCitiesModel
    {
        public Guid Guid { get; set; }
        public Guid ReceiversGuid { get; set; }
        public int CitysId { get; set; }

        public virtual ReceiverModel Receiver { get; set; }
        public virtual CityModel City { get; set; }
    }
}
