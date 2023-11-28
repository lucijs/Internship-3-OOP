using Internship_3_OOP.Enum;

namespace Internship_3_OOP.Phone
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Preferences ContactPreferences { get; set; }

        public Contact(string firstName, string lastName, string phoneNumber, string preference)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            ContactPreferences = preference == "favorit" ? Preferences.Favourite : (preference == "blokiran" ? Preferences.Blocked : Preferences.Regular);
        }

    }
}
