namespace RESOReference
{
    partial class ReferenceClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectResultsDirectory = new System.Windows.Forms.Button();
            this.ResultsDirectory = new System.Windows.Forms.TextBox();
            this.LogDirectory = new System.Windows.Forms.TextBox();
            this.SelectLogDirectory = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.webapicurrentrule = new System.Windows.Forms.Label();
            this.webapiprogressBar = new System.Windows.Forms.ProgressBar();
            this.ServerVersion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.preauthenticate = new System.Windows.Forms.CheckBox();
            this.clearsettings = new System.Windows.Forms.Button();
            this.resetsession = new System.Windows.Forms.Button();
            this.executetestscript = new System.Windows.Forms.Button();
            this.labelpassword = new System.Windows.Forms.Label();
            this.authtypelabelun = new System.Windows.Forms.Label();
            this.redirecturilabel = new System.Windows.Forms.Label();
            this.textOAuthRedirectURI = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.authorizationurilabel = new System.Windows.Forms.Label();
            this.textOAuthAuthorizationURI = new System.Windows.Forms.TextBox();
            this.textOAuthPassword = new System.Windows.Forms.TextBox();
            this.textOAuthUserName = new System.Windows.Forms.TextBox();
            this.oauth_granttype = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textWebAPIURI = new System.Windows.Forms.TextBox();
            this.SaveClientSettings = new System.Windows.Forms.Button();
            this.SelectClientSettings = new System.Windows.Forms.Button();
            this.accesstokenurilabel = new System.Windows.Forms.Label();
            this.clientidlabel = new System.Windows.Forms.Label();
            this.clientsecretlabel = new System.Windows.Forms.Label();
            this.scopelabel = new System.Windows.Forms.Label();
            this.textOAuthTokenURI = new System.Windows.Forms.TextBox();
            this.textOAuthClientIdentification = new System.Windows.Forms.TextBox();
            this.textOAuthClientSecret = new System.Windows.Forms.TextBox();
            this.textOAuthClientScope = new System.Windows.Forms.TextBox();
            this.btnTestOpenIDLogin = new System.Windows.Forms.Button();
            this.ViewMetadata = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.serviceresponsedata = new System.Windows.Forms.TextBox();
            this.webapi_metadata = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.webapi_token = new System.Windows.Forms.TextBox();
            this.openid_code = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.scriptfile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bearertokenedit = new System.Windows.Forms.TextBox();
            this.authtypebearer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectResultsDirectory
            // 
            this.SelectResultsDirectory.Location = new System.Drawing.Point(629, 446);
            this.SelectResultsDirectory.Name = "SelectResultsDirectory";
            this.SelectResultsDirectory.Size = new System.Drawing.Size(143, 23);
            this.SelectResultsDirectory.TabIndex = 150;
            this.SelectResultsDirectory.Tag = "Select Results Directory";
            this.SelectResultsDirectory.Text = "Select Results Directory";
            this.SelectResultsDirectory.UseVisualStyleBackColor = true;
            this.SelectResultsDirectory.Click += new System.EventHandler(this.SelectResultsDirectory_Click);
            // 
            // ResultsDirectory
            // 
            this.ResultsDirectory.Location = new System.Drawing.Point(140, 448);
            this.ResultsDirectory.Name = "ResultsDirectory";
            this.ResultsDirectory.Size = new System.Drawing.Size(470, 20);
            this.ResultsDirectory.TabIndex = 15;
            this.ResultsDirectory.TabStop = false;
            // 
            // LogDirectory
            // 
            this.LogDirectory.Location = new System.Drawing.Point(140, 419);
            this.LogDirectory.Name = "LogDirectory";
            this.LogDirectory.Size = new System.Drawing.Size(470, 20);
            this.LogDirectory.TabIndex = 14;
            this.LogDirectory.TabStop = false;
            // 
            // SelectLogDirectory
            // 
            this.SelectLogDirectory.Location = new System.Drawing.Point(629, 417);
            this.SelectLogDirectory.Name = "SelectLogDirectory";
            this.SelectLogDirectory.Size = new System.Drawing.Size(143, 23);
            this.SelectLogDirectory.TabIndex = 140;
            this.SelectLogDirectory.Tag = "Select Log Directory";
            this.SelectLogDirectory.Text = "Select Log Directory";
            this.SelectLogDirectory.UseVisualStyleBackColor = true;
            this.SelectLogDirectory.Click += new System.EventHandler(this.SelectLogDirectory_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 452);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 92;
            this.label12.Text = "Results Directory:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(61, 423);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 91;
            this.label13.Text = "Log Directory:";
            // 
            // webapicurrentrule
            // 
            this.webapicurrentrule.AutoSize = true;
            this.webapicurrentrule.Location = new System.Drawing.Point(528, 40);
            this.webapicurrentrule.Name = "webapicurrentrule";
            this.webapicurrentrule.Size = new System.Drawing.Size(36, 13);
            this.webapicurrentrule.TabIndex = 100;
            this.webapicurrentrule.Text = "00/00";
            // 
            // webapiprogressBar
            // 
            this.webapiprogressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webapiprogressBar.Location = new System.Drawing.Point(605, 40);
            this.webapiprogressBar.Name = "webapiprogressBar";
            this.webapiprogressBar.Size = new System.Drawing.Size(308, 23);
            this.webapiprogressBar.TabIndex = 99;
            // 
            // ServerVersion
            // 
            this.ServerVersion.FormattingEnabled = true;
            this.ServerVersion.Items.AddRange(new object[] {
            "Web API/1.0"});
            this.ServerVersion.Location = new System.Drawing.Point(140, 20);
            this.ServerVersion.Name = "ServerVersion";
            this.ServerVersion.Size = new System.Drawing.Size(212, 21);
            this.ServerVersion.TabIndex = 10;
            this.ServerVersion.Text = "Web API/1.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Standard Version:";
            // 
            // preauthenticate
            // 
            this.preauthenticate.AutoSize = true;
            this.preauthenticate.Location = new System.Drawing.Point(140, 48);
            this.preauthenticate.Name = "preauthenticate";
            this.preauthenticate.Size = new System.Drawing.Size(101, 17);
            this.preauthenticate.TabIndex = 20;
            this.preauthenticate.Text = "Preauthenticate";
            this.preauthenticate.UseVisualStyleBackColor = true;
            // 
            // clearsettings
            // 
            this.clearsettings.Location = new System.Drawing.Point(140, 359);
            this.clearsettings.Name = "clearsettings";
            this.clearsettings.Size = new System.Drawing.Size(135, 23);
            this.clearsettings.TabIndex = 129;
            this.clearsettings.TabStop = false;
            this.clearsettings.Text = "Clear Settings";
            this.clearsettings.UseVisualStyleBackColor = true;
            this.clearsettings.Click += new System.EventHandler(this.clearsettings_Click);
            // 
            // resetsession
            // 
            this.resetsession.Location = new System.Drawing.Point(281, 359);
            this.resetsession.Name = "resetsession";
            this.resetsession.Size = new System.Drawing.Size(135, 23);
            this.resetsession.TabIndex = 128;
            this.resetsession.TabStop = false;
            this.resetsession.Text = "Reset Session";
            this.resetsession.UseVisualStyleBackColor = true;
            this.resetsession.Click += new System.EventHandler(this.resetsession_Click);
            // 
            // executetestscript
            // 
            this.executetestscript.Location = new System.Drawing.Point(778, 445);
            this.executetestscript.Name = "executetestscript";
            this.executetestscript.Size = new System.Drawing.Size(143, 23);
            this.executetestscript.TabIndex = 126;
            this.executetestscript.TabStop = false;
            this.executetestscript.Text = "Execute Test Script";
            this.executetestscript.UseVisualStyleBackColor = true;
            this.executetestscript.Click += new System.EventHandler(this.executetestscript_Click_1);
            // 
            // labelpassword
            // 
            this.labelpassword.AutoSize = true;
            this.labelpassword.Location = new System.Drawing.Point(77, 152);
            this.labelpassword.Name = "labelpassword";
            this.labelpassword.Size = new System.Drawing.Size(56, 13);
            this.labelpassword.TabIndex = 124;
            this.labelpassword.Text = "Password:";
            // 
            // authtypelabelun
            // 
            this.authtypelabelun.AutoSize = true;
            this.authtypelabelun.Location = new System.Drawing.Point(32, 130);
            this.authtypelabelun.Name = "authtypelabelun";
            this.authtypelabelun.Size = new System.Drawing.Size(99, 13);
            this.authtypelabelun.TabIndex = 123;
            this.authtypelabelun.Text = "            User Name:";
            // 
            // redirecturilabel
            // 
            this.redirecturilabel.AutoSize = true;
            this.redirecturilabel.Location = new System.Drawing.Point(61, 233);
            this.redirecturilabel.Name = "redirecturilabel";
            this.redirecturilabel.Size = new System.Drawing.Size(72, 13);
            this.redirecturilabel.TabIndex = 122;
            this.redirecturilabel.Text = "Redirect URI:";
            // 
            // textOAuthRedirectURI
            // 
            this.textOAuthRedirectURI.Location = new System.Drawing.Point(139, 231);
            this.textOAuthRedirectURI.Name = "textOAuthRedirectURI";
            this.textOAuthRedirectURI.Size = new System.Drawing.Size(379, 20);
            this.textOAuthRedirectURI.TabIndex = 90;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(71, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 13);
            this.label23.TabIndex = 121;
            this.label23.Text = "Grant Type:";
            // 
            // authorizationurilabel
            // 
            this.authorizationurilabel.AutoSize = true;
            this.authorizationurilabel.Location = new System.Drawing.Point(40, 179);
            this.authorizationurilabel.Name = "authorizationurilabel";
            this.authorizationurilabel.Size = new System.Drawing.Size(93, 13);
            this.authorizationurilabel.TabIndex = 115;
            this.authorizationurilabel.Text = "Authorization URI:";
            // 
            // textOAuthAuthorizationURI
            // 
            this.textOAuthAuthorizationURI.Location = new System.Drawing.Point(139, 177);
            this.textOAuthAuthorizationURI.Name = "textOAuthAuthorizationURI";
            this.textOAuthAuthorizationURI.Size = new System.Drawing.Size(379, 20);
            this.textOAuthAuthorizationURI.TabIndex = 70;
            // 
            // textOAuthPassword
            // 
            this.textOAuthPassword.Location = new System.Drawing.Point(139, 150);
            this.textOAuthPassword.Name = "textOAuthPassword";
            this.textOAuthPassword.Size = new System.Drawing.Size(379, 20);
            this.textOAuthPassword.TabIndex = 60;
            // 
            // textOAuthUserName
            // 
            this.textOAuthUserName.Location = new System.Drawing.Point(139, 123);
            this.textOAuthUserName.Name = "textOAuthUserName";
            this.textOAuthUserName.Size = new System.Drawing.Size(380, 20);
            this.textOAuthUserName.TabIndex = 50;
            // 
            // oauth_granttype
            // 
            this.oauth_granttype.FormattingEnabled = true;
            this.oauth_granttype.Items.AddRange(new object[] {
            "authorization_code",
            "Bearer Token"});
            this.oauth_granttype.Location = new System.Drawing.Point(140, 71);
            this.oauth_granttype.Name = "oauth_granttype";
            this.oauth_granttype.Size = new System.Drawing.Size(121, 21);
            this.oauth_granttype.TabIndex = 30;
            this.oauth_granttype.Text = "authorization_code";
            this.oauth_granttype.SelectedValueChanged += new System.EventHandler(this.oauth_granttype_SelectedValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 13);
            this.label15.TabIndex = 109;
            this.label15.Text = "Web API End Point URI:";
            // 
            // textWebAPIURI
            // 
            this.textWebAPIURI.Location = new System.Drawing.Point(140, 98);
            this.textWebAPIURI.Name = "textWebAPIURI";
            this.textWebAPIURI.Size = new System.Drawing.Size(379, 20);
            this.textWebAPIURI.TabIndex = 40;
            // 
            // SaveClientSettings
            // 
            this.SaveClientSettings.Location = new System.Drawing.Point(496, 10);
            this.SaveClientSettings.Name = "SaveClientSettings";
            this.SaveClientSettings.Size = new System.Drawing.Size(135, 23);
            this.SaveClientSettings.TabIndex = 107;
            this.SaveClientSettings.TabStop = false;
            this.SaveClientSettings.Tag = "Select Results Directory";
            this.SaveClientSettings.Text = "Save Client Settings";
            this.SaveClientSettings.UseVisualStyleBackColor = true;
            this.SaveClientSettings.Click += new System.EventHandler(this.SaveClientSettings_Click);
            // 
            // SelectClientSettings
            // 
            this.SelectClientSettings.Location = new System.Drawing.Point(637, 10);
            this.SelectClientSettings.Name = "SelectClientSettings";
            this.SelectClientSettings.Size = new System.Drawing.Size(135, 23);
            this.SelectClientSettings.TabIndex = 106;
            this.SelectClientSettings.TabStop = false;
            this.SelectClientSettings.Tag = "Select Results Directory";
            this.SelectClientSettings.Text = "Select Client Settings";
            this.SelectClientSettings.UseVisualStyleBackColor = true;
            this.SelectClientSettings.Click += new System.EventHandler(this.SelectClientSettings_Click);
            // 
            // accesstokenurilabel
            // 
            this.accesstokenurilabel.AutoSize = true;
            this.accesstokenurilabel.Location = new System.Drawing.Point(32, 206);
            this.accesstokenurilabel.Name = "accesstokenurilabel";
            this.accesstokenurilabel.Size = new System.Drawing.Size(101, 13);
            this.accesstokenurilabel.TabIndex = 102;
            this.accesstokenurilabel.Text = "Access Token URI:";
            // 
            // clientidlabel
            // 
            this.clientidlabel.AutoSize = true;
            this.clientidlabel.Location = new System.Drawing.Point(83, 260);
            this.clientidlabel.Name = "clientidlabel";
            this.clientidlabel.Size = new System.Drawing.Size(50, 13);
            this.clientidlabel.TabIndex = 103;
            this.clientidlabel.Text = "Client ID:";
            // 
            // clientsecretlabel
            // 
            this.clientsecretlabel.AutoSize = true;
            this.clientsecretlabel.Location = new System.Drawing.Point(63, 287);
            this.clientsecretlabel.Name = "clientsecretlabel";
            this.clientsecretlabel.Size = new System.Drawing.Size(70, 13);
            this.clientsecretlabel.TabIndex = 104;
            this.clientsecretlabel.Text = "Client Secret:";
            // 
            // scopelabel
            // 
            this.scopelabel.AutoSize = true;
            this.scopelabel.Location = new System.Drawing.Point(92, 314);
            this.scopelabel.Name = "scopelabel";
            this.scopelabel.Size = new System.Drawing.Size(41, 13);
            this.scopelabel.TabIndex = 105;
            this.scopelabel.Text = "Scope:";
            // 
            // textOAuthTokenURI
            // 
            this.textOAuthTokenURI.Location = new System.Drawing.Point(139, 204);
            this.textOAuthTokenURI.Name = "textOAuthTokenURI";
            this.textOAuthTokenURI.Size = new System.Drawing.Size(379, 20);
            this.textOAuthTokenURI.TabIndex = 80;
            // 
            // textOAuthClientIdentification
            // 
            this.textOAuthClientIdentification.Location = new System.Drawing.Point(139, 258);
            this.textOAuthClientIdentification.Name = "textOAuthClientIdentification";
            this.textOAuthClientIdentification.Size = new System.Drawing.Size(212, 20);
            this.textOAuthClientIdentification.TabIndex = 100;
            // 
            // textOAuthClientSecret
            // 
            this.textOAuthClientSecret.Location = new System.Drawing.Point(139, 285);
            this.textOAuthClientSecret.Name = "textOAuthClientSecret";
            this.textOAuthClientSecret.Size = new System.Drawing.Size(212, 20);
            this.textOAuthClientSecret.TabIndex = 110;
            // 
            // textOAuthClientScope
            // 
            this.textOAuthClientScope.Location = new System.Drawing.Point(139, 312);
            this.textOAuthClientScope.Name = "textOAuthClientScope";
            this.textOAuthClientScope.Size = new System.Drawing.Size(212, 20);
            this.textOAuthClientScope.TabIndex = 120;
            // 
            // btnTestOpenIDLogin
            // 
            this.btnTestOpenIDLogin.Location = new System.Drawing.Point(778, 10);
            this.btnTestOpenIDLogin.Name = "btnTestOpenIDLogin";
            this.btnTestOpenIDLogin.Size = new System.Drawing.Size(135, 23);
            this.btnTestOpenIDLogin.TabIndex = 16;
            this.btnTestOpenIDLogin.Text = "Login";
            this.btnTestOpenIDLogin.UseVisualStyleBackColor = true;
            this.btnTestOpenIDLogin.Click += new System.EventHandler(this.btnTestOpenIDLogin_Click_1);
            // 
            // ViewMetadata
            // 
            this.ViewMetadata.Location = new System.Drawing.Point(544, 235);
            this.ViewMetadata.Name = "ViewMetadata";
            this.ViewMetadata.Size = new System.Drawing.Size(41, 23);
            this.ViewMetadata.TabIndex = 140;
            this.ViewMetadata.TabStop = false;
            this.ViewMetadata.Text = "View";
            this.ViewMetadata.UseVisualStyleBackColor = true;
            this.ViewMetadata.Click += new System.EventHandler(this.ViewMetadata_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(541, 304);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 13);
            this.label24.TabIndex = 139;
            this.label24.Text = "Service:";
            // 
            // serviceresponsedata
            // 
            this.serviceresponsedata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceresponsedata.Location = new System.Drawing.Point(605, 301);
            this.serviceresponsedata.Multiline = true;
            this.serviceresponsedata.Name = "serviceresponsedata";
            this.serviceresponsedata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serviceresponsedata.Size = new System.Drawing.Size(308, 73);
            this.serviceresponsedata.TabIndex = 138;
            this.serviceresponsedata.TabStop = false;
            // 
            // webapi_metadata
            // 
            this.webapi_metadata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webapi_metadata.Location = new System.Drawing.Point(605, 198);
            this.webapi_metadata.Multiline = true;
            this.webapi_metadata.Name = "webapi_metadata";
            this.webapi_metadata.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.webapi_metadata.Size = new System.Drawing.Size(308, 97);
            this.webapi_metadata.TabIndex = 137;
            this.webapi_metadata.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(541, 201);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 13);
            this.label22.TabIndex = 136;
            this.label22.Text = "Metadata:";
            // 
            // webapi_token
            // 
            this.webapi_token.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webapi_token.Location = new System.Drawing.Point(605, 99);
            this.webapi_token.Multiline = true;
            this.webapi_token.Name = "webapi_token";
            this.webapi_token.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.webapi_token.Size = new System.Drawing.Size(308, 91);
            this.webapi_token.TabIndex = 135;
            this.webapi_token.TabStop = false;
            // 
            // openid_code
            // 
            this.openid_code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openid_code.Location = new System.Drawing.Point(605, 69);
            this.openid_code.Name = "openid_code";
            this.openid_code.Size = new System.Drawing.Size(308, 20);
            this.openid_code.TabIndex = 134;
            this.openid_code.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(555, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 133;
            this.label19.Text = "Token:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(561, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 132;
            this.label18.Text = "Code:";
            // 
            // scriptfile
            // 
            this.scriptfile.Location = new System.Drawing.Point(140, 388);
            this.scriptfile.Name = "scriptfile";
            this.scriptfile.Size = new System.Drawing.Size(470, 20);
            this.scriptfile.TabIndex = 13;
            this.scriptfile.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 141;
            this.label2.Text = "Test Script";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 130;
            this.button1.Tag = "Select Log Directory";
            this.button1.Text = "Load Test Script";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bearertokenedit
            // 
            this.bearertokenedit.Location = new System.Drawing.Point(140, 125);
            this.bearertokenedit.Name = "bearertokenedit";
            this.bearertokenedit.Size = new System.Drawing.Size(380, 20);
            this.bearertokenedit.TabIndex = 50;
            this.bearertokenedit.Visible = false;
            // 
            // authtypebearer
            // 
            this.authtypebearer.AutoSize = true;
            this.authtypebearer.Location = new System.Drawing.Point(56, 130);
            this.authtypebearer.Name = "authtypebearer";
            this.authtypebearer.Size = new System.Drawing.Size(75, 13);
            this.authtypebearer.TabIndex = 151;
            this.authtypebearer.Text = "Bearer Token:";
            this.authtypebearer.Visible = false;
            // 
            // ReferenceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scriptfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ViewMetadata);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.serviceresponsedata);
            this.Controls.Add(this.webapi_metadata);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.webapi_token);
            this.Controls.Add(this.openid_code);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.preauthenticate);
            this.Controls.Add(this.clearsettings);
            this.Controls.Add(this.resetsession);
            this.Controls.Add(this.executetestscript);
            this.Controls.Add(this.labelpassword);
            this.Controls.Add(this.redirecturilabel);
            this.Controls.Add(this.textOAuthRedirectURI);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.authorizationurilabel);
            this.Controls.Add(this.textOAuthAuthorizationURI);
            this.Controls.Add(this.textOAuthPassword);
            this.Controls.Add(this.textOAuthUserName);
            this.Controls.Add(this.oauth_granttype);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textWebAPIURI);
            this.Controls.Add(this.SaveClientSettings);
            this.Controls.Add(this.SelectClientSettings);
            this.Controls.Add(this.accesstokenurilabel);
            this.Controls.Add(this.clientidlabel);
            this.Controls.Add(this.clientsecretlabel);
            this.Controls.Add(this.scopelabel);
            this.Controls.Add(this.textOAuthTokenURI);
            this.Controls.Add(this.textOAuthClientIdentification);
            this.Controls.Add(this.textOAuthClientSecret);
            this.Controls.Add(this.textOAuthClientScope);
            this.Controls.Add(this.btnTestOpenIDLogin);
            this.Controls.Add(this.webapicurrentrule);
            this.Controls.Add(this.webapiprogressBar);
            this.Controls.Add(this.ServerVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SelectResultsDirectory);
            this.Controls.Add(this.ResultsDirectory);
            this.Controls.Add(this.LogDirectory);
            this.Controls.Add(this.SelectLogDirectory);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.bearertokenedit);
            this.Controls.Add(this.authtypelabelun);
            this.Controls.Add(this.authtypebearer);
            this.Name = "ReferenceClient";
            this.Text = "RESO Reference Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectResultsDirectory;
        private System.Windows.Forms.TextBox ResultsDirectory;
        private System.Windows.Forms.TextBox LogDirectory;
        private System.Windows.Forms.Button SelectLogDirectory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label webapicurrentrule;
        private System.Windows.Forms.ProgressBar webapiprogressBar;
        private System.Windows.Forms.ComboBox ServerVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox preauthenticate;
        private System.Windows.Forms.Button clearsettings;
        private System.Windows.Forms.Button resetsession;
        private System.Windows.Forms.Button executetestscript;
        private System.Windows.Forms.Label labelpassword;
        private System.Windows.Forms.Label authtypelabelun;
        private System.Windows.Forms.Label redirecturilabel;
        private System.Windows.Forms.TextBox textOAuthRedirectURI;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label authorizationurilabel;
        private System.Windows.Forms.TextBox textOAuthAuthorizationURI;
        private System.Windows.Forms.TextBox textOAuthPassword;
        private System.Windows.Forms.TextBox textOAuthUserName;
        private System.Windows.Forms.ComboBox oauth_granttype;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textWebAPIURI;
        private System.Windows.Forms.Button SaveClientSettings;
        private System.Windows.Forms.Button SelectClientSettings;
        private System.Windows.Forms.Label accesstokenurilabel;
        private System.Windows.Forms.Label clientidlabel;
        private System.Windows.Forms.Label clientsecretlabel;
        private System.Windows.Forms.Label scopelabel;
        private System.Windows.Forms.TextBox textOAuthTokenURI;
        private System.Windows.Forms.TextBox textOAuthClientIdentification;
        private System.Windows.Forms.TextBox textOAuthClientSecret;
        private System.Windows.Forms.TextBox textOAuthClientScope;
        private System.Windows.Forms.Button btnTestOpenIDLogin;
        private System.Windows.Forms.Button ViewMetadata;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox serviceresponsedata;
        private System.Windows.Forms.TextBox webapi_metadata;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox webapi_token;
        private System.Windows.Forms.TextBox openid_code;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox scriptfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox bearertokenedit;
        private System.Windows.Forms.Label authtypebearer;
    }
}

