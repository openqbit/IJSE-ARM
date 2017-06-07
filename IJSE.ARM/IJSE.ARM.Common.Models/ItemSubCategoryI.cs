using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class ItemSubCategoryI
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public int ItemSubCategoryId { get; set; }

        [ForeignKey("ItemSubCategoryId")]
        public virtual ItemCategory ItemSubCategory { get; set; }
    }
}
