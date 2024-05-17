using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonorReceiver.Data.Models
{
    public class CityModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StateModel> States { get; set; }
    }
}
