using Lab2_FDMA.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_FDMA.View_Models
{
    class EndingEquipment : SchemaElement
    {
        const int offsetX = 50;
        const int arrowLength = 50;
        Point center;


        public EndingEquipment(UnificationEquipment equipment) : base(
            "ОАЛТ",
            "Ending Equipment",
            new Point(equipment.Location.X + equipment.Width + offsetX, equipment.Location.Y + equipment.Height / 2 - 25))
        {
            Width = 140;
            center = GetCenter();
            CreateNodes();
            CreateArrows();
        }

        void CreateNodes()
        {
            inputNodes.Add(new Point(Location.X, center.Y));
            inputNodes.Add(new Point(Location.X + Width, center.Y));
        }

        void CreateArrows()
        {
            Arrows.Add(new BigArrow(new Point(inputNodes[0].X - arrowLength, inputNodes[0].Y), inputNodes[0]));
            Arrows.Add(new BigArrow(inputNodes[1], new Point(inputNodes[1].X + arrowLength, inputNodes[1].Y)));
        }

        Point GetCenter()
        {
            Point center = new Point(Location.X + Width / 2, Location.Y + Height / 2);
            return center;
        }
    }
}
