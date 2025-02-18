namespace Contoso.Pets.Service;

public class UI
{
    public static void Run(DataEntry animalData)
    {
        string menuSelection;
        do
        {
            // NOTE: the Console.Clear method is throwing an exception in debug sessions
             try
            {
                if (!Console.IsOutputRedirected)
                    Console.Clear();
            }
            catch (IOException)
            {
                // Ignore clear errors in debug environments
                Console.WriteLine("Fuck you");
            }
            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal");
            Console.WriteLine(" 3. Validate animal data");
            // Add other menu options (4-8) here as needed
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            var readResult = Console.ReadLine();
            menuSelection = (readResult ?? "").ToLower();

            switch (menuSelection)
            {
                case "1":
                    // List all pets
                    DataEntry.DisplayAnimals();
                    Console.WriteLine("\nPress the Enter key to continue.");
                    Console.ReadLine();
                    break;

                case "2":
                    // Add a new animal
                    DataEntry.AddAnimal();
                    Console.WriteLine("\nPress the Enter key to continue.");
                    Console.ReadLine();
                    break;

                case "3":
                    // Validate animal data
                    DataEntry.ValidAnimalData(animalData);
                    Console.WriteLine("\nPress the Enter key to continue.");
                    Console.ReadLine();
                    break;

                // Implement cases 4-8 as needed
                // case "4":
                //     // Functionality for option 4
                //     break;

                case "exit":
                    break;

                default:
                    Console.WriteLine("No valid option selected. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }

        } while (menuSelection != "exit");
    }
}