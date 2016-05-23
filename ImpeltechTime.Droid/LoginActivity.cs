using System;
using System.Collections.Generic;
using Android.Accounts;
using Android.App;
using Android.Content;
using Android.OS;
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

            var pref = GetPreferences (FileCreationMode.Private);
            var userInvalid = Intent.GetBooleanExtra("user_invalid", false);
            if (userInvalid) {
                var editor = pref.Edit();
                editor.PutString("u_name", "");
                editor.PutString("p", "");
                editor.Commit();
            }

            var cred = new Tuple<string, string> (pref.GetString ("u_name", ""), pref.GetString ("p", ""));

            if (cred.Item1 != "") {
                var intent = new Intent (this, typeof (TaskListActivity));
                intent.PutExtra ("cred", new[] {cred.Item1, cred.Item2});
                StartActivity (intent);
                Finish ();
                // TODO: disable goback for activity if needed :
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
            };
        }
    }
}