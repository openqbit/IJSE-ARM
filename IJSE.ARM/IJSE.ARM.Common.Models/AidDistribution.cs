using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class AidDistribution
    {
        public int Id { get; set; }

        public DateTime ETA { get; set; }
        public DateTime DeployedDate { get; set; }
        
        public int OfficerInChargeId { get; set; }      

        public string ImagePathRef { get; set; }
        public string RefNotes { get; set; }

        [ForeignKey("OfficerInChargeId")]
        public virtual Person OfficerInCharge { get; set; }

    }
}
