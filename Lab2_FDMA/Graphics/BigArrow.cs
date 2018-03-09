using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab2_FDMA.Graphics
{
    public class BigArrow
    {
        Point startPoint;
        Point endPoint;
        int size;
        Color color;

        public BigArrow(Point startPoint, Point endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Size = 5;
            this.Color = Color.Black;
        }

        public Point StartPoint { get => startPoint; set => startPoint = value; }
        public Point EndPoint { get => endPoint; set => endPoint = value; }
        public int Size { get => size; set => size = value; }
        public Color Color { get => color; set => color = value; }

        public void Draw(PaintEventArgs e)
        {
            Pen p = new Pen(Color, 1);
            Brush b = new SolidBrush(Color);

            e.Graphics.DrawLine(p, StartPoint, EndPoint);

            float x1 = StartPoint.X;
            float x2 = EndPoint.X;
            float y1 = StartPoint.Y;
            float y2 = EndPoint.Y;

            double angle = Math.Atan2(y1 - y2, x1 - x2);
            PointF pArrowBack = new PointF(x2 - (float)(Math.Cos(angle) * Size * -2), y2 - (float)(Math.Sin(angle) * Size * -2));
            PointF pArrowLeft = new PointF(pArrowBack.X + (float)(Math.Cos(angle - Math.PI / 2.0) * Size), pArrowBack.Y + (float)(Math.Sin(angle - Math.PI / 2.0) * Size));
            PointF pArrowRight = new PointF(pArrowBack.X - (float)(Math.Cos(angle - Math.PI / 2.0) * Size), pArrowBack.Y - (float)(Math.Sin(angle - Math.PI / 2.0) * Size));

            e.Graphics.FillPolygon(b, new PointF[] { pArrowLeft, EndPoint, pArrowRight });

            p.Dispose();
            b.Dispose();
        }
    }
}
