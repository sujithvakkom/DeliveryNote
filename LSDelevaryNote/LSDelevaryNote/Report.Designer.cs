namespace LSDelevaryNote
{
    partial class Report
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
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFromDate = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelItemCode = new System.Windows.Forms.Label();
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxInckInPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptID,
            this.ItemId,
            this.Description,
            this.ExtraInfo,
            this.Qty,
            this.TaxInckInPrice,
            this.Comment});
            this.dataGridViewReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewReport.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewReport.Location = new System.Drawing.Point(3, 53);
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.RowHeadersVisible = false;
            this.dataGridViewReport.RowTemplate.Height = 24;
            this.dataGridViewReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReport.Size = new System.Drawing.Size(929, 546);
            this.dataGridViewReport.TabIndex = 0;
            this.dataGridViewReport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewReport_MouseClick);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.dataGridViewReport, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(935, 602);
            this.tableLayoutPanel.TabIndex = 1;
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
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(929, 44);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // labelFromDate
            // 
            this.labelFromDate.AutoSize = true;
            this.labelFromDate.Location = new System.Drawing.Point(3, 0);
            this.labelFromDate.Name = "labelFromDate";
            this.labelFromDate.Padding = new System.Windows.Forms.Padding(10);
            this.labelFromDate.Size = new System.Drawing.Size(94, 37);
            this.labelFromDate.TabIndex = 0;
            this.labelFromDate.Text = "From Date";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(108, 8);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(8);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFrom.TabIndex = 1;
            this.dateTimePickerFrom.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(319, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Padding = new System.Windows.Forms.Padding(10);
            this.labelTo.Size = new System.Drawing.Size(40, 37);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "to";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(370, 8);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(8);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // labelItemCode
            // 
            this.labelItemCode.AutoSize = true;
            this.labelItemCode.Location = new System.Drawing.Point(581, 0);
            this.labelItemCode.Name = "labelItemCode";
            this.labelItemCode.Padding = new System.Windows.Forms.Padding(10);
            this.labelItemCode.Size = new System.Drawing.Size(54, 37);
            this.labelItemCode.TabIndex = 4;
            this.labelItemCode.Text = "Item";
            // 
            // textBoxItem
            // 
            this.textBoxItem.Location = new System.Drawing.Point(646, 8);
            this.textBoxItem.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.Size = new System.Drawing.Size(100, 22);
            this.textBoxItem.TabIndex = 5;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(757, 3);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 41);
            this.buttonFilter.TabIndex = 6;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // ReceiptID
            // 
            this.ReceiptID.DataPropertyName = "ReceiptID";
            this.ReceiptID.FillWeight = 25F;
            this.ReceiptID.HeaderText = "Receipt";
            this.ReceiptID.Name = "ReceiptID";
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.FillWeight = 25F;
            this.ItemId.HeaderText = "Item Code";
            this.ItemId.Name = "ItemId";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 40F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // ExtraInfo
            // 
            this.ExtraInfo.DataPropertyName = "ExtraInfo";
            this.ExtraInfo.FillWeight = 30F;
            this.ExtraInfo.HeaderText = "Delivery Status";
            this.ExtraInfo.Name = "ExtraInfo";
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Visible = false;
            // 
            // TaxInckInPrice
            // 
            this.TaxInckInPrice.DataPropertyName = "TaxInckInPrice";
            this.TaxInckInPrice.HeaderText = "TaxInckInPrice";
            this.TaxInckInPrice.Name = "TaxInckInPrice";
            this.TaxInckInPrice.Visible = false;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.Visible = false;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 602);
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(872, 649);
            this.Name = "Report";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelFromDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelItemCode;
        private System.Windows.Forms.TextBox textBoxItem;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxInckInPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}