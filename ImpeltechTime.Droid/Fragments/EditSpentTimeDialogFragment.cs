using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using ImpeltechTime.Droid.Core.Model;

namespace ImpeltechTime.Droid.Fragments
{
    public class EditSpentTimeDialogFragment : DialogFragment
    {
        private readonly IElmaTask _task;

        private NumberPicker _spentHoursPicker;
        private NumberPicker _spentMinutesPicker;
        private NumberPicker _spentSecondsPicker;
        private Button _cancelButton;
        private Button _okButton;

        public EditSpentTimeDialogFragment (IElmaTask task) {
            _task = task;
        }

        private void SetupViews (View view, bool init) {
            var timeSpent = _task.UnaccountedWorkTime;

            _spentHoursPicker = view.FindViewById<NumberPicker> (Resource.Id.spentHours_numberPicker);
            // TODO: what is max hours??
            _spentHoursPicker.MaxValue = 23;
            _spentHoursPicker.Value = timeSpent?.Hours ?? 0;

            _spentMinutesPicker = view.FindViewById<NumberPicker> (Resource.Id.spentMinutes_numberPicker);
            _spentMinutesPicker.MaxValue = 59;
            _spentMinutesPicker.Value = timeSpent?.Minutes ?? 0;

            _spentSecondsPicker = view.FindViewById<NumberPicker> (Resource.Id.spentSeconds_numberPicker);
            _spentSecondsPicker.MaxValue = 59;
            _spentSecondsPicker.Value = timeSpent?.Seconds ?? 0;

            _cancelButton = view.FindViewById<Button> (Resource.Id.dialog_2_CancelButton);
            _okButton = view.FindViewById<Button> (Resource.Id.dialog_2_OKButton);

            if (init) {
                _cancelButton.Click += delegate {
                    Dismiss ();
                };
                _okButton.Click += delegate {
                    var newTimeSpent = new TimeSpan (_spentHoursPicker.Value, _spentMinutesPicker.Value,
                                                     _spentSecondsPicker.Value);
                    _task.UnaccountedWorkTime = newTimeSpent;
                    Dismiss ();
                };
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            OnCreate(savedInstanceState);
            Dialog?.Window?.RequestFeature(WindowFeatures.NoTitle);

            var view = inflater.Inflate(Resource.Layout.edit_spent_time, container, false);
            SetupViews(view, savedInstanceState == null);

            return view;
        }
    }
}