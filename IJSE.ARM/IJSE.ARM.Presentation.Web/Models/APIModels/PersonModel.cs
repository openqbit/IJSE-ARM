using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IJSE.ARM.Presentation.Web.Models.APIModels
{
    public class PersonModel
    {
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

    public enum Gender { male, Female }
}
