namespace LSDelevaryNote
{
    partial class FormDeliveryNote
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeliveryNote));
            this.TransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TransactionCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TransactionLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxReceipt = new System.Windows.Forms.TextBox();
            this.dataGridViewReceipt = new System.Windows.Forms.DataGridView();
            this.dataGridViewTransaction = new System.Windows.Forms.DataGridView();
            this.dataGridViewCustomer = new System.Windows.Forms.DataGridView();
            this.reportViewerDelivary = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelReport = new System.Windows.Forms.LinkLabel();
            this.linkLabelSettings = new System.Windows.Forms.LinkLabel();
            this.buttonSendSMS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPrint.Image = global::LSDelevaryNote.Properties.Resources.print_icon;
            this.buttonPrint.Location = new System.Drawing.Point(895, 299);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrint.Name = "buttonPrint";
            this.tableLayoutPanel1.SetRowSpan(this.buttonPrint, 2);
            this.buttonPrint.Size = new System.Drawing.Size(378, 194);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Image = global::LSDelevaryNote.Properties.Resources.close_icon;
            this.buttonCancel.Location = new System.Drawing.Point(895, 497);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.tableLayoutPanel1.SetRowSpan(this.buttonCancel, 2);
            this.buttonCancel.Size = new System.Drawing.Size(378, 195);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxReceipt
            // 
            this.textBoxReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReceipt.Location = new System.Drawing.Point(897, 104);
            this.textBoxReceipt.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxReceipt.Name = "textBoxReceipt";
            this.textBoxReceipt.Size = new System.Drawing.Size(374, 34);
            this.textBoxReceipt.TabIndex = 0;
            this.textBoxReceipt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxReceipt_KeyPress);
            // 
            // dataGridViewReceipt
            // 
            this.dataGridViewReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewReceipt, 2);
            this.dataGridViewReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReceipt.Location = new System.Drawing.Point(3, 2);
            this.dataGridViewReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewReceipt.Name = "dataGridViewReceipt";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewReceipt, 2);
            this.dataGridViewReceipt.RowTemplate.Height = 24;
            this.dataGridViewReceipt.Size = new System.Drawing.Size(1, 194);
            this.dataGridViewReceipt.TabIndex = 2;
            // 
            // dataGridViewTransaction
            // 
            this.dataGridViewTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewTransaction, 4);
            this.dataGridViewTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransaction.Location = new System.Drawing.Point(3, 200);
            this.dataGridViewTransaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewTransaction.Name = "dataGridViewTransaction";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewTransaction, 4);
            this.dataGridViewTransaction.RowTemplate.Height = 24;
            this.dataGridViewTransaction.Size = new System.Drawing.Size(1, 392);
            this.dataGridViewTransaction.TabIndex = 3;
            // 
            // dataGridViewCustomer
            // 
            this.dataGridViewCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewCustomer, 2);
            this.dataGridViewCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomer.Location = new System.Drawing.Point(3, 2);
            this.dataGridViewCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCustomer.Name = "dataGridViewCustomer";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewCustomer, 2);
            this.dataGridViewCustomer.RowTemplate.Height = 24;
            this.dataGridViewCustomer.Size = new System.Drawing.Size(1, 194);
            this.dataGridViewCustomer.TabIndex = 4;
            // 
            // reportViewerDelivary
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.reportViewerDelivary, 2);
            this.reportViewerDelivary.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Transaction";
            reportDataSource1.Value = this.TransactionBindingSource;
            reportDataSource2.Name = "TransactionCustomer";
            reportDataSource2.Value = this.TransactionCustomerBindingSource;
            reportDataSource3.Name = "TransactionLines";
            reportDataSource3.Value = this.TransactionLinesBindingSource;
            this.reportViewerDelivary.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerDelivary.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerDelivary.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerDelivary.LocalReport.ReportEmbeddedResource = "LSDelevaryNote.DelivaryReport.rdlc";
            this.reportViewerDelivary.Location = new System.Drawing.Point(3, 2);
            this.reportViewerDelivary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportViewerDelivary.Name = "reportViewerDelivary";
            this.tableLayoutPanel1.SetRowSpan(this.reportViewerDelivary, 7);
            this.reportViewerDelivary.Size = new System.Drawing.Size(886, 690);
            this.reportViewerDelivary.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewReceipt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReceipt, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewTransaction, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewCustomer, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportViewerDelivary, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonPrint, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonSendSMS, 6, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1276, 694);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.linkLabelReport);
            this.flowLayoutPanel1.Controls.Add(this.linkLabelSettings);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(895, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(378, 95);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // linkLabelReport
            // 
            this.linkLabelReport.AutoSize = true;
            this.linkLabelReport.Location = new System.Drawing.Point(302, 0);
            this.linkLabelReport.Name = "linkLabelReport";
            this.linkLabelReport.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.linkLabelReport.Size = new System.Drawing.Size(73, 37);
            this.linkLabelReport.TabIndex = 0;
            this.linkLabelReport.TabStop = true;
            this.linkLabelReport.Text = "Report";
            this.linkLabelReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReport_LinkClicked);
            // 
            // linkLabelSettings
            // 
            this.linkLabelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelSettings.AutoSize = true;
            this.linkLabelSettings.Location = new System.Drawing.Point(215, 0);
            this.linkLabelSettings.Name = "linkLabelSettings";
            this.linkLabelSettings.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.linkLabelSettings.Size = new System.Drawing.Size(81, 37);
            this.linkLabelSettings.TabIndex = 1;
            this.linkLabelSettings.TabStop = true;
            this.linkLabelSettings.Text = "Settings";
            this.linkLabelSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSettings_LinkClicked);
            // 
            // buttonSendSMS
            // 
            this.buttonSendSMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSendSMS.Image = global::LSDelevaryNote.Properties.Resources.send_sms;
            this.buttonSendSMS.Location = new System.Drawing.Point(895, 201);
            this.buttonSendSMS.Name = "buttonSendSMS";
            this.buttonSendSMS.Size = new System.Drawing.Size(378, 93);
            this.buttonSendSMS.TabIndex = 7;
            this.buttonSendSMS.UseVisualStyleBackColor = true;
            this.buttonSendSMS.Click += new System.EventHandler(this.buttonSendSMS_Click);
            // 
            // FormDeliveryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1276, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeliveryNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delivery Note";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormDeliveryNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxReceipt;
        private System.Windows.Forms.DataGridView dataGridViewReceipt;
        private System.Windows.Forms.DataGridView dataGridViewTransaction;
        private System.Windows.Forms.DataGridView dataGridViewCustomer;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerDelivary;
        private System.Windows.Forms.BindingSource TransactionBindingSource;
        private System.Windows.Forms.BindingSource TransactionCustomerBindingSource;
        private System.Windows.Forms.BindingSource TransactionLinesBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabelReport;
        private System.Windows.Forms.LinkLabel linkLabelSettings;
        private System.Windows.Forms.Button buttonSendSMS;
    }
}

