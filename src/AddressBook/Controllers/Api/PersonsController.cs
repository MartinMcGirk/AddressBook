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

        /// <summary>
        /// Gets a specific person within an organisation
        /// </summary>
        /// <param name="organisationId">The organisation identifier</param>
        /// <param name="personId">The person identifier</param>
        /// <returns><see cref="OkResult"/> if all good. <see cref="BadRequestResult"/> if not</returns>
        [HttpGet("api/organisations/{organisationId}/persons/{personId}")]
        public IActionResult Get(int organisationId, int personId)
        {
            try
            {
                var organisation = _repository.GetOrganisationById(organisationId);
                return Ok(organisation.Persons.FirstOrDefault(p => p.Id == personId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all persons: {ex}");
                return BadRequest("Error occurred");
            }
        }

        /// <summary>
        /// Adds a new person to an organisation
        /// </summary>
        /// <param name="organisationId">The organisation identifier</param>
        /// <param name="person">The person object to be saved</param>
        /// <returns><see cref="CreatedResult"/> if all good. <see cref="BadRequestResult"/> if not</returns>
        [HttpPost("api/organisations/{organisationId}/persons")]
        public async Task<IActionResult> Post(int organisationId, [FromBody]Person person)
        {
            try
            {
                _repository.AddPersonToOrganisation(organisationId, person);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/organisations/{organisationId}/persons/{person.Id}", person);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all persons: {ex}");
                return BadRequest("Error occurred");
            }
            return BadRequest("Failed to save new person");
        }

        [HttpPut("api/organisations/{organisationId}/persons")]
        public async Task<IActionResult> Put(int organisationId, [FromBody]Person person)
        {
            try
            {
                _repository.UpdatePersonInOrganisation(organisationId, person);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/organisations/{organisationId}/persons/{person.Id}", person);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all persons: {ex}");
                return BadRequest("Error occurred");
            }
            return BadRequest("Failed to save new person");
        }
    }
}
