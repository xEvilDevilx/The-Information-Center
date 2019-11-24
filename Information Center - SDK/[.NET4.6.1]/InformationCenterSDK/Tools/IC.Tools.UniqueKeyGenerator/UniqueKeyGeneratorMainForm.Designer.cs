namespace IC.Tools.UniqueKeyGenerator
{
    partial class UniqueKeyGeneratorMainForm
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
            this.lblClientName = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtUniqueClientKeyField = new System.Windows.Forms.TextBox();
            this.btnClearKeyField = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(65, 61);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(67, 13);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "Client Name:";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(20, 77);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(163, 20);
            this.txtClientName.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(48, 129);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 44);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtUniqueClientKeyField
            // 
            this.txtUniqueClientKeyField.Location = new System.Drawing.Point(219, 12);
            this.txtUniqueClientKeyField.Multiline = true;
            this.txtUniqueClientKeyField.Name = "txtUniqueClientKeyField";
            this.txtUniqueClientKeyField.ReadOnly = true;
            this.txtUniqueClientKeyField.Size = new System.Drawing.Size(424, 237);
            this.txtUniqueClientKeyField.TabIndex = 5;
            // 
            // btnClearKeyField
            // 
            this.btnClearKeyField.Location = new System.Drawing.Point(120, 226);
            this.btnClearKeyField.Name = "btnClearKeyField";
            this.btnClearKeyField.Size = new System.Drawing.Size(93, 23);
            this.btnClearKeyField.TabIndex = 6;
            this.btnClearKeyField.Text = "Clear Key Field";
            this.btnClearKeyField.UseVisualStyleBackColor = true;
            this.btnClearKeyField.Click += new System.EventHandler(this.btnClearKeyField_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 261);
            this.Controls.Add(this.btnClearKeyField);
            this.Controls.Add(this.txtUniqueClientKeyField);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lblClientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Unique Client Key Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtUniqueClientKeyField;
        private System.Windows.Forms.Button btnClearKeyField;
    }
}

