namespace Signal_Prediction
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonGeneSig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartRandomSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonResSig = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartExeSignal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonExeReset = new System.Windows.Forms.Button();
            this.buttonExeResult = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.textBoxEpoch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLearningRate = new System.Windows.Forms.TextBox();
            this.textBoxHiddenNode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIN2 = new System.Windows.Forms.TextBox();
            this.textBoxIN1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRandomSignal)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartExeSignal)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGeneSig
            // 
            this.buttonGeneSig.Location = new System.Drawing.Point(173, 473);
            this.buttonGeneSig.Name = "buttonGeneSig";
            this.buttonGeneSig.Size = new System.Drawing.Size(120, 45);
            this.buttonGeneSig.TabIndex = 0;
            this.buttonGeneSig.Text = "Run";
            this.buttonGeneSig.UseVisualStyleBackColor = true;
            this.buttonGeneSig.Click += new System.EventHandler(this.buttonGeneSig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartRandomSignal);
            this.groupBox1.Controls.Add(this.buttonResSig);
            this.groupBox1.Controls.Add(this.buttonGeneSig);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(125, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 533);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Signal";
            // 
            // chartRandomSignal
            // 
            chartArea3.Name = "ChartArea1";
            this.chartRandomSignal.ChartAreas.Add(chartArea3);
            this.chartRandomSignal.Location = new System.Drawing.Point(19, 43);
            this.chartRandomSignal.Name = "chartRandomSignal";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chartRandomSignal.Series.Add(series3);
            this.chartRandomSignal.Size = new System.Drawing.Size(700, 410);
            this.chartRandomSignal.TabIndex = 2;
            this.chartRandomSignal.Text = "chart1";
            // 
            // buttonResSig
            // 
            this.buttonResSig.Location = new System.Drawing.Point(434, 473);
            this.buttonResSig.Name = "buttonResSig";
            this.buttonResSig.Size = new System.Drawing.Size(120, 45);
            this.buttonResSig.TabIndex = 0;
            this.buttonResSig.Text = "Reset";
            this.buttonResSig.UseVisualStyleBackColor = true;
            this.buttonResSig.Click += new System.EventHandler(this.buttonResSig_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chartExeSignal);
            this.groupBox2.Controls.Add(this.buttonExeReset);
            this.groupBox2.Controls.Add(this.buttonExeResult);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(951, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 533);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Feed Forward Signal";
            // 
            // chartExeSignal
            // 
            chartArea4.Name = "ChartArea1";
            this.chartExeSignal.ChartAreas.Add(chartArea4);
            this.chartExeSignal.Location = new System.Drawing.Point(19, 43);
            this.chartExeSignal.Name = "chartExeSignal";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.chartExeSignal.Series.Add(series4);
            this.chartExeSignal.Size = new System.Drawing.Size(700, 410);
            this.chartExeSignal.TabIndex = 2;
            this.chartExeSignal.Text = "chart1";
            // 
            // buttonExeReset
            // 
            this.buttonExeReset.Location = new System.Drawing.Point(434, 473);
            this.buttonExeReset.Name = "buttonExeReset";
            this.buttonExeReset.Size = new System.Drawing.Size(120, 45);
            this.buttonExeReset.TabIndex = 0;
            this.buttonExeReset.Text = "Reset";
            this.buttonExeReset.UseVisualStyleBackColor = true;
            this.buttonExeReset.Click += new System.EventHandler(this.buttonExeReset_Click);
            // 
            // buttonExeResult
            // 
            this.buttonExeResult.Location = new System.Drawing.Point(173, 473);
            this.buttonExeResult.Name = "buttonExeResult";
            this.buttonExeResult.Size = new System.Drawing.Size(120, 45);
            this.buttonExeResult.TabIndex = 0;
            this.buttonExeResult.Text = "Run";
            this.buttonExeResult.UseVisualStyleBackColor = true;
            this.buttonExeResult.Click += new System.EventHandler(this.buttonExeResult_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonTraining);
            this.groupBox3.Controls.Add(this.textBoxEpoch);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxLearningRate);
            this.groupBox3.Controls.Add(this.textBoxHiddenNode);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxIN2);
            this.groupBox3.Controls.Add(this.textBoxIN1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(288, 756);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 320);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Training Parameter";
            // 
            // buttonTraining
            // 
            this.buttonTraining.Location = new System.Drawing.Point(130, 261);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(120, 45);
            this.buttonTraining.TabIndex = 3;
            this.buttonTraining.Text = "Train";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // textBoxEpoch
            // 
            this.textBoxEpoch.Location = new System.Drawing.Point(206, 208);
            this.textBoxEpoch.Name = "textBoxEpoch";
            this.textBoxEpoch.Size = new System.Drawing.Size(155, 35);
            this.textBoxEpoch.TabIndex = 6;
            this.textBoxEpoch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Epoch";
            // 
            // textBoxLearningRate
            // 
            this.textBoxLearningRate.Location = new System.Drawing.Point(206, 167);
            this.textBoxLearningRate.Name = "textBoxLearningRate";
            this.textBoxLearningRate.Size = new System.Drawing.Size(155, 35);
            this.textBoxLearningRate.TabIndex = 4;
            this.textBoxLearningRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxHiddenNode
            // 
            this.textBoxHiddenNode.Location = new System.Drawing.Point(206, 126);
            this.textBoxHiddenNode.Name = "textBoxHiddenNode";
            this.textBoxHiddenNode.Size = new System.Drawing.Size(155, 35);
            this.textBoxHiddenNode.TabIndex = 4;
            this.textBoxHiddenNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Learning Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hidden Node";
            // 
            // textBoxIN2
            // 
            this.textBoxIN2.Location = new System.Drawing.Point(206, 85);
            this.textBoxIN2.Name = "textBoxIN2";
            this.textBoxIN2.Size = new System.Drawing.Size(155, 35);
            this.textBoxIN2.TabIndex = 2;
            this.textBoxIN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxIN1
            // 
            this.textBoxIN1.Location = new System.Drawing.Point(206, 44);
            this.textBoxIN1.Name = "textBoxIN1";
            this.textBoxIN1.Size = new System.Drawing.Size(155, 35);
            this.textBoxIN1.TabIndex = 1;
            this.textBoxIN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input X2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input X1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1260, 740);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "Output Y";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Location = new System.Drawing.Point(1147, 772);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(334, 290);
            this.richTextBoxOutput.TabIndex = 5;
            this.richTextBoxOutput.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(563, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(814, 43);
            this.label7.TabIndex = 7;
            this.label7.Text = "Asesmen Akhir Semester - Kecerdasan Buatan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(698, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(556, 43);
            this.label8.TabIndex = 7;
            this.label8.Text = "Muhammad Syarif Nur Rohman";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(698, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 43);
            this.label9.TabIndex = 7;
            this.label9.Text = "4242201036";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(539, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(851, 24);
            this.label10.TabIndex = 8;
            this.label10.Text = "111111111111111111111111111111111111111111111111111111111111111111111111111111111" +
    "111";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 1140);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Signal Prediction";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRandomSignal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartExeSignal)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGeneSig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonResSig;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRandomSignal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExeSignal;
        private System.Windows.Forms.Button buttonExeReset;
        private System.Windows.Forms.Button buttonExeResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.TextBox textBoxEpoch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLearningRate;
        private System.Windows.Forms.TextBox textBoxHiddenNode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIN2;
        private System.Windows.Forms.TextBox textBoxIN1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

