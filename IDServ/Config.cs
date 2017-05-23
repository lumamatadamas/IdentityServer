using IdentityServer4.Models;
using System.Collections.Generic;

using IdentityServer4.Test;

namespace IDServ
{
    public class Config
    {
        //define the Resources that will be protected by IdenityServer
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        //define the clients for different resources
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //client for api1
                new Client
                {
                    ClientId = "client",

                    //no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    //secrete for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = { "api1" }
                },

                //resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                }
            };
        }

        //Class TestUser represent a test user and its claims
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username  = "Alice",
                    Password  = "password"
                },

                new TestUser
                {
                    SubjectId = "2",
                    Username  = "Bob",
                    Password  = "password"
                }
            };
        }
    }
}
