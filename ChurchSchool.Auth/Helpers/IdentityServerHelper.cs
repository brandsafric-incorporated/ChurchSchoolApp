using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSchool.Auth.Helpers
{
    public static class IdentityServerHelper
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ChurchSchoolApi", "teste api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client{
                    ClientId = "site",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("upper+topper+ultra+lol+supersecret".Sha256()) },
                    AllowedScopes = { "ChurchSchoolApi" }
                },new Client{
                    ClientId = "site-pwd",
                    AllowedGrantTypes = {
                        GrantTypes.ResourceOwnerPassword.ToString(),
                        GrantTypes.ClientCredentials.ToString()
                    },
                    ClientSecrets = { new Secret("upper+topper+ultra+lol+supersecret".Sha256()) },
                    AllowedScopes = { "ChurchSchoolApi" }
                }
            };

        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }


    }
}
