﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public int? Parentitem { get; set; }

        public double? RatioToParentItem { get; set; }

    }
}
