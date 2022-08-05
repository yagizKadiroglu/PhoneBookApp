using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneDal
    {
        List<Person> _person;

        public PhoneDal()
        {
            _person = new List<Person>
            {
                new Person{FirstName="Yağız",LastName="Kadiroğlu",PhoneNumber=123456},
                new Person{FirstName="Hasan",LastName="Sabbah",PhoneNumber=321321321},
                new Person{FirstName="Cem",LastName="Ersever",PhoneNumber=321321321},
                new Person{FirstName="Mahmut",LastName="Yıldırım",PhoneNumber=456432345},
                new Person{FirstName="Halil",LastName="İnalcık",PhoneNumber=345345345},
            };
        }

        public void Add(Person person)
        {
            _person.Add(person);
        }
        public void Delete(Person person)
        {
            Person personToDelete = _person.FirstOrDefault(p => p.PhoneNumber == person.PhoneNumber);
            _person.Remove(personToDelete);
        }
        public void Update(Person person,Person person1)
        {
            Person personToUpdate = _person.FirstOrDefault(p => p.FirstName == person.FirstName);

            personToUpdate.FirstName = person1.FirstName;
            personToUpdate.LastName = person1.LastName;
            personToUpdate.PhoneNumber = person1.PhoneNumber;
        }

        public List<Person> GetAll()
        {
            return _person;
        }
    }
}
