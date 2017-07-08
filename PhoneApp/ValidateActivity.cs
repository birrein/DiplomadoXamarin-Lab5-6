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

namespace PhoneApp
{
    [Activity(Label = "@string/ValidateActivity")]
    public class ValidateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Validate);

            var TextResult = FindViewById<TextView>(Resource.Id.ResultView);
            var ValidateButton = FindViewById<Button>(Resource.Id.ValidateButton);
            var EmailText = FindViewById<EditText>(Resource.Id.EmailText);
            var PasswordText = FindViewById<EditText>(Resource.Id.PasswordText);
            string EMail;
            string Password;
            string Device = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);


            ValidateButton.Click += (sender, e) =>
            {
                EMail = EmailText.Text;
                Password = PasswordText.Text;
                Validate();
            };

            async void Validate()
            {
                string Result;

                var ServiceClient = new SALLab06.ServiceClient();
                var SvcResult = await ServiceClient.ValidateAsync(EMail, Password, Device);

                Result = $"{SvcResult.Status}\n{SvcResult.Fullname}\n{SvcResult.Token}";
                TextResult.Text = Result;
            }
        }
    }
}