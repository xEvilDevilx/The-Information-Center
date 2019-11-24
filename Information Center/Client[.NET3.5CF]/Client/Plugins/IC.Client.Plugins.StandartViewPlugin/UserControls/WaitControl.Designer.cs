namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    partial class WaitControl
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
            this.lblWaitPlease = new IC.Client.View.Components.ICLabel();
            this.SuspendLayout();
            // 
            // lblWaitPlease
            // 
            this.lblWaitPlease.Font = new System.Drawing.Font("Cambria", 60F, System.Drawing.FontStyle.Bold);
            this.lblWaitPlease.ForeColor = System.Drawing.Color.White;
            this.lblWaitPlease.Location = new System.Drawing.Point(118, 106);
            this.lblWaitPlease.Name = "lblWaitPlease";
            this.lblWaitPlease.Size = new System.Drawing.Size(551, 273);
            this.lblWaitPlease.TabIndex = 1;
            // 
            // WaitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblWaitPlease);
            this.Name = "WaitControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.ResumeLayout(false);

        }

        #endregion

        private IC.Client.View.Components.ICLabel lblWaitPlease;
    }
}
