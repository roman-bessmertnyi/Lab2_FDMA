using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2_FDMA.Graphics;

namespace Lab2_FDMA.View_Models
{
    public class FirstLevelEquipment : SchemaElement
    {
        List<IndividualEquipment> inputEquipments;
        const int verticalOffset = 400;
        const int individualEquipmentOffsetY = -150;

        public FirstLevelEquipment(int number, Point stackLocation) : base(
            "АПП",
            "First Level Equipment " + number,
            new Point(stackLocation.X, number * (verticalOffset) + stackLocation.Y))
        {
            Height = 370;
            inputEquipments = new List<IndividualEquipment>();
            CreateInputNodes();
            OutputNodes.Add(new Point(Location.X + Width, Location.Y + Height / 2));
            int numberIE = 0;
            foreach (Point inputNode in inputNodes)
            {
                inputEquipments.Add(new IndividualEquipment(false, numberIE, number, GetStackLocationIE(number, stackLocation)));
                arrows.Add(new BigArrow(inputEquipments[numberIE++].OutputNodes[0], inputNode));
            }
        }

        void CreateInputNodes()
        {
            int firstOffset = 25;
            int Offset = 80;
            for (int i = 0; i < 5; i++)
            {
                inputNodes.Add(new Point(Location.X, Location.Y + firstOffset + Offset * i));
            }
        }

        Point GetStackLocationIE(int number, Point stackLocation)
        {
            return new Point(stackLocation.X + individualEquipmentOffsetY, stackLocation.Y + number * (verticalOffset));
        }

        public override void AddToForm(Form form, List<Label> Lablels)
        {
            form.Controls.Add(this);
            Lablels.Add(this);
            foreach (SchemaLablel inputEquipment in inputEquipments)
            {
                inputEquipment.AddToForm(form, Lablels);
            }
        }
    }
}
