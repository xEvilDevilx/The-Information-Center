namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class ProductInfoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInfoControl));
            this.pictureBoxLogo = new IC.Client.View.Components.ICPicture();
            this.imgProducImage = new IC.Client.View.Components.ICPicture();
            this.buttonSettings = new IC.Client.View.Components.ICButton();
            this.buttonShares = new IC.Client.View.Components.ICButton();
            this.buttonDown = new IC.Client.View.Components.ICButton();
            this.buttonUp = new IC.Client.View.Components.ICButton();
            this.lblProductName = new IC.Client.View.Components.ICLabel();
            this.txtProductInfo = new IC.Client.View.Components.ICLabel();
            this.lblPrice = new IC.Client.View.Components.ICLabel();
            this.txtPriceValue = new IC.Client.View.Components.ICLabel();
            this.lblArticle = new IC.Client.View.Components.ICLabel();
            this.txtArticleValue = new IC.Client.View.Components.ICLabel();
            this.lblBarcode = new IC.Client.View.Components.ICLabel();
            this.txtBarcodeValue = new IC.Client.View.Components.ICLabel();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.TabIndex = 14;
            this.pictureBoxLogo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // imgProducImage
            // 
            this.imgProducImage.Location = new System.Drawing.Point(47, 108);
            this.imgProducImage.Name = "imgProducImage";
            this.imgProducImage.Size = new System.Drawing.Size(291, 272);
            this.imgProducImage.TabIndex = 22;
            this.imgProducImage.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonSettings.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(586, 389);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(180, 68);
            this.buttonSettings.TabIndex = 13;
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
            this.buttonShares.TabIndex = 12;
            this.buttonShares.Text = "btnShares";
            this.buttonShares.Click += new System.EventHandler(this.buttonShares_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonDown.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonDown.Image")));
            this.buttonDown.Location = new System.Drawing.Point(214, 389);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(180, 68);
            this.buttonDown.TabIndex = 11;
            this.buttonDown.Text = "btnDown";
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.buttonUp.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(28, 389);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(180, 68);
            this.buttonUp.TabIndex = 5;
            this.buttonUp.Text = "btnUp";
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // lblProductName
            // 
            this.lblProductName.CountOfLinesForFit = 2;
            this.lblProductName.Font = new System.Drawing.Font("Cambria", 50F, System.Drawing.FontStyle.Italic);
            this.lblProductName.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblProductName.IsFitTextFontSize = true;
            this.lblProductName.Location = new System.Drawing.Point(47, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(521, 101);
            this.lblProductName.TabIndex = 23;
            this.lblProductName.Text = "lblProductName";
            this.lblProductName.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtProductInfo
            // 
            this.txtProductInfo.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Italic);
            this.txtProductInfo.ForeColor = System.Drawing.Color.Green;
            this.txtProductInfo.Location = new System.Drawing.Point(344, 108);
            this.txtProductInfo.Name = "txtProductInfo";
            this.txtProductInfo.Size = new System.Drawing.Size(253, 274);
            this.txtProductInfo.TabIndex = 24;
            this.txtProductInfo.Text = "txtProductInfo";
            this.txtProductInfo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.Green;
            this.lblPrice.Location = new System.Drawing.Point(622, 110);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(144, 23);
            this.lblPrice.TabIndex = 31;
            this.lblPrice.Text = "lblPrice";
            this.lblPrice.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtPriceValue
            // 
            this.txtPriceValue.Font = new System.Drawing.Font("Bodoni MT Condensed", 16F, System.Drawing.FontStyle.Bold);
            this.txtPriceValue.ForeColor = System.Drawing.Color.White;
            this.txtPriceValue.Location = new System.Drawing.Point(621, 133);
            this.txtPriceValue.Name = "txtPriceValue";
            this.txtPriceValue.Size = new System.Drawing.Size(145, 44);
            this.txtPriceValue.TabIndex = 37;
            this.txtPriceValue.Text = "txtPriceValue";
            this.txtPriceValue.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblArticle
            // 
            this.lblArticle.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.lblArticle.ForeColor = System.Drawing.Color.Green;
            this.lblArticle.Location = new System.Drawing.Point(622, 187);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(144, 23);
            this.lblArticle.TabIndex = 43;
            this.lblArticle.Text = "lblArticle";
            this.lblArticle.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtArticleValue
            // 
            this.txtArticleValue.Font = new System.Drawing.Font("Bodoni MT Condensed", 16F, System.Drawing.FontStyle.Bold);
            this.txtArticleValue.ForeColor = System.Drawing.Color.White;
            this.txtArticleValue.Location = new System.Drawing.Point(621, 210);
            this.txtArticleValue.Name = "txtArticleValue";
            this.txtArticleValue.Size = new System.Drawing.Size(145, 44);
            this.txtArticleValue.TabIndex = 47;
            this.txtArticleValue.Text = "txtArticleValue";
            this.txtArticleValue.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.ForeColor = System.Drawing.Color.Green;
            this.lblBarcode.Location = new System.Drawing.Point(622, 267);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(144, 23);
            this.lblBarcode.TabIndex = 51;
            this.lblBarcode.Text = "lblBarcode";
            this.lblBarcode.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtBarcodeValue
            // 
            this.txtBarcodeValue.Font = new System.Drawing.Font("Bodoni MT Condensed", 16F, System.Drawing.FontStyle.Bold);
            this.txtBarcodeValue.ForeColor = System.Drawing.Color.White;
            this.txtBarcodeValue.Location = new System.Drawing.Point(621, 290);
            this.txtBarcodeValue.Name = "txtBarcodeValue";
            this.txtBarcodeValue.Size = new System.Drawing.Size(145, 44);
            this.txtBarcodeValue.TabIndex = 53;
            this.txtBarcodeValue.Text = "txtBarcodeValue";
            this.txtBarcodeValue.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // ProductInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.imgProducImage);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonShares);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProductInfo);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPriceValue);
            this.Controls.Add(this.lblArticle);
            this.Controls.Add(this.txtArticleValue);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcodeValue);
            this.Name = "ProductInfoControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.Click += new System.EventHandler(this.ClickOnControl);
            this.ResumeLayout(false);

        }

        #endregion

        private IC.Client.View.Components.ICPicture imgProducImage;
        private IC.Client.View.Components.ICPicture pictureBoxLogo;
        private IC.Client.View.Components.ICButton buttonUp;
        private IC.Client.View.Components.ICButton buttonDown;
        private IC.Client.View.Components.ICButton buttonShares;
        private IC.Client.View.Components.ICButton buttonSettings;
        private IC.Client.View.Components.ICLabel lblProductName;
        private IC.Client.View.Components.ICLabel txtProductInfo;
        private IC.Client.View.Components.ICLabel lblPrice;
        private IC.Client.View.Components.ICLabel txtPriceValue;
        private IC.Client.View.Components.ICLabel lblArticle;
        private IC.Client.View.Components.ICLabel txtArticleValue;
        private IC.Client.View.Components.ICLabel lblBarcode;
        private IC.Client.View.Components.ICLabel txtBarcodeValue;
    }
}