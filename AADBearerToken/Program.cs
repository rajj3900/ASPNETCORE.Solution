using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AADBearerToken
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMethod();
        }
        static async void MainMethod()
        {
            // Normally you would use a single Global HttpClient per MS guidance
            // but for demo purposes... Just create one inline
            HttpClient client = new HttpClient();

            // This is an Aspx page so clearing anything already written in the buffer
            //Response.Clear();

            try
            {
                // get the token
                var token = await ServicePrincipal.GetS2SAccessTokenForProdMSAAsync();

                // set the auth header with the aquired Bearer token
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.AccessToken);

                // make the call to the resource requiring auth!
                var resp = await client.GetAsync("http://localhost:10540/api/countries");

                // do something with the response
                Console.WriteLine(resp.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                // important to log the exception if any because it will tell you what went wrong
                Console.WriteLine(ex.Message);
            }

            // write page out
            //Response.Flush();
            Console.ReadKey();
        }
    }

    public static class ServicePrincipal
    {
        /// <summary>
        /// The variables below are standard Azure AD terms from our various samples
        /// We set these in the Azure Portal for this app for security and to make it easy to change (you can reuse this code in other apps this way)
        /// You can name each of these what you want as long as you keep all of this straight
        /// </summary>
        static string authority = "https://login.microsoftonline.com/8c9fd545-f29a-459a-8173-21a393cc7d66/oauth2/token";  // the AD Authority used for login.  For example: https://login.microsoftonline.com/myadnamehere.onmicrosoft.com 
        static string clientId = "28dec8ad-27dd-47bb-b9ac-28d6edcb753d"; // the Application ID of this app.  This is a guid you can get from the Advanced Settings of your Auth setup in the portal
        static string clientSecret = "7mqCgmubu9VzlO7DpZNiL3yVnYbmfoz5QwrsCPvlLuk="; // the key you generate in Azure Active Directory for this application
        static string resource = "http://localhost:10540/"; // the Application ID of the app you are going to call.  This is a guid you can get from the Advanced Settings of your Auth setup for the targetapp in the portal

        /// <summary>
        /// wrapper that passes the above variables
        /// </summary>
        /// <returns></returns>
        static public async Task<AuthenticationResult> GetS2SAccessTokenForProdMSAAsync()
        {
            return await GetS2SAccessToken(authority, resource, clientId, clientSecret);
        }

        static async Task<AuthenticationResult> GetS2SAccessToken(string authority, string resource, string clientId, string clientSecret)
        {
            try
            {
                var clientCredential = new ClientCredential(clientId, clientSecret);
                AuthenticationContext context = new AuthenticationContext(authority, false);
                AuthenticationResult authenticationResult = await context.AcquireTokenAsync(
                    resource,  // the resource (app) we are going to access with the token
                    clientCredential);  // the client credentials
                return authenticationResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                var clientCredential = new ClientCredential(clientId, clientSecret);
                AuthenticationContext context = new AuthenticationContext(authority, false);
                AuthenticationResult authenticationResult = await context.AcquireTokenAsync(
                    resource,  // the resource (app) we are going to access with the token
                    clientCredential);  // the client credentials
                return authenticationResult;
            }
            
        }
    }
}
