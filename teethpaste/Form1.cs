using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
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
            var path = new[] { @"C:\Users\Admin\Desktop\testing123" }.First(p => Directory.Exists(p));
            var prefix = "toothpaste";
            var fileName = Enumerable.Range(1, 50000)
                            .Select(n => Path.Combine(path, $"{prefix}-{n}.png"))
                            .First(p => !File.Exists(p));
            if (Clipboard.ContainsImage())
            {
                Clipboard.GetImage().Save(fileName, ImageFormat.Png);
                Clipboard.SetText($"![image](/Desktop/testing123/{Path.GetFileName(fileName)})");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
