﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJSE.ARM.Common.Models
{
    public class DonationRequestDetail
    {
        public int Id { get; set; }
        public int DonationRequestId { get; set; }
        public int AidItemId { get; set; }
        public double Qty { get; set; }
        public virtual DonationRequest DonationRequest { get; set; }
        public virtual AidItem AidItem { get; set; }
    }
}
