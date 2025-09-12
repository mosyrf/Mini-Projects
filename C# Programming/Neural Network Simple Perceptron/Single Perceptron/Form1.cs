using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Single_Perceptron
{
    public partial class Form1 : Form
    {
        double[] weights = new double[4]; // 4 input 
        double learningRate;
        int epochs;
        double threshold;

        double[] trainedWeights = new double[4];
        double trainedThreshold = 0.0;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
                weights[i] = rand.NextDouble(); // Inisialisasi bobot acak
        }

        private int Activation(double net)
        {
            return net >= threshold ? 1 : 0;
        }

        private int Predict(double[] inputs)
        {
            double net = 0;
            for (int i = 0; i < 4; i++)
                net += inputs[i] * weights[i];

            return Activation(net);
        }

        private void TrainPerceptron()
        {
            double[][] trainingInputs = new double[][]
            {
                new double[] {0, 0, 0, 0},
                new double[] {0, 0, 0, 1},
                new double[] {0, 0, 1, 0},
                new double[] {0, 0, 1, 1},
                new double[] {0, 1, 0, 0},
                new double[] {0, 1, 0, 1},
                new double[] {0, 1, 1, 0},
                new double[] {0, 1, 1, 1},
                new double[] {1, 0, 0, 0},
                new double[] {1, 0, 0, 1},
                new double[] {1, 0, 1, 0},
                new double[] {1, 0, 1, 1},
                new double[] {1, 1, 0, 0},
                new double[] {1, 1, 0, 1},
                new double[] {1, 1, 1, 0},
                new double[] {1, 1, 1, 1}
            };

            int[] labels = new int[]
            {
                0,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1
            };

            for (int e = 0; e < epochs; e++)
            {
                for (int i = 0; i < trainingInputs.Length; i++)
                {
                    double[] inputs = trainingInputs[i];
                    int target = labels[i];
                    double net = 0;

                    for (int j = 0; j < 4; j++)
                        net += inputs[j] * weights[j];

                    int output = Activation(net);
                    int error = target - output;

                    for (int j = 0; j < 4; j++)
                        weights[j] += learningRate * error * inputs[j];
                }
            }
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            try
            {
                learningRate = double.Parse(textBoxLearnRate.Text);
                epochs = int.Parse(textBoxEpoch.Text);
                threshold = double.Parse(textBoxThresholdTrain.Text);

                TrainPerceptron();

                // Uji output dan tampilkan
                string output = "Training selesai.\n\nPengujian input:\n";

                double[][] testCases = new double[][]
                {
                    new double[] {0, 0, 0, 0},
                    new double[] {0, 0, 0, 1},
                    new double[] {1, 0, 1, 0},
                    new double[] {1, 1, 1, 1},
                    new double[] {0, 1, 0, 0}
                };

                foreach (var test in testCases)
                {
                    double net = 0;
                    for (int i = 0; i < 4; i++)
                        net += test[i] * weights[i];

                    int pred = Activation(net);
                    output += string.Format("Input: [{0}, {1}, {2}, {3}] -> Output: {4}, Net: {5:F3}\n",
                        test[0], test[1], test[2], test[3], pred, net);
                }

                output += "\nBobot akhir:\n";
                for (int i = 0; i < 4; i++)
                    output += string.Format("W{0}: {1:F3}\n", i + 1, weights[i]);

                output += string.Format("Threshold (manual): {0:F3}", threshold);

                richTextBoxOutput.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input tidak valid! Pastikan Learning Rate dan Epoch diisi.\n" + ex.Message);
            }
            // Simpan bobot & threshold ke variabel global
            trainedThreshold = threshold;
            for (int i = 0; i < 4; i++)
            {
                trainedWeights[i] = weights[i];

                TextBox[] textBoxW = new TextBox[] { textBoxW1, textBoxW2, textBoxW3, textBoxW4 };
                textBoxW[i].Text = weights[i].ToString("F3"); // Isi ke TextBox w1-w4 (array textBoxW)
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            double[] x = new double[4];

            // Ambil nilai input x1 - x4
            try
            {
                x[0] = double.Parse(textBoxOUT1.Text);
                x[1] = double.Parse(textBoxOUT2.Text);
                x[2] = double.Parse(textBoxOUT3.Text);
                x[3] = double.Parse(textBoxOUT4.Text);
            }
            catch
            {
                MessageBox.Show("Input tidak valid!");
                return;
            }

            // Hitung net input
            double net = 0;
            for (int i = 0; i < 4; i++)
                net += x[i] * trainedWeights[i];

            // Fungsi aktivasi dengan threshold tetap
            int output = net >= trainedThreshold ? 1 : 0;

            richTextBoxOutPredict.AppendText(string.Format("Input: [{0}, {1}, {2}, {3}]\n", x[0], x[1], x[2], x[3]));
            richTextBoxOutPredict.AppendText(string.Format("Net Input: {0:F3}\n", net));
            richTextBoxOutPredict.AppendText(string.Format("Threshold: {0:F3}\n", trainedThreshold));
            richTextBoxOutPredict.AppendText("Output: " + (output == 1 ? "Benar (1)" : "Salah (0)") + "\n\n");

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxOUT1.Clear(); textBoxOUT2.Clear(); textBoxOUT3.Clear(); textBoxOUT4.Clear();
        }
    }
}
