using Contoso.Pets.Models;
using Contoso.Pets.Service;

class Program
{
    static void Main()
    {
        DisplayStartMessage();

        DataEntry animalDataEntry = new DataEntry();
        string menuSelection;

        do
        {
            menuSelection = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(menuSelection) && menuSelection.Trim().ToLower() != "exit")
            {
                UI.UIselect(menuSelection.Trim(),animalDataEntry);
            }
        }
        while (menuSelection.Trim().ToLower() != "exit");

       DataEntry.DisplayAnimals(animalDataEntry);
    }

   

    public static void DisplayStartMessage()
    {
        Console.Clear();

        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
        Console.WriteLine(" 5. Edit an animal’s age");
        Console.WriteLine(" 6. Edit an animal’s personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type 'Exit' to exit the program):");
    }
}