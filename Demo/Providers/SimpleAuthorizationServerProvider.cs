using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;

namespace Demo.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            IdentityUser user;
            using (AuthRepository _repo = new AuthRepository())
            {
                 user = await _repo.FindUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            Microsoft.Owin.Security.AuthenticationProperties properties = new Microsoft.Owin.Security.AuthenticationProperties(new Dictionary<string, string>
                    {
                        { "userId", user.Id }
            
                    });
            Microsoft.Owin.Security.AuthenticationTicket ticket = new Microsoft.Owin.Security.AuthenticationTicket(identity, properties);
            // the above didn't worked so working around for the same
            context.Validated(ticket);
           // context.Validated(identity);
        }
        
    }
}