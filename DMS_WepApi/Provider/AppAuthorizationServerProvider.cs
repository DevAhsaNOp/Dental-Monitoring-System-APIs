using DMS_BLL.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace DMS_WepApi.Provider
{
    public class AppAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            UsersRepo repo = new UsersRepo();
            var user = repo.CheckLoginDetails(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Email and Password is incorrect!");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in user.Role.Split(','))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Trim()));
            }
            context.Validated(identity);
        }
    }
}