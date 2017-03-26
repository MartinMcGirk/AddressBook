﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public interface IAddressBookRepository
    {
        IEnumerable<Organisation> GetAllOrganisations();

        IEnumerable<Person> GetAllPersonsForOrganisation(int organisationId);
    }
}
