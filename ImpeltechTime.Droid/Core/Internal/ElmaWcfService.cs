using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Android.Util;
using ImpeltechTime.Droid.Core.Internal.WCFServices.AuthorizationService;
using ImpeltechTime.Droid.Core.Internal.WCFServices.EntityService;
using ImpeltechTime.Droid.Core.Model;
using PublicServiceException = ImpeltechTime.Droid.Core.Internal.WCFServices.AuthorizationService.PublicServiceException
    ;

namespace ImpeltechTime.Droid.Core.Internal
{
    public class ElmaWcfService : IElmaWcfService
    {
        private const string LogTag = "ElmaWcfService";
        private readonly string _applicationToken;
        private readonly ChannelFactory<IAuthorizationServiceChannel> _authServiceFactory;
        private readonly ChannelFactory<IEntityServiceChannel> _entityServiceFactory;

        public ElmaWcfService () {
            AuthToken = new Guid ("0ddbfb71-d159-4cef-aa74-0a873091bdf6");
            SessionToken =
                "BEEB9901054B521ED22A9EAEAF97F2E5E5947858411F5FFCB364373423717A978C972E9C7A122B885E1FE6D088E822A5A4A85730BACCFFF01EAD138F2C323AFC";
            _applicationToken =
                "96F90612CA041870EC032770C24ABC2F9F58E726C2930566570A9F51FE53F83040113C7476F351457AEF5EF123F69C60545B980DF32E0DB1C6538C7E68E7D51A";

            _authServiceFactory = new ChannelFactory<IAuthorizationServiceChannel> (new BasicHttpBinding (),
                                                                                    "http://bpm-demo.impeltech.ru/API/Authorization");
            _entityServiceFactory =
                new ChannelFactory<IEntityServiceChannel> (new BasicHttpBinding {MaxReceivedMessageSize = int.MaxValue},
                                                           "http://bpm-demo.impeltech.ru/API/Entity");
        }

        private Guid AuthToken { get; set; }
        private string SessionToken { get; set; }

        public IElmaUser LoginUser (string accName, string pass) {
            return AuthorizeUser (null, accName, pass);
        }

        public IEnumerable<IElmaTask> GetTasksForUser (IElmaUser user) {
            if (null == user)
                return null;

            if (!CheckToken () && null == AuthorizeUser (user))
                return null;

            // TODO: can status change?
            // TODO: what statuses are possible??
            TaskStatus[] statuses = {TaskStatus.NewOrder, TaskStatus.InProgress, TaskStatus.Read};

            return GetTasks (user, statuses);
        }

        public bool SendWorkLogAsync (IElmaUser user, IElmaTask task) {
            if (null == user || null == task)
                return false;

            return SendWorkLog (user, task);
        }

        private static DateTime? GetDateTime (string dateString) {
            try {
                DateTime parsed;
                if (DateTime.TryParseExact (dateString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                                            DateTimeStyles.None, out parsed))
                    return parsed;
                return null;
            }
            catch (Exception exception) {
                Log.Error ("GetDateTime", exception.Message);
                return null;
            }
        }

        private static TimeSpan? GetTimeSpan (string dateString) {
            try {
                TimeSpan parsed;
                int minutes;
                // TODO: check if there are minutes or seconds used!
                if (int.TryParse (dateString, out minutes))
                    return new TimeSpan (0, 0, minutes, 0);

                if (TimeSpan.TryParse (dateString, out parsed))
                    return parsed;
                return null;
            }
            catch (Exception exception) {
                Log.Error ("GetTimeSpan", exception.Message);
                return null;
            }
        }

        private static bool CompareGuids (string guidString, Guid toCompare) {
            Guid parsed;
            if (!Guid.TryParse (guidString, out parsed))
                return false;
            return parsed == toCompare;
        }

        private static bool CompareIDs (string idString, long toCompare) {
            long parsed;
            if (!long.TryParse (idString, out parsed))
                return false;
            return parsed == toCompare;
        }

        private static WebData CreateTaskData (IElmaTask task) {
            var data = new WebData {Items = new WebDataItem[4]};

            data.Items[0] = new WebDataItem {Name = "Id", Value = task.Id.ToString ()};
            data.Items[1] = new WebDataItem {Name = "TypeUid", Value = task.TypeUid};
            data.Items[2] = new WebDataItem {Name = "Uid", Value = task.Uid.ToString ()};
            data.Items[3] = new WebDataItem {Name = "Name", Value = task.Subject};

            return data;
        }

        private static WebData CreateUserData (IElmaUser user) {
            var data = new WebData {Items = new WebDataItem[4]};

            data.Items[0] = new WebDataItem {Name = "Id", Value = user.Id.ToString ()};
            data.Items[1] = new WebDataItem {Name = "TypeUid", Value = user.TypeUid};
            data.Items[2] = new WebDataItem {Name = "Uid", Value = user.Uid.ToString ()};
            data.Items[3] = new WebDataItem {Name = "Name", Value = user.FullName};

            return data;
        }

