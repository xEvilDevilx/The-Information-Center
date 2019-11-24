namespace IC.Analyst.View.Forms
{
    partial class AnalystForm
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
            _database.CloseConnection();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalystForm));
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnShowRange = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.icDiagram = new IC.Analyst.View.Components.ICDiagram();
            this.tpData = new System.Windows.Forms.TabControl();
            this.tpDiagram = new System.Windows.Forms.TabPage();
            this.tpTreeView = new System.Windows.Forms.TabPage();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LanguageCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvDate = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tpData.SuspendLayout();
            this.tpDiagram.SuspendLayout();
            this.tpTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.Location = new System.Drawing.Point(12, 24);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(129, 13);
            this.lblConnectionString.TabIndex = 0;
            this.lblConnectionString.Text = "ConnectionString:";
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Location = new System.Drawing.Point(147, 23);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(455, 20);
            this.tbConnectionString.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(609, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(115, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(147, 62);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 4;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(399, 62);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 5;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // lblDateRange
            // 
            this.lblDateRange.Location = new System.Drawing.Point(12, 64);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(91, 13);
            this.lblDateRange.TabIndex = 6;
            this.lblDateRange.Text = "DateRange:";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(99, 64);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(42, 13);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "From:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(353, 64);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(40, 13);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShowRange
            // 
            this.btnShowRange.Location = new System.Drawing.Point(609, 59);
            this.btnShowRange.Name = "btnShowRange";
            this.btnShowRange.Size = new System.Drawing.Size(115, 23);
            this.btnShowRange.TabIndex = 9;
            this.btnShowRange.Text = "Show Range";
            this.btnShowRange.UseVisualStyleBackColor = true;
            this.btnShowRange.Click += new System.EventHandler(this.btnShowRange_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IC.Analyst.View.Forms.Properties.Resources.IC_Analyst;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblConnectionString);
            this.panel1.Controls.Add(this.tbConnectionString);
            this.panel1.Controls.Add(this.btnShowRange);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.lblTo);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.lblFrom);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.lblDateRange);
            this.panel1.Location = new System.Drawing.Point(109, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 100);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.icDiagram);
            this.panel2.Location = new System.Drawing.Point(7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 447);
            this.panel2.TabIndex = 12;
            // 
            // icDiagram
            // 
            this.icDiagram.BackColor = System.Drawing.Color.White;
            this.icDiagram.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icDiagram.Location = new System.Drawing.Point(46, 3);
            this.icDiagram.Name = "icDiagram";
            this.icDiagram.Size = new System.Drawing.Size(736, 439);
            this.icDiagram.TabIndex = 3;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.tpDiagram);
            this.tpData.Controls.Add(this.tpTreeView);
            this.tpData.Location = new System.Drawing.Point(3, 109);
            this.tpData.Name = "tpData";
            this.tpData.SelectedIndex = 0;
            this.tpData.Size = new System.Drawing.Size(843, 484);
            this.tpData.TabIndex = 13;
            // 
            // tpDiagram
            // 
            this.tpDiagram.Controls.Add(this.panel2);
            this.tpDiagram.Location = new System.Drawing.Point(4, 22);
            this.tpDiagram.Name = "tpDiagram";
            this.tpDiagram.Padding = new System.Windows.Forms.Padding(3);
            this.tpDiagram.Size = new System.Drawing.Size(835, 458);
            this.tpDiagram.TabIndex = 0;
            this.tpDiagram.Text = "Diagram";
            this.tpDiagram.UseVisualStyleBackColor = true;
            // 
            // tpTreeView
            // 
            this.tpTreeView.Controls.Add(this.dgvProducts);
            this.tpTreeView.Controls.Add(this.tvDate);
            this.tpTreeView.Location = new System.Drawing.Point(4, 22);
            this.tpTreeView.Name = "tpTreeView";
            this.tpTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.tpTreeView.Size = new System.Drawing.Size(835, 458);
            this.tpTreeView.TabIndex = 1;
            this.tpTreeView.Text = "TreeView";
            this.tpTreeView.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.TerminalID,
            this.LanguageCode,
            this.CurrencyCode,
            this.Count});
            this.dgvProducts.Location = new System.Drawing.Point(213, 7);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(615, 445);
            this.dgvProducts.TabIndex = 1;
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.MaxInputLength = 12;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            // 
            // TerminalID
            // 
            this.TerminalID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TerminalID.HeaderText = "TerminalID";
            this.TerminalID.MaxInputLength = 12;
            this.TerminalID.Name = "TerminalID";
            this.TerminalID.ReadOnly = true;
            // 
            // LanguageCode
            // 
            this.LanguageCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LanguageCode.HeaderText = "LanguageCode";
            this.LanguageCode.MaxInputLength = 5;
            this.LanguageCode.Name = "LanguageCode";
            this.LanguageCode.ReadOnly = true;
            // 
            // CurrencyCode
            // 
            this.CurrencyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CurrencyCode.HeaderText = "CurrencyCode";
            this.CurrencyCode.MaxInputLength = 5;
            this.CurrencyCode.Name = "CurrencyCode";
            this.CurrencyCode.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // tvDate
            // 
            this.tvDate.Location = new System.Drawing.Point(6, 7);
            this.tvDate.Name = "tvDate";
            this.tvDate.Size = new System.Drawing.Size(202, 446);
            this.tvDate.TabIndex = 0;
            // 
            // AnalystForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 595);
            this.Controls.Add(this.tpData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalystForm";
            this.Text = "Analyst";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.tpDiagram.ResumeLayout(false);
            this.tpTreeView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.Button btnConnect;
        private Components.ICDiagram icDiagram;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnShowRange;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tpData;
        private System.Windows.Forms.TabPage tpDiagram;
        private System.Windows.Forms.TabPage tpTreeView;
        private System.Windows.Forms.TreeView tvDate;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LanguageCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}