namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class UnAvailableControl
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
            this.icPictureWarning = new IC.Client.View.Components.ICPicture();
            this.lblICUnavailable = new IC.Client.View.Components.ICLabel();
            this.SuspendLayout();
            // 
            // icPictureWarning
            // 
            this.icPictureWarning.Location = new System.Drawing.Point(248, 3);
            this.icPictureWarning.Name = "icPictureWarning";
            this.icPictureWarning.Size = new System.Drawing.Size(301, 300);
            this.icPictureWarning.TabIndex = 2;
            // 
            // lblICUnavailable
            // 
            this.lblICUnavailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular); //Microsoft Sans Serif    Arial Unicode MS
            this.lblICUnavailable.ForeColor = System.Drawing.Color.White;
            this.lblICUnavailable.Location = new System.Drawing.Point(81, 309);
            this.lblICUnavailable.Name = "lblICUnavailable";
            this.lblICUnavailable.Size = new System.Drawing.Size(631, 160);
            this.lblICUnavailable.TabIndex = 3;
            // 
            // UnAvailableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblICUnavailable);
            this.Controls.Add(this.icPictureWarning);
            this.Name = "UnAvailableControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.ResumeLayout(false);

        }

        #endregion

        private IC.Client.View.Components.ICPicture icPictureWarning;
        private IC.Client.View.Components.ICLabel lblICUnavailable;
    }
}