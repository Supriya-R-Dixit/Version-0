using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Identity.Client;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.Graph;
using System.Net.Http.Headers;




namespace GraceOfGuru
{
    [Activity(Label = "Login", MainLauncher = true)]
    public class MainActivity : Activity
    {

        //public const string SCOPES = "https://graph.microsoft.com/User.Read" ;
        public const string mScopes = "User.Read Calendars.Read";
        public const string MSGRAPH_URL = "https://graph.microsoft.com/v1.0/me";

        public const string ClientId = "d4ab34fd-8ae4-4c6f-851d-7d0f33da349d";
        public const string reDirect = "msauth://com.graceOfGuru.graceOfGuru/jO2liyEJkEGD71OjCQkqvldrtsM%3D";//"msal" + ClientId + "://auth";

        public static object AuthUIParent = null;

        /* UI & Debugging Variables */
        private string TAG = typeof(MainActivity).Name;
        Button callGraphButton;
        Button signOutButton;

        /* Azure AD Variables */
        private IPublicClientApplication sampleApp;
        // private IAuthenticationResult authResult;
        AuthenticationResult silentAuthResult = null;
        string accessToken;

        public static GraphServiceClient GraphClient;



        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.activity_main);

           var check= System.Threading.Thread.CurrentThread.Name;


            callGraphButton = (Button)FindViewById(Resource.Id.callGraph);
            signOutButton = (Button)FindViewById(Resource.Id.clearCache);


            /*            callGraphButton.Click += (sender, e) =>
                        {
                            //      onCallGraphClicked();
                        };

                        signOutButton.Click += (sender, e) =>
                        {
                            //     onSignOutClicked();
                        };*/

            //sampleApp = "";
            /* Configure your sample app and save state for this activity */
            sampleApp = PublicClientApplicationBuilder.Create(ClientId).WithRedirectUri(reDirect).Build();

            var scopes = mScopes.Split(' ');
            accessToken = string.Empty;

          /*  try
            {
                IEnumerable<IAccount> accounts = await sampleApp.GetAccountsAsync();

                if (accounts.Count() > 0)
                {
                    IAccount firstAccount = accounts.FirstOrDefault();
                    silentAuthResult = await sampleApp.AcquireTokenSilent(scopes, firstAccount).ExecuteAsync();

                    await RefreshUserDataAsync(silentAuthResult.AccessToken).ConfigureAwait(false);

                    Console.WriteLine("User already signed in.");
                    Console.WriteLine($"Access token: {silentAuthResult.AccessToken}");
                    accessToken = silentAuthResult.AccessToken;
                }
            }

            catch (MsalUiRequiredException)
            {
                // This exception is thrown when an interactive sign-in is required.
                Console.WriteLine("Silent token request failed, user needs to sign-in");
            }*/

            if (string.IsNullOrEmpty(accessToken))
            {
                // Prompt the user to sign-in
                var interactiveRequest = await sampleApp.AcquireTokenInteractive(scopes).WithParentActivityOrWindow(this).ExecuteAsync();

                await RefreshUserDataAsync(interactiveRequest.AccessToken);

                // var authResult = await interactiveRequest.WithParentActivityOrWindow(this).ExecuteAsync();
                Console.WriteLine("Access Token: {0}", arg0: interactiveRequest.AccessToken);

                var intent = new Intent(this, typeof(OptionsforKids));
                StartActivity(intent);
                AuthUIParent = this;
            }
            //code to create buttons dynamically

            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.grace);

            for (int i = 0; i < 15; i++)
            {
               

                //You create the instance of your view in this case your Button
                Button button = new Button(this);
                button.Text = "grace";
                button.SetBackgroundColor(Android.Graphics.Color.Black);
                button.SetTextColor(Android.Graphics.Color.White);

                //define the button layout
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

                //in case you want to modify other properties of the LayoutParams you use the object
                layoutParams.BottomMargin = 5;

                //Assign the layoutParams to the Button.
                button.LayoutParameters = layoutParams;

                //If you want to do something with the buttons you create you add the handle here
                //button.Click += (sender, e) => DoSomething(id);

                //Add the button as a child of your ViewGroup
                var check2 = System.Threading.Thread.CurrentThread.Name;
                RunOnUiThread(() =>
                {
                    linearLayout.AddView(button);
                });
            }

        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
            //  handleRedirect(requestCode, resultCode, data);  // not sure how to call the redirect URI
        }

        public async Task RefreshUserDataAsync(string token)
        {
            //similar to the authencall that method.. back in teh android part of java.. and al

            //make the graph calls by creating the graph object.. as specified in microsoft graph.. dont use the 
            //http request like in the xamarin code. 


            GraphClient = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
             {
                requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

                 return Task.FromResult(0);
             }));

            var user = await GraphClient.Me.Request().GetAsync();
            callGraphButton.Text=  user.UserPrincipalName.ToString();

            var UserEmail = string.IsNullOrEmpty(user.Mail) ? user.UserPrincipalName : user.Mail;

            Console.WriteLine("Access Token: {0}", arg0: user.DisplayName.ToString());
        }
    }
}