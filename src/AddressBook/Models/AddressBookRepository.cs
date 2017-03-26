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
                .FirstOrDefault(o => o.Id == organisationId);

            return org;
        }
    }
}
