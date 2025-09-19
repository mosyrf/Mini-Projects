namespace Neural_Network_Basic
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
            this.groupBoxAND = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelHasil = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxThresholdAND = new System.Windows.Forms.TextBox();
            this.numericUpDownX4AND = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX3AND = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX2AND = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX1AND = new System.Windows.Forms.NumericUpDown();
            this.buttonCalculateAND = new System.Windows.Forms.Button();
            this.buttonResetAND = new System.Windows.Forms.Button();
            this.groupBoxOR = new System.Windows.Forms.GroupBox();
            this.buttonResetOR = new System.Windows.Forms.Button();
            this.buttonCalculateOR = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.labelHasilOR = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxThresholdOR = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.groupBoxAND.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX4AND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX3AND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX2AND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX1AND)).BeginInit();
            this.groupBoxOR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAND
            // 
            this.groupBoxAND.Controls.Add(this.checkBox4);
            this.groupBoxAND.Controls.Add(this.checkBox3);
            this.groupBoxAND.Controls.Add(this.checkBox2);
            this.groupBoxAND.Controls.Add(this.checkBox1);
            this.groupBoxAND.Controls.Add(this.labelHasil);
            this.groupBoxAND.Controls.Add(this.label2);
            this.groupBoxAND.Controls.Add(this.label1);
            this.groupBoxAND.Controls.Add(this.textBoxThresholdAND);
            this.groupBoxAND.Controls.Add(this.numericUpDownX4AND);
            this.groupBoxAND.Controls.Add(this.numericUpDownX3AND);
            this.groupBoxAND.Controls.Add(this.numericUpDownX2AND);
            this.groupBoxAND.Controls.Add(this.numericUpDownX1AND);
            this.groupBoxAND.Controls.Add(this.buttonCalculateAND);
            this.groupBoxAND.Controls.Add(this.buttonResetAND);
            this.groupBoxAND.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAND.Location = new System.Drawing.Point(88, 108);
            this.groupBoxAND.Name = "groupBoxAND";
            this.groupBoxAND.Size = new System.Drawing.Size(650, 640);
            this.groupBoxAND.TabIndex = 1;
            this.groupBoxAND.TabStop = false;
            this.groupBoxAND.Text = "4 Input AND Logic";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(141, 234);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(119, 33);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Input 4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(141, 180);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(119, 33);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Input 3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(141, 130);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(119, 33);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Input 2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(141, 79);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 33);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Input 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // labelHasil
            // 
            this.labelHasil.AutoSize = true;
            this.labelHasil.Location = new System.Drawing.Point(22, 477);
            this.labelHasil.Name = "labelHasil";
            this.labelHasil.Size = new System.Drawing.Size(619, 29);
            this.labelHasil.TabIndex = 2;
            this.labelHasil.Text = "Hasil Akan Muncul Di Bagian Ini..................................";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Weight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Threshold";
            // 
            // textBoxThresholdAND
            // 
            this.textBoxThresholdAND.Location = new System.Drawing.Point(219, 336);
            this.textBoxThresholdAND.Name = "textBoxThresholdAND";
            this.textBoxThresholdAND.Size = new System.Drawing.Size(150, 35);
            this.textBoxThresholdAND.TabIndex = 2;
            this.textBoxThresholdAND.Text = "0";
            this.textBoxThresholdAND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownX4AND
            // 
            this.numericUpDownX4AND.Location = new System.Drawing.Point(354, 234);
            this.numericUpDownX4AND.Name = "numericUpDownX4AND";
            this.numericUpDownX4AND.Size = new System.Drawing.Size(94, 35);
            this.numericUpDownX4AND.TabIndex = 2;
            this.numericUpDownX4AND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownX3AND
            // 
            this.numericUpDownX3AND.Location = new System.Drawing.Point(354, 180);
            this.numericUpDownX3AND.Name = "numericUpDownX3AND";
            this.numericUpDownX3AND.Size = new System.Drawing.Size(94, 35);
            this.numericUpDownX3AND.TabIndex = 2;
            this.numericUpDownX3AND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownX2AND
            // 
            this.numericUpDownX2AND.Location = new System.Drawing.Point(354, 130);
            this.numericUpDownX2AND.Name = "numericUpDownX2AND";
            this.numericUpDownX2AND.Size = new System.Drawing.Size(94, 35);
            this.numericUpDownX2AND.TabIndex = 2;
            this.numericUpDownX2AND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownX1AND
            // 
            this.numericUpDownX1AND.Location = new System.Drawing.Point(354, 79);
            this.numericUpDownX1AND.Name = "numericUpDownX1AND";
            this.numericUpDownX1AND.Size = new System.Drawing.Size(94, 35);
            this.numericUpDownX1AND.TabIndex = 2;
            this.numericUpDownX1AND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCalculateAND
            // 
            this.buttonCalculateAND.Location = new System.Drawing.Point(165, 388);
            this.buttonCalculateAND.Name = "buttonCalculateAND";
            this.buttonCalculateAND.Size = new System.Drawing.Size(100, 50);
            this.buttonCalculateAND.TabIndex = 2;
            this.buttonCalculateAND.Text = "Start";
            this.buttonCalculateAND.UseVisualStyleBackColor = true;
            this.buttonCalculateAND.Click += new System.EventHandler(this.buttonCalculateAND_Click);
            // 
            // buttonResetAND
            // 
            this.buttonResetAND.Location = new System.Drawing.Point(330, 388);
            this.buttonResetAND.Name = "buttonResetAND";
            this.buttonResetAND.Size = new System.Drawing.Size(100, 50);
            this.buttonResetAND.TabIndex = 2;
            this.buttonResetAND.Text = "Reset";
            this.buttonResetAND.UseVisualStyleBackColor = true;
            this.buttonResetAND.Click += new System.EventHandler(this.buttonResetAND_Click);
            // 
            // groupBoxOR
            // 
            this.groupBoxOR.Controls.Add(this.buttonResetOR);
            this.groupBoxOR.Controls.Add(this.buttonCalculateOR);
            this.groupBoxOR.Controls.Add(this.checkBox6);
            this.groupBoxOR.Controls.Add(this.checkBox7);
            this.groupBoxOR.Controls.Add(this.checkBox8);
            this.groupBoxOR.Controls.Add(this.labelHasilOR);
            this.groupBoxOR.Controls.Add(this.label4);
            this.groupBoxOR.Controls.Add(this.label5);
            this.groupBoxOR.Controls.Add(this.textBoxThresholdOR);
            this.groupBoxOR.Controls.Add(this.numericUpDown2);
            this.groupBoxOR.Controls.Add(this.numericUpDown3);
            this.groupBoxOR.Controls.Add(this.numericUpDown4);
            this.groupBoxOR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOR.Location = new System.Drawing.Point(1080, 108);
            this.groupBoxOR.Name = "groupBoxOR";
            this.groupBoxOR.Size = new System.Drawing.Size(650, 640);
            this.groupBoxOR.TabIndex = 1;
            this.groupBoxOR.TabStop = false;
            this.groupBoxOR.Text = "3 Input OR Logic";
            // 
            // buttonResetOR
            // 
            this.buttonResetOR.Location = new System.Drawing.Point(338, 389);
            this.buttonResetOR.Name = "buttonResetOR";
            this.buttonResetOR.Size = new System.Drawing.Size(100, 50);
            this.buttonResetOR.TabIndex = 3;
            this.buttonResetOR.Text = "Reset";
            this.buttonResetOR.UseVisualStyleBackColor = true;
            this.buttonResetOR.Click += new System.EventHandler(this.buttonResetOR_Click);
            // 
            // buttonCalculateOR
            // 
            this.buttonCalculateOR.Location = new System.Drawing.Point(162, 389);
            this.buttonCalculateOR.Name = "buttonCalculateOR";
            this.buttonCalculateOR.Size = new System.Drawing.Size(100, 50);
            this.buttonCalculateOR.TabIndex = 3;
            this.buttonCalculateOR.Text = "Start";
            this.buttonCalculateOR.UseVisualStyleBackColor = true;
            this.buttonCalculateOR.Click += new System.EventHandler(this.buttonCalculateOR_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(141, 180);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(119, 33);
            this.checkBox6.TabIndex = 2;
            this.checkBox6.Text = "Input 3";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(141, 130);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(119, 33);
            this.checkBox7.TabIndex = 2;
            this.checkBox7.Text = "Input 2";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(141, 79);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(119, 33);
            this.checkBox8.TabIndex = 2;
            this.checkBox8.Text = "Input 1";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // labelHasilOR
            // 
            this.labelHasilOR.AutoSize = true;
            this.labelHasilOR.Location = new System.Drawing.Point(22, 477);
            this.labelHasilOR.Name = "labelHasilOR";
            this.labelHasilOR.Size = new System.Drawing.Size(619, 29);
            this.labelHasilOR.TabIndex = 2;
            this.labelHasilOR.Text = "Hasil Akan Muncul Di Bagian Ini..................................";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Weight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Threshold";
            // 
            // textBoxThresholdOR
            // 
            this.textBoxThresholdOR.Location = new System.Drawing.Point(219, 336);
            this.textBoxThresholdOR.Name = "textBoxThresholdOR";
            this.textBoxThresholdOR.Size = new System.Drawing.Size(150, 35);
            this.textBoxThresholdOR.TabIndex = 2;
            this.textBoxThresholdOR.Text = "0";
            this.textBoxThresholdOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(354, 180);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(94, 35);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(354, 130);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(94, 35);
            this.numericUpDown3.TabIndex = 2;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(354, 79);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(94, 35);
            this.numericUpDown4.TabIndex = 2;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1848, 902);
            this.Controls.Add(this.groupBoxOR);
            this.Controls.Add(this.groupBoxAND);
            this.Name = "Form1";
            this.Text = "Mcculloch-Pitts Neuron Model";
            this.groupBoxAND.ResumeLayout(false);
            this.groupBoxAND.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX4AND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX3AND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX2AND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX1AND)).EndInit();
            this.groupBoxOR.ResumeLayout(false);
            this.groupBoxOR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAND;
        private System.Windows.Forms.Label labelHasil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxThresholdAND;
        private System.Windows.Forms.NumericUpDown numericUpDownX4AND;
        private System.Windows.Forms.NumericUpDown numericUpDownX3AND;
        private System.Windows.Forms.NumericUpDown numericUpDownX2AND;
        private System.Windows.Forms.NumericUpDown numericUpDownX1AND;
        private System.Windows.Forms.Button buttonCalculateAND;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBoxOR;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Label labelHasilOR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxThresholdOR;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Button buttonResetAND;
        private System.Windows.Forms.Button buttonCalculateOR;
        private System.Windows.Forms.Button buttonResetOR;
    }
}

