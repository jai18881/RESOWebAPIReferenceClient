using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RESOClientLibrary;
using RESOClientLibrary.Transactions;
using ReferenceLibrary;
using System.Collections;
using System.IO;

namespace RESOReference
{
    public partial class ReferenceClient : Form
    {
        RESOLogging debuglog = null;
        public string executepath { get; set; }
        ReferencePropertiesFile clientproperties = new ReferencePropertiesFile();
        public string oauth_bearertoken { get; set; }
        public string metadataresponse { get; set; }
        public string serviceresponse { get; set; }
        public string openidcode { get; set; }
        public string responseheaders { get; set; }
        public Hashtable commandlinefunctions = new Hashtable();
        public ReferenceClient()
        {
            InitializeComponent();

            executepath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            debuglog = new RESOLogging("debug", System.IO.Path.Combine(executepath, @"Logs\\debug.resolog"), false);
            clientproperties.executablepath = executepath;
            CheckArguments();
        }



        void CheckArguments()
        {
            string[] args = Environment.GetCommandLineArgs();
            for (int n = 0; n < args.Length; n++)
            {
                string line = args[n];
                string[] argdata = line.Split('=');
                if (argdata.Length == 2)
                {
                    if (argdata[0].ToUpper() == "SCRIPT")
                    {
                        loadscriptfile(argdata[1].Trim(','));
                    }
                    else if (argdata[0].ToUpper() == "SETTINGS")
                    {
                        loadclientpropertiesfile(argdata[1].Trim(','));
                    }
                }
            }
        }


        private void SelectLogDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectLogDirectoryDialog = new FolderBrowserDialog();
            string currentpath = this.LogDirectory.Text;
            if (string.IsNullOrEmpty(currentpath))
            {
                SelectLogDirectoryDialog.SelectedPath = System.IO.Path.Combine(executepath, @"Logs");
            }
            else
            {
                SelectLogDirectoryDialog.SelectedPath = currentpath;
            }


            if (SelectLogDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                this.LogDirectory.Text = SelectLogDirectoryDialog.SelectedPath.ToString();
            }
        }

        private void SelectResultsDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog SelectDirectoryDialog = new FolderBrowserDialog();
            string currentpath = this.ResultsDirectory.Text;
            if (string.IsNullOrEmpty(currentpath))
            {
                //ResultsDirectory.Text = System.IO.Path.Combine(executepath, @"Results");
                SelectDirectoryDialog.SelectedPath = System.IO.Path.Combine(executepath, @"Results");
            }
            else
            {
                SelectDirectoryDialog.SelectedPath = currentpath;
            }


