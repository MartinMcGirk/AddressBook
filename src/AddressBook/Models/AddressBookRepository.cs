using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AddressBook.Models
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly ILogger<AddressBookRepository> _logger;

        public AddressBookRepository(ILogger<AddressBookRepository> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Organisation> GetAllOrganisations()
        {
            _logger.LogInformation("Getting all organisations");

            return GetDummyOrganisationData();
        }

        public IEnumerable<Person> GetAllPersonsForOrganisation(int organisationId)
        {
            _logger.LogInformation($"Getting all persons for organisation {organisationId}");
            var org = GetDummyOrganisationData().FirstOrDefault(o => o.Id == organisationId);

            return org.Persons;
        }

        private static List<Organisation> GetDummyOrganisationData()
        {
            var orgs = new List<Organisation>
            {
                new Organisation()
                {
                    Id = 0,
                    Name = "Pepsi",
                    BusinessSector = "Soft Drinks Manufacturer",
                    ContactInfo = new ContactInfo()
                    {
                        StreetAddress = "1 Royal Mile",
                        City = "Edinburgh",
                        PostCode = "EH1 7TF",
                        TelephoneNumber = "0131 456 789"
                    },
                    Persons = new List<Person>()
                    {
                        new Person()
                        {
                            Firstname = "Bob",
                            Surname = "Smith",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "Sales Manager",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "2 Royal Mile",
                                City = "Edinburgh",
                                PostCode = "EH4 7TF",
                                TelephoneNumber = "0785 456 789"
                            }
                        },
                        new Person()
                        {
                            Firstname = "Debbie",
                            Surname = "Jackson",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "CEO",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "3 Royal Mile",
                                City = "Edinburgh",
                                PostCode = "EH1 5TF",
                                TelephoneNumber = "0748 456 789"
                            }
                        }
                    }
                },
                new Organisation()
                {
                    Id = 1,
                    Name = "CocaCola",
                    BusinessSector = "Soft Drinks Manufacturer",
                    ContactInfo = new ContactInfo()
                    {
                        StreetAddress = "17 Princes Street",
                        City = "Edinburgh",
                        PostCode = "EH2 7TF",
                        TelephoneNumber = "0131 456 789"
                    },
                    Persons = new List<Person>()
                    {
                        new Person()
                        {
                            Firstname = "Stuart",
                            Surname = "Frances",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "Telephone Operator",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "2 Princes Street",
                                City = "Edinburgh",
                                PostCode = "EH5 7TF",
                                TelephoneNumber = "0785 456 789"
                            }
                        },
                        new Person()
                        {
                            Firstname = "Chloe",
                            Surname = "Pearson",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "CEO",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "3 Princes Street",
                                City = "Edinburgh",
                                PostCode = "EH1 5TF",
                                TelephoneNumber = "0748 456 789"
                            }
                        }
                    }
                },
                new Organisation()
                {
                    Id = 2,
                    Name = "Oxfam",
                    BusinessSector = "NonProfit"
                },
                new Organisation()
                {
                    Id = 3,
                    Name = "Administrate",
                    BusinessSector = "Training Software"
                }
            };
            return orgs;
        }
    }
}
