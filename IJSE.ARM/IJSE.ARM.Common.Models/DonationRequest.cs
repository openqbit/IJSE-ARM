using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class DonationRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }       
        public int DisasterMasterId { get; set; }
        public int DonorId { get; set; }
        public string ImagePathRef { get; set; }
        public bool Status { get; set; }
        
        public virtual DisasterMaster DisasterMaster { get; set; }
        public virtual Donor Donor { get; set; }
    }
}
