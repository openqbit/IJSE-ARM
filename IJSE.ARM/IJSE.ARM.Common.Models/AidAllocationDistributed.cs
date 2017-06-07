using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class AidAllocationDistributed
    {
        public int Id { get; set; }

        public int AidRequestDetailId { get; set; }
        public int AidDistributionItemDetailId { get; set; }
        public double Qty { get; set; }

        public string ImagePathRef { get; set; }
        public string RefNotes { get; set; }

        public DateTime RecivedDate { get; set; }
        public bool Active { get; set; }

     //   public virtual AidRequestDetail AidRequestDetail { get; set; }
     //   public virtual AidDistributionItemDetail AidDistributionItemDetail { get; set; }
    }
}
