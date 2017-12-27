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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form2 FrmHistogram;
        public Form1()
        {
            FrmHistogram = new Form2();
            InitializeComponent();
            FrmHistogram.Form1 = this;
            button1.Enabled = false;
            button3.Enabled = false;
            hScrollBar1.Visible = false;
        }
        bool varMI = false;
        bool dönmeSayısı = false;
        public Image İlkresim = null;
        Bitmap OrjResim;
        Image İslenenResim = null;
        Bitmap İslenenResim2;
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = OrjResim;
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpPiksel_Deger = bmp.GetPixel(i, j);
                    bmpPiksel_Deger = Color.FromArgb(255 - bmpPiksel_Deger.R, 255 - bmpPiksel_Deger.G, 255 - bmpPiksel_Deger.B);
                    bmp.SetPixel(i, j, bmpPiksel_Deger);


                }
            }
 
            pictureBox1.Image = bmp;
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pnlHi.Width==223&pnlHi.Height== 620)
            {
                //size 1090; 561
                //location 84; 21
                pictureBox1.Location = new Point(84, 21);
                pictureBox2.Location = new Point(84, 21);
                pictureBox1.Width = 1114;
                pictureBox2.Width = 1114;
                pictureBox1.Height = 561;
                pictureBox2.Height = 561;
                pnlHi.Width= 77;
                pnlHi.Height = 620;
            }
            else
            {
                //size 967; 561
                //Location 231; 21
                pictureBox1.Location = new Point(229, 21);
                pictureBox1.Width = 969;
                pictureBox1.Height = 561;
                pictureBox2.Location = new Point(229, 21);
                pictureBox2.Width = 969;
                pictureBox2.Height = 561;
                pnlHi.Width = 223;
                pnlHi.Height = 620;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            İslenenResim = pictureBox1.Image;
            Bitmap bmpİslenen = new Bitmap(İslenenResim);
            for (int i = 0; i < bmpİslenen.Width; i++)
            {
                for (int j = 0; j < bmpİslenen.Height; j++)
                {
                    var orjinaRenk = bmpİslenen.GetPixel(i, j);
                    var griTon = (int)((orjinaRenk.R * 0.3) + (orjinaRenk.G * 0.59) + (orjinaRenk.B * 0.11));
                    var griRenk = Color.FromArgb(griTon, griTon, griTon);
                    bmpİslenen.SetPixel(i, j, griRenk);
                }

            }
            pictureBox1.Image = bmpİslenen;


        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            FrmHistogram.Show();
        }
        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.gif, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.gif; *.jfif; *.png; *.bmp";
            dialog.InitialDirectory = ".";
            dialog.Title = "Bir resim dosyası seçiniz";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OrjResim = new Bitmap( dialog.FileName);
            }
            if (OrjResim != null)
            {
                hScrollBar1.Visible = true;
                button1.Enabled = true;
                button3.Enabled = true;

            }
            pictureBox2.Hide();
            pictureBox1.Image = OrjResim;
        }

        private void button3_Click(object sender, EventArgs e)
        {   SaveFileDialog kayıt = new SaveFileDialog();
            if (kayıt.ShowDialog() == DialogResult.OK)
            {
                kayıt.Title = "Klasörü seçiniz";
                pictureBox1.Image.Save(kayıt.FileName + ".jpg");
            }

        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap bmpO = new Bitmap(pictureBox1.Image);
            Bitmap bmpK = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < bmpO.Width; i++)
            {
                for (int j = 0; j < bmpO.Height; j++)
                {

                    Color pic = bmpO.GetPixel(i, j);
                    int a = pic.A;
                    int r = pic.R;
                    bmpK.SetPixel(i, j, Color.FromArgb(a, r, 0, 0));
                }
            }
            pictureBox1.Image = bmpK;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Bitmap bmpO = new Bitmap(pictureBox1.Image);
            Bitmap bmpY = new Bitmap(pictureBox1.Image);

            for (int i = 0; i < bmpO.Width; i++)
            {
                for (int j = 0; j < bmpO.Height; j++)
                {

                    Color pic = bmpO.GetPixel(i, j);
                    int a = pic.A;
                    int r = pic.R;
                    int b = pic.B;
                    int g = pic.G;
                    bmpY.SetPixel(i, j, Color.FromArgb(a, 0, g, 0));
                }
            }
            pictureBox1.Image = bmpY;
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap bmpO = new Bitmap(pictureBox1.Image);
            Bitmap bmpY = new Bitmap(pictureBox1.Image);

            for (int i = 0; i < bmpO.Width; i++)
            {
                for (int j = 0; j < bmpO.Height; j++)
                {

                    Color pic = bmpO.GetPixel(i, j);
                    int a = pic.A;
                    int g = pic.G;
                    bmpY.SetPixel(i, j, Color.FromArgb(a, 0, g, 0));
                }
            }
            pictureBox1.Image = bmpY;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap bmpM = new Bitmap(pictureBox1.Image);
            Bitmap bmpO = new Bitmap(pictureBox1.Image);

            for (int i = 0; i < bmpO.Width; i++)
            {
                for (int j = 0; j < bmpO.Height; j++)
                {

                    Color pic = bmpO.GetPixel(i, j);
                    int a = pic.A;
                    int r = pic.R;
                    int b = pic.B;
                    int g = pic.G;
                    bmpM.SetPixel(i, j, Color.FromArgb(a, 0, 0, b));
                }
            }
            pictureBox1.Image = bmpM;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap ilkResim = new Bitmap(pictureBox1.Image);
            Bitmap sonResim = new Bitmap(ilkResim.Height, ilkResim.Width);
            for (int i = 0; i < sonResim.Width; i++)
            {
                for (int j = 0; j < sonResim.Height; j++)
                {
                    sonResim.SetPixel(i, j, ilkResim.GetPixel(j, sonResim.Width - i - 1));
                }
            }
            if (dönmeSayısı == false)
            {
                dönmeSayısı = true;
            }
            else
            {
                dönmeSayısı = false;
            }
            pictureBox1.Image = sonResim;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap ilkResim = new Bitmap(pictureBox1.Image);
            Bitmap sonResim = new Bitmap(ilkResim.Height, ilkResim.Width);
            for (int i = 0; i < sonResim.Width; i++)
            {
                for (int j = 0; j < sonResim.Height; j++)
                {
                    sonResim.SetPixel(i, j, ilkResim.GetPixel(sonResim.Height - j - 1,i));
                }
            }
            if (dönmeSayısı == false)
            {
                dönmeSayısı = true;
            }
            else
            {
                dönmeSayısı = false;
            }
            pictureBox1.Image = sonResim;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap ilkResim = new Bitmap(pictureBox1.Image);
            Bitmap sonResim = new Bitmap(ilkResim.Width, ilkResim.Height);
            for (int i = 0; i < ilkResim.Width; i++)
            {
                for (int j = 0; j < ilkResim.Height; j++)
                {
                    sonResim.SetPixel(i, j, ilkResim.GetPixel(ilkResim.Width - i - 1, j));
                }
            }
            pictureBox1.Image = sonResim;
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            if (varMI)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Bitmap ilkResim = new Bitmap(pictureBox1.Image);
            Bitmap sonResim = new Bitmap(ilkResim.Width, ilkResim.Height);
            for (int i = 0; i < ilkResim.Width; i++)
            {
                for (int j = 0; j < ilkResim.Height; j++)
                {
                    sonResim.SetPixel(i, j, ilkResim.GetPixel(ilkResim.Width - i - 1, j));
                }
            }
            pictureBox1.Image = sonResim;
        }
        

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            double oran = 1 + (hScrollBar1.Value * 0.2);
            Size yeniBouyut;
            if (dönmeSayısı == false)
            {
                yeniBouyut=new Size((int)(OrjResim.Width*oran),(int)(OrjResim.Height * oran));
            }
            else
            {
                yeniBouyut = new Size((int)(OrjResim.Height * oran), (int)(OrjResim.Width * oran));
            }
            Bitmap pic = new Bitmap(pictureBox1.Image);
            İslenenResim2 = new Bitmap(pic, yeniBouyut);
            int ilkA, ilkR, ilkG, ilkB, sonA,sonR, sonG, sonB;
            Color ilk, son;
            for (int i = 0; i < İslenenResim2.Height; i++)
            {
                for (int j = 0; j < İslenenResim2.Width - 2; j += 2)
                {
                    ilk = İslenenResim2.GetPixel(j, i);
                    son = İslenenResim2.GetPixel(j + 2, i);
                    ilkA = (int)Math.Pow((int)ilk.A, 2);
                    ilkR = (int)Math.Pow((int)ilk.R, 2);
                    ilkG = (int)Math.Pow((int)ilk.G, 2);
                    ilkB = (int)Math.Pow((int)ilk.B, 2);
                    sonA = (int)Math.Pow((int)son.A, 2);
                    sonR = (int)Math.Pow((int)son.R, 2);
                    sonG = (int)Math.Pow((int)son.G, 2);
                    sonB = (int)Math.Pow((int)son.B, 2);
                    ilkA = (int)Math.Sqrt((ilkA + sonA) / 2);
                    ilkR = (int)Math.Sqrt((ilkR + sonR) / 2);
                    ilkG = (int)Math.Sqrt((ilkG + sonG) / 2);
                    ilkB = (int)Math.Sqrt((ilkB + sonB) / 2);
                    İslenenResim2.SetPixel(j + 1, i, Color.FromArgb(ilkA, ilkR, ilkG, ilkB));
                }
            }
            
            pictureBox1.Image = İslenenResim2;
            varMI = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (MetroFramework.MetroMessageBox.Show(this, " ", "Kaydetmeden kapatmak istediğinize emin misiniz ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                {
                    SaveFileDialog kayıt = new SaveFileDialog();
                    if (kayıt.ShowDialog() == DialogResult.OK)
                    {
                        kayıt.Title = "Klasörü seçiniz";
                        pictureBox1.Image.Save(kayıt.FileName + ".jpg");
                    }
                }
            }

        }
    }
    
}
