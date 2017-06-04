using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public class ItemSubCategoryIII
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ItemSubCategoryII")]
        public int ItemSubCategoryId { get; set; }
    }
}
