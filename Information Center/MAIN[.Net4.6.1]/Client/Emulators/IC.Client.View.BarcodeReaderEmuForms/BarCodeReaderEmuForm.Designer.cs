namespace IC.Client.View.BarcodeReaderEmuForms
{
    partial class BarCodeReaderEmuForm
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
            this.imgBarCode = new System.Windows.Forms.PictureBox();
            this.lblEnterBarCode = new System.Windows.Forms.Label();
            this.BarCodeTextBox = new System.Windows.Forms.TextBox();
            this.btnReadBarCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBarCode
            // 
            this.imgBarCode.BackColor = System.Drawing.Color.Transparent;
            this.imgBarCode.Image = global::IC.Client.View.BarcodeReaderEmuForms.Properties.Resources.imgBarCode;
            this.imgBarCode.Location = new System.Drawing.Point(12, 12);
            this.imgBarCode.Name = "imgBarCode";
            this.imgBarCode.Size = new System.Drawing.Size(260, 116);
            this.imgBarCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBarCode.TabIndex = 0;
            this.imgBarCode.TabStop = false;
            // 
            // lblEnterBarCode
            // 
            this.lblEnterBarCode.AutoSize = true;
            this.lblEnterBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEnterBarCode.Location = new System.Drawing.Point(60, 157);
            this.lblEnterBarCode.Name = "lblEnterBarCode";
            this.lblEnterBarCode.Size = new System.Drawing.Size(167, 20);
            this.lblEnterBarCode.TabIndex = 1;
            this.lblEnterBarCode.Text = "Enter Barcode please:";
            // 
            // BarCodeTextBox
            // 
            this.BarCodeTextBox.Location = new System.Drawing.Point(12, 180);
            this.BarCodeTextBox.Name = "BarCodeTextBox";
            this.BarCodeTextBox.Size = new System.Drawing.Size(260, 20);
            this.BarCodeTextBox.TabIndex = 2;
            this.BarCodeTextBox.TextChanged += new System.EventHandler(this.BarCodeTextBox_TextChanged);
            // 
            // btnReadBarCode
            // 
            this.btnReadBarCode.Enabled = false;
            this.btnReadBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReadBarCode.Location = new System.Drawing.Point(77, 206);
            this.btnReadBarCode.Name = "btnReadBarCode";
            this.btnReadBarCode.Size = new System.Drawing.Size(127, 45);
            this.btnReadBarCode.TabIndex = 3;
            this.btnReadBarCode.Text = "Read";
            this.btnReadBarCode.UseVisualStyleBackColor = true;
            this.btnReadBarCode.Click += new System.EventHandler(this.btnReadBarCode_Click);
            // 
            // BarCodeReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 260);
            this.Controls.Add(this.btnReadBarCode);
            this.Controls.Add(this.BarCodeTextBox);
            this.Controls.Add(this.lblEnterBarCode);
            this.Controls.Add(this.imgBarCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarCodeReaderForm";
            this.Text = "Barcode Reader Emulator";
            ((System.ComponentModel.ISupportInitialize)(this.imgBarCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBarCode;
        private System.Windows.Forms.Label lblEnterBarCode;
        private System.Windows.Forms.TextBox BarCodeTextBox;
        private System.Windows.Forms.Button btnReadBarCode;
    }
}

