using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using ImpeltechTime.Droid.Core.Model;
using ImpeltechTime.Droid.Core.Model.Providers;

namespace ImpeltechTime.Droid.Fragments
{
    public class SendWorklogDialogFragment : DialogFragment
    {
        private readonly IElmaTask _task;
        private readonly IElmaTaskProvider _taskProvider;

        private TextView _spentTimeTextView;
        private TextView _startDateTextView;
        private EditText _commentEditText;
        private Button _cancelButton;
        private Button _sendButton;

        public SendWorklogDialogFragment (IElmaTask task, IElmaTaskProvider taskProvider) {
            _task = task;
            _taskProvider = taskProvider;
        }

        private void SetupViews (View view, bool init) {
            _spentTimeTextView = view.FindViewById<TextView> (Resource.Id.spentTimeTextView);
            _spentTimeTextView.Text = _task.UnaccountedWorkTime?.ToString ();

            _startDateTextView = view.FindViewById<TextView> (Resource.Id.startDateTextView);
            _startDateTextView.Text = _task.UnaccountedWorkLog?.StartDate?.ToString ();

            _commentEditText = view.FindViewById<EditText> (Resource.Id.commentEditText);
            _commentEditText.Text = _task.UnaccountedWorkLog?.Comment;

            _cancelButton = view.FindViewById<Button> (Resource.Id.dialogCancelSendingButton);
            _sendButton = view.FindViewById<Button> (Resource.Id.dialogSendWorklogButton);
            if (init) {
                _spentTimeTextView.Click += delegate {
                    var transaction = Dialog.OwnerActivity.FragmentManager.BeginTransaction();
                    var dialog = new EditSpentTimeDialogFragment(_task);
                    dialog.Show(transaction, "");
                };
                _cancelButton.Click += delegate {
                    Dismiss ();
                };
                _sendButton.Click += delegate {
                    // TODO: apply new settings for worklog before sending!
                    _taskProvider.SendTaskWorklog (_task);
                    Dismiss ();
                };
            }
        }

        

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            OnCreate (savedInstanceState);
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            var view = inflater.Inflate (Resource.Layout.sendWorklogDialog, container, false);
            SetupViews (view, savedInstanceState == null);


            return view;
        }
    }
}