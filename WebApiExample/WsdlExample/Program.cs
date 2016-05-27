using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using WsdlExample.AuthorizationService;
using WsdlExample.EntityChangeService;
using WsdlExample.EntityService;
using WsdlExample.TasksService;

namespace WsdlExample
{
    public class WsdlService
    {
        private ChannelFactory<IAuthorizationServiceChannel> _authServiceFactory;
        private Guid _authToken;
        private ChannelFactory<IEntityChangesServiceChannel> _changesServiceFactory;

        private ChannelFactory<IEntityServiceChannel> _entityServiceFactory;

        private string _sessionToken;
        private ChannelFactory<TasksChannel> _tasksServiceFactory;
        public Guid AuthToken { get; set; }
        public string ApplicationToken { get; set; }
        public string SessionToken { get; set; }


        public void TestStart () {
            _entityServiceFactory =
                new ChannelFactory<IEntityServiceChannel> (
                    new BasicHttpBinding {MaxReceivedMessageSize = int.MaxValue},
                    "http://bpm-demo.impeltech.ru/API/Entity");
            _authServiceFactory = new ChannelFactory<IAuthorizationServiceChannel> (new BasicHttpBinding (),
                                                                                    "http://bpm-demo.impeltech.ru/API/Authorization");
            _changesServiceFactory = new ChannelFactory<IEntityChangesServiceChannel> (new BasicHttpBinding (),
                                                                                       "http://bpm-demo.impeltech.ru/API/EntityChanges");
            _tasksServiceFactory = new ChannelFactory<TasksChannel> (new BasicHttpBinding (),
                                                                     "http://bpm-demo.impeltech.ru/API/Tasks");
            GetAuthToken ();
        }

        public void GetAuthToken () {
            var authorizationService = _authServiceFactory.CreateChannel ();

            using (new OperationContextScope (authorizationService)) {
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("ApplicationToken", ApplicationToken);
                var token = authorizationService.LoginWithUserName ("admin", "");
                _authToken = token.AuthToken;
                _sessionToken = token.SessionToken;
            }
            Console.WriteLine (_authToken);
            Console.WriteLine (_sessionToken);
        }

