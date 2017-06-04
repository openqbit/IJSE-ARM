﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class AidAllocationPending
    {
        public int Id { get; set; }
        public int AidRequestDetailId { get; set; }
        public int DonationRequestDetailId { get; set; }
        public double Qty { get; set; }
        public bool Active { get; set; }
    }
}
