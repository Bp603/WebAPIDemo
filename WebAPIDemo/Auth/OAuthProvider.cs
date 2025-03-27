using System;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using Owin;



namespace WebAPIDemo.Auth
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // Allow all clients for now
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (var db = new DB1Entities1()) 
            {
                var user = db.usersTables.FirstOrDefault(u => u.email == context.UserName && u.password == context.Password);

                if (user == null)
                {
                    context.Rejected();
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Email, user.email));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.role));

                context.Validated(identity);
            }
        }
    }
}