using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonorReceiver.Core.BaseModels
{
    public interface IBaseControlOperationModel
    {
        public bool IsUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
