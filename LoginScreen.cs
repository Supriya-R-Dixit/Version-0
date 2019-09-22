using System;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Microsoft.Identity.Client;
using Xamarin.Android;
using System.Collections;
using System.Collections.Generic;

namespace GraceOfGuru
{
    [Activity(Label = "LoginScreen", MainLauncher = false)]
    public class LoginScreen : Activity
    {
        // private AuthenticationHelper mAuthHelper = null;

        // the following code is related to oauth using microsoft identity

        private IPublicClientApplication mPCA = null;
        //private String[] mScopes;
        public static object AuthUIParent = null;

        public const string ClientId = "ad6b1c58-2c79-4714-96a1-c5ffabbeb024";
        // public const string mScopes = "User.Read Calendars.Read";
        public const string mScopes = "https://graph.microsoft.com/User.Read";
        public const string MSGRAPH_URL = "https://graph.microsoft.com/v1.0/me";
        public const string reDirect = "msal"+ClientId+ "://auth";


        /* Azure AD Variables */
        private PublicClientApplication sampleApp;
       // private IAuthenticationResult authResult;

        // the above code is related to oauth using microsoft identity


        public LoginScreen()
        {
            // the following code is related to oauth using microsoft identity

            //   String ClientId =this.Resources.GetString(Resource.String.oauth_app_id);
            //   mScopes = this.Resources.GetStringArray(Resource.Array.oauth_scopes);
            mPCA = PublicClientApplicationBuilder.Create(ClientId).WithRedirectUri(reDirect).Build();

            // the above code is related to oauth using microsoft identity
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Main);
          // Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //mAuthHelper = AuthenticationHelper.getInstance();


            Console.WriteLine("GetEnvironmentVariables: ");
            foreach (DictionaryEntry de in System.Environment.GetEnvironmentVariables())
                Console.WriteLine("  {0} = {1}", de.Key, de.Value);

            Console.WriteLine("GetFolderPath: {0}", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            Console.WriteLine("GetFolderPath: {0}", System.Environment.GetFolderPath(System.Environment.SpecialFolder.System));
            int count = 4;
            //   var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "count.txt");
            /*   using (var writer = File.CreateText(backingFile))
               {
                   await writer.WriteLineAsync(count.ToString());
               }*/

            EditText usernameEditText = FindViewById<EditText>(Resource.Id.username);
            Button loginButton = FindViewById<Button>(Resource.Id.login);
            TextView messageTextView = FindViewById<TextView>(Resource.Id.messageDisplay);

            loginButton.Click += (sender, e) =>
            {
                Authenticate();

                if (usernameEditText.Text.CompareTo("Supriya") == 0 || usernameEditText.Text.CompareTo("Sree") == 0 || usernameEditText.Text.CompareTo("Rekha") == 0 || usernameEditText.Text.CompareTo("Ajay") == 0)
                {
                    // Connect check = new Connect();
                    //          check.OnSignInSignOut
                    // check.OnSignInSignOut();

                    messageTextView.Text = "there is grace!";
                   /* var intent = new Intent(this, typeof(OptionsforKids));
                    StartActivity(intent);
                    AuthUIParent = this;  //does this code here even make sense?*/

                }
                else
                {
                    messageTextView.Text = "Login failed! Try again";
                }



            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
           // Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private async void Authenticate()
        {
            var scopes = mScopes.Split(' ');
            string accessToken = string.Empty;
            try
            {
                var accounts = await mPCA.GetAccountsAsync();
                if (accounts.Count() > 0)
                {
                    var silentAuthResult = await mPCA.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                        .ExecuteAsync();

                    // Debug.
                    Console.WriteLine("User already signed in.");
                    Console.WriteLine($"Access token: {silentAuthResult.AccessToken}");
                    accessToken = silentAuthResult.AccessToken;
                }
            }
            catch (MsalUiRequiredException)
            {
                // This exception is thrown when an interactive sign-in is required.
                Console.WriteLine("Silent token request failed, user needs to sign-in");
            }

            if (string.IsNullOrEmpty(accessToken))
            {
                // Prompt the user to sign-in
                var interactiveRequest = await mPCA.AcquireTokenInteractive(scopes).WithParentActivityOrWindow(this).ExecuteAsync();

                if (AuthUIParent != null)
                {
                    //   interactiveRequest = interactiveRequest
                    //     .WithParentActivityOrWindow(AuthUIParent);
                }

                // var authResult = await interactiveRequest.WithParentActivityOrWindow(this).ExecuteAsync();
                Console.WriteLine("Access Token: {0}", arg0: interactiveRequest.AccessToken);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
            //  handleRedirect(requestCode, resultCode, data);  // not sure how to call the redirect URI
        }

        /* public void handleRedirect(int requestCode, Result resultCode, Intent data)
         {
             mPCA.handleInteractiveRequestRedirect(requestCode, resultCode, data);

         }*/
    }
}
