namespace BloodDonorReceiver.Core.BaseModel
{
    public interface IBaseModel
    {
        public Guid Guid { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
