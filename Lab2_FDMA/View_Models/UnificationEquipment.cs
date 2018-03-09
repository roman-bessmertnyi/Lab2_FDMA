using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Lab2_FDMA.Graphics;

namespace Lab2_FDMA.View_Models
{
    public class UnificationEquipment : SchemaElement, Drawable
    {
        List<FirstLevelEquipment> equipmentsFL;
        List<IndividualEquipment> equipmentsI;
        List<SchemaLablel> signals;

        const int Gap = 15;
        const int HeightS = 30;
        const int HeightIE = 80;
        const int HeightFLE = 400;
        const int FirstLevelEquipmentOffsetX = -150;

        int firstLevelNumber;
        int individualNumber;
        int signalNumber;

        public UnificationEquipment(int number, Point stackLocation) : base(
            "АС",
            "Unification Equipment",
            stackLocation)
        {
            CalculateNumbers(number);
            CalculateHeight();

            CreateInputNodes();
            foreach (Point inputNode in inputNodes)
            {
                arrows.Add(new BigArrow(new Point(inputNode.X + FirstLevelEquipmentOffsetX, inputNode.Y), inputNode));
            }

            equipmentsFL = new List<FirstLevelEquipment>();
            equipmentsI = new List<IndividualEquipment>();
            signals = new List<SchemaLablel>();
        }

        void CreateInputNodes()
        {
            for (int i = 0; i < firstLevelNumber; i++)
            {
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * i + HeightFLE / 2 - Gap));
            }
            for (int i = 0; i < individualNumber; i++)
            {
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * firstLevelNumber + HeightIE * i + HeightIE / 2 - Gap));
            }
            for (int i = 0; i < signalNumber; i++)
            {
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * firstLevelNumber + HeightIE * individualNumber + HeightS * i + HeightS / 2 - Gap));
            }
        }

        Point GetStackLocationFLE(Point stackLocation)
        {
            return new Point(stackLocation.X + FirstLevelEquipmentOffsetX, stackLocation.Y);
        }

        void CalculateNumbers(int number)
        {
            firstLevelNumber = number / 60;
            individualNumber = (number % 60) / 12;
            signalNumber = (number % 60) % 12;
        }

        void CalculateHeight()
        {
            Height = firstLevelNumber * HeightFLE + individualNumber * HeightIE + signalNumber * HeightS - 30;
        }
    }
}
