using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace GraceOfGuru
{
    [Activity(Label = "HindiVarnamala", MainLauncher = false)]
    public class HindiVarnamala : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // download JSON
            // deserialize JSON
            // get the number of nodes in the JSON (represents number of alphabets)
            // foreach (... number of nodes)
            // {

            SetContentView(Resource.Layout.HindiVarnamala);
  
            Button buttonAam = FindViewById<Button>(Resource.Id.button_Aa);
            Button buttonAinak = FindViewById<Button>(Resource.Id.button_Ai);
            Button buttonGamala = FindViewById<Button>(Resource.Id.button_Ga);
            Button buttonChaata = FindViewById<Button>(Resource.Id.button_cha);
            Button buttonTaala = FindViewById<Button>(Resource.Id.button_Ta);
            Button buttonDus = FindViewById<Button>(Resource.Id.button_Da);

            Button buttonBharath = FindViewById<Button>(Resource.Id.button_Bha);
            Button buttonBatak = FindViewById<Button>(Resource.Id.button_Ba);
            Button buttonMatar = FindViewById<Button>(Resource.Id.button_Ma);

            Console.WriteLine("folder location", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            //JSONFlashCards flashCardData= JsonConvert.DeserializeObject<JSONFlashCards>(File.ReadAllText(@"/assets/jsonfile.txt"));
            //using (StreamReader file = File.OpenText(@"/assets/jsonfile.txt"))
            AssetManager assets = this.Assets;

            /* using (StreamReader file = new StreamReader(assets.Open("jsonfile.txt")))
             {
                  JsonSerializer serializer = new JsonSerializer();
                  JSONFlashCards FlashCarddata = (JSONFlashCards)serializer.Deserialize(file, typeof(JSONFlashCards));

                 string json = file.ReadToEnd();
                 Console.WriteLine(json);
                 //List<JSONFlashCards> items = JsonConvert.DeserializeObject<List<JSONFlashCards>>(json);
                 List<System.String> items = JsonConvert.DeserializeObject<List<System.String>>(json);

                 Console.WriteLine("writing my first json object");
                 foreach (System.String value in items)
                 {
                     Console.WriteLine(value.Alphabet);
                     Console.WriteLine(value.Location);
                 }

             }*/



            //checking how file system works

            //  StreamReader jsonPath = new StreamReader(assets.Open("jsonfile.txt"));
            /* List<JSONFlashCards> fileList = new List<JSONFlashCards>();
             string jsonString = File.ReadAllText(@"/assets/jsonfile.txt");
             dynamic files = JsonConvert.DeserializeObject(jsonString);

             foreach (var f in files.objects)
                 fileList.Add(new JSONFlashCards(f.Alphabet,f.Location);*/
            string content;

            using (StreamReader file = new StreamReader(assets.Open("JSONvarnamala.txt")))
            {
                content = file.ReadToEnd();
            }

            Console.WriteLine(content);
           // var res = JsonConvert.DeserializeObject<resResRoot>(content);

            Dictionary<string, JSONFlashCards> htmlAttributes = JsonConvert.DeserializeObject<Dictionary<string, JSONFlashCards>>(content);
            Console.WriteLine("checking to see what is printing");
            Console.WriteLine(htmlAttributes[htmlAttributes.Keys.ElementAt(0)]);

            foreach (string key in htmlAttributes.Keys)
            {
                Console.WriteLine(key);
            }

            foreach (KeyValuePair<string, JSONFlashCards> item in htmlAttributes)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value.Location);
            }
            //ResRoot res = JsonConvert.DeserializeObject<ResRoot>(content);
            //dynamic res = JsonConvert.DeserializeObject<ResRoot>(content);

            /*  foreach (var f in res.Files)
               {
                   Console.WriteLine("Name={0} Size={1}", f.Key, f.Value.Location);
               }*/

            /*     foreach (KeyValuePair<string, JSONFlashCards> f in res.Files)
                 {
                     Console.WriteLine("Name={0} Size={1}", f.Key, f.Value.Location);
                 }*/

            buttonAam.Click += (sender, e) =>
             {
                 var intent = new Intent(this, typeof(FlashCards));
                 intent.PutExtra("previous", 2);
                 intent.PutExtra("next", 3);
                 intent.PutExtra("Source", Resource.Drawable.Aam);
                 intent.PutExtra("text", "आम");
                 intent.PutExtra("audio", Resource.Raw.Aam);
                 StartActivity(intent);
             };

          buttonAinak.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 3);
                intent.PutExtra("next", 4);
                intent.PutExtra("Source", Resource.Drawable.Ainak);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Ainak);
                StartActivity(intent);

            };

             buttonGamala.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 4);
                intent.PutExtra("next", 5);
                intent.PutExtra("Source", Resource.Drawable.Gamla);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Gamla);
                StartActivity(intent);
            };

           buttonChaata.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 5);
                intent.PutExtra("next", 6);
                intent.PutExtra("Source", Resource.Drawable.Chaata);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Chaata);
                StartActivity(intent);
            };

              buttonTaala.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 6);
                intent.PutExtra("next", 7);
                intent.PutExtra("Source", Resource.Drawable.Taala);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Taala);
                StartActivity(intent);
            };


            buttonDus.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 7);
                intent.PutExtra("next", 8);
                intent.PutExtra("Source", Resource.Drawable.Dus);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Dus);
                StartActivity(intent);
            };

            buttonBatak.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 8);
                intent.PutExtra("next", 9);
                intent.PutExtra("Source", Resource.Drawable.Batak);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Batakh);
                StartActivity(intent);
            };


            buttonBharath.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 9);
                intent.PutExtra("next", 10);
                intent.PutExtra("Source", Resource.Drawable.Bharath);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Bharath);
                StartActivity(intent);
            };


            buttonMatar.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FlashCards));
                intent.PutExtra("previous", 10);
                intent.PutExtra("next", 11);
                intent.PutExtra("Source", Resource.Drawable.matar);
                intent.PutExtra("text", "ऐनक");
                intent.PutExtra("audio", Resource.Raw.Matar);
                StartActivity(intent);
            };  




            //  
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}