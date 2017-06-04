using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class AidDistributionConvoy
    {
        public int Id { get; set; }
        public int AidDistributionId { get; set; }
        public int TotalVehicles { get; set; }
        public string Root { get; set; }
        public string GPSLocations { get; set; }

        public string ImagePathRef { get; set; }
        public string RefNotes { get; set; }
    }
}