        private static WebData CreateWorkLogData (IElmaUser user, IElmaTask task) {
            var data = new WebData {Items = new WebDataItem[12]};

            data.Items[0] = new WebDataItem {Name = "Id", Value = null};
            data.Items[1] = new WebDataItem {Name = "TypeUid", Value = ElmaWorkLog.WorkLogTypeUid};
            data.Items[2] = new WebDataItem {Name = "Uid", Value = null};
            data.Items[3] = new WebDataItem {Name = "CreationDate", Value = null};
            // TODO: change!!!
            if (task.UnaccountedWorkLog.WorkTime?.TotalSeconds != null)
                data.Items[4] = new WebDataItem {
                    Name = "WorkMinutes",
                    Value =
                        Math.Round ((decimal) task.UnaccountedWorkLog.WorkTime?.TotalSeconds)
                            .ToString (CultureInfo.InvariantCulture)
                };
            else
                data.Items[4] = new WebDataItem {Name = "WorkMinutes", Value = ""};
            data.Items[5] = new WebDataItem {
                Name = "StartDate",
                Value = task.UnaccountedWorkLog.StartDate?.ToString ("G")
            };
            data.Items[6] = new WebDataItem {Name = "Comment", Value = task.UnaccountedWorkLog.Comment};
            data.Items[7] = new WebDataItem {Name = "CreationAuthor", Value = null, Data = CreateUserData (user)};
            data.Items[8] = new WebDataItem {Name = "Worker", Value = null, Data = CreateUserData (user)};
            data.Items[9] = new WebDataItem {Name = "TaskBase", Value = null, Data = CreateTaskData (task)};
            // TODO: change!!!
            data.Items[10] = new WebDataItem {Name = "Status", Value = "1"};
            data.Items[11] = new WebDataItem {Name = "WorkLogItem", Value = null};

            return data;
        }

        private bool SendWorkLog (IElmaUser user, IElmaTask task) {
            if (!CheckToken () && null == AuthorizeUser (user))
                return false;

            try {
                var entityService = _entityServiceFactory.CreateChannel ();

                using (new OperationContextScope (entityService)) {
                    OperationContext.Current.OutgoingMessageHeaders.Add (MessageHeader.CreateHeader ("AuthToken", "",
                                                                                                     AuthToken.ToString
                                                                                                         ()));
                    OperationContext.Current.OutgoingMessageHeaders.Add (MessageHeader.CreateHeader ("SessionToken", "",
                                                                                                     SessionToken));

                    entityService.Insert (ElmaWorkLog.WorkLogTypeUid, CreateWorkLogData (user, task));
                }
            }
            catch (FaultException<PublicServiceException> exception) {
                Log.Error ("SendWorkLog, FaultException", exception.Message);
                return false;
            }
            catch (Exception exception) {
                Log.Error ("SendWorkLog, Exception", exception.Message);
                return false;
            }

            return true;
        }

        private IEnumerable<IElmaWorkLog> GetWorklogsForTask (IElmaUser user, long taskId) {
            WebData[] webData;
            if (null == user || (webData = QueryData (ElmaWorkLog.WorkLogTypeUid, "", "", 200, 1, "", "", "")) == null)
                return null;

            // TODO: ask Kotov about possible difference between CreationAuthor and Worker in WorkLog entity!!!!
            return new List<IElmaWorkLog> (from data in webData
                                           where CompareIDs (data?.Items?[8]?.Data?.Items?[0]?.Value, user.Id)
                                                 && CompareIDs (data?.Items?[9]?.Data?.Items?[0]?.Value, taskId)
                                           select
                                               new ElmaWorkLog (long.Parse (data.Items[0].Value),
                                                                Guid.Parse (data.Items[2].Value)) {
                                                                    StartDate = GetDateTime (data.Items?[5].Value),
                                                                    WorkTime = GetTimeSpan (data.Items?[4].Value),
                                                                    Comment = data.Items?[6].Value
                                                                });
        }

        private IEnumerable<IElmaTask> GetTasks (IElmaUser user, IEnumerable<TaskStatus> statuses) {
            WebData[] webData;
            if (null == user || (webData = QueryData (ElmaTask.TaskTypeUid, "", "", 200, 1, "", "", "")) == null)
                return null;

            return new List<IElmaTask> (from data in webData
                                        where data?.Items?[8]?.Data?.Items?[0]?.Value == user.Id.ToString ()
                                              && statuses.Contains (TaskStatusHelper.StatusById (data.Items[17].Value))
                                        select
                                            new ElmaTask (long.Parse (data.Items[0].Value),
                                                          Guid.Parse (data.Items[3].Value)) {
                                                              Subject = data.Items[4].Value,
                                                              Description = data.Items[5].Value,
                                                              StartDateTime = GetDateTime (data.Items[9].Value),
                                                              EndDateTime = GetDateTime (data.Items[10].Value),
                                                              PlannedWorkTime = GetTimeSpan (data.Items[28].Value),
                                                              WorkLogs =
                                                                  GetWorklogsForTask (user,
                                                                                      long.Parse (data.Items[0].Value))
                                            .ToList ()
                                                          });
        }

