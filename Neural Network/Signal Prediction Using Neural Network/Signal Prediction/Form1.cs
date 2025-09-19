using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Signal_Prediction
{

    public partial class Form1 : Form
    {
        Random rand = new Random();
        int N = 1000;
        double[] X1, X2, Y;
        double[] Y_pred;

        NeuralNetwork nn;


        public Form1()
        {
            WindowState = FormWindowState.Maximized; 
            InitializeComponent();
        }

        private void buttonGeneSig_Click(object sender, EventArgs e)
        {
            X1 = new double[N];
            X2 = new double[N];
            Y = new double[N];

            chartRandomSignal.Series[0].Points.Clear();
            chartRandomSignal.Series[0].ChartType = SeriesChartType.Spline;
            chartRandomSignal.ChartAreas[0].AxisX.Title = "Sample";
            chartRandomSignal.ChartAreas[0].AxisY.Title = "Amplitude";

            for (int i = 0; i < N; i += 10)
            {
                X1[i] = rand.NextDouble();
                X2[i] = rand.NextDouble();
                Y[i] = 0.5 * X1[i] + 0.3 * X2[i] + rand.NextDouble() * 0.1;
                chartRandomSignal.Series[0].Points.AddXY(i + 1, Y[i] * 100);
            }
        }

        private void buttonResSig_Click(object sender, EventArgs e)
        {
            chartRandomSignal.Series[0].Points.Clear(); 
        }

        private void buttonTraining_Click(object sender, EventArgs e)
        {
            int hidden = int.Parse(textBoxHiddenNode.Text);
            double lr = double.Parse(textBoxLearningRate.Text);
            int epoch = int.Parse(textBoxEpoch.Text);

            nn = new NeuralNetwork(hidden, lr);
            double loss = nn.Train(X1, X2, Y, epoch); 

            richTextBoxOutput.Clear();
            richTextBoxOutput.AppendText("Training Complete.\n");
            richTextBoxOutput.AppendText("Loss: " + loss.ToString("F6") + "\n");
        }

        private void buttonExeResult_Click(object sender, EventArgs e)
        {
            if (nn == null)
            {
                MessageBox.Show("Model belum dilatih!");
                return;
            }

            Y_pred = nn.Predict(X1, X2);
            chartExeSignal.Series[0].Points.Clear();
            chartExeSignal.Series[0].ChartType = SeriesChartType.Spline;
            chartExeSignal.ChartAreas[0].AxisX.Title = "Sample";
            chartExeSignal.ChartAreas[0].AxisY.Title = "Predicted Amplitude";

            for (int i = 0; i < N; i += 10)
            {
                if (i % 10 == 0)
                    chartExeSignal.Series[0].Points.AddXY(i + 1, Y_pred[i] * 100);
            }

            richTextBoxOutput.AppendText("Predicted Signal (Y_pred):\r\n");
            for (int i = 0; i < N; i++)
            {
                richTextBoxOutput.AppendText(string.Format("n = {0}, Y_pred = {1:F3}\r\n", i + 1, Y_pred[i] * 100));
            }

        }

        private void buttonExeReset_Click(object sender, EventArgs e)
        {
            chartExeSignal.Series[0].Points.Clear();
        }
    }
}

public class NeuralNetwork
{
    int inputSize = 2;
    int hiddenSize;
    double learningRate;

    double[] hiddenWeights;
    double[] outputWeights;
    double hiddenBias, outputBias;

    Random rand = new Random();

    public NeuralNetwork(int hiddenSize, double learningRate)
    {
        this.hiddenSize = hiddenSize;
        this.learningRate = learningRate;

        hiddenWeights = new double[hiddenSize * inputSize];
        outputWeights = new double[hiddenSize];

        for (int i = 0; i < hiddenWeights.Length; i++)
            hiddenWeights[i] = rand.NextDouble() - 0.5;
        for (int i = 0; i < outputWeights.Length; i++)
            outputWeights[i] = rand.NextDouble() - 0.5;

        hiddenBias = rand.NextDouble() - 0.5;
        outputBias = rand.NextDouble() - 0.5;
    }

    private double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x));
    }

    private double SigmoidDerivative(double x)
    {
        return x * (1 - x);
    }

    public double Train(double[] x1, double[] x2, double[] y, int epoch)
    {
        int n = x1.Length;
        double loss = 0;

        for (int e = 0; e < epoch; e++)
        {
            for (int i = 0; i < n; i++)
            {
                double[] inputs = new double[] { x1[i], x2[i] };

                double[] hiddenInputs = new double[hiddenSize];
                double[] hiddenOutputs = new double[hiddenSize];

                for (int h = 0; h < hiddenSize; h++)
                {
                    hiddenInputs[h] = 0;
                    for (int j = 0; j < inputSize; j++)
                        hiddenInputs[h] += inputs[j] * hiddenWeights[h * inputSize + j];
                    hiddenInputs[h] += hiddenBias;
                    hiddenOutputs[h] = Sigmoid(hiddenInputs[h]);
                }

                double outputInput = 0;
                for (int h = 0; h < hiddenSize; h++)
                    outputInput += hiddenOutputs[h] * outputWeights[h];
                outputInput += outputBias;

                double output = Sigmoid(outputInput);
                double error = y[i] - output;
                loss += error * error;

                double dOutput = error * SigmoidDerivative(output);
                for (int h = 0; h < hiddenSize; h++)
                    outputWeights[h] += learningRate * dOutput * hiddenOutputs[h];
                outputBias += learningRate * dOutput;

                for (int h = 0; h < hiddenSize; h++)
                {
                    double dHidden = dOutput * outputWeights[h] * SigmoidDerivative(hiddenOutputs[h]);
                    for (int j = 0; j < inputSize; j++)
                        hiddenWeights[h * inputSize + j] += learningRate * dHidden * inputs[j];
                    hiddenBias += learningRate * dHidden;
                }
            }
        }

        return loss / n;
    }

    public double[] Predict(double[] x1, double[] x2)
    {
        int n = x1.Length;
        double[] predictions = new double[n];

        for (int i = 0; i < n; i++)
        {
            double[] inputs = new double[] { x1[i], x2[i] };
            double[] hiddenOutputs = new double[hiddenSize];

            for (int h = 0; h < hiddenSize; h++)
            {
                double hiddenInput = 0;
                for (int j = 0; j < inputSize; j++)
                    hiddenInput += inputs[j] * hiddenWeights[h * inputSize + j];
                hiddenInput += hiddenBias;
                hiddenOutputs[h] = Sigmoid(hiddenInput);
            }

            double output = 0;
            for (int h = 0; h < hiddenSize; h++)
                output += hiddenOutputs[h] * outputWeights[h];
            output += outputBias;
            predictions[i] = Sigmoid(output);
        }

        return predictions;
    }
}

