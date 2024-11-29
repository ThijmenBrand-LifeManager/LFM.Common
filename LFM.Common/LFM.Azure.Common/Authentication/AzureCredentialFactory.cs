using Azure.Identity;
using LFM.Azure.Common.Helpers;

namespace LFM.Azure.Common.Authentication;

public static class AzureCredentialFactory
{
    private const string BaseMessage = "Setting up DefaultAzureCredential - ";

    public static DefaultAzureCredential GetCredential(string? managedIdentityClientId = null)
    {
        var defaultAzureCredentialOptions = new DefaultAzureCredentialOptions();

        if (EnvironmentHelper.IsDevelopmentEnvironment())
        {
            Console.WriteLine(BaseMessage + "Development environment detected. Using Azure CLI credential.");
            defaultAzureCredentialOptions.ExcludeInteractiveBrowserCredential = false;
        }
        else
        {
            Console.WriteLine(BaseMessage +
                              $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")} environment detected. Using Managed Identity credential.");
        }

        if (!string.IsNullOrEmpty(managedIdentityClientId))
        {
            Console.WriteLine(BaseMessage + $"Setting Managed Identity Client Id to {managedIdentityClientId}");
            defaultAzureCredentialOptions.ManagedIdentityClientId = managedIdentityClientId;
        }
        else
        {
            Console.WriteLine(BaseMessage + "Managed Identity Client Id not provided.");
        }

        var credential = new DefaultAzureCredential(defaultAzureCredentialOptions);
        return credential;
    }
}