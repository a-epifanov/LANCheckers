using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Checkers_3D
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            FileStream help = null;

            
            try
            {
                help = new FileStream ("../../help.txt", FileMode.Open);
                byte[] arrhelp = new byte[help.Length];
                help.Read(arrhelp, 0, arrhelp.Length);
                char []Chars1251 = System.Text.Encoding.GetEncoding(1251).GetChars(arrhelp);
                richTextBox1.Text = new string(Chars1251);
            }
            catch (IOException exc)
            {
                MessageBox.Show(exc.ToString(),
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
               if (help != null)
                help.Close(); 
            }
            
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }

}
