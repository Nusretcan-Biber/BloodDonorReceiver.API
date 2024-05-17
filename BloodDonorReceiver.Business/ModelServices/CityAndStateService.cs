using BloodDonorReceiver.Business.IModelServices;
using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorReceiver.Business.ModelServices
{
    public class CityAndStateService : ICityAndStateService
    {
        public List<CityModel> GetAllCities()
        {
            using(var uow = new UnitOfWork<MasterContext>())
            {
                var cityList = uow.GetRepository<CityModel>().GetAll().AsNoTracking().ToList();
                if (cityList.Count < 0)
                    return null;
                return cityList;
            }
        }

        public List<StateModel> GetAllStates()
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var stateList = uow.GetRepository<StateModel>().GetAll().AsNoTracking().ToList();
                if (stateList.Count < 0)
                    return null;
                return stateList;
            }
        }
    }
}
