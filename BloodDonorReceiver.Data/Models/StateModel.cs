﻿namespace BloodDonorReceiver.Data.Models
{
    public class StateModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual CityModel City { get; set; }
        public virtual ICollection<BloodCenterModel> BloodCenters { get; set; }


    }
}
