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
using Android.Media;

namespace GraceOfGuru
{
    [Activity(Label = "FlashCards")]
    public class FlashCards : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            int imageSource = Intent.GetIntExtra("Source", 0);
            System.String textSource = base.Intent.GetStringExtra("text");
            int audioSource = Intent.GetIntExtra("audio",0);
            MediaPlayer _player;

            SetContentView(Resource.Layout.FlashCards);
            ImageView image = FindViewById<ImageView>(Resource.Id.imageView1);
            TextView text = FindViewById<TextView>(Resource.Id.textForAam);

            
            

            image.SetBackgroundResource(imageSource);
            text.Text = textSource;
            _player = MediaPlayer.Create(this, audioSource);

            ImageButton buttonPrevious = FindViewById<ImageButton>(Resource.Id.buttonPrev);
            ImageButton buttonHome = FindViewById<ImageButton>(Resource.Id.buttonHome);
            ImageButton buttonNext = FindViewById<ImageButton>(Resource.Id.buttonNext);
            ImageButton buttonSound = FindViewById<ImageButton>(Resource.Id.buttonSound);

            int left = Intent.GetIntExtra("previous", 0);
            int right = Intent.GetIntExtra("next", 0);

            buttonSound.Click += (sender, e) =>
              {
                  _player.Start();
              };


            buttonPrevious.Click += (sender, e) =>
            {

                if (left == 3)
                {
                    image.SetBackgroundResource(Resource.Drawable.Aam);
                    text.Text = "आम";
                    left = 2;
                    right = 3;
                    _player = MediaPlayer.Create(this, Resource.Raw.Aam);
                }

                else if(left == 4)
                {
                    image.SetBackgroundResource(Resource.Drawable.Ainak);
                    text.Text = "ऐनक";
                    _player = MediaPlayer.Create(this, Resource.Raw.Ainak);
                    left = 3;
                    right = 4;

                }

                else if (left == 5)
                {
                    image.SetBackgroundResource(Resource.Drawable.Gamla);
                    text.Text = "गमला";
                    _player = MediaPlayer.Create(this, Resource.Raw.Gamla);
                    left = 4;
                    right = 5;

                }

                else if (left == 6)
                {
                    image.SetBackgroundResource(Resource.Drawable.Chaata);
                    text.Text = "छाता";
                    _player = MediaPlayer.Create(this, Resource.Raw.Chaata);
                    left = 5;
                    right = 6;

                }

                else if (left == 7)
                {
                    image.SetBackgroundResource(Resource.Drawable.Taala);
                    text.Text = "ताला";
                    _player = MediaPlayer.Create(this, Resource.Raw.Taala);
                    left = 6;
                    right = 7;

                }

                else if (left == 8)
                {
                    image.SetBackgroundResource(Resource.Drawable.Dus);
                    text.Text = "दस";
                    left = 7;
                    right = 8;

                }

                else if (left == 9)
                {
                    image.SetBackgroundResource(Resource.Drawable.Batak);
                    text.Text = "बत्तख";
                    left = 8;
                    right = 9;

                }


                else if (left == 10)
                {
                    image.SetBackgroundResource(Resource.Drawable.Bharath);
                    text.Text = "भारत";
                    _player = MediaPlayer.Create(this, Resource.Raw.Bharath);
                    left = 9;
                    right = 10;

                }


                else if (left == 11)
                {
                    image.SetBackgroundResource(Resource.Drawable.matar);
                    text.Text = "मटर";
                    _player = MediaPlayer.Create(this, Resource.Raw.Matar);
                    left = 10;
                    right = 11;

                }

            };


            buttonHome.Click += (sender, e) =>
            {
                Finish();
            };

            buttonNext.Click += (Sender, e) =>
            {
                if(right==3)
                {
                    image.SetBackgroundResource(Resource.Drawable.Ainak);
                    text.Text = "ऐनक";
                    _player = MediaPlayer.Create(this, Resource.Raw.Ainak);
                    left = 3;
                    right = 4;
                }

                else if(right == 4)
                {
                    image.SetBackgroundResource(Resource.Drawable.Gamla);
                    text.Text = "गमला";
                    _player = MediaPlayer.Create(this, Resource.Raw.Gamla);
                    left = 4;
                    right = 5;
                }

                else if (right == 5)
                {
                    image.SetBackgroundResource(Resource.Drawable.Chaata);
                    text.Text = "छाता";
                    _player = MediaPlayer.Create(this, Resource.Raw.Chaata);
                    left = 5;
                    right = 6;

                }

                else if (right == 6)
                {
                    image.SetBackgroundResource(Resource.Drawable.Taala);
                    text.Text = "ताला";
                    _player = MediaPlayer.Create(this, Resource.Raw.Taala);
                    left = 6;
                    right = 7;

                }

                else if (right == 7)
                {
                    image.SetBackgroundResource(Resource.Drawable.Dus);
                    text.Text = "दस";
                    _player = MediaPlayer.Create(this, Resource.Raw.Dus);
                    left = 7;
                    right = 8;

                }

                else if (right == 8)
                {
                    image.SetBackgroundResource(Resource.Drawable.Batak);
                    text.Text = "बत्तख";
                    _player = MediaPlayer.Create(this, Resource.Raw.Batakh);
                    left = 8;
                    right = 9;

                }


                else if (right == 9)
                {
                    image.SetBackgroundResource(Resource.Drawable.Bharath);
                    text.Text = "भारत";
                    _player = MediaPlayer.Create(this, Resource.Raw.Bharath);
                    left = 9;
                    right = 10;

                }


                else if (right == 10)
                {
                    image.SetBackgroundResource(Resource.Drawable.matar);
                    text.Text = "मटर";
                    _player = MediaPlayer.Create(this, Resource.Raw.Matar);
                    left = 10;
                    right = 11;

                }


            };

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}