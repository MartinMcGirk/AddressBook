﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBook.Controllers.Api
{
    [Route("api/organisations")]
    public class OrganisationsController : Controller
    {
        private readonly IAddressBookRepository _repository;
        private readonly ILogger<OrganisationsController> _logger;

        public OrganisationsController(IAddressBookRepository repository, ILogger<OrganisationsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrganisations());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all organisations: {ex}");
                return BadRequest("Error occurred");
            }
        }
    }
}
