namespace Single_Perceptron
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
            this.groupBoxTrain = new System.Windows.Forms.GroupBox();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelLearn = new System.Windows.Forms.Label();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLearnRate = new System.Windows.Forms.TextBox();
            this.textBoxThresholdTrain = new System.Windows.Forms.TextBox();
            this.textBoxTrainX4 = new System.Windows.Forms.TextBox();
            this.textBoxTrainX3 = new System.Windows.Forms.TextBox();
            this.textBoxTrainX2 = new System.Windows.Forms.TextBox();
            this.textBoxTrainX1 = new System.Windows.Forms.TextBox();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.groupBoxPredict = new System.Windows.Forms.GroupBox();
            this.textBoxEpoch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOUT1 = new System.Windows.Forms.TextBox();
            this.textBoxOUT2 = new System.Windows.Forms.TextBox();
            this.textBoxOUT3 = new System.Windows.Forms.TextBox();
            this.textBoxOUT4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBoxOutPredict = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxW4 = new System.Windows.Forms.TextBox();
            this.textBoxW2 = new System.Windows.Forms.TextBox();
            this.textBoxW1 = new System.Windows.Forms.TextBox();
            this.textBoxW3 = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxTrain.SuspendLayout();
            this.groupBoxPredict.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTrain
            // 
            this.groupBoxTrain.Controls.Add(this.richTextBoxOutput);
            this.groupBoxTrain.Controls.Add(this.label5);
            this.groupBoxTrain.Controls.Add(this.buttonTrain);
            this.groupBoxTrain.Controls.Add(this.label6);
            this.groupBoxTrain.Controls.Add(this.labelLearn);
            this.groupBoxTrain.Controls.Add(this.labelThreshold);
            this.groupBoxTrain.Controls.Add(this.label4);
            this.groupBoxTrain.Controls.Add(this.label3);
            this.groupBoxTrain.Controls.Add(this.label2);
            this.groupBoxTrain.Controls.Add(this.label1);
            this.groupBoxTrain.Controls.Add(this.textBoxEpoch);
            this.groupBoxTrain.Controls.Add(this.textBoxLearnRate);
            this.groupBoxTrain.Controls.Add(this.textBoxThresholdTrain);
            this.groupBoxTrain.Controls.Add(this.textBoxTrainX4);
            this.groupBoxTrain.Controls.Add(this.textBoxTrainX3);
            this.groupBoxTrain.Controls.Add(this.textBoxTrainX2);
            this.groupBoxTrain.Controls.Add(this.textBoxTrainX1);
            this.groupBoxTrain.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTrain.Location = new System.Drawing.Point(163, 50);
            this.groupBoxTrain.Name = "groupBoxTrain";
            this.groupBoxTrain.Size = new System.Drawing.Size(500, 743);
            this.groupBoxTrain.TabIndex = 0;
            this.groupBoxTrain.TabStop = false;
            this.groupBoxTrain.Text = "Training Dataset";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Location = new System.Drawing.Point(6, 225);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(488, 416);
            this.richTextBoxOutput.TabIndex = 3;
            this.richTextBoxOutput.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Output";
            // 
            // labelLearn
            // 
            this.labelLearn.AutoSize = true;
            this.labelLearn.Location = new System.Drawing.Point(183, 98);
            this.labelLearn.Name = "labelLearn";
            this.labelLearn.Size = new System.Drawing.Size(142, 24);
            this.labelLearn.TabIndex = 1;
            this.labelLearn.Text = "Learning Rate";
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Location = new System.Drawing.Point(219, 62);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(106, 24);
            this.labelThreshold.TabIndex = 1;
            this.labelThreshold.Text = "Threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "x4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "x3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "x2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "x1";
            // 
            // textBoxLearnRate
            // 
            this.textBoxLearnRate.Location = new System.Drawing.Point(351, 95);
            this.textBoxLearnRate.Name = "textBoxLearnRate";
            this.textBoxLearnRate.Size = new System.Drawing.Size(100, 30);
            this.textBoxLearnRate.TabIndex = 1;
            this.textBoxLearnRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxThresholdTrain
            // 
            this.textBoxThresholdTrain.Location = new System.Drawing.Point(351, 59);
            this.textBoxThresholdTrain.Name = "textBoxThresholdTrain";
            this.textBoxThresholdTrain.Size = new System.Drawing.Size(100, 30);
            this.textBoxThresholdTrain.TabIndex = 1;
            this.textBoxThresholdTrain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTrainX4
            // 
            this.textBoxTrainX4.Location = new System.Drawing.Point(66, 147);
            this.textBoxTrainX4.Name = "textBoxTrainX4";
            this.textBoxTrainX4.Size = new System.Drawing.Size(100, 30);
            this.textBoxTrainX4.TabIndex = 1;
            this.textBoxTrainX4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTrainX3
            // 
            this.textBoxTrainX3.Location = new System.Drawing.Point(66, 111);
            this.textBoxTrainX3.Name = "textBoxTrainX3";
            this.textBoxTrainX3.Size = new System.Drawing.Size(100, 30);
            this.textBoxTrainX3.TabIndex = 1;
            this.textBoxTrainX3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTrainX2
            // 
            this.textBoxTrainX2.Location = new System.Drawing.Point(66, 75);
            this.textBoxTrainX2.Name = "textBoxTrainX2";
            this.textBoxTrainX2.Size = new System.Drawing.Size(100, 30);
            this.textBoxTrainX2.TabIndex = 1;
            this.textBoxTrainX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTrainX1
            // 
            this.textBoxTrainX1.Location = new System.Drawing.Point(66, 39);
            this.textBoxTrainX1.Name = "textBoxTrainX1";
            this.textBoxTrainX1.Size = new System.Drawing.Size(100, 30);
            this.textBoxTrainX1.TabIndex = 1;
            this.textBoxTrainX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(156, 662);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(130, 60);
            this.buttonTrain.TabIndex = 2;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // groupBoxPredict
            // 
            this.groupBoxPredict.Controls.Add(this.buttonReset);
            this.groupBoxPredict.Controls.Add(this.buttonStart);
            this.groupBoxPredict.Controls.Add(this.richTextBoxOutPredict);
            this.groupBoxPredict.Controls.Add(this.label14);
            this.groupBoxPredict.Controls.Add(this.textBoxW3);
            this.groupBoxPredict.Controls.Add(this.textBoxOUT3);
            this.groupBoxPredict.Controls.Add(this.textBoxW1);
            this.groupBoxPredict.Controls.Add(this.textBoxOUT1);
            this.groupBoxPredict.Controls.Add(this.textBoxW2);
            this.groupBoxPredict.Controls.Add(this.textBoxW4);
            this.groupBoxPredict.Controls.Add(this.textBoxOUT2);
            this.groupBoxPredict.Controls.Add(this.label15);
            this.groupBoxPredict.Controls.Add(this.textBoxOUT4);
            this.groupBoxPredict.Controls.Add(this.label13);
            this.groupBoxPredict.Controls.Add(this.label7);
            this.groupBoxPredict.Controls.Add(this.label12);
            this.groupBoxPredict.Controls.Add(this.label8);
            this.groupBoxPredict.Controls.Add(this.label11);
            this.groupBoxPredict.Controls.Add(this.label10);
            this.groupBoxPredict.Controls.Add(this.label9);
            this.groupBoxPredict.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPredict.Location = new System.Drawing.Point(1108, 50);
            this.groupBoxPredict.Name = "groupBoxPredict";
            this.groupBoxPredict.Size = new System.Drawing.Size(508, 743);
            this.groupBoxPredict.TabIndex = 0;
            this.groupBoxPredict.TabStop = false;
            this.groupBoxPredict.Text = "Predict Dataset";
            // 
            // textBoxEpoch
            // 
            this.textBoxEpoch.Location = new System.Drawing.Point(351, 131);
            this.textBoxEpoch.Name = "textBoxEpoch";
            this.textBoxEpoch.Size = new System.Drawing.Size(100, 30);
            this.textBoxEpoch.TabIndex = 1;
            this.textBoxEpoch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Epoch";
            // 
            // textBoxOUT1
            // 
            this.textBoxOUT1.Location = new System.Drawing.Point(92, 39);
            this.textBoxOUT1.Name = "textBoxOUT1";
            this.textBoxOUT1.Size = new System.Drawing.Size(100, 30);
            this.textBoxOUT1.TabIndex = 1;
            this.textBoxOUT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxOUT2
            // 
            this.textBoxOUT2.Location = new System.Drawing.Point(92, 75);
            this.textBoxOUT2.Name = "textBoxOUT2";
            this.textBoxOUT2.Size = new System.Drawing.Size(100, 30);
            this.textBoxOUT2.TabIndex = 1;
            this.textBoxOUT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxOUT3
            // 
            this.textBoxOUT3.Location = new System.Drawing.Point(92, 111);
            this.textBoxOUT3.Name = "textBoxOUT3";
            this.textBoxOUT3.Size = new System.Drawing.Size(100, 30);
            this.textBoxOUT3.TabIndex = 1;
            this.textBoxOUT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxOUT4
            // 
            this.textBoxOUT4.Location = new System.Drawing.Point(92, 147);
            this.textBoxOUT4.Name = "textBoxOUT4";
            this.textBoxOUT4.Size = new System.Drawing.Size(100, 30);
            this.textBoxOUT4.TabIndex = 1;
            this.textBoxOUT4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "x1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "x2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "x3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 24);
            this.label10.TabIndex = 1;
            this.label10.Text = "x4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(203, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 24);
            this.label14.TabIndex = 1;
            this.label14.Text = "Output";
            // 
            // richTextBoxOutPredict
            // 
            this.richTextBoxOutPredict.Location = new System.Drawing.Point(12, 225);
            this.richTextBoxOutPredict.Name = "richTextBoxOutPredict";
            this.richTextBoxOutPredict.Size = new System.Drawing.Size(488, 416);
            this.richTextBoxOutPredict.TabIndex = 3;
            this.richTextBoxOutPredict.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(313, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "w3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(313, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 24);
            this.label12.TabIndex = 1;
            this.label12.Text = "w4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(313, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 24);
            this.label13.TabIndex = 1;
            this.label13.Text = "w2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(313, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 24);
            this.label15.TabIndex = 1;
            this.label15.Text = "w1";
            // 
            // textBoxW4
            // 
            this.textBoxW4.Location = new System.Drawing.Point(351, 144);
            this.textBoxW4.Name = "textBoxW4";
            this.textBoxW4.Size = new System.Drawing.Size(100, 30);
            this.textBoxW4.TabIndex = 1;
            this.textBoxW4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxW2
            // 
            this.textBoxW2.Location = new System.Drawing.Point(351, 72);
            this.textBoxW2.Name = "textBoxW2";
            this.textBoxW2.Size = new System.Drawing.Size(100, 30);
            this.textBoxW2.TabIndex = 1;
            this.textBoxW2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxW1
            // 
            this.textBoxW1.Location = new System.Drawing.Point(351, 36);
            this.textBoxW1.Name = "textBoxW1";
            this.textBoxW1.Size = new System.Drawing.Size(100, 30);
            this.textBoxW1.TabIndex = 1;
            this.textBoxW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxW3
            // 
            this.textBoxW3.Location = new System.Drawing.Point(351, 108);
            this.textBoxW3.Name = "textBoxW3";
            this.textBoxW3.Size = new System.Drawing.Size(100, 30);
            this.textBoxW3.TabIndex = 1;
            this.textBoxW3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(62, 662);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(130, 60);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(321, 662);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(130, 60);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1831, 897);
            this.Controls.Add(this.groupBoxPredict);
            this.Controls.Add(this.groupBoxTrain);
            this.Name = "Form1";
            this.Text = "Single Perceptron Training ";
            this.groupBoxTrain.ResumeLayout(false);
            this.groupBoxTrain.PerformLayout();
            this.groupBoxPredict.ResumeLayout(false);
            this.groupBoxPredict.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTrainX4;
        private System.Windows.Forms.TextBox textBoxTrainX3;
        private System.Windows.Forms.TextBox textBoxTrainX2;
        private System.Windows.Forms.TextBox textBoxTrainX1;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.GroupBox groupBoxPredict;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelLearn;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.TextBox textBoxLearnRate;
        private System.Windows.Forms.TextBox textBoxThresholdTrain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEpoch;
        private System.Windows.Forms.RichTextBox richTextBoxOutPredict;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxW3;
        private System.Windows.Forms.TextBox textBoxOUT3;
        private System.Windows.Forms.TextBox textBoxW1;
        private System.Windows.Forms.TextBox textBoxOUT1;
        private System.Windows.Forms.TextBox textBoxW2;
        private System.Windows.Forms.TextBox textBoxW4;
        private System.Windows.Forms.TextBox textBoxOUT2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxOUT4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonStart;
    }
}

