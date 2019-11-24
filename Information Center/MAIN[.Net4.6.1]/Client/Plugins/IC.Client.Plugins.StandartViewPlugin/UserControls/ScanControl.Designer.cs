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
            this.lblScanBarcodePlease = new IC.Client.View.Components.ICLabel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonShares = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScanBarcodePlease
            // 
            this.lblScanBarcodePlease.Font = new System.Drawing.Font("Cambria Math", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScanBarcodePlease.ForeColor = System.Drawing.Color.White;
            this.lblScanBarcodePlease.Location = new System.Drawing.Point(48, 104);
            this.lblScanBarcodePlease.Name = "lblScanBarcodePlease";
            this.lblScanBarcodePlease.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.lblScanBarcodePlease.OutlineForeColor = System.Drawing.Color.Green;
            this.lblScanBarcodePlease.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.lblScanBarcodePlease.OutlineWidth = 4F;
            this.lblScanBarcodePlease.Size = new System.Drawing.Size(718, 239);
            this.lblScanBarcodePlease.TabIndex = 0;
            this.lblScanBarcodePlease.Text = "lblScanBarcodePlease";
            this.lblScanBarcodePlease.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSettings.BackgroundImage")));
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Cambria Math", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(20)));
            this.buttonSettings.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSettings.Location = new System.Drawing.Point(586, 389);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(180, 68);
            this.buttonSettings.TabIndex = 5;
            this.buttonSettings.Text = "btnSettings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonShares
            // 
            this.buttonShares.BackColor = System.Drawing.Color.Transparent;
            this.buttonShares.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonShares.BackgroundImage")));
            this.buttonShares.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShares.FlatAppearance.BorderSize = 0;
            this.buttonShares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShares.Font = new System.Drawing.Font("Cambria Math", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(20)));
            this.buttonShares.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonShares.Location = new System.Drawing.Point(400, 389);
            this.buttonShares.Name = "buttonShares";
            this.buttonShares.Size = new System.Drawing.Size(180, 68);
            this.buttonShares.TabIndex = 4;
            this.buttonShares.Text = "btnShares";
            this.buttonShares.UseVisualStyleBackColor = false;
            this.buttonShares.Click += new System.EventHandler(this.buttonShares_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 6;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // ScanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.imgCleanBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonShares);
            this.Controls.Add(this.lblScanBarcodePlease);
            this.DoubleBuffered = true;
            this.Name = "ScanControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.Click += new System.EventHandler(this.ClickOnControl);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private View.Components.ICLabel lblScanBarcodePlease;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonShares;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}
