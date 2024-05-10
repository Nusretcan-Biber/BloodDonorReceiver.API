namespace BloodDonorReceiver.Core.BaseModel
{
    public class BaseModel : IBaseModel
    {
        public Guid Guid { get; set; }
        public DateTime CreatedDate { get ; set ; }

        public BaseModel()
        {
            Guid = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
    }
}
