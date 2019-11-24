namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class ScanControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanControl));
            this.buttonSettings = new IC.Client.View.Components.ICButton();
            this.buttonShares = new IC.Client.View.Components.ICButton();
            this.pictureBoxLogo = new IC.Client.View.Components.ICPicture();
            this.lblScanBarcodePlease = new IC.Client.View.Components.ICLabel();
            this.SuspendLayout();
            // 
            // buttonSettings
            // 
            this.buttonSettings.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonSettings.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(586, 389);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(180, 68);
            this.buttonSettings.TabIndex = 8;
            this.buttonSettings.Text = "btnSettings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonShares
            // 
            this.buttonShares.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonShares.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonShares.Image")));
            this.buttonShares.Location = new System.Drawing.Point(400, 389);
            this.buttonShares.Name = "buttonShares";
            this.buttonShares.Size = new System.Drawing.Size(180, 68);
            this.buttonShares.TabIndex = 6;
            this.buttonShares.Text = "btnShares";
            this.buttonShares.Click += new System.EventHandler(this.buttonShares_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.TabIndex = 10;
            this.pictureBoxLogo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblScanBarcodePlease
            // 
            this.lblScanBarcodePlease.Font = new System.Drawing.Font("Cambria", 44F, System.Drawing.FontStyle.Bold);
            this.lblScanBarcodePlease.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScanBarcodePlease.Location = new System.Drawing.Point(48, 104);
            this.lblScanBarcodePlease.Name = "lblScanBarcodePlease";
            this.lblScanBarcodePlease.Size = new System.Drawing.Size(718, 239);
            this.lblScanBarcodePlease.TabIndex = 11;
            this.lblScanBarcodePlease.Text = "lblScanBarcodePlease";
            // 
            // ScanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonShares);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.lblScanBarcodePlease);
            this.Name = "ScanControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.Click += new System.EventHandler(this.ClickOnControl);
            this.ResumeLayout(false);

        }

        #endregion

        private IC.Client.View.Components.ICPicture pictureBoxLogo;
        private IC.Client.View.Components.ICButton buttonShares;
        private IC.Client.View.Components.ICButton buttonSettings;
        private IC.Client.View.Components.ICLabel lblScanBarcodePlease;
    }
}