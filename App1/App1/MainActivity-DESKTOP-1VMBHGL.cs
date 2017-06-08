using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button translatebutton;
        private EditText textarea1;
        private EditText textarea2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            translatebutton = FindViewById<Button>(Resource.Id.Translate);
            textarea1 = FindViewById<EditText>(Resource.Id.PhoneNumber);
            textarea2 = FindViewById<EditText>(Resource.Id.PhoneNumberTran);
            translatebutton.Click += (object sender, EventArgs e) =>
            {
                textarea2 = textarea1;
            };

        }
    }
}

