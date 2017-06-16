using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IJSE.ARM.Presentation.Web.Models.APIModels
{
    public class DonationCombinationModel
    {
        CompanyModel company { get; set; }
        PersonModel donor { get; set; }

        PersonModel[] personArray { get; set; }
    }
}