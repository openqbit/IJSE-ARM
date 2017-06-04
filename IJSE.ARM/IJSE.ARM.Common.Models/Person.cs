using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class Person
    {
        public int Id { get; set; }
        public DateTime DOB { get; set; }
        public string NIC { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender { male, Female}
}
