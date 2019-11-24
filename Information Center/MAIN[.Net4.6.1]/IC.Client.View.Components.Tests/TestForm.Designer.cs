namespace IC.Client.View.Components.Tests
{
    partial class TestForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.icLabel1 = new IC.Client.View.Components.ICLabel();
            this.SuspendLayout();
            // 
            // icLabel1
            // 
            this.icLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icLabel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.icLabel1.Font = new System.Drawing.Font("Cambria", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.icLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.icLabel1.Location = new System.Drawing.Point(21, 20);
            this.icLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.icLabel1.Name = "icLabel1";
            this.icLabel1.OutlineAlignment = System.Drawing.StringAlignment.Center;
            this.icLabel1.OutlineForeColor = System.Drawing.Color.Green;
            this.icLabel1.OutlineLineAlignment = System.Drawing.StringAlignment.Center;
            this.icLabel1.OutlineWidth = 4F;
            this.icLabel1.Size = new System.Drawing.Size(398, 87);
            this.icLabel1.TabIndex = 0;
            this.icLabel1.Text = "IC.Client.View.Components.Tests";
            this.icLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 293);
            this.Controls.Add(this.icLabel1);
            this.Name = "TestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ICLabel icLabel1;
    }
}

