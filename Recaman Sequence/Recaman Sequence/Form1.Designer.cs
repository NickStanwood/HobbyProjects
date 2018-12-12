namespace Recaman_Sequence
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSequenceCount = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pbSequence = new System.Windows.Forms.PictureBox();
            this.tbSequence = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPenWidth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxResolution = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlForeColor = new System.Windows.Forms.Panel();
            this.pnlBackColor = new System.Windows.Forms.Panel();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSequence)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Iterations";
            // 
            // tbSequenceCount
            // 
            this.tbSequenceCount.Location = new System.Drawing.Point(15, 34);
            this.tbSequenceCount.Name = "tbSequenceCount";
            this.tbSequenceCount.Size = new System.Drawing.Size(55, 20);
            this.tbSequenceCount.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmit.Location = new System.Drawing.Point(3, 404);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(123, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "GO!";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pbSequence
            // 
            this.pbSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSequence.Location = new System.Drawing.Point(129, 0);
            this.pbSequence.Name = "pbSequence";
            this.pbSequence.Size = new System.Drawing.Size(671, 430);
            this.pbSequence.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSequence.TabIndex = 3;
            this.pbSequence.TabStop = false;
            // 
            // tbSequence
            // 
            this.tbSequence.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbSequence.Location = new System.Drawing.Point(0, 430);
            this.tbSequence.Name = "tbSequence";
            this.tbSequence.ReadOnly = true;
            this.tbSequence.Size = new System.Drawing.Size(800, 20);
            this.tbSequence.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(76, 32);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxPenWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxResolution);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.pnlForeColor);
            this.groupBox1.Controls.Add(this.pnlBackColor);
            this.groupBox1.Controls.Add(this.btnForeColor);
            this.groupBox1.Controls.Add(this.btnBackColor);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.tbSequenceCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 430);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Pen Width";
            // 
            // comboBoxPenWidth
            // 
            this.comboBoxPenWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPenWidth.FormattingEnabled = true;
            this.comboBoxPenWidth.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "1 ",
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.comboBoxPenWidth.Location = new System.Drawing.Point(15, 206);
            this.comboBoxPenWidth.Name = "comboBoxPenWidth";
            this.comboBoxPenWidth.Size = new System.Drawing.Size(102, 21);
            this.comboBoxPenWidth.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Resolution";
            // 
            // comboBoxResolution
            // 
            this.comboBoxResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolution.FormattingEnabled = true;
            this.comboBoxResolution.Items.AddRange(new object[] {
            "0.25",
            "0.5",
            "1",
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.comboBoxResolution.Location = new System.Drawing.Point(15, 166);
            this.comboBoxResolution.Name = "comboBoxResolution";
            this.comboBoxResolution.Size = new System.Drawing.Size(102, 21);
            this.comboBoxResolution.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlForeColor
            // 
            this.pnlForeColor.BackColor = System.Drawing.Color.Maroon;
            this.pnlForeColor.Location = new System.Drawing.Point(96, 91);
            this.pnlForeColor.Name = "pnlForeColor";
            this.pnlForeColor.Size = new System.Drawing.Size(23, 23);
            this.pnlForeColor.TabIndex = 9;
            // 
            // pnlBackColor
            // 
            this.pnlBackColor.BackColor = System.Drawing.Color.Wheat;
            this.pnlBackColor.Location = new System.Drawing.Point(96, 61);
            this.pnlBackColor.Name = "pnlBackColor";
            this.pnlBackColor.Size = new System.Drawing.Size(23, 23);
            this.pnlBackColor.TabIndex = 8;
            // 
            // btnForeColor
            // 
            this.btnForeColor.Location = new System.Drawing.Point(17, 91);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(73, 23);
            this.btnForeColor.TabIndex = 7;
            this.btnForeColor.Text = "Fore Color";
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(17, 61);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(73, 23);
            this.btnBackColor.TabIndex = 6;
            this.btnBackColor.Text = "Back Color";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbSequence);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbSequence);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbSequence)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSequenceCount;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.PictureBox pbSequence;
        private System.Windows.Forms.TextBox tbSequence;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Panel pnlForeColor;
        private System.Windows.Forms.Panel pnlBackColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPenWidth;
    }
}

