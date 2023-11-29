using Internship_3_OOP.Classes;
using Internship_3_OOP.Phone;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

var History = new Dictionary<Contact, List<PhoneCall>>();
var MainMenu = new Dictionary<int, (Action actionWeWantToDo, string actionDescription)>()
{
    {1, (ContactsList.ListAllContacts , "Ispis svih kontakata") },
    {2, (ContactsList.Add, "Dodavanje novog kontakta u imenik") },
    {3, (ContactsList.Remove,"Brisanje kontakta iz imenika")},
    {4, (ChangePreferences,"Editiranje preference kontakta")},
    {5, (OpenSubMeni,"Upravljanje kontaktom")},
    {6, (ContactsList.Remove,"Ispis svih poziva")},
    {7, (() => Console.ReadKey(), "Izlaz iz aplikacije") }
    
};

RunTheProgram(MainMenu,7);

static void OpenSubMeni()
{
    var SubMenu = new Dictionary<int, (Action actionWeWantToDo, string actionDescription)>()
    {
        {3, (()=> Console.ReadKey(), "izlaz iz podmenua") }
    };
    RunTheProgram(SubMenu, 3);
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
    var (name, surname) = ContactsList.GettingTheNameAndSurname();
    Contact contact = ContactsList.DoesThisContatctExists(name, surname);
    var preference = ContactsList.GettingThePreference($"Preferenca je trenutno postavljena na {contact.ContactPreferences}. Na što je želite postaviti? (napisati riječima naš odabir)");
    contact.SettingTheChosenPreference(preference);
}

static void ListAllThePhoneCallsWithOneContact()
{ 
    
}



