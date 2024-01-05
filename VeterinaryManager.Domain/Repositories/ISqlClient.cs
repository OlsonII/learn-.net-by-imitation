using Dapper;

namespace VeterinaryManager.Domain.Repositories;

public interface ISqlClient
{
    Task<List<T>> ExecuteQuery<T>(string query, DynamicParameters? parameters = null);
    Task<T?> ExecuteQuerySingle<T>(string query, DynamicParameters? parameters = null);
    Task ExecuteCommandAsync(string command, object? parameters = null);
}