        public void LoadTask () {
            if (null == _entityServiceFactory)
                _entityServiceFactory =
                    new ChannelFactory<IEntityServiceChannel> (
                        new BasicHttpBinding {MaxReceivedMessageSize = int.MaxValue},
                        "http://bpm-demo.impeltech.ru/API/Entity");

            if (null == _authServiceFactory)
                _authServiceFactory = new ChannelFactory<IAuthorizationServiceChannel> (new BasicHttpBinding (),
                                                                                        "http://bpm-demo.impeltech.ru/API/Authorization");

            var entityService = _entityServiceFactory.CreateChannel ();
            var authService = _authServiceFactory.CreateChannel ();
            // TaskBase typeUid
            const string typeUid = "f532ef81-20e1-467d-89a4-940c57a609bc";
            const string id = "6040";

            using (new OperationContextScope (entityService)) {
                using (new OperationContextScope (authService)) {
                    try {
                        //если ошибки нет, забираем данные из ответа
                        var auth = authService?.CheckToken (AuthToken);
                        if (auth != null) {
                            AuthToken = auth.AuthToken;
                            SessionToken = auth.SessionToken;
                        }
                    }
                    catch (FaultException<AuthorizationService.PublicServiceException> ex) {
                        if (ex.Detail.StatusCode == 401) {
                            //если в запросе произошла ошибка авторизации, заново получаем данные для авторизации
                            WebOperationContext.Current?.OutgoingRequest.Headers.Add ("ApplicationToken",
                                                                                      ApplicationToken);
                            WebOperationContext.Current?.OutgoingRequest.Headers.Add ("SessionToken", SessionToken);
                            var token = authService?.LoginWithUserName ("admin", "");
                            if (token != null) {
                                AuthToken = token.AuthToken;
                                SessionToken = token.SessionToken;
                            }
                        }
                        else {
                            Console.WriteLine (ex.Message);
                            //иначе выбрасываем ошибку или дальше её обрабатываем
                            throw;
                        }
                    }
                }

                Console.WriteLine (AuthToken);
                Console.WriteLine (SessionToken);

                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("AuthToken", AuthToken.ToString ());
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("SessionToken", SessionToken);
                try {
                    var task = entityService.Load (typeUid, id);

                    foreach (var item in task.Items)
                        Console.WriteLine (item.Name + ": " + item.Value);

                    const string worklogTypeId = "e51a53b7-087a-4d31-8033-4d130676d0da";

                    var workLog = entityService.Load (worklogTypeId, "db07cd3a-2d8c-4f64-bb72-cf823e0b2576");

                    if (null != workLog?.Items) {
                        using (var file = new StreamWriter ("worklog properties_new.txt")) {
                            foreach (var item in workLog.Items) {
                                file.WriteLine (item.Name + ": " + item.Value);
                                if (item.Name == "TaskBase" && null != item.Data) {
                                    file.WriteLine ($"TaskBase id - {item.Data.Items[0]?.Value}");
                                    file.WriteLine ($"TaskBase typeId - {item.Data.Items[1]?.Value}");
                                    file.WriteLine ($"TaskBase Uid - {item.Data.Items[2]?.Value}");
                                }
                            }
                        }
                        //                            if (item.Name == "WorkMinutes") {
                        //                                var workMinutes = Convert.ToInt32 (item.Value);
                        //                                workMinutes += 50;
                        //                                workLog.Items[Array.IndexOf (workLog.Items, item)].Value = workMinutes.ToString ();
                        //                                entityService.Update (worklogTypeId, "db07cd3a-2d8c-4f64-bb72-cf823e0b2576", workLog);
                        ////                                workLog.Items[0].Value = null;
                        ////                                workLog.Items[2].Value = null;
                        //                                
                        //                            }
                        //                        }
                        var worker = workLog.Items[7].Data;
                        var taskBase = workLog.Items[9].Data;
                        var newWorklog = new EntityService.WebData {Items = new EntityService.WebDataItem[12]};
                        newWorklog.Items[0] = new EntityService.WebDataItem {Name = "Id", Value = null};
                        newWorklog.Items[1] = new EntityService.WebDataItem {Name = "TypeUid", Value = worklogTypeId};
                        newWorklog.Items[2] = new EntityService.WebDataItem {Name = "Uid", Value = null};
                        newWorklog.Items[3] = new EntityService.WebDataItem {Name = "CreationDate", Value = null};
                        newWorklog.Items[4] = new EntityService.WebDataItem {Name = "WorkMinutes", Value = "35"};
                        newWorklog.Items[5] = new EntityService.WebDataItem {
                            Name = "StartDate",
                            Value = DateTime.Now.ToString ("G")
                        };
                        newWorklog.Items[6] = new EntityService.WebDataItem {
                            Name = "Comment",
                            Value = "Generated worklog item"
                        };
                        newWorklog.Items[7] = new EntityService.WebDataItem {
                            Name = "CreationAuthor",
                            Value = null,
                            Data = worker
                        };
                        newWorklog.Items[8] = new EntityService.WebDataItem {
                            Name = "Worker",
                            Value = null,
                            Data = worker
                        };
                        newWorklog.Items[9] = new EntityService.WebDataItem {
                            Name = "TaskBase",
                            Value = null,
                            Data = taskBase
                        };
                        newWorklog.Items[10] = new EntityService.WebDataItem {Name = "Status", Value = "1"};
                        newWorklog.Items[11] = new EntityService.WebDataItem {Name = "WorkLogItem", Value = null};
                        entityService.Insert (worklogTypeId, newWorklog);
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine (ex.Message);
                }
            }
            Console.ReadKey ();
        }

        public void LoadTaskList () {
            var entityService = _entityServiceFactory.CreateChannel ();
            // TaskBase typeUid
            const string typeUid = "f532ef81-20e1-467d-89a4-940c57a609bc";

            using (new OperationContextScope (entityService)) {
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("AuthToken", _authToken.ToString ());
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("SessionToken", _sessionToken);
                var tasks = entityService.Query (typeUid, "", "", 100, 1, "", "", "");

                using (var file = new StreamWriter ("task list.txt")) {
                    foreach (var task in tasks) {
                        foreach (var item in task.Items) {
                            file.WriteLine (item.Name + ": " + item.Value);
                        }
                        file.WriteLine ("===================End of task===================");
                    }
                }
            }
            Console.ReadKey ();
        }

        public void LoadWorklogList () {
            var entityService = _entityServiceFactory.CreateChannel ();
            // TaskBase typeUid
            const string typeUid = "e51a53b7-087a-4d31-8033-4d130676d0da";

            using (new OperationContextScope (entityService)) {
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("AuthToken", _authToken.ToString ());
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("SessionToken", _sessionToken);
                var tasks = entityService.Query (typeUid, "", "", 100, 1, "", "", "");

                using (var file = new StreamWriter ("worklog list.txt")) {
                    foreach (var task in tasks) {
                        foreach (var item in task.Items) {
                            file.WriteLine (item.Name + ": " + item.Value);
                        }
                        file.WriteLine ("===================End of worklog===================");
                    }
                }
            }
            Console.ReadKey ();
        }

        public void ChangeTest () {
            var changesService = _changesServiceFactory.CreateChannel ();
            // TaskBase typeUid
            const string typeUid = "f532ef81-20e1-467d-89a4-940c57a609bc";
            using (new OperationContextScope (changesService)) {
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("AuthToken", _authToken.ToString ());
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("SessionToken", _sessionToken);

                //                Console.WriteLine(changesService.IsSupported(typeUid));
                //                var sync = new SyncChanges();
                //                changesService.Sync(sync);

                var id = changesService.Changes (typeUid, DateTime.Now.AddHours (256), "");
                Console.WriteLine (id.Id);
                Console.WriteLine (id.Updated.Length);

                Console.WriteLine (changesService.ChangesCommit (id.Id));
            }
            Console.ReadKey ();
        }

        public void TasksTest () {
            var tasksService = _tasksServiceFactory.CreateChannel ();
            using (new OperationContextScope (tasksService)) {
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("AuthToken", _authToken.ToString ());
                WebOperationContext.Current?.OutgoingRequest.Headers.Add ("SessionToken", _sessionToken);

                var data = new TasksService.WebData ();

                var newData = tasksService.ApprovementStatus (data);
                Console.WriteLine ("\nPrinting NEW data after ApprovementStatus:");
                if (newData?.Items != null) {
                    foreach (var item in newData.Items)
                        Console.WriteLine (item.Name + ": " + item.Value);
                }

                newData = tasksService.ConfirmApproval (data);
                Console.WriteLine ("\nPrinting NEW data after confirm:");
                if (newData?.Items != null) {
                    foreach (var item in newData.Items)
                        Console.WriteLine (item.Name + ": " + item.Value);
                }

                newData = tasksService.ApprovementStatus (data);
                Console.WriteLine ("\nPrinting NEW data after ApprovementStatus:");
                if (newData?.Items != null) {
                    foreach (var item in newData.Items)
                        Console.WriteLine (item.Name + ": " + item.Value);
                }
            }
        }
    }

