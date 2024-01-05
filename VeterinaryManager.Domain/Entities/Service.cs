using VeterinaryManager.Domain.Enums;

namespace VeterinaryManager.Domain.Entities;

public class Service
{
    public int Id { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
    public int PetId { get; set; }
    public string DoctorId { get; set; }
    public ServiceType Type { get; set; }

    public void CalculatePrice(PetSize petSize)
    {
        // TODO: Calculate price based on the pet size and the service type, define you the values
    }
}