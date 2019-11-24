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
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonShares = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.imgProducImage = new System.Windows.Forms.PictureBox();
            this.lblArticle = new IC.Client.View.Components.ICLabel();
            this.lblPrice = new IC.Client.View.Components.ICLabel();
            this.lblProductName = new IC.Client.View.Components.ICLabel();
            this.lblBarcode = new IC.Client.View.Components.ICLabel();
            this.txtPriceValue = new System.Windows.Forms.Label();
            this.txtArticleValue = new System.Windows.Forms.Label();
            this.txtBarcodeValue = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.txtProductInfo = new IC.Client.View.Components.ICTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgProducImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.Transparent;
            this.buttonUp.BackgroundImage = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.imgButton02;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUp.FlatAppearance.BorderSize = 0;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.Font = new System.Drawing.Font("Cambria Math", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(20)));
            this.buttonUp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonUp.Location = new System.Drawing.Point(28, 389);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(180, 68);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.Text = "btnUp";
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.Transparent;
            this.buttonDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDown.BackgroundImage")));
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDown.FlatAppearance.BorderSize = 0;
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDown.Font = new System.Drawing.Font("Cambria Math", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(20)));
            this.buttonDown.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDown.Location = new System.Drawing.Point(214, 389);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(180, 68);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.Text = "btnDown";
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
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
            this.buttonShares.TabIndex = 2;
            this.buttonShares.Text = "btnShares";
            this.buttonShares.UseVisualStyleBackColor = false;
            this.buttonShares.Click += new System.EventHandler(this.buttonShares_Click);
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
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "btnSettings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // imgProducImage
            // 
            this.imgProducImage.BackColor = System.Drawing.Color.Transparent;
            this.imgProducImage.Location = new System.Drawing.Point(47, 110);
            this.imgProducImage.Name = "imgProducImage";
            this.imgProducImage.Size = new System.Drawing.Size(388, 273);
            this.imgProducImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgProducImage.TabIndex = 6;
            this.imgProducImage.TabStop = false;
            this.imgProducImage.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblArticle
            // 
            this.lblArticle.Font = new System.Drawing.Font("Cambria Math", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArticle.ForeColor = System.Drawing.Color.Green;
            this.lblArticle.Location = new System.Drawing.Point(622, 187);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.lblArticle.OutlineForeColor = System.Drawing.Color.White;
            this.lblArticle.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.lblArticle.OutlineWidth = 2F;
            this.lblArticle.Size = new System.Drawing.Size(144, 23);
            this.lblArticle.TabIndex = 11;
            this.lblArticle.Text = "lblArticle";
            this.lblArticle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblArticle.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Cambria Math", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.ForeColor = System.Drawing.Color.Green;
            this.lblPrice.Location = new System.Drawing.Point(622, 110);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.lblPrice.OutlineForeColor = System.Drawing.Color.White;
            this.lblPrice.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.lblPrice.OutlineWidth = 2F;
            this.lblPrice.Size = new System.Drawing.Size(144, 23);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "lblPrice";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPrice.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Cambria", 39.75F);
            this.lblProductName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProductName.Location = new System.Drawing.Point(28, 12);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.lblProductName.OutlineForeColor = System.Drawing.Color.Green;
            this.lblProductName.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.lblProductName.OutlineWidth = 4F;
            this.lblProductName.Size = new System.Drawing.Size(560, 90);
            this.lblProductName.TabIndex = 8;
            this.lblProductName.Text = "lblProductName";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProductName.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Cambria Math", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBarcode.ForeColor = System.Drawing.Color.Green;
            this.lblBarcode.Location = new System.Drawing.Point(622, 267);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.lblBarcode.OutlineForeColor = System.Drawing.Color.White;
            this.lblBarcode.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.lblBarcode.OutlineWidth = 2F;
            this.lblBarcode.Size = new System.Drawing.Size(144, 23);
            this.lblBarcode.TabIndex = 12;
            this.lblBarcode.Text = "lblBarcode";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBarcode.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtPriceValue
            // 
            this.txtPriceValue.Font = new System.Drawing.Font("Bodoni MT Condensed", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceValue.ForeColor = System.Drawing.Color.White;
            this.txtPriceValue.Location = new System.Drawing.Point(598, 133);
            this.txtPriceValue.Name = "txtPriceValue";
            this.txtPriceValue.Size = new System.Drawing.Size(199, 44);
            this.txtPriceValue.TabIndex = 13;
            this.txtPriceValue.Text = "13555955.480 EURO";
            this.txtPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtPriceValue.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtArticleValue
            // 
            this.txtArticleValue.Font = new System.Drawing.Font("Bodoni MT Condensed", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArticleValue.ForeColor = System.Drawing.Color.White;
            this.txtArticleValue.Location = new System.Drawing.Point(598, 210);
            this.txtArticleValue.Name = "txtArticleValue";
            this.txtArticleValue.Size = new System.Drawing.Size(199, 44);
            this.txtArticleValue.TabIndex = 14;
            this.txtArticleValue.Text = "999999999";
            this.txtArticleValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtArticleValue.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtBarcodeValue
            // 
            this.txtBarcodeValue.Font = new System.Drawing.Font("Bodoni MT Condensed", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeValue.ForeColor = System.Drawing.Color.White;
            this.txtBarcodeValue.Location = new System.Drawing.Point(598, 290);
            this.txtBarcodeValue.Name = "txtBarcodeValue";
            this.txtBarcodeValue.Size = new System.Drawing.Size(199, 44);
            this.txtBarcodeValue.TabIndex = 15;
            this.txtBarcodeValue.Text = "5000299601525";
            this.txtBarcodeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtBarcodeValue.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 16;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // txtProductInfo
            // 
            this.txtProductInfo.BackAlpha = 0;
            this.txtProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.txtProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductInfo.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.txtProductInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(245)))));
            this.txtProductInfo.Location = new System.Drawing.Point(434, 110);
            this.txtProductInfo.Multiline = true;
            this.txtProductInfo.Name = "txtProductInfo";
            this.txtProductInfo.ReadOnly = true;
            this.txtProductInfo.Size = new System.Drawing.Size(163, 273);
            this.txtProductInfo.TabIndex = 17;
            this.txtProductInfo.Text = "txtProductInfo";
            this.txtProductInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProductInfo.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // ProductInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.imgBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtProductInfo);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.txtBarcodeValue);
            this.Controls.Add(this.txtArticleValue);
            this.Controls.Add(this.txtPriceValue);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblArticle);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.imgProducImage);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonShares);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.DoubleBuffered = true;
            this.Name = "ProductInfoControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.Click += new System.EventHandler(this.ClickOnControl);
            ((System.ComponentModel.ISupportInitialize)(this.imgProducImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonShares;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.PictureBox imgProducImage;
        private View.Components.ICLabel lblProductName;
        private View.Components.ICLabel lblPrice;
        private View.Components.ICLabel lblArticle;
        private View.Components.ICLabel lblBarcode;
        private System.Windows.Forms.Label txtPriceValue;
        private System.Windows.Forms.Label txtArticleValue;
        private System.Windows.Forms.Label txtBarcodeValue;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private View.Components.ICTextBox txtProductInfo;
    }
}