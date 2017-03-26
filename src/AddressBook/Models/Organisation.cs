using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Organisation
    {
        public string Name { get; set; }
        public string BusinessSector { get; set; }
        public ContactInfo _contactInfo { get; set; } = new ContactInfo();

        public ICollection<Person> Persons { get; set; }
    }
}
