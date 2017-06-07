using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public DonorType DonorType { get; set; }

        public string Name { get; set; }
        
        public int PrimaryContactPersonId { get; set; }      

        [ForeignKey("PrimaryContactPersonId")]
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual ICollection<DonorPeople> DonorPeople { get; set; }
       // public virtual DonorCompany DonorCompany { get; set; }  // can be null for Individual, Group

    }

    public enum DonorType { Individual, Company, Group}
}
