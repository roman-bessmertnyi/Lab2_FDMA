using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Lab2_FDMA.Graphics;
using System.Windows.Forms;

namespace Lab2_FDMA.View_Models
{
    public class IndividualEquipment : SchemaElement
    {
        List<SchemaLablel> inputNumbers = new List<SchemaLablel>();
        const int verticalOffset = 130;
        const int inputArrowOffset = -20;
        const int inputNumberOffsetX = -40;
        const int inputNumberOffsetY = -8;

        public IndividualEquipment(int number, Point stackLocation) : base(
            "АИП",
            "Individual Equipment " + number,
            new Point(number * (verticalOffset) + stackLocation.X, stackLocation.Y))
        {
            
            inputNodes.Add(new Point(Location.X, Location.Y));
            inputNodes.Add(new Point(Location.X, Location.Y + Height));
            outputNodes.Add(new Point(Location.X + Width, Location.Y + Height / 2));
            foreach(Point inputNode in inputNodes)
            {
                bool isFirst = (inputNodes.IndexOf(inputNode) == 0);
                arrows.Add(new BigArrow(new Point(inputNode.X + inputArrowOffset, inputNode.Y), inputNode));
                inputNumbers.Add(new SchemaLablel(
                    Convert.ToString(GetFirstInputNumber(number, isFirst)),
                    "Input " + (GetFirstInputNumber(number, isFirst)),
                    new Point(inputNode.X + inputNumberOffsetX, inputNode.Y + inputNumberOffsetY)));
            }
        }

        int GetFirstInputNumber(int number, bool isFirst)
        {
            if (isFirst) return number * 12 + 1;
            else return number * 12 + 12;
        }

        new public void AddToForm(Form form, List<Label> schemaLablels)
        {
            form.Controls.Add(this);
            schemaLablels.Add(this);
            foreach (SchemaLablel number in inputNumbers)
            {
                number.AddToForm(form, schemaLablels);
            }
        }
    }
}
