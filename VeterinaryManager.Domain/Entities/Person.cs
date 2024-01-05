namespace VeterinaryManager.Domain.Entities;

public abstract class Person
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }

    protected Person(string id, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
    }

    public void Update(string? phone)
    {
        Phone = phone ?? Phone;
    }
}