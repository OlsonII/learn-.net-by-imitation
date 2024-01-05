using VeterinaryManager.Domain.Entities;

namespace VeterinaryManager.Domain.Services;

public interface IDoctorServices
{
    Task<Doctor> Find(string doctorId);
    Task<List<Doctor>> Find();
    Task Register(Doctor doctor);
    Task Update(Doctor doctor);
}