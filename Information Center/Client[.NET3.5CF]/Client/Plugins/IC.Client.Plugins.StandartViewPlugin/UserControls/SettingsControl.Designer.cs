using System.ComponentModel;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class SettingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsControl));
            this.languageItem3 = new IC.Client.View.Components.ICAdvancedItem();
            this.languageItem2 = new IC.Client.View.Components.ICAdvancedItem();
            this.languageItem1 = new IC.Client.View.Components.ICAdvancedItem();
            this.currencyItem3 = new IC.Client.View.Components.ICAdvancedItem();
            this.currencyItem2 = new IC.Client.View.Components.ICAdvancedItem();
            this.currencyItem1 = new IC.Client.View.Components.ICAdvancedItem();
            this.buttonChoose = new IC.Client.View.Components.ICButton();
            this.buttonLanguage = new IC.Client.View.Components.ICButton();
            this.buttonCurrency = new IC.Client.View.Components.ICButton();
            this.buttonCancel = new IC.Client.View.Components.ICButton();
            this.pictureBoxLogo = new IC.Client.View.Components.ICPicture();
            this.lblSettings = new IC.Client.View.Components.ICLabel();
            this.imgCurrencyDots = new IC.Client.View.Components.ICPicture();
            this.imgLanguageDots = new IC.Client.View.Components.ICPicture();
            this.SuspendLayout();
            // 
            // languageItem3
            // 
            this.languageItem3.Location = new System.Drawing.Point(400, 279);
            this.languageItem3.MaxTextLength = 11;
            this.languageItem3.Name = "languageItem3";
            this.languageItem3.Size = new System.Drawing.Size(370, 80);
            this.languageItem3.TabIndex = 20;
            // 
            // languageItem2
            // 
            this.languageItem2.Location = new System.Drawing.Point(400, 193);
            this.languageItem2.MaxTextLength = 11;
            this.languageItem2.Name = "languageItem2";
            this.languageItem2.Size = new System.Drawing.Size(370, 80);
            this.languageItem2.TabIndex = 19;
            // 
            // languageItem1
            // 
            this.languageItem1.Location = new System.Drawing.Point(400, 107);
            this.languageItem1.MaxTextLength = 11;
            this.languageItem1.Name = "languageItem1";
            this.languageItem1.Size = new System.Drawing.Size(370, 80);
            this.languageItem1.TabIndex = 18;
            // 
            // currencyItem3
            // 
            this.currencyItem3.Location = new System.Drawing.Point(24, 279);
            this.currencyItem3.MaxTextLength = 11;
            this.currencyItem3.Name = "currencyItem3";
            this.currencyItem3.Size = new System.Drawing.Size(370, 80);
            this.currencyItem3.TabIndex = 17;
            // 
            // currencyItem2
            // 
            this.currencyItem2.Location = new System.Drawing.Point(24, 193);
            this.currencyItem2.MaxTextLength = 11;
            this.currencyItem2.Name = "currencyItem2";
            this.currencyItem2.Size = new System.Drawing.Size(370, 80);
            this.currencyItem2.TabIndex = 16;
            // 
            // currencyItem1
            // 
            this.currencyItem1.Location = new System.Drawing.Point(24, 107);
            this.currencyItem1.MaxTextLength = 11;
            this.currencyItem1.Name = "currencyItem1";
            this.currencyItem1.Size = new System.Drawing.Size(370, 80);
            this.currencyItem1.TabIndex = 15;
            // 
            // buttonChoose
            // 
            this.buttonChoose.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonChoose.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonChoose.Image")));
            this.buttonChoose.Location = new System.Drawing.Point(586, 389);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(180, 68);
            this.buttonChoose.TabIndex = 12;
            this.buttonChoose.Text = "btnChoose";
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
            // 
            // buttonLanguage
            // 
            this.buttonLanguage.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonLanguage.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonLanguage.Image")));
            this.buttonLanguage.Location = new System.Drawing.Point(400, 389);
            this.buttonLanguage.Name = "buttonLanguage";
            this.buttonLanguage.Size = new System.Drawing.Size(180, 68);
            this.buttonLanguage.TabIndex = 11;
            this.buttonLanguage.Text = "btnLanguage";
            this.buttonLanguage.Click += new System.EventHandler(this.buttonLanguage_Click);
            // 
            // buttonCurrency
            // 
            this.buttonCurrency.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonCurrency.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonCurrency.Image")));
            this.buttonCurrency.Location = new System.Drawing.Point(214, 389);
            this.buttonCurrency.Name = "buttonCurrency";
            this.buttonCurrency.Size = new System.Drawing.Size(180, 68);
            this.buttonCurrency.TabIndex = 10;
            this.buttonCurrency.Text = "btnCurrency";
            this.buttonCurrency.Click += new System.EventHandler(this.buttonCurrency_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(28, 389);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(180, 68);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "btnCancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.TabIndex = 13;
            this.pictureBoxLogo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblSettings
            // 
            this.lblSettings.Font = new System.Drawing.Font("Cambria", 50F, System.Drawing.FontStyle.Regular);
            this.lblSettings.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblSettings.Location = new System.Drawing.Point(25, 13);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(542, 88);
            this.lblSettings.TabIndex = 14;
            this.lblSettings.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // imgCurrencyDots
            // 
            this.imgCurrencyDots.Image = ((System.Drawing.Bitmap)(resources.GetObject("imgCurrencyDots.Image")));
            this.imgCurrencyDots.Location = new System.Drawing.Point(167, 358);
            this.imgCurrencyDots.Name = "imgCurrencyDots";
            this.imgCurrencyDots.Size = new System.Drawing.Size(88, 28);
            this.imgCurrencyDots.TabIndex = 23;
            // 
            // imgLanguageDots
            // 
            this.imgLanguageDots.Image = ((System.Drawing.Bitmap)(resources.GetObject("imgLanguageDots.Image")));
            this.imgLanguageDots.Location = new System.Drawing.Point(538, 358);
            this.imgLanguageDots.Name = "imgLanguageDots";
            this.imgLanguageDots.Size = new System.Drawing.Size(88, 28);
            this.imgLanguageDots.TabIndex = 24;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.imgLanguageDots);
            this.Controls.Add(this.imgCurrencyDots);
            this.Controls.Add(this.languageItem3);
            this.Controls.Add(this.languageItem2);
            this.Controls.Add(this.languageItem1);
            this.Controls.Add(this.currencyItem3);
            this.Controls.Add(this.currencyItem2);
            this.Controls.Add(this.currencyItem1);
            this.Controls.Add(this.buttonChoose);
            this.Controls.Add(this.buttonLanguage);
            this.Controls.Add(this.buttonCurrency);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.lblSettings);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.Click += new System.EventHandler(this.ClickOnControl);
            this.ResumeLayout(false);

        }

        #endregion

        private IC.Client.View.Components.ICPicture pictureBoxLogo;
        private IC.Client.View.Components.ICButton buttonCancel;
        private IC.Client.View.Components.ICButton buttonCurrency;
        private IC.Client.View.Components.ICButton buttonLanguage;
        private IC.Client.View.Components.ICButton buttonChoose;
        private IC.Client.View.Components.ICLabel lblSettings;
        private IC.Client.View.Components.ICAdvancedItem currencyItem1;
        private IC.Client.View.Components.ICAdvancedItem currencyItem2;
        private IC.Client.View.Components.ICAdvancedItem currencyItem3;
        private IC.Client.View.Components.ICAdvancedItem languageItem1;
        private IC.Client.View.Components.ICAdvancedItem languageItem2;
        private IC.Client.View.Components.ICAdvancedItem languageItem3;
        private IC.Client.View.Components.ICPicture imgCurrencyDots;
        private IC.Client.View.Components.ICPicture imgLanguageDots;
    }
}