            if (SelectDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                this.ResultsDirectory.Text = SelectDirectoryDialog.SelectedPath.ToString();
            }
        }


        private void SelectClientSettings_Click(object sender, EventArgs e)
        {
            loadclientpropertiesfile();
        }


        private void loadclientpropertiesfile()
        {
            OpenFileDialog testfile = new OpenFileDialog();
            testfile.Filter = "Client Settings Files (*.resocs)|*.resocs|Property Files (*.properties)|*.properties|All files (*.*)|*.*";
            testfile.FilterIndex = 1;
            testfile.RestoreDirectory = true;
            testfile.InitialDirectory = System.IO.Path.Combine(executepath, @"Properties");

            if (testfile.ShowDialog() == DialogResult.OK)
            {
                loadclientpropertiesfile(testfile.FileName);

            }
        }

        private void clearclientsettings()
        {
            try
            {
                DebugLogLabel("ReferenceClient:clearclientsettings()");
                webapicurrentrule.Text = string.Empty;

                this.webapiprogressBar.Value = 0;
                this.ServerVersion.Text = string.Empty;
                this.textOAuthAuthorizationURI.Text = string.Empty;
                this.textOAuthTokenURI.Text = string.Empty;
                this.textOAuthTokenURI.Text = string.Empty;
                this.textOAuthClientIdentification.Text = string.Empty;
                this.textOAuthRedirectURI.Text = string.Empty;
                this.textOAuthClientSecret.Text = string.Empty;
                this.textOAuthClientScope.Text = string.Empty;
                this.textWebAPIURI.Text = string.Empty;
                this.textOAuthUserName.Text = string.Empty;
                this.textOAuthPassword.Text = string.Empty;
                this.LogDirectory.Text = string.Empty;
                this.ResultsDirectory.Text = string.Empty;
                this.openid_code.Text = string.Empty;
                this.webapi_token.Text = string.Empty;
                this.webapi_metadata.Text = string.Empty;
                this.serviceresponsedata.Text = string.Empty;
                this.preauthenticate.Checked = false;
                resetsessionvalues();
                this.Update();

            }
            catch (Exception ex)
            {
                DebugLogLabel("ReferenceClient:clearclientsettings():ERROR:" + ex.Message);
            }
        }

        private void resetsessionvalues()
        {
            try
            {
                DebugLogLabel("ReferenceClient:resetsessionvalues()");
                RESOClientSettings clientsettings = GetSettings();
                this.openid_code.Text = string.Empty;
                this.webapi_token.Text = string.Empty;
                this.webapi_metadata.Text = string.Empty;
                this.serviceresponsedata.Text = string.Empty;
                openid_code.Text = string.Empty;

                oauth_bearertoken = string.Empty;
                metadataresponse = string.Empty;
                serviceresponse = string.Empty;
                webapi_token.Text = oauth_bearertoken;
                webapi_metadata.Text = metadataresponse;
                serviceresponsedata.Text = serviceresponse;

                clientsettings.SetSetting(settings.openid_code, string.Empty);
            }
            catch (Exception ex)
            {
                DebugLogLabel("ReferenceClient:resetsessionvalues():ERROR:" + ex.Message);
            }
        }

        private RESOClientSettings GetSettings()
        {
            try
            {
                DebugLogLabel("ReferenceClient:GetSettings()");
                RESOClientSettings clientsettings = new RESOClientSettings();

                clientsettings.SetSetting(settings.rulecontroloutput, System.IO.Path.Combine(executepath, @"config"));
                clientsettings.SetSetting(settings.rulecontrolinput, System.IO.Path.Combine(executepath, @"config"));
                clientsettings.SetSetting(settings.rulescontrolfile, System.IO.Path.Combine(executepath, @"config") + "\\rulecontrol.xml");
                clientsettings.SetSetting(settings.certificatepath, System.IO.Path.Combine(executepath, @"Certificate") + "\\FiddlerRoot.cer");

                clientsettings.SetSetting(settings.log_directory, System.IO.Path.Combine(executepath, @"Logs"));


                if (this.ServerVersion.Text == "RETS 1.8")
                {
                    clientsettings.SetSetting(settings.version, "1.8");
                    clientsettings.SetSetting(settings.standard, "RETS");

                }
                else
                {
                    string dataversion = ServerVersion.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(dataversion))
                    {
                        if (dataversion.IndexOf("/") > 0)
                        {
                            string[] version = dataversion.Split('/');
                            clientsettings.SetSetting(settings.version, version[0]);
                            clientsettings.SetSetting(settings.standard, version[1]);
                        }
                    }
                }
                if (string.IsNullOrEmpty(scriptfile.Text))
                {
                    scriptfile.Text = System.IO.Path.Combine(executepath, @"webapitestscript") + "\\TestScript.xml";
                }

                clientsettings.SetSetting(settings.testscript, scriptfile.Text);
                clientsettings.SetSetting(settings.oauth_authorizationuri, textOAuthAuthorizationURI.Text);
                clientsettings.SetSetting(settings.oauth_clientidentification, textOAuthClientIdentification.Text);
                clientsettings.SetSetting(settings.oauth_redirecturi, textOAuthRedirectURI.Text);
                clientsettings.SetSetting(settings.oauth_clientscope, textOAuthClientScope.Text);
                clientsettings.SetSetting(settings.oauth_clientsecret, textOAuthClientSecret.Text);
                clientsettings.SetSetting(settings.oauth_tokenuri, textOAuthTokenURI.Text);
                clientsettings.SetSetting(settings.webapi_uri, textWebAPIURI.Text);
                clientsettings.SetSetting(settings.oauth_granttype, oauth_granttype.Text);
                clientsettings.SetSetting(settings.rets_username, textOAuthUserName.Text);
                clientsettings.SetSetting(settings.rets_password, textOAuthPassword.Text);
                clientsettings.SetSetting(settings.useragent, "webapiclient/1.0");

                string resultsdirectory = ResultsDirectory.Text;
                if (string.IsNullOrWhiteSpace(resultsdirectory))
                {
                    resultsdirectory = System.IO.Path.Combine(executepath, @"Results");
                    ResultsDirectory.Text = resultsdirectory;

                }
                clientsettings.SetSetting(settings.results_directory, resultsdirectory);
                string logdirectory = LogDirectory.Text;
                if (string.IsNullOrWhiteSpace(logdirectory))
                {
                    logdirectory = System.IO.Path.Combine(executepath, @"Logs");
                    LogDirectory.Text = logdirectory;

                }
                clientsettings.SetSetting(settings.log_directory, logdirectory);

                //LogDirectory.Text = System.IO.Path.Combine(executepath, @"Logs");
                //ResultsDirectory.Text = System.IO.Path.Combine(executepath, @"Results");
                clientsettings.SetSetting(settings.outputdirectory, resultsdirectory);

                return clientsettings;
            }
            catch (Exception ex)
            {
                DebugLogLabel("ReferenceClient:GetSettings():ERROR:" + ex.Message);
            }
            return null;
        }

        private void SaveClientSettings_Click(object sender, EventArgs e)
        {
            saveclientpropertiesfile();
        }

        private void saveclientpropertiesfile()
        {
            try
            {

                DebugLogLabel("ReferenceClient:saveclientpropertiesfile()");
                if (this.textOAuthClientScope.Text.ToUpper().IndexOf("OPENID") < 0)
                {
                    MessageBox.Show("Scope requires openid as a parameter for the RESO Web API OpenID Authentcation.  Please correct before saving.");
                    return;
                }
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Client Settings Files (*.resocs)|*.resocs|Property Files (*.properties)|*.properties|All files (*.*)|*.*";
                saveFileDialog1.Title = "Save Client Settings";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {

                    clientproperties.setProperty("AuthenticationType", this.oauth_granttype.Text);
                    clientproperties.setProperty("Preauthenticate", ((this.preauthenticate.Checked == true) ? ("TRUE") : ("FALSE")));
                    clientproperties.setProperty("ServerVersion", this.ServerVersion.Text);
                    //OData
                    clientproperties.setProperty("textScriptFile", this.scriptfile.Text);
                    clientproperties.setProperty("textOAuthAuthorizationURI", this.textOAuthAuthorizationURI.Text);
                    clientproperties.setProperty("textOAuthTokenURI", this.textOAuthTokenURI.Text);
                    clientproperties.setProperty("textOAuthTokenURI", this.textOAuthTokenURI.Text);
                    clientproperties.setProperty("textWebAPIURI", this.textWebAPIURI.Text);
                    clientproperties.setProperty("textOAuthClientIdentification", this.textOAuthClientIdentification.Text);
                    clientproperties.setProperty("textOAuthRedirectURI", this.textOAuthRedirectURI.Text);
                    clientproperties.setProperty("textOAuthClientSecret", this.textOAuthClientSecret.Text);
                    clientproperties.setProperty("textOAuthClientScope", this.textOAuthClientScope.Text);
                    //clientproperties.setProperty("textWebAPIHost", this.textWebAPIURI.Text);
                    clientproperties.setProperty("textOAuthUserName", this.textOAuthUserName.Text);
                    clientproperties.setProperty("textOAuthPassword", this.textOAuthPassword.Text);
                    clientproperties.setProperty("transactionlogdirectory", this.LogDirectory.Text);
                    clientproperties.setProperty("resultsdirectory", this.ResultsDirectory.Text);
                    clientproperties.saveFile(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                DebugLogLabel("ReferenceClient:saveclientpropertiesfile():ERROR:" + ex.Message);
            }
        }

        private void btnTestOpenIDLogin_Click_1(object sender, EventArgs e)
        {
            RESOClientSettings clientsettings = GetSettings();
            if (string.IsNullOrWhiteSpace(clientsettings.GetSetting(settings.webapi_uri)))
            {
                loadclientpropertiesfile();
                clientsettings = GetSettings();
            }

            if (string.IsNullOrEmpty(clientsettings.GetSetting(settings.oauth_authorizationuri)))
            {
                MessageBox.Show("Please Enter login information or load select a saved client properties file");
                return;
            }
            try
            {
                Uri test = new Uri(clientsettings.GetSetting(settings.oauth_authorizationuri));
            }
            catch
            {
                MessageBox.Show("Please Enter correct authorization URI");
                return;
            }
            Login();
        }

        private void OutputLog(string logentry)
        {
            //OutputWindow.Text += logentry;
            //OutputWindow.Update();
        }

        private void ViewNavigateURL(Uri uri)
        {
            if (uri.AbsoluteUri.IndexOf("code=") > 0)
            {
                string[] urlparts = uri.AbsoluteUri.Split('&');
                foreach (string part in urlparts)
                {
                    if (part.IndexOf("code=") >= 0)
                    {
                        string[] codeurlparts = part.Split('=');
                        if (codeurlparts.Length == 2)
                        {
                            openidcode = codeurlparts[1];
                        }

                    }
                }

            }

        }

        private bool BrowserLogin(ref RESOClientSettings clientsettings)
        {
            if (clientsettings.GetSetting(settings.oauth_granttype) == "authorization_code")
            {
                if (string.IsNullOrEmpty(clientsettings.GetSetting(settings.openid_code)))
                {
                    LoginBrowser browserform = new LoginBrowser();
                    browserform.SetURL(clientsettings.GetSetting(settings.oauth_authorizationuri) + "?response_type=code&client_id=" + clientsettings.GetSetting(settings.oauth_clientidentification) + "&redirect_uri=" + clientsettings.GetSetting(settings.oauth_redirecturi) + "&scope=" + clientsettings.GetSetting(settings.oauth_clientscope), ViewNavigateURL);
                    //browserform.SetURL(clientsettings.GetSetting(settings.oauth_authorizationuri) + "?response_type=code&client_id=" + clientsettings.GetSetting(settings.oauth_clientidentification) + "&redirect_uri=" + clientsettings.GetSetting(settings.oauth_redirecturi) /*+ "&scope=" + clientsettings.GetSetting(settings.oauth_clientscope)*/, ViewNavigateURL);
                    browserform.ShowDialog();
                    if (string.IsNullOrEmpty(openidcode))
                    {
                        MessageBox.Show("Open ID Code not retrieved");
                        return false;
                    }
                    clientsettings.SetSetting(settings.openid_code, openidcode);
                }
            }
            return true;
        }
        private bool Login()
        {
            RESOClientSettings clientsettings = GetSettings();
            RESOClient app = new RESOClient(clientsettings, OutputLog);
            return Login(ref app,ref clientsettings);
        }
        private bool Login(ref RESOClient app, ref RESOClientSettings clientsettings)
        {
            if (clientsettings == null)
            {
                clientsettings = GetSettings();
            }
            if (app == null)
            {
                app = new RESOClient(clientsettings, OutputLog);
            }
            if(!BrowserLogin(ref clientsettings))
            {
                return false;
            }
            openid_code.Text = "Loading...";
            webapi_token.Text = "Loading...";
            webapi_metadata.Text = "Loading...";
            serviceresponsedata.Text = "Loading...";
            this.Update();
            bool preauth = preauthenticate.Checked;
            ODataLoginTransaction login = new ODataLoginTransaction(app.clientsettings);
            try
            {
                if (!login.ExecuteEvent(app, preauth))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("(401)") > 0)
                {
                    if (!preauth)
                    {
                        string messageerror = "Non-Compliant:  " + ex.Message + " Please select Preauthentication to continue test.  Please review the HTTP Standard for Basic Authentication Challenge Response";
                        webapi_metadata.Text = messageerror;

                    }
                    else
                    {
                        webapi_metadata.Text = ex.Message;
                    }

                }
                else
                {
                    webapi_metadata.Text = ex.Message;
                }

                openid_code.Text = "Error";
                webapi_token.Text = "Error";
                serviceresponsedata.Text = "Error";
                this.Update();
                return false;
            }

            oauth_bearertoken = app.oauth_token.token_type + " " + app.oauth_token.access_token;
            openid_code.Text = clientsettings.GetSetting(settings.openid_code);
            webapi_token.Text = oauth_bearertoken;
            this.Update();
            ODataMetadataTransaction metadata = new ODataMetadataTransaction(app.clientsettings);
            if (!metadata.ExecuteEvent(app))
            {
                webapi_metadata.Text = "Error";
                this.Update();
                return false;
            }
            metadataresponse = metadata.responsedata;
            if (string.IsNullOrEmpty(metadataresponse))
            {
                webapi_metadata.Text = "No Data Returned";
            }
            else
            {

                webapi_metadata.Text = metadataresponse;
            }
            this.Update();
            ODataServiceTransaction service = new ODataServiceTransaction(app.clientsettings);
            if (!service.ExecuteEvent(app))
            {
                serviceresponsedata.Text = "Error";
                this.Update();
                return false;
            }
            serviceresponse = service.responsedata;
            if (string.IsNullOrEmpty(serviceresponse))
            {
                serviceresponsedata.Text = "No Data Returned";
            }
            else
            {

                serviceresponsedata.Text = serviceresponse;
            }

            this.Update();
            //string ServiceStatusHeaders = "ODataVersion:4.0;Authorization:" + app.oauth_token.token_type + " " + app.oauth_token.access_token;
            //try
            //{
            //    ServiceStatus.GetInstance(clientsettings.GetSetting(settings.webapi_uri).TrimEnd('/'), ServiceStatusHeaders);
            //}
            //catch
            //{
            //    ServiceStatus.GetInstance(clientsettings.GetSetting(settings.webapi_uri).TrimEnd('/'), ServiceStatusHeaders);
            //}


            //ServiceStatus.ReviseMetadata(metadata.responsedata);


            responseheaders = app.responseobject.ResponseHeaders;
            return true;
        }

        private void loadscriptfile(string scriptfiledata)
        {

            RESOClientSettings clientsettings = GetSettings();

            clientsettings.SetSetting(settings.testscript, scriptfiledata);

            scriptfile.Text = scriptfiledata;
            ReferencePropertiesFile testproperties = new ReferencePropertiesFile();
            if (string.IsNullOrEmpty(scriptfiledata))
            {
                MessageBox.Show("Please load a Script File");
                return;
            }
            testproperties.ReadFile(scriptfiledata);
            if (testproperties.IsLoaded())
            {
                loadclientpropertiesfile(scriptfiledata);
                clientproperties.setProperty("textScriptFile", scriptfiledata);
                scriptfile.Text = scriptfiledata;
            }

            if (string.IsNullOrWhiteSpace(clientsettings.GetSetting(settings.oauth_authorizationuri)))
            {
                loadclientpropertiesfile();
                clientsettings = GetSettings();
            }
            RESOClient app = new RESOClient(clientsettings, OutputLog);
            if (!Login(ref app, ref clientsettings))
            {
                return;
            }
            Update();
       
            if (app.oauth_token == null)
            {
                MessageBox.Show("Error Authenticating.  Token is null");
                return;
            }
            oauth_bearertoken = app.oauth_token.token_type + " " + app.oauth_token.access_token;

            LoadTestScript testscript = new LoadTestScript();
            testscript.LoadData(clientsettings.GetSetting(settings.testscript));
            
            ODataTestScriptTransaction testscriptobject = new ODataTestScriptTransaction(app.clientsettings);
            string outputdirectory = clientsettings.GetSetting(settings.outputdirectory);
            if (testscript.parameters["Parameter_OutputDirectory"] != null)
            {
                outputdirectory = testscript.parameters["Parameter_OutputDirectory"] as string;
            }
            outputdirectory = outputdirectory.Trim('\\');
            if(string.IsNullOrEmpty(outputdirectory) || !Directory.Exists(outputdirectory))
            {
                outputdirectory = testscript.parameters["config_defaultresultsdirectory"] as string;
                if (!Directory.Exists(outputdirectory))
                {
                    Directory.CreateDirectory(outputdirectory);
                }
            }
            DebugLogData(outputdirectory);
            
            int currcount = 0;
            foreach (RESOClientLibrary.Request item in testscript.requests)
            {
                StringBuilder sbresults = new StringBuilder();
                RESOClientLibrary.Transactions.EventRequest eventitem = new RESOClientLibrary.Transactions.EventRequest();
                eventitem.url = item.url;
                eventitem.outputfile = item.outputfile;
                eventitem.validationid = item.validationid;
                eventitem.method = item.method;
                eventitem.payload = item.payload;

                if (!testscriptobject.ExecuteEvent(app, eventitem, outputdirectory, ref debuglog))
                {
                    return;
                }
                currcount++;
                
                sbresults.Append(Convert.ToString(currcount));
                sbresults.Append("\t");
                sbresults.Append(outputdirectory + item.outputfile);
                sbresults.Append("\t");
                sbresults.Append(item.method);
                sbresults.Append("\t");
                sbresults.Append(item.url);
                sbresults.Append("\t");
                sbresults.Append(item.payload);
                sbresults.Append("\t");
                sbresults.Append(item.validationid);
                sbresults.Append("\r\n");
                DebugLogData(sbresults.ToString());
                sbresults.Clear();
                webapitestcomplete(Convert.ToString(currcount) + "/" + Convert.ToString(testscript.requests.Count), testscript.requests.Count, currcount);
            }
            DebugLogLabel("CLIENT LOG");
            DebugLogData(app.ClientLog.ToString());
            OutputDebugLog();
            webapitestcomplete("Complete", testscript.requests.Count, currcount);
        }

        private void OutputDebugLog()
        {
            if(debuglog != null)
            {
                debuglog.OutputLogFile();
            }
        }

        private void DebugLogLabel(string label)
        {
            if (debuglog != null)
            {
                debuglog.LogLabel(label);
            }
        }
        private void DebugLogData(string data)
        {
            if (debuglog != null)
            {
                debuglog.LogData(data);
            }
        }
        void webapitestcomplete(string name, int numberofrules, int count)
        {

            webapicurrentrule.Text = name;
            webapicurrentrule.Update();
            this.webapiprogressBar.Value = (int)((100 * count) / numberofrules);


            this.Update();
        }
        private void executetestscript_Click_1(object sender, EventArgs e)
        {

            loadscriptfile(scriptfile.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog testfile = new OpenFileDialog();
            testfile.Filter = "Client Script Files (*.resoscript)|*.resoscript|XML Script Files (*.xml)|*.xml|All files (*.*)|*.*";
            testfile.FilterIndex = 1;
            testfile.RestoreDirectory = true;
            if (string.IsNullOrEmpty(scriptfile.Text))
            {
                testfile.InitialDirectory = System.IO.Path.Combine(executepath, @"webapitestscript");
            }
            else
            {
                testfile.InitialDirectory = scriptfile.Text;
            }

            if (testfile.ShowDialog() == DialogResult.OK)
            {
                scriptfile.Text = testfile.FileName;
                ReferencePropertiesFile testproperties = new ReferencePropertiesFile();
                testproperties.ReadFile(testfile.FileName);
                if(testproperties.IsLoaded())
                {
                    loadclientpropertiesfile(testfile.FileName);
                    clientproperties.setProperty("textScriptFile", testfile.FileName);
                    scriptfile.Text = testfile.FileName;
                }
            }
        }

        private void loadclientpropertiesfile(string filename)
        {
            try
            {
                clearclientsettings();
                clientproperties.ReadFile(filename);
                string sv = clientproperties.getProperty("ServerVersion");
                if (string.IsNullOrEmpty(sv))
                {
                    sv = "Web API/1.0";
                }
                int index = this.ServerVersion.Items.IndexOf(sv.Trim());

                if (index >= 0)
                {
                    this.ServerVersion.SelectedIndex = index;
                }
                else
                {
                    this.ServerVersion.SelectedIndex = 0;
                }
                this.ServerVersion.Text = this.ServerVersion.SelectedItem.ToString();

                string granttype = clientproperties.getProperty("AuthenticationType");
                if (string.IsNullOrEmpty(granttype))
                {
                    granttype = "authorization_code";
                }
                index = this.oauth_granttype.Items.IndexOf(granttype.Trim());

                if (index >= 0)
                {
                    this.oauth_granttype.SelectedIndex = index;
                }
                else
                {
                    this.oauth_granttype.SelectedIndex = 0;
                }
                this.oauth_granttype.Text = this.oauth_granttype.SelectedItem.ToString();

                
                

                //OData
                this.scriptfile.Text = clientproperties.getProperty("textScriptFile");
                if (string.IsNullOrEmpty(scriptfile.Text))
                {
                    scriptfile.Text = System.IO.Path.Combine(executepath, @"webapitestscript") + "\\TestScript.resoscript";
                }

                //clientproperties.setProperty("Preauthenticate", ((this.preauthenticate.Checked == true) ? ("TRUE") : ("FALSE")));
                this.preauthenticate.Checked = ((clientproperties.getProperty("Preauthenticate") == "TRUE") ? (true):(false));
                this.textOAuthAuthorizationURI.Text = clientproperties.getProperty("textOAuthAuthorizationURI");
                this.textOAuthTokenURI.Text = clientproperties.getProperty("textOAuthTokenURI");

                this.textWebAPIURI.Text = clientproperties.getProperty("textWebAPIURI");

                this.textOAuthClientIdentification.Text = clientproperties.getProperty("textOAuthClientIdentification");
                this.textOAuthRedirectURI.Text = clientproperties.getProperty("textOAuthRedirectURI");

                this.textOAuthClientSecret.Text = clientproperties.getProperty("textOAuthClientSecret");
                this.textOAuthClientScope.Text = clientproperties.getProperty("textOAuthClientScope");


                this.textOAuthUserName.Text = clientproperties.getProperty("textOAuthUserName");
                this.textOAuthPassword.Text = clientproperties.getProperty("textOAuthPassword");
                //Global
                this.LogDirectory.Text = clientproperties.getProperty("transactionlogdirectory");
                this.ResultsDirectory.Text = clientproperties.getProperty("resultsdirectory");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void resetsession_Click(object sender, EventArgs e)
        {
            resetsessionvalues();
        }

        private void clearsettings_Click(object sender, EventArgs e)
        {
            clearclientsettings();
        }

        private void ViewMetadata_Click(object sender, EventArgs e)
        {
            MetadataForm metadataview = new MetadataForm();
            metadataview.LoadData(webapi_metadata.Text);
            metadataview.ShowDialog();
        }

        private void viewscript_Click(object sender, EventArgs e)
        {

        }
  
        private void oauth_granttype_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            SetAuthTypeControls(comboBox.SelectedItem as string);

         



        }

        private void SetAuthTypeControls(string authtype)
        {
            bool showbearer = false;
            if (authtype == "Bearer Token")
            {
                showbearer = true;
            }

            authtypelabelun.Visible = !showbearer;
            authtypebearer.Visible = showbearer;
            textOAuthUserName.Visible = !showbearer;
            bearertokenedit.Visible = showbearer;
            labelpassword.Visible = !showbearer;
            authorizationurilabel.Visible = !showbearer;
            accesstokenurilabel.Visible = !showbearer;
            redirecturilabel.Visible = !showbearer;
            clientidlabel.Visible = !showbearer;
            clientsecretlabel.Visible = !showbearer;
            scopelabel.Visible = !showbearer;
            textOAuthPassword.Visible = !showbearer;
            textOAuthAuthorizationURI.Visible = !showbearer;
            textOAuthTokenURI.Visible = !showbearer;
            textOAuthRedirectURI.Visible = !showbearer;
            textOAuthClientIdentification.Visible = !showbearer;
            textOAuthClientSecret.Visible = !showbearer;
            textOAuthClientScope.Visible = !showbearer;
        }
    }




        
    
}
    
