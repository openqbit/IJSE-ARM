using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IJSE.ARM.Presentation.Web.Models.APIModels
{
    public class DonorModel
    {
        public int Id { get; set; }
        public DonorType DonorType { get; set; }

        public string Name { get; set; }

    }

    public enum DonorType { Individual, Company, Group }
}
