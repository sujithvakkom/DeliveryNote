namespace LSDelevaryNote
{
    partial class ReportViewer
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DelivaryTransactionViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFromDate = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelItemCode = new System.Windows.Forms.Label();
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonSMS = new System.Windows.Forms.Button();
            this.radioButtonSummary = new System.Windows.Forms.RadioButton();
            this.radioButtonReplinish = new System.Windows.Forms.RadioButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DelivaryTransactionViewBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DelivaryTransactionViewBindingSource
            // 
            this.DelivaryTransactionViewBindingSource.DataSource = typeof(LSDelevaryNote.Provider.Entities.DelivaryTransactionView);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1204, 685);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelFromDate);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerFrom);
            this.flowLayoutPanel1.Controls.Add(this.labelTo);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerTo);
            this.flowLayoutPanel1.Controls.Add(this.labelItemCode);
            this.flowLayoutPanel1.Controls.Add(this.textBoxItem);
            this.flowLayoutPanel1.Controls.Add(this.buttonFilter);
            this.flowLayoutPanel1.Controls.Add(this.buttonSMS);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSummary);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonReplinish);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1198, 44);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelFromDate
            // 
            this.labelFromDate.AutoSize = true;
            this.labelFromDate.Location = new System.Drawing.Point(3, 0);
            this.labelFromDate.Name = "labelFromDate";
            this.labelFromDate.Padding = new System.Windows.Forms.Padding(10);
            this.labelFromDate.Size = new System.Drawing.Size(94, 37);
            this.labelFromDate.TabIndex = 7;
            this.labelFromDate.Text = "From Date";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(108, 8);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(8);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFrom.TabIndex = 8;
            this.dateTimePickerFrom.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(319, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Padding = new System.Windows.Forms.Padding(10);
            this.labelTo.Size = new System.Drawing.Size(40, 37);
            this.labelTo.TabIndex = 9;
            this.labelTo.Text = "to";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(370, 8);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(8);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerTo.TabIndex = 10;
            // 
            // labelItemCode
            // 
            this.labelItemCode.AutoSize = true;
            this.labelItemCode.Location = new System.Drawing.Point(581, 0);
            this.labelItemCode.Name = "labelItemCode";
            this.labelItemCode.Padding = new System.Windows.Forms.Padding(10);
            this.labelItemCode.Size = new System.Drawing.Size(54, 37);
            this.labelItemCode.TabIndex = 11;
            this.labelItemCode.Text = "Item";
            // 
            // textBoxItem
            // 
            this.textBoxItem.Location = new System.Drawing.Point(646, 8);
            this.textBoxItem.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.Size = new System.Drawing.Size(100, 22);
            this.textBoxItem.TabIndex = 12;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(757, 3);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 41);
            this.buttonFilter.TabIndex = 13;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonSMS
            // 
            this.buttonSMS.Location = new System.Drawing.Point(838, 3);
            this.buttonSMS.Name = "buttonSMS";
            this.buttonSMS.Size = new System.Drawing.Size(75, 41);
            this.buttonSMS.TabIndex = 14;
            this.buttonSMS.Text = "SMS";
            this.buttonSMS.UseVisualStyleBackColor = true;
            this.buttonSMS.Visible = false;
            // 
            // radioButtonSummary
            // 
            this.radioButtonSummary.AutoSize = true;
            this.radioButtonSummary.Location = new System.Drawing.Point(919, 3);
            this.radioButtonSummary.Name = "radioButtonSummary";
            this.radioButtonSummary.Padding = new System.Windows.Forms.Padding(10);
            this.radioButtonSummary.Size = new System.Drawing.Size(108, 41);
            this.radioButtonSummary.TabIndex = 1;
            this.radioButtonSummary.TabStop = true;
            this.radioButtonSummary.Tag = "";
            this.radioButtonSummary.Text = "Summary";
            this.radioButtonSummary.UseVisualStyleBackColor = true;
            this.radioButtonSummary.CheckedChanged += new System.EventHandler(this.radioButtonReportType_CheckedChanged);
            // 
            // radioButtonReplinish
            // 
            this.radioButtonReplinish.AutoSize = true;
            this.radioButtonReplinish.Location = new System.Drawing.Point(1033, 3);
            this.radioButtonReplinish.Name = "radioButtonReplinish";
            this.radioButtonReplinish.Padding = new System.Windows.Forms.Padding(10);
            this.radioButtonReplinish.Size = new System.Drawing.Size(143, 41);
            this.radioButtonReplinish.TabIndex = 15;
            this.radioButtonReplinish.TabStop = true;
            this.radioButtonReplinish.Tag = "";
            this.radioButtonReplinish.Text = "Replanishment";
            this.radioButtonReplinish.UseVisualStyleBackColor = true;
            this.radioButtonReplinish.CheckedChanged += new System.EventHandler(this.radioButtonReportType_CheckedChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "SummaryDataSet";
            reportDataSource2.Value = this.DelivaryTransactionViewBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LSDelevaryNote.SummaryReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 53);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1198, 579);
            this.reportViewer1.TabIndex = 1;
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 685);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DelivaryTransactionViewBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelFromDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelItemCode;
        private System.Windows.Forms.TextBox textBoxItem;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonSMS;
        private System.Windows.Forms.RadioButton radioButtonSummary;
        private System.Windows.Forms.RadioButton radioButtonReplinish;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DelivaryTransactionViewBindingSource;
    }
}