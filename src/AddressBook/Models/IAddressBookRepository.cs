using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public interface IAddressBookRepository
    {
        IEnumerable<Organisation> GetAllOrganisations();

        Organisation GetOrganisationById(int organisationId);
    }
}
