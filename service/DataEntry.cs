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
                Animal animal = new Animal();
                
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

 public  static  void ValidAnimalData(DataEntry dataEntryService) 
 {
    foreach(Animal animal in  dataEntryService.ourAnimals) 
    {
            if (animal.ID == "") {
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