using VeterinaryManager.Domain.Entities;
using VeterinaryManager.Domain.Repositories;
using VeterinaryManager.Domain.Services;

namespace VeterinaryManager.Application;

public class DoctorServices : IDoctorServices
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorServices(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Doctor> Find(string doctorId)
    {
        var doctor = await _doctorRepository.Find(doctorId) ?? throw new Exception("Doctor not found");
        return doctor;
    }

    public Task<List<Doctor>> Find()
    {
        // TODO: Finish the find service
        throw new NotImplementedException();
    }

    public async Task Register(Doctor doctor)
    {
        var registeredDoctor = await _doctorRepository.Find(doctor.Id);
        if (registeredDoctor != null)
            throw new Exception("Doctor already registered");

        await _doctorRepository.Register(doctor);
    }

    public Task Update(Doctor doctor)
    {
        // TODO: Finish the update service
        throw new NotImplementedException();
    }
}