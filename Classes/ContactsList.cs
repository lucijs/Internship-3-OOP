using Internship_3_OOP.Phone;

namespace Internship_3_OOP.Classes
{
    public static class ContactsList
    {
        public static List<Contact> AllContacts { get; } = new();

        public static void Add()
        {
            var (name, surname) = GettingTheNameAndSurname();
            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Odaberi je li kontakt favorit, regularan ili blokiran. (napisati riječima naš odabir)");
            var preference = Console.ReadLine();

            var newContact = new Contact(name, surname, phoneNumber, preference);

            foreach (var contact in AllContacts)
            {
                if (contact.PhoneNumber == newContact.PhoneNumber)
                {
                    Console.WriteLine("Već postoji kontakt s tim brojem.");
                    Console.ReadKey();

                }

            }
            AllContacts.Add(newContact);
            Console.WriteLine("Kontakt je uspješno dodan.");
            Console.ReadKey();
        }

        public static void ListAllContacts()
        {
            foreach (var contact in AllContacts)
                Console.WriteLine($"{contact.FirstName} {contact.LastName}\n\t{contact.PhoneNumber}\n\t{contact.ContactPreferences}");
            Console.ReadKey();
        }

        public static void Remove()
        {
            var (firstName, lastName) = GettingTheNameAndSurname();

            foreach (var contact in AllContacts)
            {
                if (contact.FirstName == firstName && contact.LastName == lastName)
                {
                    AllContacts.Remove(contact);
                    Console.WriteLine($"Uspješno izbrisan kontakt {firstName} {lastName}");
                    Console.ReadKey();
                    return;
                }

            }
            Console.WriteLine("Ne postoji kontakt s tim imenom i prezimenom.");
            Console.ReadKey();
        }

        public static (string firstName, string lastName) GettingTheNameAndSurname()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Surname: ");
            var surname = Console.ReadLine();
            return (name, surname);
        }
    }
}
