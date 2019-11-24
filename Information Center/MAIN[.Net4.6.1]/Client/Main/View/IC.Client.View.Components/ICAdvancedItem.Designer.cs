using System.Windows.Forms;

namespace IC.Client.View.Components
{
    partial class ICAdvancedItem
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
            this._image = new System.Windows.Forms.PictureBox();
            this._lblText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._image)).BeginInit();
            this.SuspendLayout();
            // 
            // _image
            // 
            this._image.BackColor = System.Drawing.Color.Transparent;
            this._image.Location = new System.Drawing.Point(267, 5);
            this._image.Name = "_image";
            this._image.Size = new System.Drawing.Size(100, 70);
            this._image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._image.TabIndex = 0;
            this._image.TabStop = false;
            // 
            // _lblText
            // 
            this._lblText.Location = new System.Drawing.Point(3, 5);
            this._lblText.Name = "_lblText";
            this._lblText.Size = new System.Drawing.Size(260, 70);
            this._lblText.TabIndex = 1;
            this._lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ICAdvancedItem
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._lblText);
            this.Controls.Add(this._image);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 34F, System.Drawing.FontStyle.Bold);
            this.Name = "ICAdvancedItem";
            this.Size = new System.Drawing.Size(370, 80);
            ((System.ComponentModel.ISupportInitialize)(this._image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label _lblText;
        private PictureBox _image;
    }
}