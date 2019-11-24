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
            this.lblWaitPlease.Font = new System.Drawing.Font("Cambria Math", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWaitPlease.ForeColor = System.Drawing.Color.White;
            this.lblWaitPlease.Location = new System.Drawing.Point(118, 106);
            this.lblWaitPlease.Name = "lblWaitPlease";
            this.lblWaitPlease.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.lblWaitPlease.OutlineForeColor = System.Drawing.Color.Green;
            this.lblWaitPlease.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.lblWaitPlease.OutlineWidth = 4F;
            this.lblWaitPlease.Size = new System.Drawing.Size(551, 273);
            this.lblWaitPlease.TabIndex = 0;
            this.lblWaitPlease.Text = "lblWaitPlease";
            // 
            // WaitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.imgProductNotFoundBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblWaitPlease);
            this.DoubleBuffered = true;
            this.Name = "WaitControl";
            this.Size = new System.Drawing.Size(800, 480);
            this.ResumeLayout(false);

        }

        #endregion

        private View.Components.ICLabel lblWaitPlease;
    }
}
