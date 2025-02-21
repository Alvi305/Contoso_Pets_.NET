using Contoso.Pets.Models;
using System.Collections.Generic;


namespace Contoso.Pets.Service
{

  public class DataEntry
  {
   
   public static List<Animal> ourAnimals =new List<Animal>(maxPets);
   public static int maxPets = 8;
   public static decimal decimalDonation;

        public DataEntry() {
    InitializeAnimals(ourAnimals);
   }

public List<Animal> InitializeAnimals(List<Animal> animals)
{
    ourAnimals.Clear();

    Animal animal1 = new Animal
    {
        Species = "dog",
        ID = "d1",
        Age = "2",
        PhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.",
        PersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.",
        Nickname = "lola",
        SuggestedDonation = 85.00m
    };
    ourAnimals.Add(animal1);

    Animal animal2 = new Animal
    {
        Species = "dog",
        ID = "d2",
        Age = "9",
        PhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.",
        PersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.",
        Nickname = "loki",
        SuggestedDonation = 49.99m

    };
    ourAnimals.Add(animal2);

    Animal animal3 = new Animal
    {
        Species = "cat",
        ID = "c3",
        Age = "1",
        PhysicalDescription = "small white female weighing about 8 pounds. litter box trained.",
        PersonalityDescription = "friendly",
        Nickname = "Puss",
        SuggestedDonation = 40.00m
    };
    ourAnimals.Add(animal3);

    Animal animal4 = new Animal
    {
        Species = "cat",
        ID = "c4",
        Age = "?",
        PhysicalDescription = "",
        PersonalityDescription = "",
        Nickname = "",
        SuggestedDonation = 45.00m
    };
    ourAnimals.Add(animal4);

    return ourAnimals;
}

    public static void DisplayAnimals()
    {
        foreach (Animal animal in ourAnimals)
        {
            Console.WriteLine("ID: " + animal.ID);
            Console.WriteLine("Species: " + animal.Species);
            Console.WriteLine("Age: " + animal.Age);
            Console.WriteLine("Nickname: " + animal.Nickname);
            Console.WriteLine("Physical Description: " + animal.PhysicalDescription);
            Console.WriteLine("Personality Description: " + animal.PersonalityDescription);
            Console.WriteLine($"Suggested Donation: {animal.SuggestedDonation:C2}");
            Console.WriteLine("-----------------------------");
        }
    }

public static void AddAnimal()
{
    string anotherPet = "y";
    int petCount = 0;

    string readResult = "";

    // display existing pets and update petCount
     Console.WriteLine("\nCurrent Animals:");
    foreach (Animal animal in ourAnimals)
    {
        if (!string.IsNullOrEmpty(animal.ID))
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Species: {animal.Species}");
            Console.WriteLine($"ID #: {animal.ID}");
            Console.WriteLine($"Age: {animal.Age}");
            Console.WriteLine($"Physical Description: {animal.PhysicalDescription}");
            Console.WriteLine($"Personality Description: {animal.PersonalityDescription}");
            Console.WriteLine($"Nickname: {animal.Nickname}");
            petCount++;
        }
    }


    while (anotherPet == "y" && petCount < maxPets)
    {
        bool validEntry = false;

        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";
        string suggestedDontation = "";

        // get species (cat or dog) - string animalSpecies is a required field
        do
        {
            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
            readResult = Console.ReadLine();

            animalSpecies = readResult;

            if (animalSpecies == "dog" || animalSpecies == "cat")
            {
                validEntry = true;
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'dog' or 'cat'.");
            }
        } while (!validEntry);

        // Age code block
        validEntry = false;
        do
        {
            Console.WriteLine("Enter the pet's age or enter ? if unknown");
            readResult = Console.ReadLine();

            animalAge = readResult;

            if (animalAge == "?")
            {
                validEntry = true;
            }
            else if (int.TryParse(animalAge, out int petAge))
            {
                validEntry = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid age or '?'.");
            }
        } while (!validEntry);

        // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank
        Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
        animalPhysicalDescription = Console.ReadLine()?.Trim() ?? "tbd";

        // get a description of the pet's personality - animalPersonalityDescription can be blank
        Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
        animalPersonalityDescription = Console.ReadLine()?.Trim() ?? "tbd";

        // get the pet's nickname - animalNickname can be blank
        Console.WriteLine("Enter a nickname for the pet");
        animalNickname = Console.ReadLine()?.Trim() ?? "tbd";

        // get suggestedDonation
        Console.WriteLine("Enter Suggested Donation or leave empty for defualt of $45.00");
        suggestedDontation = Console.ReadLine()?.Trim() ?? "45.00";

        if(!decimal.TryParse(suggestedDontation, out decimalDonation))
        {
            decimalDonation = 45.00m;
        }

        Animal newAnimal = new Animal(
            animalSpecies,
            animalID,
            animalAge,
            animalPhysicalDescription,
            animalPersonalityDescription,
            animalNickname,
            decimalDonation
        );
        
        ourAnimals.Add(newAnimal);
        petCount++;

        if (petCount < maxPets)
        {
            Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {maxPets - petCount} more.");
            do
            {
                Console.WriteLine("Do you want to enter info for another pet (y/n)");
                anotherPet = Console.ReadLine()?.ToLower().Trim() ?? "";

                if (anotherPet != "y" && anotherPet != "n")
                {
                    Console.WriteLine("Please enter 'y' or 'n'.");
                }
            } while (anotherPet != "y" && anotherPet != "n");
        }
    }

    if (petCount >= maxPets)
    {
        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
        Console.WriteLine("Press the Enter key to continue.");
        Console.ReadLine();
    }
}

 public  static  void ValidAnimalData(DataEntry dataEntryService) 
 {
    foreach(Animal animal in  ourAnimals) 
    {
            if (animal.ID == "") 
            {
                continue;
            }


            if(animal.Age == "?" || animal.PhysicalDescription == "") {
                Console.WriteLine($"Enter an age for ID #{animal.ID}");
                string inputAge = Console.ReadLine();
                
                do 
                {
                    Console.WriteLine($"Enter an age for ID #{animal.ID}");
                    inputAge = Console.ReadLine();
                } while (!int.TryParse(inputAge, out int petAge));

                animal.Age = inputAge;

                Console.WriteLine($"Enter physical description for ID: {animal.PersonalityDescription} (size, color, gender, weight, housebroken)");

                string descriptionInput = Console.ReadLine();
                
               do
                {
                    Console.WriteLine($"Enter physical description for ID: {animal.PersonalityDescription} (size, color, gender, weight, housebroken)");
                    descriptionInput = Console.ReadLine();
                }  while (string.IsNullOrEmpty(descriptionInput));

                animal.PhysicalDescription = descriptionInput;

                Console.WriteLine("Age and physical description fields are complete for all of our friends.");
                Console.WriteLine("Press the Enter key to continue");
                Console.ReadLine();
    }
   }    
  }
 }
}  