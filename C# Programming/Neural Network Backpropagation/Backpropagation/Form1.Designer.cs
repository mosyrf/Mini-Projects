namespace Backpropagation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.richTextBoxWN = new System.Windows.Forms.RichTextBox();
            this.richTextBoxVN = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxError = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLoadInput = new System.Windows.Forms.Button();
            this.buttonTraining = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxIN1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIN2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOUTweightX1 = new System.Windows.Forms.TextBox();
            this.textBoxOUTweightX2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOUTX1 = new System.Windows.Forms.TextBox();
            this.textBoxOUTX2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxHiddenNode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxToleransiError = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxLearnRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxEpoch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chartError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxParameterTraining = new System.Windows.Forms.GroupBox();
            this.groupBoxControl = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).BeginInit();
            this.groupBoxParameterTraining.SuspendLayout();
            this.groupBoxControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxWN
            // 
            this.richTextBoxWN.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxWN.Location = new System.Drawing.Point(12, 40);
            this.richTextBoxWN.Name = "richTextBoxWN";
            this.richTextBoxWN.Size = new System.Drawing.Size(225, 250);
            this.richTextBoxWN.TabIndex = 0;
            this.richTextBoxWN.Text = "";
            // 
            // richTextBoxVN
            // 
            this.richTextBoxVN.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxVN.Location = new System.Drawing.Point(269, 40);
            this.richTextBoxVN.Name = "richTextBoxVN";
            this.richTextBoxVN.Size = new System.Drawing.Size(225, 250);
            this.richTextBoxVN.TabIndex = 0;
            this.richTextBoxVN.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(315, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Weight v(n)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Weight w(n)";
            // 
            // richTextBoxError
            // 
            this.richTextBoxError.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxError.Location = new System.Drawing.Point(609, 40);
            this.richTextBoxError.Name = "richTextBoxError";
            this.richTextBoxError.Size = new System.Drawing.Size(225, 250);
            this.richTextBoxError.TabIndex = 0;
            this.richTextBoxError.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(687, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Error";
            // 
            // buttonLoadInput
            // 
            this.buttonLoadInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadInput.Location = new System.Drawing.Point(134, 29);
            this.buttonLoadInput.Name = "buttonLoadInput";
            this.buttonLoadInput.Size = new System.Drawing.Size(150, 50);
            this.buttonLoadInput.TabIndex = 2;
            this.buttonLoadInput.Text = "Load Input";
            this.buttonLoadInput.UseVisualStyleBackColor = true;
            this.buttonLoadInput.Click += new System.EventHandler(this.buttonLoadInput_Click);
            // 
            // buttonTraining
            // 
            this.buttonTraining.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTraining.Location = new System.Drawing.Point(134, 85);
            this.buttonTraining.Name = "buttonTraining";
            this.buttonTraining.Size = new System.Drawing.Size(150, 50);
            this.buttonTraining.TabIndex = 2;
            this.buttonTraining.Text = "Training";
            this.buttonTraining.UseVisualStyleBackColor = true;
            this.buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTest.Location = new System.Drawing.Point(260, 147);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(150, 50);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "Testing";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBoxIN1
            // 
            this.textBoxIN1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIN1.Location = new System.Drawing.Point(65, 66);
            this.textBoxIN1.Name = "textBoxIN1";
            this.textBoxIN1.Size = new System.Drawing.Size(150, 30);
            this.textBoxIN1.TabIndex = 3;
            this.textBoxIN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "X1";
            // 
            // textBoxIN2
            // 
            this.textBoxIN2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIN2.Location = new System.Drawing.Point(65, 103);
            this.textBoxIN2.Name = "textBoxIN2";
            this.textBoxIN2.Size = new System.Drawing.Size(150, 30);
            this.textBoxIN2.TabIndex = 3;
            this.textBoxIN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "X2";
            // 
            // textBoxOUTweightX1
            // 
            this.textBoxOUTweightX1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOUTweightX1.Location = new System.Drawing.Point(257, 66);
            this.textBoxOUTweightX1.Name = "textBoxOUTweightX1";
            this.textBoxOUTweightX1.Size = new System.Drawing.Size(150, 30);
            this.textBoxOUTweightX1.TabIndex = 3;
            this.textBoxOUTweightX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxOUTweightX2
            // 
            this.textBoxOUTweightX2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOUTweightX2.Location = new System.Drawing.Point(257, 103);
            this.textBoxOUTweightX2.Name = "textBoxOUTweightX2";
            this.textBoxOUTweightX2.Size = new System.Drawing.Size(150, 30);
            this.textBoxOUTweightX2.TabIndex = 3;
            this.textBoxOUTweightX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(298, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Output";
            // 
            // textBoxOUTX1
            // 
            this.textBoxOUTX1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOUTX1.Location = new System.Drawing.Point(455, 66);
            this.textBoxOUTX1.Name = "textBoxOUTX1";
            this.textBoxOUTX1.Size = new System.Drawing.Size(150, 30);
            this.textBoxOUTX1.TabIndex = 3;
            this.textBoxOUTX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxOUTX2
            // 
            this.textBoxOUTX2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOUTX2.Location = new System.Drawing.Point(455, 103);
            this.textBoxOUTX2.Name = "textBoxOUTX2";
            this.textBoxOUTX2.Size = new System.Drawing.Size(150, 30);
            this.textBoxOUTX2.TabIndex = 3;
            this.textBoxOUTX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(450, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "Output Logika";
            // 
            // textBoxHiddenNode
            // 
            this.textBoxHiddenNode.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHiddenNode.Location = new System.Drawing.Point(244, 32);
            this.textBoxHiddenNode.Name = "textBoxHiddenNode";
            this.textBoxHiddenNode.Size = new System.Drawing.Size(150, 30);
            this.textBoxHiddenNode.TabIndex = 3;
            this.textBoxHiddenNode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 24);
            this.label8.TabIndex = 4;
            this.label8.Text = "Hidden Node";
            // 
            // textBoxToleransiError
            // 
            this.textBoxToleransiError.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxToleransiError.Location = new System.Drawing.Point(244, 68);
            this.textBoxToleransiError.Name = "textBoxToleransiError";
            this.textBoxToleransiError.Size = new System.Drawing.Size(150, 30);
            this.textBoxToleransiError.TabIndex = 3;
            this.textBoxToleransiError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 24);
            this.label9.TabIndex = 4;
            this.label9.Text = "Toleransi Error";
            // 
            // textBoxLearnRate
            // 
            this.textBoxLearnRate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLearnRate.Location = new System.Drawing.Point(244, 104);
            this.textBoxLearnRate.Name = "textBoxLearnRate";
            this.textBoxLearnRate.Size = new System.Drawing.Size(150, 30);
            this.textBoxLearnRate.TabIndex = 3;
            this.textBoxLearnRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 24);
            this.label10.TabIndex = 4;
            this.label10.Text = "Learning Rate";
            // 
            // textBoxEpoch
            // 
            this.textBoxEpoch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEpoch.Location = new System.Drawing.Point(244, 140);
            this.textBoxEpoch.Name = "textBoxEpoch";
            this.textBoxEpoch.Size = new System.Drawing.Size(150, 30);
            this.textBoxEpoch.TabIndex = 3;
            this.textBoxEpoch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(31, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "Epoch";
            // 
            // textBoxError
            // 
            this.textBoxError.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxError.Location = new System.Drawing.Point(244, 176);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(150, 30);
            this.textBoxError.TabIndex = 3;
            this.textBoxError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(31, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 24);
            this.label12.TabIndex = 4;
            this.label12.Text = "Error";
            // 
            // chartError
            // 
            chartArea1.Name = "ChartArea1";
            this.chartError.ChartAreas.Add(chartArea1);
            this.chartError.Location = new System.Drawing.Point(96, 338);
            this.chartError.Name = "chartError";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartError.Series.Add(series1);
            this.chartError.Size = new System.Drawing.Size(650, 400);
            this.chartError.TabIndex = 5;
            this.chartError.Text = "chart1";
            // 
            // groupBoxParameterTraining
            // 
            this.groupBoxParameterTraining.Controls.Add(this.textBoxLearnRate);
            this.groupBoxParameterTraining.Controls.Add(this.textBoxHiddenNode);
            this.groupBoxParameterTraining.Controls.Add(this.textBoxToleransiError);
            this.groupBoxParameterTraining.Controls.Add(this.textBoxEpoch);
            this.groupBoxParameterTraining.Controls.Add(this.textBoxError);
            this.groupBoxParameterTraining.Controls.Add(this.label12);
            this.groupBoxParameterTraining.Controls.Add(this.label8);
            this.groupBoxParameterTraining.Controls.Add(this.label11);
            this.groupBoxParameterTraining.Controls.Add(this.label9);
            this.groupBoxParameterTraining.Controls.Add(this.label10);
            this.groupBoxParameterTraining.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParameterTraining.Location = new System.Drawing.Point(1086, 224);
            this.groupBoxParameterTraining.Name = "groupBoxParameterTraining";
            this.groupBoxParameterTraining.Size = new System.Drawing.Size(400, 230);
            this.groupBoxParameterTraining.TabIndex = 6;
            this.groupBoxParameterTraining.TabStop = false;
            this.groupBoxParameterTraining.Text = "PARAMETER TRAINING";
            // 
            // groupBoxControl
            // 
            this.groupBoxControl.Controls.Add(this.buttonTraining);
            this.groupBoxControl.Controls.Add(this.buttonLoadInput);
            this.groupBoxControl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxControl.Location = new System.Drawing.Point(1086, 40);
            this.groupBoxControl.Name = "groupBoxControl";
            this.groupBoxControl.Size = new System.Drawing.Size(400, 150);
            this.groupBoxControl.TabIndex = 7;
            this.groupBoxControl.TabStop = false;
            this.groupBoxControl.Text = "TOMBOL KONTROL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxOUTX2);
            this.groupBox1.Controls.Add(this.textBoxIN1);
            this.groupBox1.Controls.Add(this.buttonTest);
            this.groupBox1.Controls.Add(this.textBoxOUTweightX1);
            this.groupBox1.Controls.Add(this.textBoxOUTX1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxOUTweightX2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxIN2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(950, 490);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 223);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TES OUTPUT";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(101, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 24);
            this.label14.TabIndex = 4;
            this.label14.Text = "Input";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(394, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 24);
            this.label13.TabIndex = 1;
            this.label13.Text = "Grafik Error";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Open File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1849, 922);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxControl);
            this.Controls.Add(this.groupBoxParameterTraining);
            this.Controls.Add(this.chartError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxError);
            this.Controls.Add(this.richTextBoxVN);
            this.Controls.Add(this.richTextBoxWN);
            this.Name = "Form1";
            this.Text = "Multi Perceptron";
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).EndInit();
            this.groupBoxParameterTraining.ResumeLayout(false);
            this.groupBoxParameterTraining.PerformLayout();
            this.groupBoxControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxWN;
        private System.Windows.Forms.RichTextBox richTextBoxVN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLoadInput;
        private System.Windows.Forms.Button buttonTraining;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.TextBox textBoxIN1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIN2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOUTweightX1;
        private System.Windows.Forms.TextBox textBoxOUTweightX2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOUTX1;
        private System.Windows.Forms.TextBox textBoxOUTX2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxHiddenNode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxToleransiError;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxLearnRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxEpoch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxError;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartError;
        private System.Windows.Forms.GroupBox groupBoxParameterTraining;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label14;
    }
}

