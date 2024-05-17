using BloodDonorReceiver.Data.Models;
using BloodDonorReceiver.DataAccess.Context;
using BloodDonorReceiver.Utils.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace BloodDonorReceiver.Utils.InitialHelper
{
    public class Init : IDisposable
    {
        public Init()
        {
            AddInital();
        }
        public void AddInital()
        {
            using (var uow = new UnitOfWork<MasterContext>())
            {
                var user = uow.GetRepository<UserModel>().Get(x => x.Name.Equals("root"));
                if (user == null)
                {
                    user = new UserModel("root", "root", "11111111112", "01.01.2024", "root", "0000000000", "root", "root");
                    uow.GetRepository<UserModel>().Add(user);
                    var counnt = uow.SaveChanges();
                }

            }


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(Environment.GetEnvironmentVariable("CITY_STATE_FILE_PATH"))))
            {
                var worksheetStates = package.Workbook.Worksheets[1];
                var worksheetCities = package.Workbook.Worksheets[0];

                var rowCountStates = worksheetStates.Dimension.Rows;
                var rowCountCities = worksheetCities.Dimension.Rows;

                CityModel city; ;
                StateModel state;

                using (var uow = new UnitOfWork<MasterContext>())
                {
                    for (int cityRow = 2; cityRow <= rowCountCities; cityRow++)
                    {
                        var worksheetCityId = worksheetCities.Cells[cityRow, 1].Text;
                        var cityName = worksheetCities.Cells[cityRow, 2].Text;
                        var isExistCity = uow.GetRepository<CityModel>().Get(x => x.ID == int.Parse(worksheetCityId) && x.Name.Equals(cityName));
                        if (isExistCity == null)
                        {
                            city = new CityModel
                            {
                                ID = int.Parse(worksheetCityId),
                                Name = cityName
                            };
                            uow.GetRepository<CityModel>().Add(city);
                        }
                        
                    }
                    uow.SaveChanges();
                }

                using (var uow = new UnitOfWork<MasterContext>())
                {
                    for (int row = 2; row <= rowCountStates; row++)
                    {
                        var stateId = worksheetStates.Cells[row, 1].Text;
                        var stateName = worksheetStates.Cells[row, 2].Text;
                        var cityId = worksheetStates.Cells[row, 3].Text;
                        var isExistState = uow.GetRepository<CityModel>().Get(x => x.ID == int.Parse(stateId) && x.Name.Equals(stateName));
                        if (isExistState == null)
                        {
                            state = new StateModel
                            {
                                ID = int.Parse(stateId),
                                Name = stateName,
                                CityId = int.Parse(cityId)
                            };
                            uow.GetRepository<StateModel>().Add(state);
                        }
                    }
                    uow.SaveChanges();
                }
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
