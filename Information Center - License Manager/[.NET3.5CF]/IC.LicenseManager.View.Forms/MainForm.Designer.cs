namespace IC.LicenseManager.View.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnTestLecinseVerifier = new System.Windows.Forms.Button();
            this.btnTestGetClientLicenseDataFromKey = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestLecinseVerifier
            // 
            this.btnTestLecinseVerifier.Location = new System.Drawing.Point(187, 151);
            this.btnTestLecinseVerifier.Name = "btnTestLecinseVerifier";
            this.btnTestLecinseVerifier.Size = new System.Drawing.Size(261, 42);
            this.btnTestLecinseVerifier.TabIndex = 1;
            this.btnTestLecinseVerifier.Text = "Test Lecinse Verifier";
            this.btnTestLecinseVerifier.Click += new System.EventHandler(this.btnTestLicenseVerifier_Click);
            // 
            // btnTestGetClientLicenseDataFromKey
            // 
            this.btnTestGetClientLicenseDataFromKey.Location = new System.Drawing.Point(187, 240);
            this.btnTestGetClientLicenseDataFromKey.Name = "btnTestGetClientLicenseDataFromKey";
            this.btnTestGetClientLicenseDataFromKey.Size = new System.Drawing.Size(261, 42);
            this.btnTestGetClientLicenseDataFromKey.TabIndex = 2;
            this.btnTestGetClientLicenseDataFromKey.Text = "Test Get Client License Data From Key";
            this.btnTestGetClientLicenseDataFromKey.Click += new System.EventHandler(this.btnTestGetClientLicenseDataFromKey_Click);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(483, 362);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(94, 54);
            this.btnClearResult.TabIndex = 3;
            this.btnClearResult.Text = "Clear Result";
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.lblStatus.Location = new System.Drawing.Point(254, 54);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(140, 38);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatusText
            // 
            this.lblStatusText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblStatusText.Location = new System.Drawing.Point(254, 24);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(140, 30);
            this.lblStatusText.Text = "Status:";
            this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClearResult);
            this.Controls.Add(this.btnTestGetClientLicenseDataFromKey);
            this.Controls.Add(this.btnTestLecinseVerifier);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestLecinseVerifier;
        private System.Windows.Forms.Button btnTestGetClientLicenseDataFromKey;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusText;
    }
}

