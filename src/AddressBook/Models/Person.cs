using System;

namespace AddressBook.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public ContactInfo ContactInfo { get; set; } = new ContactInfo();
    }
}