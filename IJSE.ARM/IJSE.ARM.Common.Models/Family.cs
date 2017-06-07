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
        public int NoOfMembers { get; set; }

        public int GSAreaId { get; set; }
        public virtual GSArea GSArea { get; set; }


        //public int PrimaryMemeberId { get; set; }

        //[ForeignKey("primaryMemberId")]
        //public virtual Person PrimaryMember { get; set; }
    }
}