    internal class Program
    {
        private static void Main (string[] args) {
            var wsdl = new WsdlService {
                AuthToken = new Guid ("0ddbfb71-d159-4cef-aa74-0a873091bdf6"),
                SessionToken =
                    "BEEB9901054B521ED22A9EAEAF97F2E5E5947858411F5FFCB364373423717A978C972E9C7A122B885E1FE6D088E822A5A4A85730BACCFFF01EAD138F2C323AFC",
                //                ApplicationToken =
                //                    "FCD9913007A3A1483D55700EAC702C41A42B3CE4F887538ADC37FACBC397160F57612B2DBC8E839A61C6A05D24508177C48EFE4D3898931C46F4C91B52F133E3"
                ApplicationToken =
                    "96F90612CA041870EC032770C24ABC2F9F58E726C2930566570A9F51FE53F83040113C7476F351457AEF5EF123F69C60545B980DF32E0DB1C6538C7E68E7D51A"
            };
            wsdl.TestStart ();
            wsdl.LoadTask ();
            //            wsdl.LoadTaskList ();
//            wsdl.LoadWorklogList ();
            //            wsdl.TasksTest ();
            //            Console.ReadKey ();

            //            wsdl.ChangeTest ();
            //            wsdl.LoadTask();
            //            wsdl.ExecuteTask();


            //            Console.ReadKey ();
        }
    }
}