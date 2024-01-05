using VeterinaryManager.Domain.Enums;

namespace VeterinaryManager.Domain.Entities;

public class Pet
{
    public string Name { get; set; }
    public string OwnerId { get; set; }
    public PetType Type { get; set; }
    public PetGender Gender { get; set; }
    public PetSize Size { get; set; }
}