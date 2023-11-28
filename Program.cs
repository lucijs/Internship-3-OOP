using Internship_3_OOP.Classes;
using Internship_3_OOP.Phone;

var History = new Dictionary<Contact, List<PhoneCall>>();
var MainMenu = new Dictionary<int, (Action actionWeWantToDo, string actionDescription)>()
{
    {1, (ContactsList.ListAllContacts , "Ispis svih kontakata") },
    {2, (ContactsList.Add, "Dodavanje novog kontakta u imenik") },
    {3, (ContactsList.Remove,"Brisanje kontakta iz imenika")}
    
};
while (true)
{ 
    PrintMenu(MainMenu);
}
static void PrintMenu(Dictionary<int, (Action actionWeWantToDo, string actionDescription)> mainMenu)
{
    Console.Clear();
    foreach (var option in mainMenu)
        Console.WriteLine($"{option.Key}. - {option.Value.actionDescription}");
    var chosenOption = UserInput();
    foreach (var option in mainMenu)
        if (chosenOption == option.Key)
            option.Value.actionWeWantToDo.Invoke();
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




