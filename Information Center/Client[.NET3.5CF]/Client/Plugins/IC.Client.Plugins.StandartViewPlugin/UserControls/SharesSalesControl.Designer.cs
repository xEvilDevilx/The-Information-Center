namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class SharesSalesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharesSalesControl));
            this.pictureBoxLogo = new IC.Client.View.Components.ICPicture();
            this.buttonUp = new IC.Client.View.Components.ICButton();
            this.buttonDown = new IC.Client.View.Components.ICButton();
            this.buttonBack = new IC.Client.View.Components.ICButton();
            this.buttonSettings = new IC.Client.View.Components.ICButton();
            this.btnPrevious = new IC.Client.View.Components.ICButton();
            this.btnNext = new IC.Client.View.Components.ICButton();
            this.lblSharesSales = new IC.Client.View.Components.ICLabel();
            this.lblSharesSalesCapture = new IC.Client.View.Components.ICLabel();
            this.txtSharesSalesDescriptions = new IC.Client.View.Components.ICLabel();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.TabIndex = 37;
            this.pictureBoxLogo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonUp.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(28, 389);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(180, 68);
            this.buttonUp.TabIndex = 29;
            this.buttonUp.Text = "btnUp";
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonDown.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonDown.Image")));
            this.buttonDown.Location = new System.Drawing.Point(214, 389);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(180, 68);
            this.buttonDown.TabIndex = 31;
            this.buttonDown.Text = "btnDown";
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonBack.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.Location = new System.Drawing.Point(400, 389);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(180, 68);
            this.buttonBack.TabIndex = 32;
            this.buttonBack.Text = "btnBack";
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonSettings.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(586, 389);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(180, 68);
            this.buttonSettings.TabIndex = 33;
            this.buttonSettings.Text = "btnSettings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(10, 204);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(97, 72);
            this.btnPrevious.TabIndex = 34;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.btnNext.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(682, 204);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(97, 72);
            this.btnNext.TabIndex = 36;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblSharesSales
            // 
            this.lblSharesSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 44F, System.Drawing.FontStyle.Regular);
            this.lblSharesSales.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblSharesSales.Location = new System.Drawing.Point(3, 0);
            this.lblSharesSales.Name = "lblSharesSales";
            this.lblSharesSales.Size = new System.Drawing.Size(577, 101);
            this.lblSharesSales.TabIndex = 38;
            this.lblSharesSales.Text = "lblSharesSales";
            this.lblSharesSales.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblSharesSalesCapture
            // 
            this.lblSharesSalesCapture.CountOfLinesForFit = 2;
            this.lblSharesSalesCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblSharesSalesCapture.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblSharesSalesCapture.IsFitTextFontSize = true;
            this.lblSharesSalesCapture.Location = new System.Drawing.Point(120, 105);
            this.lblSharesSalesCapture.Name = "lblSharesSalesCapture";
            this.lblSharesSalesCapture.Size = new System.Drawing.Size(549, 60);
            this.lblSharesSalesCapture.TabIndex = 39;
            this.lblSharesSalesCapture.Text = "lblSharesSalesCapture";
            this.lblSharesSalesCapture.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtSharesSalesDescriptions
            // 
            this.txtSharesSalesDescriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular);
            this.txtSharesSalesDescriptions.ForeColor = System.Drawing.Color.Green;
            this.txtSharesSalesDescriptions.Location = new System.Drawing.Point(120, 167);
            this.txtSharesSalesDescriptions.Name = "txtSharesSalesDescriptions";
            this.txtSharesSalesDescriptions.Size = new System.Drawing.Size(549, 212);
            this.txtSharesSalesDescriptions.TabIndex = 40;
            this.txtSharesSalesDescriptions.Text = "txtSharesSalesDescriptions";
            this.txtSharesSalesDescriptions.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // SharesSalesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.lblSharesSales);
            this.Controls.Add(this.lblSharesSalesCapture);
            this.Controls.Add(this.txtSharesSalesDescriptions);
            this.Name = "SharesSalesControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.Click += new System.EventHandler(this.ClickOnControl);
            this.ResumeLayout(false);

        }

        #endregion

        private IC.Client.View.Components.ICPicture pictureBoxLogo;
        private IC.Client.View.Components.ICButton buttonUp;
        private IC.Client.View.Components.ICButton buttonDown;
        private IC.Client.View.Components.ICButton buttonBack;
        private IC.Client.View.Components.ICButton buttonSettings;
        private IC.Client.View.Components.ICButton btnPrevious;
        private IC.Client.View.Components.ICButton btnNext;
        private IC.Client.View.Components.ICLabel lblSharesSales;
        private IC.Client.View.Components.ICLabel lblSharesSalesCapture;
        private IC.Client.View.Components.ICLabel txtSharesSalesDescriptions;
    }
}