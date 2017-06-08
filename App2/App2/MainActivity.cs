using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Text.RegularExpressions;
using Android.Content;
using Android.Telephony;

namespace App2
{
    [Activity(Label = "App2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button button;
        private EditText address;
        private EditText message;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            button = FindViewById<Button>(Resource.Id.button);
            address = FindViewById<EditText>(Resource.Id.address);
            message = FindViewById<EditText>(Resource.Id.message);
            button.Click += (object sender, EventArgs e) =>
            {
                String text = message.Text;
                if (IsPhoneNumber(address.Text) && string.IsNullOrEmpty(text))
                {
                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + address.Text));
                    StartActivity(callIntent);


                }else if(IsPhoneNumber(address.Text) && !string.IsNullOrEmpty(text)){
                    var smsUri = Android.Net.Uri.Parse("smsto:"+ address.Text);
                    var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                    smsIntent.PutExtra("sms_body", message.Text);
                    StartActivity(smsIntent);
                }else if (IsValidEmail(address.Text))
                {
                    Intent email = new Intent(Intent.ActionSend);
                    email.SetType("message/rfc822");
                    email.PutExtra(Intent.ExtraCc, new String[] { address.Text });
                    email.PutExtra(Intent.ExtraSubject, "Hello!");
                    email.PutExtra(Intent.ExtraText, message.Text);
                    StartActivity(Intent.CreateChooser(email, "Send mail"));
                   /* try
                    {
                        StartActivity(Intent.CreateChooser(i, "Send mail"));
                    }
                    catch (ActivityNotFoundException ex)
                    {
                        Toast.MakeText(this, "There are no email applications installed.", ToastLength.Long).Show();
                    }*/

                }

            };

            
        }


         bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0123456789-]{9,13})$").Success;
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
