﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WsdlExample.TasksService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WebData", Namespace="http://schemas.datacontract.org/2004/07/EleWise.ELMA.Common.Models")]
    [System.SerializableAttribute()]
    public partial class WebData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WsdlExample.TasksService.WebDataItem[] ItemsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WsdlExample.TasksService.WebDataItem[] Items {
            get {
                return this.ItemsField;
            }
            set {
                if ((object.ReferenceEquals(this.ItemsField, value) != true)) {
                    this.ItemsField = value;
                    this.RaisePropertyChanged("Items");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WebDataItem", Namespace="http://schemas.datacontract.org/2004/07/EleWise.ELMA.Common.Models")]
    [System.SerializableAttribute()]
    public partial class WebDataItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WsdlExample.TasksService.WebData DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WsdlExample.TasksService.WebData[] DataArrayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WsdlExample.TasksService.WebData Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WsdlExample.TasksService.WebData[] DataArray {
            get {
                return this.DataArrayField;
            }
            set {
                if ((object.ReferenceEquals(this.DataArrayField, value) != true)) {
                    this.DataArrayField = value;
                    this.RaisePropertyChanged("DataArray");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PublicServiceException", Namespace="http://schemas.datacontract.org/2004/07/EleWise.ELMA.Services.Public")]
    [System.SerializableAttribute()]
    public partial class PublicServiceException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WsdlExample.TasksService.PublicServiceException InnerExceptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusCodeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WsdlExample.TasksService.PublicServiceException InnerException {
            get {
                return this.InnerExceptionField;
            }
            set {
                if ((object.ReferenceEquals(this.InnerExceptionField, value) != true)) {
                    this.InnerExceptionField = value;
                    this.RaisePropertyChanged("InnerException");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StatusCode {
            get {
                return this.StatusCodeField;
            }
            set {
                if ((this.StatusCodeField.Equals(value) != true)) {
                    this.StatusCodeField = value;
                    this.RaisePropertyChanged("StatusCode");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.elma-bpm.ru/api/Tasks", ConfigurationName="TasksService.Tasks")]
    public interface Tasks {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Create", ReplyAction="http://www.elma-bpm.ru/api/Tasks/CreateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/Create", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData Create(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Create", ReplyAction="http://www.elma-bpm.ru/api/Tasks/CreateResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> CreateAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Reopen", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ReopenResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/Reopen", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData Reopen(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Reopen", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ReopenResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ReopenAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/AddComment", ReplyAction="http://www.elma-bpm.ru/api/Tasks/AddCommentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/AddComment", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData AddComment(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/AddComment", ReplyAction="http://www.elma-bpm.ru/api/Tasks/AddCommentResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> AddCommentAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Complete", ReplyAction="http://www.elma-bpm.ru/api/Tasks/CompleteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/Complete", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData Complete(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Complete", ReplyAction="http://www.elma-bpm.ru/api/Tasks/CompleteResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> CompleteAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Incomplete", ReplyAction="http://www.elma-bpm.ru/api/Tasks/IncompleteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/Incomplete", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData Incomplete(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Incomplete", ReplyAction="http://www.elma-bpm.ru/api/Tasks/IncompleteResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> IncompleteAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/StartWork", ReplyAction="http://www.elma-bpm.ru/api/Tasks/StartWorkResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/StartWork", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData StartWork(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/StartWork", ReplyAction="http://www.elma-bpm.ru/api/Tasks/StartWorkResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> StartWorkAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/MarkRead", ReplyAction="http://www.elma-bpm.ru/api/Tasks/MarkReadResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/MarkRead", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData MarkRead(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/MarkRead", ReplyAction="http://www.elma-bpm.ru/api/Tasks/MarkReadResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> MarkReadAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Redirect", ReplyAction="http://www.elma-bpm.ru/api/Tasks/RedirectResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/Redirect", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData Redirect(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Redirect", ReplyAction="http://www.elma-bpm.ru/api/Tasks/RedirectResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> RedirectAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ChangeEndDate", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ChangeEndDateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/ChangeEndDate", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData ChangeEndDate(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ChangeEndDate", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ChangeEndDateResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ChangeEndDateAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ControlComplete", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ControlCompleteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/ControlComplete", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData ControlComplete(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ControlComplete", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ControlCompleteResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ControlCompleteAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ChangeControl", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ChangeControlResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/ChangeControl", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData ChangeControl(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ChangeControl", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ChangeControlResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ChangeControlAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Close", ReplyAction="http://www.elma-bpm.ru/api/Tasks/CloseResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/Close", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData Close(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/Close", ReplyAction="http://www.elma-bpm.ru/api/Tasks/CloseResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> CloseAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/AddQuestion", ReplyAction="http://www.elma-bpm.ru/api/Tasks/AddQuestionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/AddQuestion", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData AddQuestion(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/AddQuestion", ReplyAction="http://www.elma-bpm.ru/api/Tasks/AddQuestionResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> AddQuestionAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/AnswerQuestion", ReplyAction="http://www.elma-bpm.ru/api/Tasks/AnswerQuestionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/AnswerQuestion", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData AnswerQuestion(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/AnswerQuestion", ReplyAction="http://www.elma-bpm.ru/api/Tasks/AnswerQuestionResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> AnswerQuestionAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ConfirmApproval", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ConfirmApprovalResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/ConfirmApproval", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData ConfirmApproval(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ConfirmApproval", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ConfirmApprovalResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ConfirmApprovalAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/RefuseApproval", ReplyAction="http://www.elma-bpm.ru/api/Tasks/RefuseApprovalResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/RefuseApproval", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData RefuseApproval(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/RefuseApproval", ReplyAction="http://www.elma-bpm.ru/api/Tasks/RefuseApprovalResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> RefuseApprovalAsync(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ApprovementStatus", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ApprovementStatusResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WsdlExample.TasksService.PublicServiceException), Action="http://www.elma-bpm.ru/api/Tasks/ApprovementStatus", Name="PublicServiceExceptionFault")]
        WsdlExample.TasksService.WebData ApprovementStatus(WsdlExample.TasksService.WebData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.elma-bpm.ru/api/Tasks/ApprovementStatus", ReplyAction="http://www.elma-bpm.ru/api/Tasks/ApprovementStatusResponse")]
        System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ApprovementStatusAsync(WsdlExample.TasksService.WebData data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TasksChannel : WsdlExample.TasksService.Tasks, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TasksClient : System.ServiceModel.ClientBase<WsdlExample.TasksService.Tasks>, WsdlExample.TasksService.Tasks {
        
        public TasksClient() {
        }
        
        public TasksClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TasksClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TasksClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TasksClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WsdlExample.TasksService.WebData Create(WsdlExample.TasksService.WebData data) {
            return base.Channel.Create(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> CreateAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.CreateAsync(data);
        }
        
        public WsdlExample.TasksService.WebData Reopen(WsdlExample.TasksService.WebData data) {
            return base.Channel.Reopen(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ReopenAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.ReopenAsync(data);
        }
        
        public WsdlExample.TasksService.WebData AddComment(WsdlExample.TasksService.WebData data) {
            return base.Channel.AddComment(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> AddCommentAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.AddCommentAsync(data);
        }
        
        public WsdlExample.TasksService.WebData Complete(WsdlExample.TasksService.WebData data) {
            return base.Channel.Complete(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> CompleteAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.CompleteAsync(data);
        }
        
        public WsdlExample.TasksService.WebData Incomplete(WsdlExample.TasksService.WebData data) {
            return base.Channel.Incomplete(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> IncompleteAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.IncompleteAsync(data);
        }
        
        public WsdlExample.TasksService.WebData StartWork(WsdlExample.TasksService.WebData data) {
            return base.Channel.StartWork(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> StartWorkAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.StartWorkAsync(data);
        }
        
        public WsdlExample.TasksService.WebData MarkRead(WsdlExample.TasksService.WebData data) {
            return base.Channel.MarkRead(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> MarkReadAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.MarkReadAsync(data);
        }
        
        public WsdlExample.TasksService.WebData Redirect(WsdlExample.TasksService.WebData data) {
            return base.Channel.Redirect(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> RedirectAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.RedirectAsync(data);
        }
        
        public WsdlExample.TasksService.WebData ChangeEndDate(WsdlExample.TasksService.WebData data) {
            return base.Channel.ChangeEndDate(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ChangeEndDateAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.ChangeEndDateAsync(data);
        }
        
        public WsdlExample.TasksService.WebData ControlComplete(WsdlExample.TasksService.WebData data) {
            return base.Channel.ControlComplete(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ControlCompleteAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.ControlCompleteAsync(data);
        }
        
        public WsdlExample.TasksService.WebData ChangeControl(WsdlExample.TasksService.WebData data) {
            return base.Channel.ChangeControl(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ChangeControlAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.ChangeControlAsync(data);
        }
        
        public WsdlExample.TasksService.WebData Close(WsdlExample.TasksService.WebData data) {
            return base.Channel.Close(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> CloseAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.CloseAsync(data);
        }
        
        public WsdlExample.TasksService.WebData AddQuestion(WsdlExample.TasksService.WebData data) {
            return base.Channel.AddQuestion(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> AddQuestionAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.AddQuestionAsync(data);
        }
        
        public WsdlExample.TasksService.WebData AnswerQuestion(WsdlExample.TasksService.WebData data) {
            return base.Channel.AnswerQuestion(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> AnswerQuestionAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.AnswerQuestionAsync(data);
        }
        
        public WsdlExample.TasksService.WebData ConfirmApproval(WsdlExample.TasksService.WebData data) {
            return base.Channel.ConfirmApproval(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ConfirmApprovalAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.ConfirmApprovalAsync(data);
        }
        
        public WsdlExample.TasksService.WebData RefuseApproval(WsdlExample.TasksService.WebData data) {
            return base.Channel.RefuseApproval(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> RefuseApprovalAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.RefuseApprovalAsync(data);
        }
        
        public WsdlExample.TasksService.WebData ApprovementStatus(WsdlExample.TasksService.WebData data) {
            return base.Channel.ApprovementStatus(data);
        }
        
        public System.Threading.Tasks.Task<WsdlExample.TasksService.WebData> ApprovementStatusAsync(WsdlExample.TasksService.WebData data) {
            return base.Channel.ApprovementStatusAsync(data);
        }
    }
}