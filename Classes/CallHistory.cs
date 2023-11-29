using Internship_3_OOP.Phone;

namespace Internship_3_OOP.Classes
{
    public static class CallHistory
    {
        public static List<PhoneCall> AllPhoneCalls { get; } = new();
        public static Dictionary<Contact, List<PhoneCall>> PhoneCallHistory { get; } = new();
        public static void Add(PhoneCall phoneCall)
        { 
            AllPhoneCalls.Add(phoneCall);
            foreach (var call in ContactsList.AllContacts)
            {
                if (phoneCall.PhoneNumber == call.PhoneNumber)//nemaju dva kontakta s istim brojem
                {
                    PhoneCallHistory[call].Add(phoneCall);
                    Console.WriteLine("Ovaj poziv je spremljen");
                    phoneCall.PrintThePhoneCall();
                    Console.ReadKey();
                }
            }
        }

        public static void ListAllPhoneCalls()
        {
            Console.Clear();
            foreach (var phoneCall in AllPhoneCalls)
                phoneCall.PrintThePhoneCall();
            Console.ReadKey();
        }
    }
}
