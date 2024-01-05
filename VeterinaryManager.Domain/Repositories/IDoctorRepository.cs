using VeterinaryManager.Domain.Entities;

namespace VeterinaryManager.Domain.Repositories;

public interface IDoctorRepository
{
    Task<Doctor?> Find(string doctorId);
    Task<List<Doctor>> Find();
    Task Register(Doctor doctor);
    Task Update(Doctor doctor);
}