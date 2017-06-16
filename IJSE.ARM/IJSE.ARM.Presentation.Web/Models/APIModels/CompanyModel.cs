using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IJSE.ARM.Presentation.Web.Models.APIModels
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelLand { get; set; }
        public string TelMobile { get; set; }
        public string Address { get; set; }
    }
}