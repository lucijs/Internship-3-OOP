using Internship_3_OOP.Classes;
using Internship_3_OOP.Enum;
using Internship_3_OOP.Phone;

var MainMenu = new Dictionary<int, (Action actionWeWantToDo, string actionDescription)>()
{
    {1, (ContactsList.ListAllContacts , "Ispis svih kontakata") },
    {2, (ContactsList.Add, "Dodavanje novog kontakta u imenik") },
    {3, (ContactsList.Remove,"Brisanje kontakta iz imenika")},
    {4, (ChangePreferences,"Editiranje preference kontakta")},
    {5, (OpenSubMeni,"Upravljanje kontaktom")},
    {6, (CallHistory.ListAllPhoneCalls,"Ispis svih poziva")},
    {7, (() => Console.ReadKey(), "Izlaz iz aplikacije") }
    
};

RunTheProgram(MainMenu,7);

static void OpenSubMeni()
{
    var SubMenu = new Dictionary<int, (Action actionWeWantToDo, string actionDescription)>()
    {
        {1, (ListAllThePhoneCallsWithOneContact, "ispis svih poziva s odabranim kontaktom") },
        {2, (AddPhoneCall, "kreiranje novog poziva") },
        {3, (()=> Console.ReadKey(), "izlaz iz podmenua") }
    };
    RunTheProgram(SubMenu, 3);
}

static void AddPhoneCall()
{
    Console.Clear();
    var contact = GettingTheContact();
    if (contact.ContactPreferences == Preferences.Blocked)
    {
        Console.WriteLine("Ovaj kontakt vam je blokiran i s njim trenutno ne možete uspostaviti poziv.");
        return;
    }
    List<Status> statuses = new List<Status>{ Status.Missed, Status.Finished, Status.Ongoing };
    var randomNumberGenerator = new Random();
    var randomNumber = randomNumberGenerator.Next(1,20);
    var phoneCall = new PhoneCall(contact, DateTime.Now, statuses[randomNumber % 3], DateTime.Now.AddSeconds(randomNumber));

    foreach (var call in CallHistory.AllPhoneCalls)
    {
        if(DateTime.Now.CompareTo(call.WhenDidPhoneCallEnded())<0)
            call.FinishThePhonCall();
        if (call.WhatWasTheTimeOfTheCall().AddSeconds(-randomNumber).CompareTo(phoneCall.WhatWasTheTimeOfTheCall()) >= 0||call.ReturnTheStatus()==Status.Ongoing)
        {
            Console.WriteLine("Ne možemo imati više poziva istovremeno");
            return;
        }
    }
    CallHistory.Add(phoneCall);
}
static void RunTheProgram(Dictionary<int, (Action actionWeWantToDo, string actionDescription)> menu, int number)
{
    bool doWeWantToContinue;
    do
    {
        doWeWantToContinue = PrintMenu(menu, number);
    } while (doWeWantToContinue);
}

static bool PrintMenu(Dictionary<int, (Action actionWeWantToDo, string actionDescription)> mainMenu, int whenToExit)
{
    Console.Clear();
    foreach (var option in mainMenu)
        Console.WriteLine($"{option.Key}. - {option.Value.actionDescription}");
    var chosenOption = UserInput();
    if (chosenOption == whenToExit) 
        return false;
    foreach (var option in mainMenu)
        if (chosenOption == option.Key)
            option.Value.actionWeWantToDo.Invoke();
    return true;
}
static int UserInput()
{
    bool isCorrectInput;
    int chosenOption;
    do
    {
        isCorrectInput = Int32.TryParse(Console.ReadLine(), out chosenOption);
    } while (!isCorrectInput);
    return chosenOption;
}

static void ChangePreferences()
{
    Console.Clear();
    var contact = GettingTheContact();
    var preference = ContactsList.GettingThePreference($"Preferenca je trenutno postavljena na {contact.ContactPreferences}. Na što je želite postaviti? (napisati riječima naš odabir)");
    contact.SettingTheChosenPreference(preference);
}

static void ListAllThePhoneCallsWithOneContact()
{
    Console.Clear ();
    var contact = GettingTheContact();
    var listOfPhoneCalls = CallHistory.PhoneCallHistory[contact];
    var listOfDates = new List<DateTime>();
    foreach (var obj in listOfPhoneCalls)
        listOfDates.Add(obj.WhatWasTheTimeOfTheCall());
    listOfDates.Order();

    foreach (var date in listOfDates)
        foreach (var phoneCall in listOfPhoneCalls)
            if (date == phoneCall.WhatWasTheTimeOfTheCall())
                phoneCall.PrintThePhoneCall();
    Console.ReadKey();
}

static Contact GettingTheContact()
{
    Contact contact;
    do
    {
        var (name, surname) = ContactsList.GettingTheNameAndSurname();
        contact = ContactsList.DoesThisContatctExists(name, surname);
    } while (contact == null);
    return contact;
}


