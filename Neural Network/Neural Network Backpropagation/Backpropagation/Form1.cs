using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Backpropagation
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized; 
            InitializeChart();
        }

        private void InitializeChart()
        {
            chartError.Series.Clear();
            Series series = new Series("Error");
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Red;
            chartError.Series.Add(series);
            chartError.ChartAreas[0].AxisX.Title = "Epoch";
            chartError.ChartAreas[0].AxisY.Title = "Error";
        }

        private NeuralNetwork nn;
        private List<TrainingData> trainingData = new List<TrainingData>();

        private void buttonLoadInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                trainingData.Clear();
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 5)
                    {
                        trainingData.Add(new TrainingData(
                            double.Parse(parts[1]),
                            double.Parse(parts[2]),
                            double.Parse(parts[3]),
                            double.Parse(parts[4])
                        ));
                    }
                }
                MessageBox.Show(string.Format("Loaded {0} training data points", trainingData.Count),
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void buttonTraining_Click(object sender, EventArgs e)
        {
            if (trainingData.Count == 0)
            {
                MessageBox.Show("Please load training data first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse parameters
            int hiddenNodes = int.Parse(textBoxHiddenNode.Text);
            double tolerance = double.Parse(textBoxToleransiError.Text);
            double learningRate = double.Parse(textBoxLearnRate.Text);
            int maxEpoch = int.Parse(textBoxEpoch.Text);

            nn = new NeuralNetwork(hiddenNodes, learningRate);
            List<double> errors = nn.Train(trainingData, tolerance, maxEpoch);

            // Display weights
            DisplayWeights();

            // Display errors
            richTextBoxError.Clear();
            foreach (double error in errors)
            {
                richTextBoxError.AppendText(string.Format("{0:F6}\n", error));
            }

            // Update final error
            textBoxError.Text = errors.Count > 0 ?
                string.Format("{0:F6}", errors[errors.Count - 1]) :
                "N/A";

            // Update chart
            UpdateErrorChart(errors);
        }

        private void DisplayWeights()
        {
            // Display W weights
            richTextBoxWN.Clear();
            for (int i = 0; i < nn.W.GetLength(0); i++)
            {
                for (int j = 0; j < nn.W.GetLength(1); j++)
                {
                    richTextBoxWN.AppendText(string.Format("{0:F4}\t", nn.W[i, j]));
                }
                richTextBoxWN.AppendText("\n");
            }

            // Display V weights
            richTextBoxVN.Clear();
            for (int i = 0; i < nn.V.GetLength(0); i++)
            {
                for (int j = 0; j < nn.V.GetLength(1); j++)
                {
                    richTextBoxVN.AppendText(string.Format("{0:F4}\t", nn.V[i, j]));
                }
                richTextBoxVN.AppendText("\n");
            }
        }

        private void UpdateErrorChart(List<double> errors)
        {
            chartError.Series[0].Points.Clear();
            for (int i = 0; i < errors.Count; i++)
            {
                chartError.Series[0].Points.AddXY(i + 1, errors[i]);
            }
            chartError.Update();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (nn == null)
            {
                MessageBox.Show("Please train the network first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse input dengan format yang benar
            double x1 = double.Parse(textBoxIN1.Text, System.Globalization.CultureInfo.InvariantCulture);
            double x2 = double.Parse(textBoxIN2.Text, System.Globalization.CultureInfo.InvariantCulture);

            double[] output = nn.FeedForward(x1, x2);

            // Output weight untuk masing-masing output
            textBoxOUTweightX1.Text = string.Format("{0:F4}", output[0]);
            textBoxOUTweightX2.Text = string.Format("{0:F4}", output[1]);

            // Output logika untuk masing-masing output
            int logic1 = (output[0] >= 0.5) ? 1 : 0;
            int logic2 = (output[1] >= 0.5) ? 1 : 0;
            textBoxOUTX1.Text = logic1.ToString();
            textBoxOUTX2.Text = logic2.ToString();
        }
    }

    public class TrainingData
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Output1 { get; set; }
        public double Output2 { get; set; }

        public TrainingData(double x1, double x2, double output1, double output2)
        {
            X1 = x1;
            X2 = x2;
            Output1 = output1;
            Output2 = output2;
        }
    }

    public class NeuralNetwork
    {
        private readonly int inputSize = 3; // Input + bias
        private readonly int hiddenSize;
        private readonly int outputSize = 2;
        private readonly double learningRate;

        public double[,] W; // Input to hidden weights
        public double[,] V; // Hidden to output weights

        public NeuralNetwork(int hiddenNodes, double lr)
        {
            hiddenSize = hiddenNodes;
            learningRate = lr;
            InitializeWeights();
        }

        private void InitializeWeights()
        {
            Random rand = new Random();

            // Initialize W (input to hidden)
            W = new double[inputSize, hiddenSize];
            for (int i = 0; i < inputSize; i++)
                for (int j = 0; j < hiddenSize; j++)
                    W[i, j] = rand.NextDouble() * 2 - 1; // [-1, 1]

            // Initialize V (hidden to output)
            V = new double[hiddenSize + 1, outputSize]; // +1 for hidden bias
            for (int i = 0; i < hiddenSize + 1; i++)
                for (int j = 0; j < outputSize; j++)
                    V[i, j] = rand.NextDouble() * 2 - 1;
        }

        public double[] FeedForward(double x1, double x2)
        {
            // Input layer
            double[] inputs = { 1.0, x1, x2 }; // Bias included

            // Hidden layer
            double[] hiddenOutputs = new double[hiddenSize + 1];
            hiddenOutputs[0] = 1.0; // Hidden bias
            for (int j = 0; j < hiddenSize; j++)
            {
                double sum = 0;
                for (int i = 0; i < inputSize; i++)
                    sum += inputs[i] * W[i, j];
                hiddenOutputs[j + 1] = Sigmoid(sum);
            }

            // Output layer
            double[] outputs = new double[outputSize];
            for (int k = 0; k < outputSize; k++)
            {
                double sum = 0;
                for (int j = 0; j < hiddenSize + 1; j++)
                    sum += hiddenOutputs[j] * V[j, k];
                outputs[k] = Sigmoid(sum);
            }

            return outputs;
        }

        public List<double> Train(List<TrainingData> trainingSet, double tolerance, int maxEpoch)
        {
            List<double> epochErrors = new List<double>();

            for (int epoch = 0; epoch < maxEpoch; epoch++)
            {
                double totalError = 0;

                foreach (TrainingData data in trainingSet)
                {
                    // Feedforward
                    double[] inputs = { 1.0, data.X1, data.X2 };
                    double[] hiddenOutputs = new double[hiddenSize + 1];
                    hiddenOutputs[0] = 1.0; // Hidden bias
                    double[] hiddenSums = new double[hiddenSize];

                    // Calculate hidden layer
                    for (int j = 0; j < hiddenSize; j++)
                    {
                        double sum = 0;
                        for (int i = 0; i < inputSize; i++)
                            sum += inputs[i] * W[i, j];
                        hiddenSums[j] = sum;
                        hiddenOutputs[j + 1] = Sigmoid(sum);
                    }

                    // Calculate output layer
                    double[] outputs = new double[outputSize];
                    double[] outputSums = new double[outputSize];
                    for (int k = 0; k < outputSize; k++)
                    {
                        double sum = 0;
                        for (int j = 0; j < hiddenSize + 1; j++)
                            sum += hiddenOutputs[j] * V[j, k];
                        outputSums[k] = sum;
                        outputs[k] = Sigmoid(sum);
                    }

                    // Calculate error
                    double[] targets = { data.Output1, data.Output2 };
                    double error = 0.5 * (Math.Pow(targets[0] - outputs[0], 2) + Math.Pow(targets[1] - outputs[1], 2));
                    totalError += error;

                    // Backpropagation
                    // Output layer deltas
                    double[] deltaOutput = new double[outputSize];
                    for (int k = 0; k < outputSize; k++)
                    {
                        double errorDerivative = targets[k] - outputs[k];
                        double activationDerivative = SigmoidDerivative(outputs[k]);
                        deltaOutput[k] = errorDerivative * activationDerivative;
                    }

                    // Hidden layer deltas
                    double[] deltaHidden = new double[hiddenSize];
                    for (int j = 0; j < hiddenSize; j++)
                    {
                        double sum = 0;
                        for (int k = 0; k < outputSize; k++)
                        {
                            sum += deltaOutput[k] * V[j + 1, k];
                        }
                        deltaHidden[j] = sum * SigmoidDerivative(hiddenOutputs[j + 1]);
                    }

                    // Update V weights (hidden to output)
                    for (int j = 0; j < hiddenSize + 1; j++)
                    {
                        for (int k = 0; k < outputSize; k++)
                        {
                            V[j, k] += learningRate * deltaOutput[k] * hiddenOutputs[j];
                        }
                    }

                    // Update W weights (input to hidden)
                    for (int i = 0; i < inputSize; i++)
                    {
                        for (int j = 0; j < hiddenSize; j++)
                        {
                            W[i, j] += learningRate * deltaHidden[j] * inputs[i];
                        }
                    }
                }

                double averageError = totalError / trainingSet.Count;
                epochErrors.Add(averageError);

                if (averageError <= tolerance)
                    break;
            }

            return epochErrors;
        }

        private double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        private double SigmoidDerivative(double x)
        {
            double s = Sigmoid(x);
            return s * (1 - s);
        }
    }
}
