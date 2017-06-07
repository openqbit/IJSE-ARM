using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class FamilyDetail
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public bool IsPrimaryMember { get; set; }
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
        public virtual Person Person { get; set; }

        public FamilyMemeberType FamilyMemeberType { get; set; }
    }

    public enum FamilyMemeberType {  }
}
