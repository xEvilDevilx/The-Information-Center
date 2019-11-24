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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.icLabel1 = new IC.Client.View.Components.ICLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.imgUnAvailabel;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(229, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 319);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.IC_Terminal;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // icLabel1
            // 
            this.icLabel1.Font = new System.Drawing.Font("Cambria Math", 54F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.icLabel1.ForeColor = System.Drawing.Color.White;
            this.icLabel1.Location = new System.Drawing.Point(81, 343);
            this.icLabel1.Name = "icLabel1";
            this.icLabel1.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.icLabel1.OutlineForeColor = System.Drawing.Color.Green;
            this.icLabel1.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.icLabel1.OutlineWidth = 4F;
            this.icLabel1.Size = new System.Drawing.Size(631, 137);
            this.icLabel1.TabIndex = 1;
            this.icLabel1.Text = "Information Center is unavailable!";
            // 
            // UnAvailableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::IC.Client.Plugins.StandartViewPlugin.Properties.Resources.imgCleanBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.icLabel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "UnAvailableControl";
            this.Size = new System.Drawing.Size(800, 480);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private View.Components.ICLabel icLabel1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
