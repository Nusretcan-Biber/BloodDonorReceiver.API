using BloodDonorReceiver.Core.BaseModels;

namespace BloodDonorReceiver.Core.BaseModel
{
    public class BaseModel : IBaseModel, IBaseDateOperationModel,IBaseControlOperationModel
    {
        public Guid Guid { get; set; }
        public bool IsUpdated { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public BaseModel()
        {
            Guid = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            IsUpdated = false;
            IsDeleted = false;
            
        }
    }
}
