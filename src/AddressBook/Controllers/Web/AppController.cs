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
        private readonly IAddressBookRepository _repository;

        public AppController(IAddressBookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var orgs = _repository.GetAllOrganisations();

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
    }
}
