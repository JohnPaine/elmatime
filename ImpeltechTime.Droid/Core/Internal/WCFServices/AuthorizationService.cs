﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace ImpeltechTime.Droid.Core.Internal.WCFServices.AuthorizationService
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
    [Serializable()]
    public partial class PublicServiceException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerialized()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [OptionalField()]
        private PublicServiceException InnerExceptionField;

        [OptionalField()]
        private string MessageField;

        [OptionalField()]
        private int StatusCodeField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember()]
        public PublicServiceException InnerException
        {
            get
            {
                return this.InnerExceptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.InnerExceptionField, value) != true))
                {
                    this.InnerExceptionField = value;
                    this.RaisePropertyChanged("InnerException");
                }
            }
        }

        [DataMember()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MessageField, value) != true))
                {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }

        [DataMember()]
        public int StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                if ((this.StatusCodeField.Equals(value) != true))
                {
                    this.StatusCodeField = value;
                    this.RaisePropertyChanged("StatusCode");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "ApiVersion", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.API.Models")]
    [Serializable()]
    public partial class ApiVersion : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerialized()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [OptionalField()]
        private ApiService[] ServicesField;

        [OptionalField()]
        private string VersionField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember()]
        public ApiService[] Services
        {
            get
            {
                return this.ServicesField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ServicesField, value) != true))
                {
                    this.ServicesField = value;
                    this.RaisePropertyChanged("Services");
                }
            }
        }

        [DataMember()]
        public string Version
        {
            get
            {
                return this.VersionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.VersionField, value) != true))
                {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "ApiService", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.API.Models")]
    [Serializable()]
    public partial class ApiService : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerialized()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [OptionalField()]
        private ApiMethod[] MethodsField;

        [OptionalField()]
        private string NameField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember()]
        public ApiMethod[] Methods
        {
            get
            {
                return this.MethodsField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MethodsField, value) != true))
                {
                    this.MethodsField = value;
                    this.RaisePropertyChanged("Methods");
                }
            }
        }

        [DataMember()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NameField, value) != true))
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "ApiMethod", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.API.Models")]
    [Serializable()]
    public partial class ApiMethod : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerialized()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [OptionalField()]
        private string NameField;

        [OptionalField()]
        private string VersionField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.NameField, value) != true))
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        [DataMember()]
        public string Version
        {
            get
            {
                return this.VersionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.VersionField, value) != true))
                {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "Auth", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.API.Models")]
    [Serializable()]
    public partial class Auth : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerialized()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [OptionalField()]
        private System.Guid AuthTokenField;

        [OptionalField()]
        private string CurrentUserIdField;

        [OptionalField()]
        private string LangField;

        [OptionalField()]
        private string SessionTokenField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember()]
        public System.Guid AuthToken
        {
            get
            {
                return this.AuthTokenField;
            }
            set
            {
                if ((this.AuthTokenField.Equals(value) != true))
                {
                    this.AuthTokenField = value;
                    this.RaisePropertyChanged("AuthToken");
                }
            }
        }

        [DataMember()]
        public string CurrentUserId
        {
            get
            {
                return this.CurrentUserIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CurrentUserIdField, value) != true))
                {
                    this.CurrentUserIdField = value;
                    this.RaisePropertyChanged("CurrentUserId");
                }
            }
        }

        [DataMember()]
        public string Lang
        {
            get
            {
                return this.LangField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LangField, value) != true))
                {
                    this.LangField = value;
                    this.RaisePropertyChanged("Lang");
                }
            }
        }

        [DataMember()]
        public string SessionToken
        {
            get
            {
                return this.SessionTokenField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SessionTokenField, value) != true))
                {
                    this.SessionTokenField = value;
                    this.RaisePropertyChanged("SessionToken");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "CheckPermissionRequest", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.API.Models")]
    [Serializable()]
    public partial class CheckPermissionRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerialized()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [OptionalField()]
        private System.Guid IdField;

        [OptionalField()]
        private long ObjectIdField;

        [OptionalField()]
        private System.Guid TypeUidField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember()]
        public System.Guid Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((this.IdField.Equals(value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }

        [DataMember()]
        public long ObjectId
        {
            get
            {
                return this.ObjectIdField;
            }
            set
            {
                if ((this.ObjectIdField.Equals(value) != true))
                {
                    this.ObjectIdField = value;
                    this.RaisePropertyChanged("ObjectId");
                }
            }
        }

        [DataMember()]
        public System.Guid TypeUid
        {
            get
            {
                return this.TypeUidField;
            }
            set
            {
                if ((this.TypeUidField.Equals(value) != true))
                {
                    this.TypeUidField = value;
                    this.RaisePropertyChanged("TypeUid");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContract(Name = "CheckPermissionResponse", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.API.Models")]
    [Serializable()]
    public partial class CheckPermissionResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [NonSerialized()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [OptionalField()]
        private bool AllowField;

        [OptionalField()]
        private System.Guid IdField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [DataMember()]
        public bool Allow
        {
            get
            {
                return this.AllowField;
            }
            set
            {
                if ((this.AllowField.Equals(value) != true))
                {
                    this.AllowField = value;
                    this.RaisePropertyChanged("Allow");
                }
            }
        }

        [DataMember()]
        public System.Guid Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if ((this.IdField.Equals(value) != true))
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.elma-bpm.ru/api/", ConfigurationName = "AuthorizationService.IAuthorizationService")]
    public interface IAuthorizationService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/Version", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/VersionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//VersionPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        string Version();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/Version", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/VersionResponse")]
        System.Threading.Tasks.Task<string> VersionAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/ApiVersion", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/ApiVersionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//ApiVersionPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        ApiVersion ApiVersion(bool allServices);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/ApiVersion", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/ApiVersionResponse")]
        System.Threading.Tasks.Task<ApiVersion> ApiVersionAsync(bool allServices);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTime", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTimeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//ServerTimePublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        System.DateTime ServerTime();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTime", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTimeResponse")]
        System.Threading.Tasks.Task<System.DateTime> ServerTimeAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTimeUTC", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTimeUTCResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//ServerTimeUTCPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        System.DateTime ServerTimeUTC();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTimeUTC", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/ServerTimeUTCResponse")]
        System.Threading.Tasks.Task<System.DateTime> ServerTimeUTCAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckToken", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckTokenResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//CheckTokenPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        Auth CheckToken(System.Guid token);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckToken", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckTokenResponse")]
        System.Threading.Tasks.Task<Auth> CheckTokenAsync(System.Guid token);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithBasic", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithBasicResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//LoginWithBasicPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        Auth LoginWithBasic();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithBasic", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithBasicResponse")]
        System.Threading.Tasks.Task<Auth> LoginWithBasicAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithUserName", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithUserNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//LoginWithUserNamePublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        Auth LoginWithUserName(string username, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithUserName", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithUserNameResponse")]
        System.Threading.Tasks.Task<Auth> LoginWithUserNameAsync(string username, string password);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithSSPI", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithSSPIResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//LoginWithSSPIPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        Auth LoginWithSSPI(string ticket);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithSSPI", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/LoginWithSSPIResponse")]
        System.Threading.Tasks.Task<Auth> LoginWithSSPIAsync(string ticket);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/TemporaryGuid", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/TemporaryGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//TemporaryGuidPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        System.Guid TemporaryGuid();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/TemporaryGuid", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/TemporaryGuidResponse")]
        System.Threading.Tasks.Task<System.Guid> TemporaryGuidAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckPermissions", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckPermissionsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PublicServiceException), Action = "http://www.elma-bpm.ru/api//CheckPermissionsPublicServiceExceptionFault", Name = "PublicServiceException", Namespace = "http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
        CheckPermissionResponse[] CheckPermissions(CheckPermissionRequest[] requestList);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckPermissions", ReplyAction = "http://www.elma-bpm.ru/api/IAuthorizationService/CheckPermissionsResponse")]
        System.Threading.Tasks.Task<CheckPermissionResponse[]> CheckPermissionsAsync(CheckPermissionRequest[] requestList);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthorizationServiceChannel : IAuthorizationService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthorizationServiceClient : System.ServiceModel.ClientBase<IAuthorizationService>, IAuthorizationService
    {

        public AuthorizationServiceClient()
        {
        }

        public AuthorizationServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public AuthorizationServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public AuthorizationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public AuthorizationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public string Version()
        {
            return base.Channel.Version();
        }

        public System.Threading.Tasks.Task<string> VersionAsync()
        {
            return base.Channel.VersionAsync();
        }

        public ApiVersion ApiVersion(bool allServices)
        {
            return base.Channel.ApiVersion(allServices);
        }

        public System.Threading.Tasks.Task<ApiVersion> ApiVersionAsync(bool allServices)
        {
            return base.Channel.ApiVersionAsync(allServices);
        }

        public System.DateTime ServerTime()
        {
            return base.Channel.ServerTime();
        }

        public System.Threading.Tasks.Task<System.DateTime> ServerTimeAsync()
        {
            return base.Channel.ServerTimeAsync();
        }

        public System.DateTime ServerTimeUTC()
        {
            return base.Channel.ServerTimeUTC();
        }

        public System.Threading.Tasks.Task<System.DateTime> ServerTimeUTCAsync()
        {
            return base.Channel.ServerTimeUTCAsync();
        }

        public Auth CheckToken(System.Guid token)
        {
            return base.Channel.CheckToken(token);
        }

        public System.Threading.Tasks.Task<Auth> CheckTokenAsync(System.Guid token)
        {
            return base.Channel.CheckTokenAsync(token);
        }

        public Auth LoginWithBasic()
        {
            return base.Channel.LoginWithBasic();
        }

        public System.Threading.Tasks.Task<Auth> LoginWithBasicAsync()
        {
            return base.Channel.LoginWithBasicAsync();
        }

        public Auth LoginWithUserName(string username, string password)
        {
            return base.Channel.LoginWithUserName(username, password);
        }

        public System.Threading.Tasks.Task<Auth> LoginWithUserNameAsync(string username, string password)
        {
            return base.Channel.LoginWithUserNameAsync(username, password);
        }

        public Auth LoginWithSSPI(string ticket)
        {
            return base.Channel.LoginWithSSPI(ticket);
        }

        public System.Threading.Tasks.Task<Auth> LoginWithSSPIAsync(string ticket)
        {
            return base.Channel.LoginWithSSPIAsync(ticket);
        }

        public System.Guid TemporaryGuid()
        {
            return base.Channel.TemporaryGuid();
        }

        public System.Threading.Tasks.Task<System.Guid> TemporaryGuidAsync()
        {
            return base.Channel.TemporaryGuidAsync();
        }

        public CheckPermissionResponse[] CheckPermissions(CheckPermissionRequest[] requestList)
        {
            return base.Channel.CheckPermissions(requestList);
        }

        public System.Threading.Tasks.Task<CheckPermissionResponse[]> CheckPermissionsAsync(CheckPermissionRequest[] requestList)
        {
            return base.Channel.CheckPermissionsAsync(requestList);
        }
    }
}
