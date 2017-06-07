using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class Family
    {
        public int Id { get; set; } 
        public string Address { get; set; }
        public int NoOfMemebers { get; set; }
       
        public int primaryMemeberId { get; set; }

        [ForeignKey("primaryMemeberId")]
        public virtual Person primaryMemeber { get; set; }
    }
}
