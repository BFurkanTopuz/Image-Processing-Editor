using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAZLAB1
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form1 Form1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Bitmap OrjHistogram = new Bitmap(Form1.pictureBox1.Image);
            Bitmap GriHistogram = new Bitmap(Form1.pictureBox1.Image);
            for (int i = 0; i < GriHistogram.Width; i++)
            {
                for (int j = 0; j < GriHistogram.Height; j++)
                {
                    var orjinaRenk = GriHistogram.GetPixel(i, j);
                    var griTon = (int)((orjinaRenk.R * 0.3) + (orjinaRenk.G * 0.59) + (orjinaRenk.B * 0.11));
                    var griRenk = Color.FromArgb(griTon, griTon, griTon);
                    GriHistogram.SetPixel(i, j, griRenk);
                }

            }
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            int[] G_kirmizi = new int[256];
            int[] G_yesil = new int[256];
            int[] G_mavi = new int[256];
            // Orjinal Resimin Histogram Değerlerinin Bulunması
            for (int i = 0; i < OrjHistogram.Width; i++)
            {
                for (int j = 0; j < OrjHistogram.Height; j++)
                {
                    Color renk = OrjHistogram.GetPixel(i, j);
                    kirmizi[renk.R]++;
                    yesil[renk.G]++;
                    mavi[renk.B]++;
                }
            }
            //Gri Resmin Histogram Değerlerinin Bulunması
            for (int i = 0; i < GriHistogram.Width; i++)
            {
                for (int j = 0; j < GriHistogram.Height; j++)
                {
                    Color G_renk = GriHistogram.GetPixel(i, j);
                    G_kirmizi[G_renk.R]++;
                    G_yesil[G_renk.G]++;
                    G_mavi[G_renk.B]++;
                }
            }
            //Orjinal Histogram Değerlerinin Grafikte gösterilmesi -> TAB Control Orjinal Histogram
            for (int i = 0; i < 256; i++)
            {
                chart1.Series["KIRMIZI"].Points.AddXY(i + 1, kirmizi[i]);
                chart1.Series["YEŞİL"].Points.AddXY(i + 1, yesil[i]);
                chart1.Series["MAVİ"].Points.AddXY(i + 1, mavi[i]);
            }
            chart1.ChartAreas["ChartArea1"].AxisY.Name = "Frekans";
            chart1.ChartAreas["ChartArea1"].AxisX.Name = "Renk Değeri";
            //Gri Histogram Değerlerinin Grafite Gösterilmesi -> TAB Control Gri Histogram
            for (int i = 0; i < 256; i++)
            {
                chart2.Series["KIRMIZI"].Points.AddXY(i + 1, G_kirmizi[i]);
                chart2.Series["YEŞİL"].Points.AddXY(i + 1, G_yesil[i]);
                chart2.Series["MAVİ"].Points.AddXY(i + 1, G_mavi[i]);
            }
            chart2.ChartAreas[0].AxisX.Maximum = 256;
            chart2.ChartAreas[0].AxisY.Name = "Frekans";
            chart2.ChartAreas[0].AxisX.Name = "Renk Değeri";
            
        }
    }
}
