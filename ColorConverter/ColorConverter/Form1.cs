using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorConverter
{
    public partial class Form1 : Form
    {

        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap img;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                img = new Bitmap(openFileDialog1.FileName);
                textBox1.Text = openFileDialog1.FileName;
                pictureBox1.Image = img;
                //pictureBox1.Size = img.Size;           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {         
           if (img != null)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        if (img.GetPixel(x, y).ToArgb() == colorDialog1.Color.ToArgb())
                        {
                            img.SetPixel(x, y, colorDialog2.Color);                                           
                        }
                    }
                }
                img.Save(string.Format(@"{0}\{1:00}.png", textBox1.Text.Remove(textBox1.Text.LastIndexOf("\\") + 1), counter), ImageFormat.Png);                
                counter++;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox2.BackColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            textBox3.BackColor = colorDialog2.Color;
        }    
    }
}
