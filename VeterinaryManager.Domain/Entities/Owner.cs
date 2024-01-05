namespace VeterinaryManager.Domain.Entities;

public class Owner : Person
{
    public string Address { get; private set; }

    public Owner(string id, string name, string phone) : base(id, name, phone)
    {
    }
    
    public void Update(string? address, string? phone)
    {
        Address = address ?? Address;
        base.Update(phone);
    }

}