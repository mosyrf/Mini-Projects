using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural_Network_Basic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void buttonResetAND_Click(object sender, EventArgs e)
        {
            // Reset all inputs to default values
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            numericUpDownX1AND.Value = 0;
            numericUpDownX2AND.Value = 0;
            numericUpDownX3AND.Value = 0;
            numericUpDownX4AND.Value = 0;

            textBoxThresholdAND.Text = "0";
            labelHasil.Text = "Hasil Akan Muncul Di Bagian Ini..................................";
        }

        private void buttonCalculateAND_Click(object sender, EventArgs e)
        {
            try
            {
                // Get binary inputs from checkboxes
                int x1 = checkBox1.Checked ? 1 : 0;
                int x2 = checkBox2.Checked ? 1 : 0;
                int x3 = checkBox3.Checked ? 1 : 0;
                int x4 = checkBox4.Checked ? 1 : 0;

                // Get weights from numeric up-down controls
                double w1 = (double)numericUpDownX1AND.Value;
                double w2 = (double)numericUpDownX2AND.Value;
                double w3 = (double)numericUpDownX3AND.Value;
                double w4 = (double)numericUpDownX4AND.Value;

                // Get threshold value
                double threshold;
                if (!double.TryParse(textBoxThresholdAND.Text, out threshold))
                {
                    labelHasil.Text = "Error: Threshold harus berupa angka!";
                    return;
                }

                // Calculate activation
                double activation = (x1 * w1) + (x2 * w2) + (x3 * w3) + (x4 * w4);

                // Step activation function
                bool isAND = (x1 == 1 && x2 == 1 && x3 == 1 && x4 == 1);
                bool outVal = (activation >= threshold) && isAND;

                bool outputBOOL = outVal ? true : false;
                int outputINT = outVal ? 1 : 0;

                // Display result in label
                labelHasil.Text = string.Format(
                    "Hasil: {1}  ({0}) \n\n\t(Aktivasi: {2})\nDetail Perhitungan:\n" +
                    "({3} × {4:F2}) + ({5} × {6:F2}) + ({7} × {8:F2}) + ({9} × {10:F2}) = {2:F2}",
                    outputBOOL, outputINT, activation, x1, w1, x2, w2, x3, w3, x4, w4);
            }
            catch (Exception ex)
            {
                labelHasil.Text = "Error dalam perhitungan: " + ex.Message;
            }
        }

        private void buttonResetOR_Click(object sender, EventArgs e)
        {
            // Reset all inputs to default values
            checkBox8.Checked = false;
            checkBox7.Checked = false;
            checkBox6.Checked = false;

            numericUpDown4.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown2.Value = 0;

            textBoxThresholdOR.Text = "0";
            labelHasilOR.Text = "Hasil Akan Muncul Di Bagian Ini..................................";
        }

        private void buttonCalculateOR_Click(object sender, EventArgs e)
        {
            try
            {
             // Get binary inputs from checkboxes
                int x1 = checkBox8.Checked ? 1 : 0;
                int x2 = checkBox7.Checked ? 1 : 0;
                int x3 = checkBox6.Checked ? 1 : 0;

                // Get weights from numeric up-down controls
                double w1 = (double)numericUpDown4.Value;
                double w2 = (double)numericUpDown3.Value;
                double w3 = (double)numericUpDown2.Value;

                // Get threshold value
                double threshold;
                if (!double.TryParse(textBoxThresholdOR.Text, out threshold))
                {
                    labelHasilOR.Text = "Error: Threshold harus berupa angka!";
                    return;
                }

                // Calculate activation
                double activation = (x1 * w1) + (x2 * w2) + (x3 * w3);

                // Step activation function
                bool isOR = (x1 == 1 || x2 == 1 || x3 == 1);
                bool outVal = (activation >= threshold) && isOR;

                bool outputBOOL = outVal ? true : false;
                int outputINT = outVal ? 1 : 0;

                // Display result in label
                labelHasilOR.Text = string.Format(
                    "Hasil: {1}  ({0}) \n\n\t(Aktivasi: {2})\nDetail Perhitungan:\n" +
                    "({3} × {4:F2}) + ({5} × {6:F2}) + ({7} × {8:F2}) = {2:F2}",
                    outputBOOL, outputINT, activation, x1, w1, x2, w2, x3, w3);
            }
            catch (Exception ex)
            {
                labelHasilOR.Text = "Error dalam perhitungan: " + ex.Message;
            }
        }
    }
}
