using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2_FDMA.Graphics;

namespace Lab2_FDMA.View_Models
{
    class GenerationEquipment : SchemaElement, IDrawable
    {
        const int offsetX = -150;
        const int offsetY = 150;
        Point center;


        public GenerationEquipment(UnificationEquipment equipment) : base(
            "ГО",
            "Generation Equipment",
            new Point(equipment.Location.X + offsetX, equipment.Location.Y + equipment.Height + offsetY))
        {
            center = GetCenter();
            CreateNodes();
            CreateArrows();
        }

        void CreateNodes()
        {
            inputNodes.Add(new Point(Location.X, center.Y));
            inputNodes.Add(new Point(center.X, Location.Y));
            inputNodes.Add(new Point(Location.X + Width, center.Y));
        }

        void CreateArrows()
        {
            Arrows.Add(new BigArrow(inputNodes[0], new Point(center.X + offsetX, center.Y - offsetY - Height / 2)));
            Arrows.Add(new BigArrow(inputNodes[1], new Point(center.X, center.Y - offsetY - Height / 2)));
            Arrows.Add(new BigArrow(inputNodes[2], new Point(center.X - offsetX, center.Y - offsetY - Height / 2)));
        }

        Point GetCenter()
        {
            Point center = new Point(Location.X + Width / 2, Location.Y + Height / 2);
            return center;
        }
    }
}
