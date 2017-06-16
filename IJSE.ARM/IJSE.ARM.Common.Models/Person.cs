using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public string NIC { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }


      //  public virtual ICollection<AidDistribution> AidDistribution { get; set; }
    }

    public enum Gender { male, Female}
}
