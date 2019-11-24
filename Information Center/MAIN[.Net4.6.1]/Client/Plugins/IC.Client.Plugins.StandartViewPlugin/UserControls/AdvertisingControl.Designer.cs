namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class AdvertisingControl
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
            this.advertisingPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.advertisingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // advertisingPictureBox
            // 
            this.advertisingPictureBox.Location = new System.Drawing.Point(0, 0);
            this.advertisingPictureBox.Name = "advertisingPictureBox";
            this.advertisingPictureBox.Size = new System.Drawing.Size(800, 480);
            this.advertisingPictureBox.TabIndex = 0;
            this.advertisingPictureBox.TabStop = false;
            this.advertisingPictureBox.Click += new System.EventHandler(this.ClickOnControl);
            // 
            // AdvertisingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advertisingPictureBox);
            this.Name = "AdvertisingControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.Click += new System.EventHandler(this.ClickOnControl);
            ((System.ComponentModel.ISupportInitialize)(this.advertisingPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox advertisingPictureBox;
    }
}
