namespace VeterinaryManager.Domain.Utils;

public static class EnvironmentManger
{
    public static string ApiKey => Environment.GetEnvironmentVariable("API_KEY");
}