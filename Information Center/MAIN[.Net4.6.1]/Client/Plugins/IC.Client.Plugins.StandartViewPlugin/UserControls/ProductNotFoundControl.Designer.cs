namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class ProductNotFoundControl
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
            this.txtProductNotFound = new IC.Client.View.Components.ICLabel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductNotFound
            // 
            this.txtProductNotFound.BackColor = System.Drawing.Color.Transparent;
            this.txtProductNotFound.Font = new System.Drawing.Font("Cambria Math", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtProductNotFound.ForeColor = System.Drawing.Color.White;
            this.txtProductNotFound.Location = new System.Drawing.Point(119, 104);
            this.txtProductNotFound.Name = "txtProductNotFound";
            this.txtProductNotFound.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.txtProductNotFound.OutlineForeColor = System.Drawing.Color.Green;
            this.txtProductNotFound.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.txtProductNotFound.OutlineWidth = 3F;
            this.txtProductNotFound.Size = new System.Drawing.Size(549, 275);
            this.txtProductNotFound.TabIndex = 1;
            this.txtProductNotFound.Text = "txtProductNotFound";
            this.txtProductNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            // 
            // ProductNotFoundControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.imgProductNotFoundBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.txtProductNotFound);
            this.DoubleBuffered = true;
            this.Name = "ProductNotFoundControl";
            this.Size = new System.Drawing.Size(800, 480);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private View.Components.ICLabel txtProductNotFound;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}
