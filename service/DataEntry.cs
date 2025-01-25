using Contoso.Pets.Models;
using System.Collections.Generic;


namespace Contoso.Pets.Service
{

  public class DataEntry
  {
   
   public List<Animal> ourAnimals;
   private int maxPets = 8;

   public DataEntry() {
    ourAnimals = new List<Animal>(maxPets);
    InitializeAnimals();
   }

    public List<Animal> InitializeAnimals() 
    {
         for (int i = 0; i < maxPets; i++)
            {
                Animal animal = new();
                
                switch (i)
                {
                    case 0:
                        animal.Species = "dog";
                        animal.ID = "d1";
                        animal.Age = "2";
                        animal.PhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                        animal.PersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                        animal.Nickname = "lola";
                        break;
                    case 1:
                        animal.Species = "dog";
                        animal.ID = "d2";
                        animal.Age = "9";
                        animal.PhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                        animal.PersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animal.Nickname = "loki";
                        break;
                    case 2:
                        animal.Species = "cat";
                        animal.ID = "c3";
                        animal.Age = "1";
                        animal.PhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animal.PersonalityDescription = "friendly";
                        animal.Nickname = "Puss";
                        break;
                    case 3:
                        animal.Species = "cat";
                        animal.ID = "c4";
                        animal.Age = "?";
                        animal.PhysicalDescription = "";
                        animal.PersonalityDescription = "";
                        animal.Nickname = "";
                        break;
                    default:
                        animal.Species = "";
                        animal.ID = "";
                        animal.Age = "";
                        animal.PhysicalDescription = "";
                        animal.PersonalityDescription = "";
                        animal.Nickname = "";
                        break;
                }

                ourAnimals.Add(animal);
            }

    return ourAnimals;
    }

    public static void DisplayAnimals(DataEntry dataEntryService)
    {
        foreach (Animal animal in dataEntryService.ourAnimals)
        {
            Console.WriteLine("ID: " + animal.ID);
            Console.WriteLine("Species: " + animal.Species);
            Console.WriteLine("Age: " + animal.Age);
            Console.WriteLine("Nickname: " + animal.Nickname);
            Console.WriteLine("Physical Description: " + animal.PhysicalDescription);
            Console.WriteLine("Personality Description: " + animal.PersonalityDescription);
            Console.WriteLine("-----------------------------");
        }
    }

public static void AddAnimal(DataEntry dataEntryService)
{
    string anotherPet = "y";
    int petCount = 0;

    string readResult = "";

    // display existing pets and update petcount
    for (int i = 0; i < dataEntryService.maxPets; i++)
    {
        var animal = dataEntryService.ourAnimals[i];
        if (animal.ID != "")
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Species: {animal.Species}");
            Console.WriteLine($"ID #: {animal.ID}");
            Console.WriteLine($"Age: {animal.Age}");
            Console.WriteLine($"Physical Description: {animal.PhysicalDescription}");
            Console.WriteLine($"Personality Description: {animal.PersonalityDescription}");
            Console.WriteLine($"Nickname: {animal.Nickname}");
            Console.WriteLine("-----------------------------");

            petCount += 1;
        }
    }

    if (petCount < dataEntryService.maxPets)
    {   
        bool validEntry = false;

        string animalSpecies = "";
        string animalID = "";
        string animalPhysicalDescription="";
        string animalPersonalityDescription="";
        string animalNickname = "";

        // get species (cat or dog) - string animalSpecies is a required field 
        do
        {
            // Species code block
            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
            readResult = Console.ReadLine();

            animalSpecies = NullCheckandConvertToLower(readResult);

            if (animalSpecies != "dog" && animalSpecies != "cat")
                validEntry = false;
        
            else
            {
                validEntry = true;
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
            }

        // Age  code block
            int petAge; 

            Console.WriteLine("Enter the pet's age or enter ? if unknown");

            readResult = Console.ReadLine();

            var animalAge = NullCheckandConvertToLower(readResult);

            if (animalAge != "?")
            {
                validEntry = int.TryParse(animalAge, out petAge);
            }
            else
            {
                validEntry = true;
            }


        // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
            do
            {
                Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPhysicalDescription = readResult.ToLower();
                    if (animalPhysicalDescription == "")
                    {
                        animalPhysicalDescription = "tbd";
                        
                    }

                    else
                        validEntry = true;

                }
            } while (animalPhysicalDescription == "");

        // get a description of the pet's personality - animalPersonalityDescription can be blank.
            do
            {
                Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPersonalityDescription = readResult.ToLower();
                    if (animalPersonalityDescription == "")
                    {
                        animalPersonalityDescription = "tbd";
                    }

                    else
                        validEntry = true;
                }
            } while (animalPersonalityDescription == "");

            // get the pet's nickname. animalNickname can be blank.
            do
            {
                Console.WriteLine("Enter a nickname for the pet");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalNickname = readResult.ToLower();
                    if (animalNickname == "")
                    {
                        animalNickname = "tbd";
                    }
                    else
                        validEntry = true;
                }
            } while (animalNickname == "");


            if (validEntry) 
            {
                Animal newAnimal = new Animal (
                    animalSpecies,
                    animalID,
                    animalAge,
                    animalPhysicalDescription,
                    animalPersonalityDescription,
                    animalNickname

                );
                    dataEntryService.ourAnimals.Add(newAnimal);
                    petCount ++;
            }


        } while (validEntry == false);

        while (anotherPet == "y" && petCount <dataEntryService.maxPets)
        {

        Console.WriteLine("Do you want to enter info for another pet (y/n)");
            do
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(dataEntryService.maxPets - petCount)} more.");
                Console.WriteLine("Do you want to enter info for another pet (y/n)");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    anotherPet = readResult.ToLower().Trim();
                }

                if (anotherPet != "y" && anotherPet != "n")
                {
                    Console.WriteLine("Please enter y or n");
                }
            } while (anotherPet != "y" && anotherPet != "n");

        }
    }

    if (petCount >= dataEntryService.maxPets)
    {
        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
    }
}

public static string  NullCheckandConvertToLower(string result) 
{
            if (result != null) 
                return result.ToLower();

            else 
             {
                Console.WriteLine($"Please enter value");
                 return string.Empty;
             }
}


 public  static  void ValidAnimalData(DataEntry dataEntryService) 
 {
    foreach(Animal animal in  dataEntryService.ourAnimals) 
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