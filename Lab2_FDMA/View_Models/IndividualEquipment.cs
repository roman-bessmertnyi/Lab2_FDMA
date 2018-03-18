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
        List<SchemaLablel> inputNumbers;
        const int verticalOffset = 80;
        const int inputArrowOffset = -20;
        const int inputNumberOffsetX = -40;
        const int inputNumberOffsetY = -8;
        bool small;

        public IndividualEquipment(bool small, int equipmentNumber, int signalNumber, Point stackLocation) : base(
            "АИП",
            "Individual Equipment " + equipmentNumber,
            new Point(stackLocation.X, equipmentNumber * (verticalOffset) + stackLocation.Y))
        {
            this.small = small;
            inputNumbers = new List<SchemaLablel>();
            inputNodes.Add(new Point(Location.X, Location.Y));
            inputNodes.Add(new Point(Location.X, Location.Y + Height));
            OutputNodes.Add(new Point(Location.X + Width, Location.Y + Height / 2));
            foreach(Point inputNode in inputNodes)
            {
                bool isFirst = (inputNodes.IndexOf(inputNode) == 0);
                arrows.Add(new BigArrow(new Point(inputNode.X + inputArrowOffset, inputNode.Y), inputNode));
                inputNumbers.Add(new SchemaLablel(
                    Convert.ToString(GetInputNumberValue(equipmentNumber, signalNumber, isFirst)),
                    "Input " + (GetInputNumberValue(equipmentNumber, signalNumber, isFirst)),
                    new Point(inputNode.X + inputNumberOffsetX, inputNode.Y + inputNumberOffsetY)));
            }
        }

        int GetInputNumberValue(int equipmentNumber, int signalNumber, bool isFirst)
        {
            if (small)
            {
                if (isFirst) return equipmentNumber * 4 + 1 + signalNumber;
                else return equipmentNumber * 4 + 4 + signalNumber;
            }
            else
            {
                if (isFirst) return equipmentNumber * 12 + 1 + signalNumber;
                else return equipmentNumber * 12 + 12 + signalNumber;
            }
        }

        public override void AddToForm(Form form, List<Label> schemaLablels)
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
