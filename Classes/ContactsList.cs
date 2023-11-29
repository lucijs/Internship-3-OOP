using Internship_3_OOP.Phone;

namespace Internship_3_OOP.Classes
{
    public static class ContactsList
    {
        public static List<Contact> AllContacts { get; } = new();

        public static void Add()
        {
            Console.Clear();
            Console.WriteLine("Dodavanje novog kontakta");
            var (name, surname) = GettingTheNameAndSurname();
            var phoneNumber = GettingTheNumber();
            var preference = GettingThePreference("Odaberi je li kontakt favorit, regularan ili blokiran. (napisati riječima naš odabir)");

            var newContact = new Contact(name, surname, phoneNumber, preference);

            foreach (var contact in AllContacts)
            {
                if (contact.PhoneNumber == newContact.PhoneNumber)
                {
                    Console.WriteLine("Već postoji kontakt s tim brojem.");
                    Console.ReadKey();
                    return;
                }

            }
            AllContacts.Add(newContact);
            CallHistory.PhoneCallHistory.Add(newContact, new List<PhoneCall>());
            Console.WriteLine("Kontakt je uspješno dodan.");
            Console.ReadKey();
        }

        public static void ListAllContacts()
        {
            Console.Clear();
            foreach (var contact in AllContacts)
                Console.WriteLine($"{contact.FirstName} {contact.LastName}\n\t{contact.PhoneNumber}\n\t{contact.ContactPreferences}");
            Console.ReadKey();
        }

        public static void Remove()
        {
            Console.Clear() ;
            var (firstName, lastName) = GettingTheNameAndSurname();
            var contact = DoesThisContatctExists(firstName, lastName);
            if (contact == null)
            {
                Console.WriteLine("Ne postoji kontakt s tim imenom i prezimenom.");
                Console.ReadKey();
            }

            AllContacts.Remove(contact);
            Console.WriteLine($"Uspješno izbrisan kontakt {firstName} {lastName}");
            Console.ReadKey();
        }

        public static Contact DoesThisContatctExists(string firstName, string lastName)
        {
            foreach (var contact in AllContacts)
                if (contact.FirstName == firstName && contact.LastName == lastName)
                    return contact;

            return null;
        }

        public static (string firstName, string lastName) GettingTheNameAndSurname()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Surname: ");
            var surname = Console.ReadLine();
            return (name, surname);
        }

        public static string GettingTheNumber()
        {
            Console.Write("Unesite broj, može se sastojati samo od znamenki: ");
            var phoneNumber = Console.ReadLine();
            foreach(var num in phoneNumber)
                if(!int.TryParse(num.ToString(),out var someNumber))
                {
                    Console.WriteLine("Pogriješili ste pri upisu, pokušajte ponovno.");
                    GettingTheNumber();
                }
            if (phoneNumber.Length < 9)
            {
                Console.WriteLine("Pogriješili ste pri upisu, pokušajte ponovno.");
                GettingTheNumber();
            }

            return phoneNumber;
        }

        public static string GettingThePreference(string output)
        {
            Console.WriteLine(output);
            var preference = Console.ReadLine();
            if (!"favorit~regularan~blokiran".Contains(preference))
            {
                Console.WriteLine( "Vaš odabir ne postoji, pokušajte ponovno");
                GettingThePreference(output);
            }
            return preference;
        }
    }
}
