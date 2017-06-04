using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class DonationRecived
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int DonationRequestId { get; set; }
        public string ImagePathRef { get; set; }
        public string RefNotes { get; set; }

        [ForeignKey("Person")]
        public int AcceptedOfficerId { get; set; }       
        public bool Status { get; set; }

        public virtual Person AcceptedOfficer { get; set; }
        public virtual DonationRequest DonationRequest { get; set; }

    }
}
