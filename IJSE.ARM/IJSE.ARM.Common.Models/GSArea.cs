using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class GSArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AGOfficeId { get; set; }
        public virtual AGOffice AGOffice { get; set; }
    }
}
