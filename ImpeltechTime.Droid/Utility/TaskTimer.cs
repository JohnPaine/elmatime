using System;
using System.Diagnostics;
using System.Timers;
using ImpeltechTime.Droid.Core.Model;

namespace ImpeltechTime.Droid.Utility
{
    public class TaskTimer : Timer
    {
        private readonly Stopwatch _stopwatch;
        private IElmaTask _currentlyExecutingTask;

        public TaskTimer (double interval) : base(interval) {
            _stopwatch = new Stopwatch ();
        }

        public void StartTimer (IElmaTask task) {
            if (null != _currentlyExecutingTask && _currentlyExecutingTask.Id != task.Id) {
                RestartTimer (task);
            }
            else {
                Start ();
                _stopwatch.Start ();
                _currentlyExecutingTask = task;
            }
        }

        public void StopTimer (IElmaTask task) {
            Stop ();
            _stopwatch.Stop ();
            if (_currentlyExecutingTask.Id == task.Id)
                task.AddUnaccountedTime (ElapsedTimeSpan ());
        }

        private void ResetTimer (IElmaTask task) {
            _currentlyExecutingTask?.AddUnaccountedTime(ElapsedTimeSpan());
            Stop();
            _stopwatch.Reset ();
            _currentlyExecutingTask = task;
        }

        private void RestartTimer (IElmaTask task) {
            _currentlyExecutingTask?.AddUnaccountedTime(ElapsedTimeSpan());
            Start ();
            _stopwatch.Restart ();
            _currentlyExecutingTask = task;
        }

        public TimeSpan? ElapsedTimeSpan () {
            return _stopwatch.Elapsed;
        }

        public long? ElapsedMilliseconds () {
            return _stopwatch.ElapsedMilliseconds;
        }
    }
}