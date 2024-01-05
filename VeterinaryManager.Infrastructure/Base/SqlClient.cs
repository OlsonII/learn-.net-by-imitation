using Dapper;
using Npgsql;
using VeterinaryManager.Domain.Repositories;

namespace VeterinaryManager.Infrastructure.Base;

public abstract class SqlClient : ISqlClient
{
    private readonly string _connectionString;

    protected SqlClient()
    {
        // TODO: Using Docker Create a local database and connect your project with it
        // TODO: DEFINE POSTGRES CONNECTION STRING
        _connectionString = @$"";
    }

    protected SqlClient(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<T>> ExecuteQuery<T>(string query, DynamicParameters? parameters = null)
    {
        var connection = new NpgsqlConnection(_connectionString);
        var response = (await connection.QueryAsync<T>(query, parameters)).AsList();
        await connection.CloseAsync();
        return response;
    }

    public async Task<T?> ExecuteQuerySingle<T>(string query, DynamicParameters? parameters = null)
    {    
        var connection = new NpgsqlConnection(_connectionString);
        var response = await connection.QuerySingleOrDefaultAsync<T?>(query, parameters);
        await connection.CloseAsync();
        return response;
    }
        
    public async Task ExecuteCommandAsync(string command, object? parameters = null)
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(command, parameters);
        await connection.CloseAsync();
    }
}