using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IJSE.ARM.Common.Models
{
    public class DonorCompany
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Donor")]
        public int DonorId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        [ForeignKey("DonorId")]
        public virtual Donor Donor { get; set; }

    }
}
