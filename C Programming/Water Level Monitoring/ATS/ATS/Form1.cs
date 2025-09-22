using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ATS
{
    public partial class Form1 : Form
    {
        String bacaData, teksWaterLevel;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string namaPort = textBoxSerialPort.Text;
            serialPort1.PortName = namaPort;

            try
            {
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("COM TIDAK ADA / MASIH TERPAKAI", "ERROR");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string namaFile = "";
            serialPort1.Close();

            //TEMPAT PENYIMPANAN DATA
            saveFileDialog1.Filter = "Text Document Files (*.TXT) | *.txt | All files (*.*) | *.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                namaFile = saveFileDialog1.FileName;
            }

            //TULIS DATA KE FILE
            StreamWriter file = new StreamWriter(namaFile);
            file.Write("DATA DIAMBIL PADA: " + System.DateTime.Now + "\n");
            file.Write("OLEH MAHASISWA DENGAN NIM: 4242201036\n");
            file.Write("=====================================\n");
            file.Write("#\n");
            file.Write(teksWaterLevel);
            file.Close();

            MessageBox.Show("DATA BERHASIL DISIMPAN", "PESAN");
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            bacaData = serialPort1.ReadLine();
            bacaData = bacaData.Trim();
            //teksWaterLevel = bacaData;
            this.Invoke(new EventHandler(tampilData));
        }

        private void tampilData(object sender, EventArgs e)
        {
            int waterLevel = 0;
            Int32.TryParse(bacaData, out waterLevel);

            chartData.Series.Clear();
            chartData.Series.Add("Water Level");
            chartData.ChartAreas[0].AxisY.Maximum = 30;
            chartData.Series["Water Level"].Points.AddXY("Water", waterLevel);

            textBoxWaterLevel.Text = waterLevel.ToString();
            teksWaterLevel += textBoxWaterLevel.Text + "\n";

            if (waterLevel >= 10)
            {
                buttonIndicator.BackColor = Color.Red;
                labelWaterIndicator.Text = "WARNING";
            }
            else
            {
                buttonIndicator.BackColor = Color.Lime;
                labelWaterIndicator.Text = "NORMAL";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
