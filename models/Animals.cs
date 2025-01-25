namespace Contoso.Pets.Models
{
    public class Animal
    {
        public Animal()
        {
        }

        public Animal(string animalSpecies, string animalID, string animalAge, string animalPhysicalDescription, string animalPersonalityDescription, string animalNickname)
        {
            AnimalSpecies = animalSpecies;
            AnimalID = animalID;
            Age = animalAge;
            AnimalPhysicalDescription = animalPhysicalDescription;
            AnimalPersonalityDescription = animalPersonalityDescription;
            AnimalNickname = animalNickname;
        }

        public string Species { get; set; }
        public string ID { get; set; }
        public string Age { get; set; }
        public string PhysicalDescription { get; set; }
        public string PersonalityDescription { get; set; }
        public string Nickname { get; set; }
        public string AnimalSpecies { get; }
        public string AnimalID { get; }
    
        public string AnimalPhysicalDescription { get; }
        public string AnimalPersonalityDescription { get; }
        public string AnimalNickname { get; }

        public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(ID);
    }
    }

    
}