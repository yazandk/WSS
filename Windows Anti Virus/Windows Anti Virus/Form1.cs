using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Windows_Anti_Virus
{
    public partial class Form1 : Form
    {
        int progress = 0;
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Renderer = new BlueRenderer();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            lblStatus.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progress++;
            this.progressBar1.Increment(1);
            if(progress == 100)
            {
                var md5signatures = File.ReadAllLines("MD5base.txt");
                if (md5signatures.Contains(textBox1.Text))
                {
                    lblStatus.Text = "Infected!";
                    lblStatus.ForeColor = Color.Red;
                }

                else
                {
                    lblStatus.Text = "Clean!";
                    lblStatus.ForeColor = Color.Green;
                }
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            {
            }
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Textfiles | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
                textBox1.Text = GetMD5FromFile(ofd.FileName);
        }

        public string GetMD5FromFile(string filenPath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filenPath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class BlueRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            Color c = Color.Black;
            using (SolidBrush brush = new SolidBrush(c))
                e.Graphics.FillRectangle(brush, rc);
        }
    }
}
