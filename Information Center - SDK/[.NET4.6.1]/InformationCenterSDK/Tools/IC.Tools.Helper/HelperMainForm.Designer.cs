namespace IC.Tools.Helper
{
    partial class HelperMainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetMACAddress = new System.Windows.Forms.Button();
            this.txtMACAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetMACAddress
            // 
            this.btnGetMACAddress.Location = new System.Drawing.Point(79, 60);
            this.btnGetMACAddress.Name = "btnGetMACAddress";
            this.btnGetMACAddress.Size = new System.Drawing.Size(119, 23);
            this.btnGetMACAddress.TabIndex = 0;
            this.btnGetMACAddress.Text = "Get MAC Address";
            this.btnGetMACAddress.UseVisualStyleBackColor = true;
            this.btnGetMACAddress.Click += new System.EventHandler(this.btnGetMACAddress_Click);
            // 
            // txtMACAddress
            // 
            this.txtMACAddress.Location = new System.Drawing.Point(35, 24);
            this.txtMACAddress.Name = "txtMACAddress";
            this.txtMACAddress.ReadOnly = true;
            this.txtMACAddress.Size = new System.Drawing.Size(210, 20);
            this.txtMACAddress.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 95);
            this.Controls.Add(this.txtMACAddress);
            this.Controls.Add(this.btnGetMACAddress);
            this.Name = "MainForm";
            this.Text = "Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetMACAddress;
        private System.Windows.Forms.TextBox txtMACAddress;
    }
}

