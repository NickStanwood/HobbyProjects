namespace MagicReader
{
    partial class FormDBViewer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDBSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSetSelect = new System.Windows.Forms.ComboBox();
            this.dataGridViewDB = new System.Windows.Forms.DataGridView();
            this.dBDataSet = new MagicReader.DBDataSet();
            this.cardsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cardsTableAdapter = new MagicReader.DBDataSetTableAdapters.CardsTableAdapter();
            this.dBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expansionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSetSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxDBSelect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 477);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Controls";
            // 
            // comboBoxDBSelect
            // 
            this.comboBoxDBSelect.FormattingEnabled = true;
            this.comboBoxDBSelect.Items.AddRange(new object[] {
            "My Collection",
            "All Cards",
            "List of Sets"});
            this.comboBoxDBSelect.Location = new System.Drawing.Point(6, 49);
            this.comboBoxDBSelect.Name = "comboBoxDBSelect";
            this.comboBoxDBSelect.Size = new System.Drawing.Size(188, 21);
            this.comboBoxDBSelect.TabIndex = 0;
            this.comboBoxDBSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxDBSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DataBase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sets to Display";
            // 
            // comboBoxSetSelect
            // 
            this.comboBoxSetSelect.FormattingEnabled = true;
            this.comboBoxSetSelect.Location = new System.Drawing.Point(6, 108);
            this.comboBoxSetSelect.MaxDropDownItems = 100;
            this.comboBoxSetSelect.Name = "comboBoxSetSelect";
            this.comboBoxSetSelect.Size = new System.Drawing.Size(188, 21);
            this.comboBoxSetSelect.TabIndex = 3;
            // 
            // dataGridViewDB
            // 
            this.dataGridViewDB.AutoGenerateColumns = false;
            this.dataGridViewDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.cardIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.expansionDataGridViewTextBoxColumn});
            this.dataGridViewDB.DataSource = this.cardsBindingSource;
            this.dataGridViewDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDB.Location = new System.Drawing.Point(200, 0);
            this.dataGridViewDB.Name = "dataGridViewDB";
            this.dataGridViewDB.Size = new System.Drawing.Size(563, 477);
            this.dataGridViewDB.TabIndex = 1;
            // 
            // dBDataSet
            // 
            this.dBDataSet.DataSetName = "DBDataSet";
            this.dBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cardsBindingSource
            // 
            this.cardsBindingSource.DataMember = "Cards";
            this.cardsBindingSource.DataSource = this.dBDataSet;
            // 
            // cardsTableAdapter
            // 
            this.cardsTableAdapter.ClearBeforeFill = true;
            // 
            // dBDataSetBindingSource
            // 
            this.dBDataSetBindingSource.DataSource = this.dBDataSet;
            this.dBDataSetBindingSource.Position = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardIDDataGridViewTextBoxColumn
            // 
            this.cardIDDataGridViewTextBoxColumn.DataPropertyName = "cardID";
            this.cardIDDataGridViewTextBoxColumn.HeaderText = "cardID";
            this.cardIDDataGridViewTextBoxColumn.Name = "cardIDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // expansionDataGridViewTextBoxColumn
            // 
            this.expansionDataGridViewTextBoxColumn.DataPropertyName = "Expansion";
            this.expansionDataGridViewTextBoxColumn.HeaderText = "Expansion";
            this.expansionDataGridViewTextBoxColumn.Name = "expansionDataGridViewTextBoxColumn";
            // 
            // FormDBViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 477);
            this.Controls.Add(this.dataGridViewDB);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDBViewer";
            this.Text = "FormDBViewer";
            this.Load += new System.EventHandler(this.FormDBViewer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxSetSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDBSelect;
        private System.Windows.Forms.DataGridView dataGridViewDB;
        private DBDataSet dBDataSet;
        private System.Windows.Forms.BindingSource cardsBindingSource;
        private DBDataSetTableAdapters.CardsTableAdapter cardsTableAdapter;
        private System.Windows.Forms.BindingSource dBDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expansionDataGridViewTextBoxColumn;
    }
}