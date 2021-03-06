﻿using System;
using System.Threading.Tasks;
using Android.Accounts;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using ImpeltechTime.Droid.Core.Model;
using ImpeltechTime.Droid.Core.Providers;

namespace ImpeltechTime.Droid
{
    [Activity (Label = "ImpeltechTime", Icon = "@drawable/icon", MainLauncher = true)]
    public class LoginActivity : AccountAuthenticatorActivity
    {
        protected override void OnCreate (Bundle bundle) {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Login);

            Log.Info ("LoginActivity", "Starting");

            var pref = GetPreferences (FileCreationMode.Private);
            var userInvalid = Intent.GetBooleanExtra ("user_invalid", false);
            if (userInvalid) {
                Log.Info ("LoginActivity", "User invalid");
                var editor = pref.Edit ();
                editor.PutString ("u_name", "");
                editor.PutString ("p", "");
                editor.Commit ();
            }

            Log.Info ("LoginActivity", "Getting credentials");
            var cred = new Tuple<string, string> (pref.GetString ("u_name", ""), pref.GetString ("p", ""));

            if (cred.Item1 != "") {
                Log.Info ("LoginActivity", "Got credentials and starting TaskListActivity");
                var taskListIntent = new Intent (this, typeof (TaskListActivity));
                taskListIntent.PutExtra ("cred", new[] {cred.Item1, cred.Item2});
                StartActivity (taskListIntent);
                Finish ();
                Log.Info ("LoginActivity", "Started TaskListActivity and Finishing LoginActivity");
                // TODO: disable goback for activity if needed :
                // In AndroidManifest.xml add: android: noHistory = "true"
                return;
            }

            var button = FindViewById<Button> (Resource.Id.LoginButton);

            button.Click += async delegate {
                var an = FindViewById<EditText> (Resource.Id.loginEditText).Text;
                var p = FindViewById<EditText> (Resource.Id.passwordEditText).Text;

                // TODO: add "loading sign" while authorizing user

                var user = await LoginAsync (an, p);
                if (null == user) {
                    // TODO: add some tooltip for user that credentials aren't OK or Internet is off...
                    // TODO: add checking for App permissions if needed
                    return;
                }

                var editor = pref.Edit ();
                editor.PutString ("u_name", an);
                editor.PutString ("p", p);
                editor.Commit ();

                var intent = new Intent (this, typeof (TaskListActivity));
                intent.PutExtra ("cred", new[] {an, p});
                StartActivity (intent);
                Finish ();

                Log.Info ("LoginActivity", "Started TryLoginUser in secondary thread");
            };
        }

        private static async Task<IElmaUser> LoginAsync (string name, string pass) {
            return await Task.Run (() => {
                var userProvider =
                    App.Container.Resolve (typeof (ElmaUserProvider), "ElmaUserProvider") as ElmaUserProvider;
                var user = userProvider?.LoginUser (name, pass);
                if (null == user)
                    Log.Error ("LoginActivity, LoginAsync", "Error getting user instance! Wrong credentials or connection error");
                return user;
            });
        }
    }
}