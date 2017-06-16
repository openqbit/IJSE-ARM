using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IJSE.ARM.Presentation.Web.Models.APIModels;

namespace IJSE.ARM.Presentation.Web.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DonationRegistration(CompanyModel Company, PersonModel Donor, PersonModel[] personArray)
        {
            return View();
        }
    }
}