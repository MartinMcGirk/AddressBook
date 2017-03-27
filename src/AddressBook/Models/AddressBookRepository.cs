using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AddressBook.Models
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly ILogger<AddressBookRepository> _logger;
        private readonly AddressBookContext _context;

        public AddressBookRepository(ILogger<AddressBookRepository> logger, AddressBookContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IEnumerable<Organisation> GetAllOrganisations()
        {
            _logger.LogInformation("Getting all organisations");

            return _context.Organisations
                .Include(o => o.ContactInfo)
                .ToList();
        }

        public Organisation GetOrganisationById(int organisationId)
        {
            _logger.LogInformation($"Getting organisation with id of {organisationId}");
            var org = _context.Organisations
                .Include(o => o.ContactInfo)
                .Include(o => o.Persons)
                .ThenInclude(o => o.ContactInfo)
                .FirstOrDefault(o => o.Id == organisationId);

            return org;
        }

        public void AddOrganisation(Organisation organisation)
        {
            _logger.LogInformation($"Adding organisation to context: {organisation.Name}");
            _context.Organisations.Add(organisation);
        }

        public void AddPersonToOrganisation(int organisationId, Person person)
        {
            _logger.LogInformation($"Adding person: {person.Firstname} {person.Surname} to organisation: {organisationId}");

            var organisation = GetOrganisationById(organisationId);
            if (organisation != null)
            {
                organisation.Persons.Add(person);
                _context.Persons.Add(person);
            }
        }


        public void UpdateOrganisation(Organisation organisation)
        {
            _logger.LogInformation($"Updating organisation: {organisation.Id}");

            var record = GetOrganisationById(organisation.Id);
            if (record != null)
            {
                record.Name = organisation.Name;
                record.BusinessSector = organisation.BusinessSector;
                if (record.ContactInfo != null)
                {
                    record.ContactInfo.TelephoneNumber = organisation.ContactInfo.TelephoneNumber;
                    record.ContactInfo.StreetAddress = organisation.ContactInfo.StreetAddress;
                    record.ContactInfo.City = organisation.ContactInfo.City;
                    record.ContactInfo.PostCode = organisation.ContactInfo.PostCode;
                }
            }
        }

        public void UpdatePersonInOrganisation(int organisationId, Person person)
        {
            _logger.LogInformation($"Updating person: {person.Id} in organisation: {organisationId}");

            var organisation = GetOrganisationById(organisationId);
            var record = organisation?.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (record != null)
            {
                record.Firstname = person.Firstname;
                record.Surname = record.Surname;
                record.JobTitle = person.JobTitle;
                if (record.ContactInfo != null)
                {
                    record.ContactInfo.TelephoneNumber = person.ContactInfo.TelephoneNumber;
                    record.ContactInfo.StreetAddress = person.ContactInfo.StreetAddress;
                    record.ContactInfo.City = person.ContactInfo.City;
                    record.ContactInfo.PostCode = person.ContactInfo.PostCode;
                }
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
