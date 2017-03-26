using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class AddressBookContextSeedData
    {
        private readonly AddressBookContext _context;

        public AddressBookContextSeedData(AddressBookContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Organisations.Any())
            {
                var pepsi = new Organisation()
                {
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
                };

                _context.Organisations.Add(pepsi);
                _context.Persons.AddRange(pepsi.Persons);
                _context.ContactInfos.Add(pepsi.ContactInfo);

                var coke = new Organisation()
                {
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
                };

                _context.Organisations.Add(coke);
                _context.Persons.AddRange(coke.Persons);
                _context.ContactInfos.Add(coke.ContactInfo);

                var oxfam = new Organisation()
                {
                    Name = "Oxfam",
                    BusinessSector = "Non Profit",
                    ContactInfo = new ContactInfo()
                    {
                        StreetAddress = "22 Cambridge Street",
                        City = "Edinburgh",
                        PostCode = "EH17 7TF",
                        TelephoneNumber = "0131 456 789"
                    },
                    Persons = new List<Person>()
                    {
                        new Person()
                        {
                            Firstname = "Tom",
                            Surname = "Melrose",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "Marketing",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "52 Princes Street",
                                City = "Edinburgh",
                                PostCode = "EH5 7TF",
                                TelephoneNumber = "0785 456 789"
                            }
                        },
                        new Person()
                        {
                            Firstname = "George",
                            Surname = "Banks",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "Head of Finance",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "93 Princes Street",
                                City = "Edinburgh",
                                PostCode = "EH1 5TF",
                                TelephoneNumber = "0748 456 789"
                            }
                        }
                    }
                };

                _context.Organisations.Add(oxfam);
                _context.Persons.AddRange(oxfam.Persons);
                _context.ContactInfos.Add(oxfam.ContactInfo);

                var rbs = new Organisation()
                {
                    Name = "RBS",
                    BusinessSector = "Banking",
                    ContactInfo = new ContactInfo()
                    {
                        StreetAddress = "15 George Street",
                        City = "Edinburgh",
                        PostCode = "EH17 7TF",
                        TelephoneNumber = "0131 456 789"
                    },
                    Persons = new List<Person>()
                    {
                        new Person()
                        {
                            Firstname = "Hazel",
                            Surname = "McDonald",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "Testing",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "85 George Street",
                                City = "Edinburgh",
                                PostCode = "EH5 7TF",
                                TelephoneNumber = "0785 456 789"
                            }
                        },
                        new Person()
                        {
                            Firstname = "Nigel",
                            Surname = "Banks",
                            DateOfBirth = DateTime.Now,
                            JobTitle = "Cleaner",
                            ContactInfo = new ContactInfo()
                            {
                                StreetAddress = "93 George Street",
                                City = "Edinburgh",
                                PostCode = "EH1 5TF",
                                TelephoneNumber = "0748 456 789"
                            }
                        }
                    }
                };

                _context.Organisations.Add(rbs);
                _context.Persons.AddRange(rbs.Persons);
                _context.ContactInfos.Add(rbs.ContactInfo);

                await _context.SaveChangesAsync();
            }
        }
    }
}
