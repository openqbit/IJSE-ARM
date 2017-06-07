using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class AidDistributionConvoyVehicles
    {

        public int Id { get; set; }
        public int AidDistributionConvoyId { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }

        public string ImagePathRef { get; set; }
        public string RefNotes { get; set; }

        public virtual AidDistributionConvoy AidDistributionConvoy { get; set; }
    }

}
