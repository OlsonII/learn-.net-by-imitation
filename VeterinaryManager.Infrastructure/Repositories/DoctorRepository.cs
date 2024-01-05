using Dapper;
using VeterinaryManager.Domain.Entities;
using VeterinaryManager.Domain.Repositories;

namespace VeterinaryManager.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ISqlClient _sqlClient;

    public DoctorRepository(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }

    public Task<Doctor?> Find(string doctorId)
    {
        const string query = "SELECT * FROM Doctor where Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", doctorId);
        return _sqlClient.ExecuteQuerySingle<Doctor>(query, parameters);
    }

    public Task<List<Doctor>> Find()
    {
        // TODO: Finish find method
        throw new NotImplementedException();
    }

    public async Task Register(Doctor doctor)
    {
        const string query = "INSERT INTO Doctor (Id, Name, Phone) VALUES (@Id, @Name, @Phone)";
        var parameters = new DynamicParameters(doctor);
        await _sqlClient.ExecuteCommandAsync(query, parameters);
    }

    public Task Update(Doctor doctor)
    {
        // TODO: Finish Update method
        throw new NotImplementedException();
    }
}