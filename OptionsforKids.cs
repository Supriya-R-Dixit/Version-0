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

namespace GraceOfGuru
{
    [Activity(Label = "OptionsforKids")]
    public class OptionsforKids : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.variousOptionsForKids);

            Button hindiVarnamalaButton = FindViewById<Button>(Resource.Id.HindiVarnamala);

           hindiVarnamalaButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(HindiVarnamala));
                StartActivity(intent);

            };
        }
    }
}