using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class DonorPeople
    {
        public int Id { get; set; }

        public bool IsPrimaryContact { get; set; }

        public int DonorId { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Donor Donor { get; set; }
    }
}
