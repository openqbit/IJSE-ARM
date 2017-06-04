using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class SystemUser {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserHashedPwd { get; set; }
        public string AccessLevel { get; set; }
        public int PersonId { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool Active { get; set; }
        public virtual Person Person { get; set; }
    }
}
