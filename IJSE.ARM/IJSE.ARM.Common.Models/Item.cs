﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace IJSE.ARM.Common.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        [ForeignKey("ItemSubCategoryIII")]
        public int ItemSubCategoryId { get; set; }
        public int? ParentitemId { get; set; }       
        public double? RatioToParentItem { get; set; }

        public virtual ItemSubCategoryIII ItemSubCategory { get; set; }

    }
}
