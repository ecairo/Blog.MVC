using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Helpers
{
    public static class ServiceExtensions
    {
        public static string MyReverse(this string stringToReverse)
        {

            return "String reversed";
        }

        public static void ConfigureAuth(this IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                //Provider = new CookieAuthenticationProvider
                //{
                //    // Enables the application to validate the security stamp when the user logs in.
                //    // This is a security feature which is used when you change a password or add an external login to your account.  
                //    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                //    validateInterval: TimeSpan.FromMinutes(30),
                //    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                //}
            });
        }
    }
}