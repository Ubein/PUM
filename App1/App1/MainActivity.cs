using Android.App;
using Android.Widget;
using Android.OS;
using System.Text.RegularExpressions;
using System;
using Android.Content;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button translatebutton;
        private EditText plaintext1;
        private EditText plaintext2;
        private string translatednumber;
        private Button callbutton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            translatebutton = FindViewById<Button>(Resource.Id.Translate);
            callbutton = FindViewById<Button>(Resource.Id.buttoncall);
            plaintext1 = FindViewById<EditText>(Resource.Id.PhoneNumber);
            plaintext2 = FindViewById<EditText>(Resource.Id.PhoneNumberTran);
            translatebutton.Click += (object sender, EventArgs e) =>
            {
                plaintext2.Text = getNumber(plaintext1.Text);
            };
            callbutton.Click += (object sender, EventArgs e) =>
            {
                var callIntent = new Intent(Intent.ActionCall);
                callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatednumber));
                StartActivity(callIntent);
            };
        }
        string getNumber(string text1)
        {
            string number = text1;
            number = Regex.Replace(number, @"[abcABC]", "2");
            number = Regex.Replace(number, @"[defDEF]", "3");
            number = Regex.Replace(number, @"[ghiGHI]", "4");
            number = Regex.Replace(number, @"[jklJKL]", "5");
            number = Regex.Replace(number, @"[mnoMNO]", "6");
            number = Regex.Replace(number, @"[pqrsPQRS]", "7");
            number = Regex.Replace(number, @"[tuvTUV]", "8");
            number = Regex.Replace(number, @"[wxyzWXYZ]", "9");
            translatednumber = number;
            return translatednumber;
        }
    }
}

