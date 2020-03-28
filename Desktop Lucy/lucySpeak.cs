using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Lucy
{
    public partial class lucySpeak : Form
    {
        public lucySpeak(string t)
        {
            InitializeComponent();
            text = t;
        }

        public string text;
        public Font font = new Font("Lucida Console", 25);
        public Pen thicc = new Pen(Color.Black, 3);
        public bool suicideOnNextTick = false;

        private void lucySpeak_Load(object sender, EventArgs e)
        {
            _suicide.Start();

            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

            Bitmap tmpl = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(tmpl);

            SizeF s = g.MeasureString(text, font);
            int sWidth = (int)s.Width;
            int sHeight = (int)s.Height;

            g.Dispose();

            tmpl = new Bitmap((int)s.Width + 20, (int)s.Height + 20);

            g = Graphics.FromImage(tmpl);

            g.FillRectangle(Brushes.White, 0, 0, sWidth, sHeight);
            g.FillRectangle(Brushes.White, 0, sHeight - 3, sWidth + 4, 3);
            g.DrawString(text, font, Brushes.Black, 3, 3);
            Point p1 = new Point(1, 1);
            Point p2 = new Point(sWidth, 1);
            Point p3 = new Point(sWidth, sHeight - 5);
            Point p4 = new Point(sWidth + 10, sHeight);
            Point p5 = new Point(1, sHeight);
            Point[] points = new Point[] { p1, p2, p3, p4, p5 };
            g.DrawPolygon(thicc, points);

            g.Dispose();

            Bitmap final = new Bitmap(1000, 50);
            g = Graphics.FromImage(final);
            g.DrawImage(tmpl, 1000 - tmpl.Width, 0, tmpl.Width, tmpl.Height);

            this.TopMost = true;
            Rectangle r = Screen.FromControl(this).Bounds;
            this.Location = new Point((r.Width - this.Width - 155), (r.Height - this.Height * 3));

            pictureBox1.Image = final;
        }

        private void _suicide_Tick(object sender, EventArgs e)
        {
            if (!suicideOnNextTick)
            {
                suicideOnNextTick = true;
            }
            else
            {
                this.Close();
            }
        }
    }
}