        private WebData[] QueryData (string typeuid, string eqlQuery, string sort, int limit, int offset,
                                     string filterProviderUid, string filterProviderData, string filter) {
            var entityService = _entityServiceFactory.CreateChannel ();

            try {
                using (new OperationContextScope (entityService)) {
                    OperationContext.Current.OutgoingMessageHeaders.Add (MessageHeader.CreateHeader ("AuthToken", "",
                                                                                                     AuthToken.ToString
                                                                                                         ()));
                    OperationContext.Current.OutgoingMessageHeaders.Add (MessageHeader.CreateHeader ("SessionToken", "",
                                                                                                     SessionToken));

                    // TODO: findout why QueryAsync throws null exception or make it async another way!
                    return entityService.Query (typeuid, eqlQuery, sort, limit, offset, filterProviderUid,
                                                filterProviderData, filter);
                }
            }
            catch (FaultException<PublicServiceException> exception) {
                Log.Error ("QueryData, FaultException", exception.Message);
                return null;
            }
            catch (Exception exception) {
                Log.Error ("QueryData, Exception", exception.Message);
                return null;
            }
        }

        private WebData LoadData (string typeUid, string id) {
            var entityService = _entityServiceFactory.CreateChannel ();

            try {
                using (new OperationContextScope (entityService)) {
                    OperationContext.Current.OutgoingMessageHeaders.Add (MessageHeader.CreateHeader ("AuthToken", "",
                                                                                                     AuthToken.ToString
                                                                                                         ()));
                    OperationContext.Current.OutgoingMessageHeaders.Add (MessageHeader.CreateHeader ("SessionToken", "",
                                                                                                     SessionToken));
                    return entityService.Load (typeUid, id);
                }
            }
            catch (FaultException<PublicServiceException> exception) {
                Log.Error ("LoadData, FaultException", exception.Message);
                return null;
            }
            catch (Exception exception) {
                Log.Error ("LoadData, Exception", exception.Message);
                return null;
            }
        }

        private bool GetUserData (IElmaUser user) {
            WebData webData;
            if (null == user || (webData = LoadData (user.TypeUid, user.Id.ToString ())) == null)
                return false;
            user.Uid = Guid.Parse (webData.Items[2].Value);
            user.Password = webData.Items[5].Value;
            user.FirstName = webData.Items[6].Value;
            user.MiddleName = webData.Items[7].Value;
            user.LastName = webData.Items[8].Value;
            user.FullName = webData.Items[9].Value;
            return true;
        }

        private bool CheckToken () {
            var authorizationService = _authServiceFactory.CreateChannel ();
            try {
                var auth = authorizationService.CheckToken (AuthToken);
                if (auth == null)
                    return false;
                AuthToken = auth.AuthToken;
                SessionToken = auth.SessionToken;
                return true;
            }
            catch (FaultException<PublicServiceException> exception) {
                Log.Error ("CheckToken, FaultException", exception.Message);
                return false;
            }
            catch (Exception exception) {
                Log.Error ("CheckToken, Exception", exception.Message);
                return false;
            }
        }

        private IElmaUser AuthorizeUser (IElmaUser user, string accountName = "", string pass = "") {
            var authorizationService = _authServiceFactory.CreateChannel ();

            try {
                using (new OperationContextScope (authorizationService)) {
                    OperationContext.Current.OutgoingMessageHeaders.Add (MessageHeader.CreateHeader ("ApplicationToken",
                                                                                                     "",
                                                                                                     _applicationToken));
                    var token = authorizationService.LoginWithUserName (user?.AccountName ?? accountName,
                                                                        user?.InitialPass ?? pass);
                    var auth = authorizationService.CheckToken (token.AuthToken);
                    if (auth != null) {
                        AuthToken = auth.AuthToken;
                        SessionToken = auth.SessionToken;
                        if (null == user) {
                            user = new ElmaUser (long.Parse (auth.CurrentUserId), Guid.NewGuid (), this);
                        }
                        user.AccountName = accountName;
                        user.InitialPass = pass;
                        if (!GetUserData (user))
                            return null;
                    }
                }
            }
            catch (FaultException<PublicServiceException> exception) {
                Log.Error ("AuthorizeUser, FaultException", exception.Message);
                Log.Error ("AuthorizeUser, StackTrace", exception.StackTrace);
                Log.Error ("AuthorizeUser, Detail.Message", exception.Detail.Message);
                Log.Error ("AuthorizeUser, exception.Detail.StatusCode", exception.Detail.StatusCode.ToString ());
                Log.Error ("AuthorizeUser, exception.Code", exception.Code.ToString ());
                return null;
            }
            catch (Exception exception) {
                Log.Error ("AuthorizeUser, FaultException", exception.Message);
                return null;
            }
            return user;
        }
    }
}