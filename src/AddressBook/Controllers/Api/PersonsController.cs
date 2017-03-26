using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBook.Controllers.Api
{
    
    public class PersonsController : Controller
    {
        private readonly IAddressBookRepository _repository;
        private readonly ILogger<OrganisationsController> _logger;

        public PersonsController(IAddressBookRepository repository, ILogger<OrganisationsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("api/persons/{personId}")]
        public IActionResult Get(int personId)
        {
            try
            {
                return Ok(_repository.GetPersonById(personId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all persons: {ex}");
                return BadRequest("Error occurred");
            }
        }
    }
}
