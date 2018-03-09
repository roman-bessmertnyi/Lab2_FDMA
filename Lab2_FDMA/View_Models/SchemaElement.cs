using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Lab2_FDMA.Graphics;

namespace Lab2_FDMA.View_Models
{
    public class SchemaElement : SchemaLablel , Drawable
    {
        public SchemaElement(string text, string name, Point Location) : base(text, name, Location)
        {
            Font = new Font("Arial", 24, FontStyle.Bold);
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLightLight;
            AutoSize = false;
            Size = new Size(100, 50);
        }

        protected List<Point> inputNodes = new List<Point>();
        protected List<Point> outputNodes = new List<Point>();
        protected List<BigArrow> arrows = new List<BigArrow>();

        public List<BigArrow> Arrows { get => arrows; set => arrows = value; }
        public List<Point> OutputNodes { get => outputNodes; set => outputNodes = value; }

        public virtual void Draw(PaintEventArgs e)
        {
            foreach(BigArrow arrow in arrows)
            {
                arrow.Draw(e);
            }
        }
    }
}
