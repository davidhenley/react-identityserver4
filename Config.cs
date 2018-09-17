using System.Collections.Generic;
using IdentityServer4.Models;

namespace ID4
{
  public static class Config
  {
    public static IEnumerable<ApiResource> GetApiResources()
    {
      return new List<ApiResource>
      {
        new ApiResource("api", "My API")
      };
    }

    public static IEnumerable<Client> GetClients()
    {
      return new List<Client>
      {
        new Client
        {
          ClientId = "ReactApp",
          AllowedGrantTypes = GrantTypes.ClientCredentials,
          ClientSecrets =
          {
            new Secret("secretkey".Sha256())
          },
          AllowedScopes = { "api" }
        }
      };
    }
  }
}