using BloodDonorReceiver.Data.Models;

namespace BloodDonorReceiver.Business.IModelServices
{
    public interface ICityAndStateService
    {
        public List<CityModel> GetAllCities();
        public List<StateModel> GetAllCitysStates(int cityId);
    }
}
