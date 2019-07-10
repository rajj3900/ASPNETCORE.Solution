using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(ASPNET.Solution.WebAPI.Startup))]

namespace ASPNET.Solution.WebAPI
{
    //public partial class Startup
    //{
    //    #region Public /Protected Properties.  

    //    /// <summary>  
    //    /// OAUTH options property.  
    //    /// </summary>  
    //    public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

    //    /// <summary>  
    //    /// Public client ID property.  
    //    /// </summary>  
    //    public static string PublicClientId { get; private set; }

    //    #endregion

    //    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864  
    //    public void ConfigureAuth(IAppBuilder app)
    //    {
    //        // Enable the application to use a cookie to store information for the signed in user  
    //        // and to use a cookie to temporarily store information about a user logging in with a third party login provider  
    //        // Configure the sign in cookie  
    //        app.UseCookieAuthentication(new CookieAuthenticationOptions
    //        {
    //            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    //            LoginPath = new PathString("/Account/Login"),
    //            LogoutPath = new PathString("/Account/LogOff"),
    //            ExpireTimeSpan = TimeSpan.FromMinutes(5.0),
    //        });

    //        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

    //        // Configure the application for OAuth based flow  
    //        PublicClientId = "self";
    //        OAuthOptions = new OAuthAuthorizationServerOptions
    //        {
    //            TokenEndpointPath = new PathString("/Token"),
    //            Provider = new AppOAuthProvider(PublicClientId),
    //            AuthorizeEndpointPath = new PathString("/Account/ExternalLogin"),
    //            AccessTokenExpireTimeSpan = TimeSpan.FromHours(4),
    //            AllowInsecureHttp = true //Don't do this in production ONLY FOR DEVELOPING: ALLOW INSECURE HTTP!  
    //        };

    //        // Enable the application to use bearer tokens to authenticate users  
    //        app.UseOAuthBearerTokens(OAuthOptions);

    //        // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.  
    //        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

    //        // Enables the application to remember the second login verification factor such as phone or email.  
    //        // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.  
    //        // This is similar to the RememberMe option when you log in.  
    //        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

    //        // Uncomment the following lines to enable logging in with third party login providers  
    //        //app.UseMicrosoftAccountAuthentication(  
    //        //    clientId: "",  
    //        //    clientSecret: "");  

    //        //app.UseTwitterAuthentication(  
    //        //   consumerKey: "",  
    //        //   consumerSecret: "");  

    //        //app.UseFacebookAuthentication(  
    //        //   appId: "",  
    //        //   appSecret: "");  

    //        //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()  
    //        //{  
    //        //    ClientId = "",  
    //        //    ClientSecret = ""  
    //        //});  
    //    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //ConfigureOAuth(app);
            //ConfigureWinAAD(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(
            new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType
            });

            //app.UseKentorOwinCookieSaver();  // As suggested by https://stackoverflow.com/questions/42431801/after-implementing-to-office-365-able-to-login-but-getting-bad-request
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                        new OpenIdConnectAuthenticationOptions
                        {
                            ClientId = "28dec8ad-27dd-47bb-b9ac-28d6edcb753d",//"c8b3de1f-f71c-48b8-9152-adb48ff6d8d7",//clientId,
                            Authority = "https://login.microsoftonline.com/8c9fd545-f29a-459a-8173-21a393cc7d66",//authority,
                            RedirectUri = "http://localhost:10540/",//realm,
                            TokenValidationParameters = new TokenValidationParameters { SaveSigninToken = true }
                        });
        }

        public void ConfigureWinAAD(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    AuthenticationType = "Bearer",
                    AuthenticationMode = AuthenticationMode.Active,
                    Tenant = "8c9fd545-f29a-459a-8173-21a393cc7d66",

                    TokenValidationParameters = new TokenValidationParameters
                    {
                        SaveSigninToken = true,
                        ValidAudience = "28dec8ad-27dd-47bb-b9ac-28d6edcb753d"
                    }
                });
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                Provider = new IMNTAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }

    public class IMNTAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                string toscaUser = context.UserName;
                string toscaPassword = context.Password;
                bool toscaValidUser = false;

                string adminUser = ConfigurationManager.AppSettings["AdminUser"];
                string adminUserPassword = ConfigurationManager.AppSettings["AdminUserPassword"];
                string juryUser = ConfigurationManager.AppSettings["JuryUser"];
                string juryUserPassword = ConfigurationManager.AppSettings["JuryUserPassword"];

                if (toscaUser.ToLower() == adminUser.ToLower() && toscaPassword.ToLower() == adminUserPassword.ToLower())
                    toscaValidUser = true;

                if (toscaUser.ToLower() == juryUser.ToLower() && toscaPassword.ToLower() == juryUserPassword.ToLower())
                    toscaValidUser = true;

                if (!toscaValidUser)
                {
                    context.SetError("invalid_grant", "Invalid User Id or password'");
                    context.Rejected();
                }
                else
                {
                    context.Validated(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Upn, toscaUser) }, context.Options.AuthenticationType));
                }
            }
            catch
            {
                context.SetError("Could not retrieve user details");
                context.Rejected();
                return;
            }
        }
    }
}
