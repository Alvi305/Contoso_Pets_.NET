namespace Contoso.Pets.Models
{
    public class Animal
    {
        public string Species { get; set; }
        public string ID { get; set; }
        public string Age { get; set; }
        public string PhysicalDescription { get; set; }
        public string PersonalityDescription { get; set; }
        public string Nickname { get; set; }

        public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(ID);
    }
    }

    
}