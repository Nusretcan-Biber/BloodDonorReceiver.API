using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorReceiver.Business.ModelServices
{
    public class BloodCenterService : IBloodCenterService
    {
        public List<BloodCenterModel> GetAllBloodCenters()
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var bloodCentersList = uow.GetRepository<BloodCenterModel>().GetAll().AsNoTracking().ToList();
                if (bloodCentersList.Count < 0)
                    return null;
                return bloodCentersList;
            }
        }

        public List<BloodCenterModel> GetBloodCenterByCityAndStateId(int cityId, int stateID)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var bloodCentersList = uow.GetRepository<BloodCenterModel>().GetAll(x => x.CityId == cityId && x.StateId == stateID).AsNoTracking().ToList();
                if (bloodCentersList.Count < 0)
                    return null;
                return bloodCentersList;
            }
        }

        public List<BloodCenterModel> GetBloodCenterByStateId(int stateID)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var bloodCentersList = uow.GetRepository<BloodCenterModel>().GetAll(x => x.StateId == stateID).AsNoTracking().ToList();
                if (bloodCentersList.Count < 0)
                    return null;
                return bloodCentersList;
            }
        }

        public List<BloodCenterModel> GetBloodCenterByCityId(int cityId)
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var bloodCentersList = uow.GetRepository<BloodCenterModel>().GetAll(x => x.CityId == cityId).AsNoTracking().ToList();
                if (bloodCentersList.Count < 0)
                    return null;
                return bloodCentersList;
            }
        }
    }
}
