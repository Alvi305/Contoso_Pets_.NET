namespace Contoso.Pets.Service;

public class UI
{
    public static void UIselect(string menuSelection, DataEntry animalData)
    {

        switch (menuSelection)
        {
            case "1":
                // List all of our current pet information
                DataEntry.DisplayAnimals(animalData);
                menuSelection = Console.ReadLine()!;
                break;

            case "2":
                Console.WriteLine("You selected menu option 2.");
                Console.WriteLine("Press the Enter key to continue.");
                menuSelection = Console.ReadLine()!;
                break;

            case "3":
                Console.WriteLine("You selected menu option 2.");
                Console.WriteLine("Press the Enter key to continue.");
                menuSelection = Console.ReadLine()!;
                break;

            case "4":
                // Implement functionality for menu selection 4
                break;

            case "5":
                // Implement functionality for menu selection 5
                break;

            case "6":
                // Implement functionality for menu selection 6
                break;

            case "7":
                // Implement functionality for menu selection 7
                break;

            case "8":
                // Implement functionality for menu selection 8
                break;

            default:
                Console.WriteLine("No valid option selected.");
                break;
        }

        Console.WriteLine("Press the Enter key to continue.");
        Console.ReadLine(); 
    }
}