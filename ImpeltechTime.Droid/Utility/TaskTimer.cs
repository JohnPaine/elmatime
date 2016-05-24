using System;
using Android.OS;
using Android.Widget;
using ImpeltechTime.Droid.Core.Model;

namespace ImpeltechTime.Droid.Utility
{
    public class TaskTimer
    {
        private IElmaTask _currentlyExecutingTask;
        private readonly Chronometer _chronometer;

        public TaskTimer (Chronometer chronometer) {
            _chronometer = chronometer;
        }

        public void StartTimer (IElmaTask task) {
            _chronometer.Base = SystemClock.ElapsedRealtime ();
            _chronometer.Start ();
            _currentlyExecutingTask = task;
        }

        public void StopTimer () {
            _chronometer.Stop ();
            _currentlyExecutingTask.AddUnaccountedTime (ElapsedTimeSpan ());
        }

        private TimeSpan? ElapsedTimeSpan () {
            var millisec = SystemClock.ElapsedRealtime() - _chronometer.Base;
            return new TimeSpan(millisec * 10000);
        }
    }
}