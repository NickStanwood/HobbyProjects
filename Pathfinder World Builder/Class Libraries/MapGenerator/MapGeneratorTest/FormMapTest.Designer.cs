namespace MapGeneratorTest
{
    partial class FormMapTest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnZoom = new System.Windows.Forms.Button();
            this.btnDrag = new System.Windows.Forms.Button();
            this.lblGetDataTime = new System.Windows.Forms.Label();
            this.lblHeatScale = new System.Windows.Forms.Label();
            this.lblMoistureScale = new System.Windows.Forms.Label();
            this.lblWaterScale = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.trackBarResolution = new System.Windows.Forms.TrackBar();
            this.btnUpdateMap = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarCold = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarDry = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarWater = new System.Windows.Forms.TrackBar();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnCreateNewMap = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pbMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWater)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnZoom);
            this.splitContainer1.Panel1.Controls.Add(this.btnDrag);
            this.splitContainer1.Panel1.Controls.Add(this.lblGetDataTime);
            this.splitContainer1.Panel1.Controls.Add(this.lblHeatScale);
            this.splitContainer1.Panel1.Controls.Add(this.lblMoistureScale);
            this.splitContainer1.Panel1.Controls.Add(this.lblWaterScale);
            this.splitContainer1.Panel1.Controls.Add(this.labelResolution);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarResolution);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdateMap);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarCold);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarDry);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.trackBarWater);
            this.splitContainer1.Panel1.Controls.Add(this.btnNext);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrev);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateNewMap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.pbMap);
            this.splitContainer1.Size = new System.Drawing.Size(1156, 592);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnZoom
            // 
            this.btnZoom.Location = new System.Drawing.Point(20, 423);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(75, 23);
            this.btnZoom.TabIndex = 36;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnDrag
            // 
            this.btnDrag.Location = new System.Drawing.Point(20, 393);
            this.btnDrag.Name = "btnDrag";
            this.btnDrag.Size = new System.Drawing.Size(75, 23);
            this.btnDrag.TabIndex = 35;
            this.btnDrag.Text = "Drag";
            this.btnDrag.UseVisualStyleBackColor = true;
            this.btnDrag.Click += new System.EventHandler(this.btnDrag_Click);
            // 
            // lblGetDataTime
            // 
            this.lblGetDataTime.AutoSize = true;
            this.lblGetDataTime.Location = new System.Drawing.Point(22, 376);
            this.lblGetDataTime.Name = "lblGetDataTime";
            this.lblGetDataTime.Size = new System.Drawing.Size(79, 13);
            this.lblGetDataTime.TabIndex = 34;
            this.lblGetDataTime.Text = "Get Data Time:";
            // 
            // lblHeatScale
            // 
            this.lblHeatScale.AutoSize = true;
            this.lblHeatScale.Location = new System.Drawing.Point(17, 345);
            this.lblHeatScale.Name = "lblHeatScale";
            this.lblHeatScale.Size = new System.Drawing.Size(36, 13);
            this.lblHeatScale.TabIndex = 33;
            this.lblHeatScale.Text = "Heat: ";
            // 
            // lblMoistureScale
            // 
            this.lblMoistureScale.AutoSize = true;
            this.lblMoistureScale.Location = new System.Drawing.Point(17, 313);
            this.lblMoistureScale.Name = "lblMoistureScale";
            this.lblMoistureScale.Size = new System.Drawing.Size(53, 13);
            this.lblMoistureScale.TabIndex = 32;
            this.lblMoistureScale.Text = "Moisture: ";
            // 
            // lblWaterScale
            // 
            this.lblWaterScale.AutoSize = true;
            this.lblWaterScale.Location = new System.Drawing.Point(17, 283);
            this.lblWaterScale.Name = "lblWaterScale";
            this.lblWaterScale.Size = new System.Drawing.Size(39, 13);
            this.lblWaterScale.TabIndex = 31;
            this.lblWaterScale.Text = "Water:";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(100, 23);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(107, 13);
            this.labelResolution.TabIndex = 30;
            this.labelResolution.Text = "Resolution 512 x 512";
            // 
            // trackBarResolution
            // 
            this.trackBarResolution.LargeChange = 1;
            this.trackBarResolution.Location = new System.Drawing.Point(56, 39);
            this.trackBarResolution.Maximum = 4;
            this.trackBarResolution.Name = "trackBarResolution";
            this.trackBarResolution.Size = new System.Drawing.Size(203, 45);
            this.trackBarResolution.TabIndex = 29;
            this.trackBarResolution.Value = 2;
            this.trackBarResolution.Scroll += new System.EventHandler(this.trackBarResolution_Scroll);
            // 
            // btnUpdateMap
            // 
            this.btnUpdateMap.Enabled = false;
            this.btnUpdateMap.Location = new System.Drawing.Point(85, 243);
            this.btnUpdateMap.Name = "btnUpdateMap";
            this.btnUpdateMap.Size = new System.Drawing.Size(160, 23);
            this.btnUpdateMap.TabIndex = 28;
            this.btnUpdateMap.Text = "Update Map";
            this.btnUpdateMap.UseVisualStyleBackColor = true;
            this.btnUpdateMap.Click += new System.EventHandler(this.btnUpdateMap_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Hot";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Cold";
            // 
            // trackBarCold
            // 
            this.trackBarCold.Location = new System.Drawing.Point(51, 192);
            this.trackBarCold.Maximum = 90;
            this.trackBarCold.Minimum = 10;
            this.trackBarCold.Name = "trackBarCold";
            this.trackBarCold.Size = new System.Drawing.Size(208, 45);
            this.trackBarCold.TabIndex = 25;
            this.trackBarCold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarCold.Value = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Moist";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Dry";
            // 
            // trackBarDry
            // 
            this.trackBarDry.Location = new System.Drawing.Point(51, 141);
            this.trackBarDry.Maximum = 90;
            this.trackBarDry.Minimum = 10;
            this.trackBarDry.Name = "trackBarDry";
            this.trackBarDry.Size = new System.Drawing.Size(208, 45);
            this.trackBarDry.TabIndex = 22;
            this.trackBarDry.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarDry.Value = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Land";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Water";
            // 
            // trackBarWater
            // 
            this.trackBarWater.Location = new System.Drawing.Point(51, 90);
            this.trackBarWater.Maximum = 90;
            this.trackBarWater.Minimum = 10;
            this.trackBarWater.Name = "trackBarWater";
            this.trackBarWater.Size = new System.Drawing.Size(208, 45);
            this.trackBarWater.TabIndex = 19;
            this.trackBarWater.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarWater.Value = 40;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(170, 528);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(85, 528);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnCreateNewMap
            // 
            this.btnCreateNewMap.Location = new System.Drawing.Point(85, 557);
            this.btnCreateNewMap.Name = "btnCreateNewMap";
            this.btnCreateNewMap.Size = new System.Drawing.Size(160, 23);
            this.btnCreateNewMap.TabIndex = 0;
            this.btnCreateNewMap.Text = "Create New";
            this.btnCreateNewMap.UseVisualStyleBackColor = true;
            this.btnCreateNewMap.Click += new System.EventHandler(this.btnCreateNewMap_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 482);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(3, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(825, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 54);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(825, 53);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.Color.Gray;
            this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMap.Location = new System.Drawing.Point(0, 0);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(831, 592);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMap.TabIndex = 0;
            this.pbMap.TabStop = false;
            // 
            // FormMapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 592);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMapTest";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWater)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCreateNewMap;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarWater;
        private System.Windows.Forms.Button btnUpdateMap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarCold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarDry;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.TrackBar trackBarResolution;
        private System.Windows.Forms.Label lblHeatScale;
        private System.Windows.Forms.Label lblMoistureScale;
        private System.Windows.Forms.Label lblWaterScale;
        private System.Windows.Forms.Label lblGetDataTime;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.Button btnDrag;
    }
}

