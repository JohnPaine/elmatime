using System;
using System.Collections.Generic;
using Android.Accounts;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using ImpeltechTime.Droid;

namespace ImpeltechTime.Droid
{
    [Activity (Label = "ImpeltechTime", Icon = "@drawable/icon", MainLauncher = true)]
    public class LoginActivity : AccountAuthenticatorActivity
    {
        protected override void OnCreate (Bundle bundle) {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Login);

            Log.Info("LoginActivity", "Starting");

            var pref = GetPreferences (FileCreationMode.Private);
            var userInvalid = Intent.GetBooleanExtra("user_invalid", false);
            if (userInvalid) {
                Log.Info("LoginActivity", "User invalid");
                var editor = pref.Edit();
                editor.PutString("u_name", "");
                editor.PutString("p", "");
                editor.Commit();
            }

            Log.Info("LoginActivity", "Getting credentials");
            var cred = new Tuple<string, string> (pref.GetString ("u_name", ""), pref.GetString ("p", ""));

            if (cred.Item1 != "") {
                Log.Info("LoginActivity", "Got credentials and starting TaskListActivity");
                var taskListIntent = new Intent (this, typeof (TaskListActivity));
                taskListIntent.PutExtra ("cred", new[] {cred.Item1, cred.Item2});
                StartActivity (taskListIntent);
                Finish ();
                Log.Info("LoginActivity", "Started TaskListActivity and Finishing LoginActivity");
                // TODO: disable goback for activity if needed :
//                     TODO: add logout!!!
                // In AndroidManifest.xml add: android: noHistory = "true"
                return;
            }

            var button = FindViewById<Button> (Resource.Id.LoginButton);

            button.Click += delegate {
                var an = FindViewById<EditText>(Resource.Id.loginEditText).Text;
                var p = FindViewById<EditText>(Resource.Id.passwordEditText).Text;

                var editor = pref.Edit ();
                editor.PutString ("u_name", an);
                editor.PutString("p", p);
                editor.Commit ();

                var intent = new Intent(this, typeof(TaskListActivity));
                intent.PutExtra("cred", new[] { an, p });
                StartActivity(intent);
                Finish();
                Log.Info("LoginActivity", "Started TaskListActivity and Finishing LoginActivity");
            };
        }
    }
}