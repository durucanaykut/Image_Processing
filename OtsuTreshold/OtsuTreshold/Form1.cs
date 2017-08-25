using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;

namespace OtsuTreshold
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = (Bitmap)System.Drawing.Image.FromFile(openFileDialog1.FileName);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Bitmap FiltreliResim, KaynakResim;
            OtsuThreshold OtsuFiltre = new OtsuThreshold();

            KaynakResim = (Bitmap)pictureBox1.Image;
            FiltreliResim = OtsuFiltre.Apply(KaynakResim.PixelFormat != PixelFormat.Format8bppIndexed ? Grayscale.CommonAlgorithms.BT709.Apply(KaynakResim) : KaynakResim);
            pictureBox2.Image = FiltreliResim;

            this.Text = "Threshold Değeri : " + OtsuFiltre.ThresholdValue.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
