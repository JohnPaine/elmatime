using System.Collections.Generic;
using System.Linq;

namespace ImpeltechTime.Droid.Core.Internal
{
    public enum TaskStatus
    {
        NewOrder,
        Complete,
        Incomplete,
        InProgress,
        WasClosed,
        Read,
        Prepared,
        CompleteControlled,
        IncompleteControlled,
        OnApproval,
        RefuseApproval,
        OnApprovalExecutor,
        RefuseApprovalExecutor,
        NoComplete,
        Unknown
    }

    public static class TaskStatusHelper
    {
        private static readonly Dictionary<string, TaskStatus> _dict = new Dictionary<string, TaskStatus> ();

        static TaskStatusHelper () {
            _dict.Add ("34387afa-6b70-476f-9d34-748732059003", TaskStatus.NewOrder);
            _dict.Add ("dd048b73-4e08-404a-b62e-c55222845cc4", TaskStatus.Complete);
            _dict.Add ("1710de4d-86fa-4072-951a-55ebbdcd5bf1", TaskStatus.Incomplete);
            _dict.Add ("37a184b8-a81d-4177-9eb5-4ebe3dfae959", TaskStatus.InProgress);
            _dict.Add ("fd7993c6-99c7-4b23-83cc-0f576a63c144", TaskStatus.WasClosed);
            _dict.Add ("85707efe-806c-4ec6-8cd6-4d5e4edd8b19", TaskStatus.Read);
            _dict.Add ("112ea757-36f7-4859-b0d3-6cc0f5a04705", TaskStatus.Prepared);
            _dict.Add ("46f88008-94cd-4b14-985c-31ba6edeb60e", TaskStatus.CompleteControlled);
            _dict.Add ("2968382b-e9be-4e2f-967b-0dce0a67a4c4", TaskStatus.IncompleteControlled);
            _dict.Add ("b9c9f74a-15ec-4337-9916-f02ffec83dd4", TaskStatus.OnApproval);
            _dict.Add ("1f6de7ff-03af-401a-a3ca-23af7cab8f65", TaskStatus.RefuseApproval);
            _dict.Add ("b0b6a339-ba74-4e46-b721-2733d7fb76a9", TaskStatus.OnApprovalExecutor);
            _dict.Add ("70918293-8b84-43be-ad39-181375d51373", TaskStatus.RefuseApprovalExecutor);
            _dict.Add ("98ff43bd-b897-41f0-adf2-4eb3b3783851", TaskStatus.NoComplete);
        }

        public static TaskStatus StatusById (string id) {
            TaskStatus status;
            return _dict.TryGetValue (id, out status) ? status : TaskStatus.Unknown;
        }

        public static string StatusId (TaskStatus status) {
            return _dict.FirstOrDefault (x => x.Value == status).Key;
        }
    }
}