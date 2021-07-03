using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Config
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
        {
          new TestUser
          {
            SubjectId = "818727",
            Username = "alice",
            Password = "alice",
            Claims =
            {
              new Claim(JwtClaimTypes.Name, "Alice Smith"),
              new Claim(JwtClaimTypes.GivenName, "Alice"),
              new Claim(JwtClaimTypes.FamilyName, "Smith"),
              new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
              new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
              new Claim(JwtClaimTypes.Role, "admin"),
              new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
              new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address),
                IdentityServerConstants.ClaimValueTypes.Json)
            }
          },
          new TestUser
          {
            SubjectId = "88421113",
            Username = "bob",
            Password = "bob",
            Claims =
            {
              new Claim(JwtClaimTypes.Name, "Bob Smith"),
              new Claim(JwtClaimTypes.GivenName, "Bob"),
              new Claim(JwtClaimTypes.FamilyName, "Smith"),
              new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
              new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
              new Claim(JwtClaimTypes.Role, "user"),
              new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
              new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address),
                IdentityServerConstants.ClaimValueTypes.Json)
            }
          }
        };
            }
        }

        public static IEnumerable<IdentityResource> IdentityResources =>
          new[]
          {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource
        {
          Name = "role",
          UserClaims = new List<string> {"role"}
        }
          };

        public static IEnumerable<ApiScope> ApiScopes =>
          new[]
          {
        new ApiScope("activitiesapi.read"),
        new ApiScope("activitiesapi.write"),
        new ApiScope("groupsapi.read"),
        new ApiScope("groupsapi.write"),
        new ApiScope("roomsmanagementapi.read"),
        new ApiScope("roomsmanagementapi.write"),
        new ApiScope("scheduleapi.read"),
        new ApiScope("scheduleapi.write"),
        new ApiScope("teachingapi.read"),
        new ApiScope("teachingapi.write")
          };
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
      new ApiResource("activitiesapi")
      {
        Scopes = new List<string> { "activitiesapi.read", "activitiesapi.write"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        UserClaims = new List<string> {"role"}
      },
      new ApiResource("groupsapi")
      {
        Scopes = new List<string> { "groupsapi.read", "groupsapi.write"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        UserClaims = new List<string> {"role"}
      },
      new ApiResource("roomsmanagementapi")
      {
        Scopes = new List<string> { "roomsmanagementapi.read", "roomsmanagementapi.write"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        UserClaims = new List<string> {"role"}
      },
      new ApiResource("scheduleapi")
      {
        Scopes = new List<string> { "scheduleapi.read", "scheduleapi.write"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        UserClaims = new List<string> {"role"}
      },
      new ApiResource("teachingapi")
      {
        Scopes = new List<string> { "teachingapi.read", "teachingapi.write"},
        ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
        UserClaims = new List<string> {"role"}
      }
    };

        public static IEnumerable<Client> Clients =>
          new[]
          {
            // m2m client credentials flow client
            new Client
            {
              ClientId = "m2m.client",
              ClientName = "Client Credentials Client",

              AllowedGrantTypes = GrantTypes.ClientCredentials,
              ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

              AllowedScopes = { "activitiesapi.read", "activitiesapi.write", "groupsapi.read", "groupsapi.write",
                "roomsmanagementapi.read", "roomsmanagementapi.write", "scheduleapi.read", "scheduleapi.write", "teachingapi.read", "teachingapi.write"}
            },

            // interactive client using code flow + pkce
            new Client
            {
              ClientId = "interactive",
              ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

              AllowedGrantTypes = GrantTypes.Code,

              RedirectUris = {"https://localhost:5444/signin-oidc"},
              FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
              PostLogoutRedirectUris = {"https://localhost:5444/signout-callback-oidc"},

              AllowOfflineAccess = true,
              AllowedScopes = {"openid", "profile", "activitiesapi.read", "groupsapi.read", "roomsmanagementapi.read",
                "scheduleapi.read", "teachingapi.read"},
              RequirePkce = true,
              RequireConsent = true,
              AllowPlainTextPkce = false
            },
          };
    }
}
