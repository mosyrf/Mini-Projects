namespace ATS
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBoxSerialPort = new System.Windows.Forms.TextBox();
            this.textBoxWaterLevel = new System.Windows.Forms.TextBox();
            this.labelWaterLevel = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonIndicator = new System.Windows.Forms.Button();
            this.labelWaterIndicator = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.chartData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerialPort.Location = new System.Drawing.Point(12, 9);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(94, 19);
            this.labelSerialPort.TabIndex = 0;
            this.labelSerialPort.Text = "Serial Port:";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // textBoxSerialPort
            // 
            this.textBoxSerialPort.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSerialPort.Location = new System.Drawing.Point(16, 36);
            this.textBoxSerialPort.Name = "textBoxSerialPort";
            this.textBoxSerialPort.Size = new System.Drawing.Size(113, 22);
            this.textBoxSerialPort.TabIndex = 1;
            this.textBoxSerialPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxWaterLevel
            // 
            this.textBoxWaterLevel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWaterLevel.Location = new System.Drawing.Point(16, 101);
            this.textBoxWaterLevel.Name = "textBoxWaterLevel";
            this.textBoxWaterLevel.Size = new System.Drawing.Size(113, 22);
            this.textBoxWaterLevel.TabIndex = 3;
            this.textBoxWaterLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelWaterLevel
            // 
            this.labelWaterLevel.AutoSize = true;
            this.labelWaterLevel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaterLevel.Location = new System.Drawing.Point(12, 74);
            this.labelWaterLevel.Name = "labelWaterLevel";
            this.labelWaterLevel.Size = new System.Drawing.Size(84, 19);
            this.labelWaterLevel.TabIndex = 2;
            this.labelWaterLevel.Text = "Level (m):";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Lime;
            this.buttonStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(27, 141);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(88, 43);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Red;
            this.buttonStop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(27, 205);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(88, 43);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Yellow;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(679, 205);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 43);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonIndicator
            // 
            this.buttonIndicator.BackColor = System.Drawing.Color.Lime;
            this.buttonIndicator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIndicator.Location = new System.Drawing.Point(696, 14);
            this.buttonIndicator.Name = "buttonIndicator";
            this.buttonIndicator.Size = new System.Drawing.Size(63, 33);
            this.buttonIndicator.TabIndex = 4;
            this.buttonIndicator.UseVisualStyleBackColor = false;
            // 
            // labelWaterIndicator
            // 
            this.labelWaterIndicator.AutoSize = true;
            this.labelWaterIndicator.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaterIndicator.Location = new System.Drawing.Point(688, 55);
            this.labelWaterIndicator.Name = "labelWaterIndicator";
            this.labelWaterIndicator.Size = new System.Drawing.Size(79, 19);
            this.labelWaterIndicator.TabIndex = 0;
            this.labelWaterIndicator.Text = "NORMAL";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1345, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // chartData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartData.Legends.Add(legend1);
            this.chartData.Location = new System.Drawing.Point(135, 9);
            this.chartData.Name = "chartData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "WATER LEVEL";
            this.chartData.Series.Add(series1);
            this.chartData.Size = new System.Drawing.Size(538, 258);
            this.chartData.TabIndex = 5;
            this.chartData.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 279);
            this.Controls.Add(this.chartData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonIndicator);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxWaterLevel);
            this.Controls.Add(this.labelWaterLevel);
            this.Controls.Add(this.labelWaterIndicator);
            this.Controls.Add(this.textBoxSerialPort);
            this.Controls.Add(this.labelSerialPort);
            this.Name = "Form1";
            this.Text = "Water Level Monitoring";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSerialPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBoxSerialPort;
        private System.Windows.Forms.TextBox textBoxWaterLevel;
        private System.Windows.Forms.Label labelWaterLevel;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonIndicator;
        private System.Windows.Forms.Label labelWaterIndicator;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartData;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

