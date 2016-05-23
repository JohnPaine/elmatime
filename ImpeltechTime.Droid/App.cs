using System;
using System.Collections.Generic;
using System.ComponentModel;
using Android.Accounts;
using Android.App;
using Android.Runtime;
using ImpeltechTime.Droid.Core;
using ImpeltechTime.Droid.Core.Internal;
using ImpeltechTime.Droid.Core.Model;
using ImpeltechTime.Droid.Core.Model.Providers;
using ImpeltechTime.Droid.Core.Providers;
using Microsoft.Practices.Unity;

namespace ImpeltechTime.Droid
{
    [Application(Icon = "@drawable/icon", Label = "ImpeltechTime")]
    public class App : Application
    {
        public const string ApplicationAccountType = "impeltech.time";

        public static UnityContainer Container { get; set; }

        public App (IntPtr handle, JniHandleOwnership transfer)
            : base(handle,transfer) {
            // do any initialisation you want here (for example initialising properties)
        }

        public override void OnCreate () {
            Container = new UnityContainer();

            Container.RegisterType<IElmaServiceProvider, ElmaServiceProvider>();
            Container.RegisterType<IElmaWcfService, ElmaWcfService>();
            Container.RegisterType<IElmaUser, ElmaUser>();
            Container.RegisterType<IElmaUserProvider, ElmaUserProvider>();
            Container.RegisterType<IElmaTaskProvider, ElmaTaskProvider>();
            Container.RegisterType<IElmaTask, ElmaTask>();
            Container.RegisterType<IElmaWorkLog, ElmaWorkLog>();

            base.OnCreate ();
        }
    }
}