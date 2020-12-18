using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teethpaste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path1 = pathText.Text;
            var prefix = "toothpaste";
            var fileName = Enumerable.Range(1, 50000)
                            .Select(n => Path.Combine(path1, $"{prefix}-{n}.png"))
                            .First(p => !File.Exists(p));
            if (Clipboard.ContainsImage())
            {
                Clipboard.GetImage().Save(fileName, ImageFormat.Png);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.ShowBalloonTip(2147483647);
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pathSave_Click(object sender, EventArgs e)
        {
            string path = pathText.Text;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                MessageBox.Show("ok this should work");
            }
            else
            {
                MessageBox.Show("it already exists dum dum");
            }

        }
        void icon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
        }
    }



}
