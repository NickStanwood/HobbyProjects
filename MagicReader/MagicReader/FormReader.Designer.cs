namespace MagicReader
{
    partial class FormReader
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
            this.btnStartReading = new System.Windows.Forms.Button();
            this.btnStopReading = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbCOMSelect = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbSuccesfulCards = new System.Windows.Forms.TextBox();
            this.lvSuccessfulCards = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lvAttemptedCards = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnViewDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartReading
            // 
            this.btnStartReading.Location = new System.Drawing.Point(12, 121);
            this.btnStartReading.Name = "btnStartReading";
            this.btnStartReading.Size = new System.Drawing.Size(150, 50);
            this.btnStartReading.TabIndex = 0;
            this.btnStartReading.Text = "Start Reading Cards";
            this.btnStartReading.UseVisualStyleBackColor = true;
            this.btnStartReading.Click += new System.EventHandler(this.btnStartReading_Click);
            // 
            // btnStopReading
            // 
            this.btnStopReading.Enabled = false;
            this.btnStopReading.Location = new System.Drawing.Point(12, 177);
            this.btnStopReading.Name = "btnStopReading";
            this.btnStopReading.Size = new System.Drawing.Size(150, 50);
            this.btnStopReading.TabIndex = 1;
            this.btnStopReading.Text = "Stop Reading Cards";
            this.btnStopReading.UseVisualStyleBackColor = true;
            this.btnStopReading.Click += new System.EventHandler(this.btnStopReading_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "COM port:";
            // 
            // tbCOMSelect
            // 
            this.tbCOMSelect.Location = new System.Drawing.Point(70, 19);
            this.tbCOMSelect.Name = "tbCOMSelect";
            this.tbCOMSelect.Size = new System.Drawing.Size(79, 20);
            this.tbCOMSelect.TabIndex = 3;
            this.tbCOMSelect.Text = "COM4";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(168, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(719, 415);
            this.splitContainer1.SplitterDistance = 359;
            this.splitContainer1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tbSuccesfulCards, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvSuccessfulCards, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.253886F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.74612F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbSuccesfulCards
            // 
            this.tbSuccesfulCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSuccesfulCards.Enabled = false;
            this.tbSuccesfulCards.Location = new System.Drawing.Point(3, 3);
            this.tbSuccesfulCards.Name = "tbSuccesfulCards";
            this.tbSuccesfulCards.Size = new System.Drawing.Size(353, 20);
            this.tbSuccesfulCards.TabIndex = 1;
            this.tbSuccesfulCards.Text = "Successfully Read Cards";
            // 
            // lvSuccessfulCards
            // 
            this.lvSuccessfulCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSuccessfulCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSuccessfulCards.Location = new System.Drawing.Point(3, 33);
            this.lvSuccessfulCards.Name = "lvSuccessfulCards";
            this.lvSuccessfulCards.Size = new System.Drawing.Size(353, 379);
            this.lvSuccessfulCards.TabIndex = 2;
            this.lvSuccessfulCards.UseCompatibleStateImageBehavior = false;
            this.lvSuccessfulCards.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 129;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Expansion";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.Width = 79;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lvAttemptedCards, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.253886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.74612F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(356, 415);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lvAttemptedCards
            // 
            this.lvAttemptedCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvAttemptedCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAttemptedCards.Location = new System.Drawing.Point(3, 33);
            this.lvAttemptedCards.Name = "lvAttemptedCards";
            this.lvAttemptedCards.Size = new System.Drawing.Size(350, 379);
            this.lvAttemptedCards.TabIndex = 3;
            this.lvAttemptedCards.UseCompatibleStateImageBehavior = false;
            this.lvAttemptedCards.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Expansion";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 162;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Quantity";
            this.columnHeader6.Width = 57;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(3, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(350, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "Attempted Cards";
            // 
            // tbStatus
            // 
            this.tbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbStatus.Location = new System.Drawing.Point(12, 433);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(875, 22);
            this.tbStatus.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewDB);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.tbCOMSelect);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 103);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(12, 233);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 50);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnViewDB
            // 
            this.btnViewDB.Location = new System.Drawing.Point(7, 46);
            this.btnViewDB.Name = "btnViewDB";
            this.btnViewDB.Size = new System.Drawing.Size(139, 23);
            this.btnViewDB.TabIndex = 4;
            this.btnViewDB.Text = "View Database";
            this.btnViewDB.UseVisualStyleBackColor = true;
            this.btnViewDB.Click += new System.EventHandler(this.btnViewDB_Click);
            // 
            // FormReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 465);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnStopReading);
            this.Controls.Add(this.btnStartReading);
            this.Name = "FormReader";
            this.Text = "Magic Reader";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartReading;
        private System.Windows.Forms.Button btnStopReading;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbCOMSelect;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbSuccesfulCards;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListView lvSuccessfulCards;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvAttemptedCards;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnViewDB;
    }
}

