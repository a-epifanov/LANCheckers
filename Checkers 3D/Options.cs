using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Shared;

namespace GameOptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Shared.SharedCode.CurrentPlayer.UserImage;
            textBox1.Text = Shared.SharedCode.CurrentPlayer.Name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files (*.jpg)|*.jpg|(*.jpeg)|*.jpeg|(*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 4;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            pictureBox1.ImageLocation = openFileDialog1.FileName;
                            pictureBox1.Load();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                Shared.SharedCode.CurrentPlayer.Name = textBox1.Text;
                Shared.SharedCode.CurrentPlayer.UserImage = new Bitmap(pictureBox1.Image);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Введите имя игрока",
"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

    }
}
