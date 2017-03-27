using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Models
{
    public interface IAddressBookRepository
    {
        IEnumerable<Organisation> GetAllOrganisations();

        Organisation GetOrganisationById(int organisationId);

        void AddOrganisation(Organisation organisation);
        void AddPersonToOrganisation(int organisationId, Person person);

        void UpdateOrganisation(Organisation organisation);
        void UpdatePersonInOrganisation(int organisationId, Person person);

        Task<bool> SaveChangesAsync();
    }
}
