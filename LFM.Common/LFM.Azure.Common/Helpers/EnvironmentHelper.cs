namespace LFM.Azure.Common.Helpers;

public static class EnvironmentHelper
{
    public static bool IsDevelopmentEnvironment() => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"; 
}