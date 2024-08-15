using Contoso.Pets.Models;
using Contoso.Pets.Service;

class Program {

    static void Main() {
        DataEntry animalDataEntry = new DataEntry();
        DisplayAnimals(animalDataEntry);

    }



    static void DisplayAnimals(DataEntry dataEntryService) {
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

}