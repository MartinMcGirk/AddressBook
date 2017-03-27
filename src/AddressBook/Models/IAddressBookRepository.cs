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

        Person GetPersonById(int personId);

        void AddOrganisation(Organisation organisation);
        void AddPersonToOrganisation(int organisationId, Person person);

        Task<bool> SaveChangesAsync();
    }
}
