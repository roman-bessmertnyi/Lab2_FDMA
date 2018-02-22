using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_FDMA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Blue, 1);
            Brush b = new SolidBrush(p.Color);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int x1 = 20;
            int y1 = 20;
            int x2 = 100;
            int y2 = 200;

            e.Graphics.DrawLine(p, x1, y1, x2, y2);

            int arrowSize = 10;

            double angle = Math.Atan2(y2 - y1, x2 - x1);
            PointF pArrowBack = new PointF(x1 - (float)(Math.Cos(angle) * arrowSize * -2), y1 - (float)(Math.Sin(angle) * arrowSize * -2));
            PointF pArrowLeft = new PointF(pArrowBack.X + (float)(Math.Cos(angle - Math.PI / 2.0) * arrowSize), pArrowBack.Y + (float)(Math.Sin(angle - Math.PI / 2.0) * arrowSize));
            PointF pArrowRight = new PointF(pArrowBack.X - (float)(Math.Cos(angle - Math.PI / 2.0) * arrowSize), pArrowBack.Y - (float)(Math.Sin(angle - Math.PI / 2.0) * arrowSize));

            e.Graphics.FillPolygon(b, new PointF[] { pArrowLeft, new PointF(x1,y1), pArrowRight });

            p.Dispose();
            b.Dispose();
        }
    }
}
