using Internship_3_OOP.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    public static class ContactsList
    {
        public static List<Contact> AllContacts { get; } = new();

        public static bool Add(Contact contactWeWantToAdd)
        {
            foreach (var contact in AllContacts)
            {
                if (contact.PhoneNumber == contactWeWantToAdd.PhoneNumber)
                {
                    return false;
                }

            }
            AllContacts.Add(contactWeWantToAdd);
            return true;
        }


        public static bool Remove(string firstName, string lastName)
        {
            foreach (var contact in AllContacts)
            {
                if (contact.FirstName == firstName && contact.LastName == lastName)
                {
                    AllContacts.Remove(contact);
                    return true;
                }

            }
            return false;
        }
    }
}
