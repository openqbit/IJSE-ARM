﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class DisasterMaster
    {
        public int Id { get; set; }
        public string  Description { get; set; }
        public DateTime Date { get; set; }

        public int DisasterTypeId { get; set; }
        public virtual DisasterType DisasterType { get; set; }

        
    }
}
