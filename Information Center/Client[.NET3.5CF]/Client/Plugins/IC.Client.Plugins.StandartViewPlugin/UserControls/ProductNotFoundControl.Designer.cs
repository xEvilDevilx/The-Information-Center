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
            this.pictureBoxLogo = new IC.Client.View.Components.ICPicture();
            this.txtProductNotFound = new IC.Client.View.Components.ICLabel();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(586, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(214, 101);
            this.pictureBoxLogo.TabIndex = 1;
            // 
            // txtProductNotFound
            // 
            this.txtProductNotFound.Font = new System.Drawing.Font("Cambria", 48F, System.Drawing.FontStyle.Bold);
            this.txtProductNotFound.ForeColor = System.Drawing.Color.White;
            this.txtProductNotFound.Location = new System.Drawing.Point(119, 104);
            this.txtProductNotFound.Name = "txtProductNotFound";
            this.txtProductNotFound.Size = new System.Drawing.Size(549, 275);
            this.txtProductNotFound.TabIndex = 2;
            this.txtProductNotFound.Text = "";
            // 
            // ProductNotFoundControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.txtProductNotFound);
            this.Name = "ProductNotFoundControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.ResumeLayout(false);

        }

        #endregion

        private IC.Client.View.Components.ICPicture pictureBoxLogo;
        private IC.Client.View.Components.ICLabel txtProductNotFound;
    }
}