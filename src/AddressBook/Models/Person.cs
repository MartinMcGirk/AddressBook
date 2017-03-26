using System;

namespace AddressBook.Models
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public ContactInfo _contactInfo { get; set; } = new ContactInfo();
    }
}