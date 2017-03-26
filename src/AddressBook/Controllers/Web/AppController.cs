using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            var orgs = GetDummyOrganisationData();

            return View(orgs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private static List<Organisation> GetDummyOrganisationData()
        {
            var orgs = new List<Organisation>();
            orgs.Add(new Organisation()
            {
                Name = "Pepsi",
                BusinessSector = "Soft Drinks Manufacturer"
            });
            orgs.Add(new Organisation()
            {
                Name = "CocaCola",
                BusinessSector = "Soft Drinks Manufacturer"
            });
            orgs.Add(new Organisation()
            {
                Name = "Oxfam",
                BusinessSector = "NonProfit"
            });
            orgs.Add(new Organisation()
            {
                Name = "Administrate",
                BusinessSector = "Training Software"
            });
            return orgs;
        }
    }
}
