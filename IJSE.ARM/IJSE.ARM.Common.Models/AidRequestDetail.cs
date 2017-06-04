using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class AidRequestDetail
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AidItemId { get; set; }
        public double Qty { get; set; }
        public virtual Person Person { get; set; }
        public virtual AidItem AidItem  { get; set; }
    }
}
