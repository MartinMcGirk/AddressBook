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
    [Route("api/organisations/{organisationId}/persons")]
    public class PersonsController : Controller
    {
        private readonly IAddressBookRepository _repository;
        private readonly ILogger<OrganisationsController> _logger;

        public PersonsController(IAddressBookRepository repository, ILogger<OrganisationsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get(int organisationId)
        {
            try
            {
                return Ok(_repository.GetAllPersonsForOrganisation(organisationId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all persons: {ex}");
                return BadRequest("Error occurred");
            }
        }
    }
}
