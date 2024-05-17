using BloodDonorReceiver.Data.Models;

namespace BloodDonorReceiver.Business.IModelServices
{
    public interface IBloodCenterService
    {
        public List<BloodCenterModel> GetAllBloodCenters();
        public List<BloodCenterModel> GetBloodCenterByCityAndStateId(int cityId, int stateID);
        public List<BloodCenterModel> GetBloodCenterByStateId(int stateID);
        public List<BloodCenterModel> GetBloodCenterByCityId(int cityId);
    }
}
