﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace HUBAdvance.extranet.cbn.crms {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ReturnSubmissionWSEJBBeanPortBinding", Namespace="http://services.model.crms.cbn.gov.ng/")]
    public partial class ReturnSubmissionWSEJBBeanService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback confirmReturnOperationCompleted;
        
        private System.Threading.SendOrPostCallback submitReturnOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ReturnSubmissionWSEJBBeanService() {
            this.Url = global::HUBAdvance.Properties.Settings.Default.SalaryAdvanceNew_extranet_cbn_crms_ReturnSubmissionWSEJBBeanService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event confirmReturnCompletedEventHandler confirmReturnCompleted;
        
        /// <remarks/>
        public event submitReturnCompletedEventHandler submitReturnCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://services.model.crms.cbn.gov.ng/", ResponseNamespace="http://services.model.crms.cbn.gov.ng/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("confirmreturn", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string confirmReturn([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string username, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string password, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string returnname, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string returnxml) {
            object[] results = this.Invoke("confirmReturn", new object[] {
                        username,
                        password,
                        returnname,
                        returnxml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void confirmReturnAsync(string username, string password, string returnname, string returnxml) {
            this.confirmReturnAsync(username, password, returnname, returnxml, null);
        }
        
        /// <remarks/>
        public void confirmReturnAsync(string username, string password, string returnname, string returnxml, object userState) {
            if ((this.confirmReturnOperationCompleted == null)) {
                this.confirmReturnOperationCompleted = new System.Threading.SendOrPostCallback(this.OnconfirmReturnOperationCompleted);
            }
            this.InvokeAsync("confirmReturn", new object[] {
                        username,
                        password,
                        returnname,
                        returnxml}, this.confirmReturnOperationCompleted, userState);
        }
        
        private void OnconfirmReturnOperationCompleted(object arg) {
            if ((this.confirmReturnCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.confirmReturnCompleted(this, new confirmReturnCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://services.model.crms.cbn.gov.ng/", ResponseNamespace="http://services.model.crms.cbn.gov.ng/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("submitreturn", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string submitReturn([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string username, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string password, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string returnname, [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] string returnxml) {
            object[] results = this.Invoke("submitReturn", new object[] {
                        username,
                        password,
                        returnname,
                        returnxml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void submitReturnAsync(string username, string password, string returnname, string returnxml) {
            this.submitReturnAsync(username, password, returnname, returnxml, null);
        }
        
        /// <remarks/>
        public void submitReturnAsync(string username, string password, string returnname, string returnxml, object userState) {
            if ((this.submitReturnOperationCompleted == null)) {
                this.submitReturnOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsubmitReturnOperationCompleted);
            }
            this.InvokeAsync("submitReturn", new object[] {
                        username,
                        password,
                        returnname,
                        returnxml}, this.submitReturnOperationCompleted, userState);
        }
        
        private void OnsubmitReturnOperationCompleted(object arg) {
            if ((this.submitReturnCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.submitReturnCompleted(this, new submitReturnCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void confirmReturnCompletedEventHandler(object sender, confirmReturnCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class confirmReturnCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal confirmReturnCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void submitReturnCompletedEventHandler(object sender, submitReturnCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class submitReturnCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal submitReturnCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591