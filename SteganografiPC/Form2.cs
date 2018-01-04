using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteganografiPC
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            About tampil = new About();
            tampil.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = "Picture";
            openfile.Filter = "JPG|*.jpg";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string file = openfile.FileName.ToString();
                PB_E.ImageLocation = file;
                MAlamat_E.Text = file;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(PB_E.Image);
            int i, j;
            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (i < 1 && j < TB_E.Text.Length)
                    {
                        Console.WriteLine("R[" + i + "][" + j + "] :" + pixel.R);
                        Console.WriteLine("G[" + i + "][" + j + "] :" + pixel.G);
                        Console.WriteLine("B[" + i + "][" + j + "] :" + pixel.B);
                        char letter = Convert.ToChar(TB_E.Text.Substring(j, 1));
                        int value = Convert.ToInt32(letter);
                        Console.WriteLine("letter :" + letter + "\n value :" + value);
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, value));
                    }

                    if (i == img.Width - 1 && j == img.Height - 1)
                    {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, TB_E.Text.Length));
                    }
                }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "JPG|*.jpg";
            savefile.InitialDirectory = "Picture";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string filename = savefile.FileName;
                img.Save(filename);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.InitialDirectory = "Picture";
            openfile.Filter = "JPG|*.jpg";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string file = openfile.FileName.ToString();
                PB_D.ImageLocation = file;
                MAlamat_D.Text = file;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(MAlamat_D.Text);
            string message = "";
            Color lpixel = img.GetPixel(img.Width - 1, img.Height - 1);
            int messlen = lpixel.B;
            int i, j;
            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (i < 1 && j < messlen)
                    {
                        Console.WriteLine("R[" + i + "][" + j + "] :" + pixel.R);
                        Console.WriteLine("G[" + i + "][" + j + "] :" + pixel.G);
                        Console.WriteLine("B[" + i + "][" + j + "] :" + pixel.B);
                        int value = pixel.B;
                        Console.WriteLine("Value :" + value);
                        char c = Convert.ToChar(value);
                        string letter = c.ToString();

                        message = message + letter;
                    }
                }
            }
            MTB_D.Text = message;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            PB_E.Image = null;
            MAlamat_E.Text = null;
            TB_E.Text = null;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            PB_D.Image = null;
            MAlamat_D.Text = null;
            MTB_D.Text = null;
        }
    }
}