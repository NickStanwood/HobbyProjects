namespace VoronoiTest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbImgSize = new System.Windows.Forms.TextBox();
            this.tbSeedCount = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnGrow = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.pbVoronoiDiagram = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoronoiDiagram)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbStatus);
            this.panel1.Controls.Add(this.btnGrow);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.tbSeedCount);
            this.panel1.Controls.Add(this.tbImgSize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seed Count";
            // 
            // tbImgSize
            // 
            this.tbImgSize.Location = new System.Drawing.Point(81, 21);
            this.tbImgSize.Name = "tbImgSize";
            this.tbImgSize.Size = new System.Drawing.Size(100, 20);
            this.tbImgSize.TabIndex = 2;
            // 
            // tbSeedCount
            // 
            this.tbSeedCount.Location = new System.Drawing.Point(81, 51);
            this.tbSeedCount.Name = "tbSeedCount";
            this.tbSeedCount.Size = new System.Drawing.Size(100, 20);
            this.tbSeedCount.TabIndex = 3;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(81, 77);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "Set Seeds";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnGrow
            // 
            this.btnGrow.Location = new System.Drawing.Point(81, 106);
            this.btnGrow.Name = "btnGrow";
            this.btnGrow.Size = new System.Drawing.Size(75, 23);
            this.btnGrow.TabIndex = 5;
            this.btnGrow.Text = "Grow Seeds";
            this.btnGrow.UseVisualStyleBackColor = true;
            // 
            // tbStatus
            // 
            this.tbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbStatus.Location = new System.Drawing.Point(0, 430);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(200, 20);
            this.tbStatus.TabIndex = 6;
            // 
            // pbVoronoiDiagram
            // 
            this.pbVoronoiDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbVoronoiDiagram.Location = new System.Drawing.Point(200, 0);
            this.pbVoronoiDiagram.Name = "pbVoronoiDiagram";
            this.pbVoronoiDiagram.Size = new System.Drawing.Size(600, 450);
            this.pbVoronoiDiagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVoronoiDiagram.TabIndex = 1;
            this.pbVoronoiDiagram.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbVoronoiDiagram);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoronoiDiagram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGrow;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox tbSeedCount;
        private System.Windows.Forms.TextBox tbImgSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.PictureBox pbVoronoiDiagram;
    }
}

