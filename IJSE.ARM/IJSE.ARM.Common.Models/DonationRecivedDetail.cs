using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class DonationRecivedDetail
    {
        public int Id { get; set; }
        public int DonationArrivalId { get; set; }
        public int AidItemId { get; set; }
        public double Qty { get; set; }
        public string ImagePathRef { get; set; }
        public string RefNotes { get; set; }
        public virtual DonationRecived DonationRecived { get; set; }
        public virtual AidItem AidItem { get; set; }
    }
}
