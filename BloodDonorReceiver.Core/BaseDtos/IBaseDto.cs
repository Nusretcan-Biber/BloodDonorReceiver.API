using BloodDonorReceiver.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorReceiver.Core.BaseDtos
{
    public class IBaseDto : IBaseModel
    {
        public Guid Guid { get; set; }
    }
}
