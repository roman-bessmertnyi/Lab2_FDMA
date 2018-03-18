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
    public class UnificationEquipment : SchemaElement, IDrawable
    {
        List<FirstLevelEquipment> equipmentsFL;
        List<IndividualEquipment> equipmentsI;
        List<SchemaLablel> signals;

        const int Gap = 15;
        const int HeightS = 30;
        const int HeightIE = 80;
        const int HeightFLE = 400;
        const int LevelEquipmentOffsetX = -150;
        const int inputArrowOffset = -20;
        const int inputNumberOffsetX = -340;
        const int inputNumberOffsetY = -8;

        int firstLevelNumber;
        int individualNumber;
        int signalNumber;

        public UnificationEquipment(int number, Point stackLocation) : base(
            "АС",
            "Unification Equipment",
            stackLocation)
        {
            equipmentsFL = new List<FirstLevelEquipment>();
            equipmentsI = new List<IndividualEquipment>();
            signals = new List<SchemaLablel>();

            CalculateNumbers(number);
            CalculateHeight();

            if (number >= 12) CreateDependables(stackLocation);
            else CreateSmallDependables(stackLocation);
            
        }

        void CreateDependables(Point stackLocation)
        {
            int inputNumber = 0;
            int signalCounter = 0;
            for (int i = 0; i < firstLevelNumber; i++)
            {
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * i + HeightFLE / 2 - Gap));
                equipmentsFL.Add(new FirstLevelEquipment(i, new Point(stackLocation.X + LevelEquipmentOffsetX, stackLocation.Y)));
                arrows.Add(new BigArrow(new Point(inputNodes[inputNumber].X + LevelEquipmentOffsetX, inputNodes[inputNumber].Y), inputNodes[inputNumber]));
                inputNumber++;
                signalCounter += 60;
            }
            for (int i = 0; i < individualNumber; i++)
            {
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * firstLevelNumber + HeightIE * i + HeightIE / 2 - Gap));
                equipmentsI.Add(new IndividualEquipment(false, i, signalCounter, new Point(stackLocation.X + LevelEquipmentOffsetX * 2, stackLocation.Y + HeightFLE * firstLevelNumber)));
                arrows.Add(new BigArrow(new Point(inputNodes[inputNumber].X + LevelEquipmentOffsetX * 2, inputNodes[inputNumber].Y), inputNodes[inputNumber]));
                inputNumber++;
            }
            signalCounter += 12 * individualNumber;
            for (int i = 0; i < signalNumber; i++)
            {
                signalCounter++;
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * firstLevelNumber + HeightIE * individualNumber + HeightS * i + HeightS / 2 - Gap));
                signals.Add(new SchemaLablel(
                    Convert.ToString(signalCounter),
                    "Input " + (signalCounter),
                    new Point(inputNodes[inputNumber].X + inputNumberOffsetX, inputNodes[inputNumber].Y + inputNumberOffsetY)));
                arrows.Add(new BigArrow(new Point(inputNodes[inputNumber].X + LevelEquipmentOffsetX * 2 + inputArrowOffset, inputNodes[inputNumber].Y), inputNodes[inputNumber]));
                inputNumber++;
            }
        }

        void CreateSmallDependables(Point stackLocation)
        {
            int inputNumber = 0;
            int signalCounter = 0;
            for (int i = 0; i < individualNumber; i++)
            {
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * firstLevelNumber + HeightIE * i + HeightIE / 2 - Gap));
                equipmentsI.Add(new IndividualEquipment(true, i, signalCounter, new Point(stackLocation.X + LevelEquipmentOffsetX * 2, stackLocation.Y + HeightFLE * firstLevelNumber)));
                arrows.Add(new BigArrow(new Point(inputNodes[inputNumber].X + LevelEquipmentOffsetX * 2, inputNodes[inputNumber].Y), inputNodes[inputNumber]));
                inputNumber++;
            }
            signalCounter += 4 * individualNumber;
            for (int i = 0; i < signalNumber; i++)
            {
                signalCounter++;
                inputNodes.Add(new Point(
                    Location.X,
                    Location.Y + HeightFLE * firstLevelNumber + HeightIE * individualNumber + HeightS * i + HeightS / 2 - Gap));
                signals.Add(new SchemaLablel(
                    Convert.ToString(signalCounter),
                    "Input " + (signalCounter),
                    new Point(inputNodes[inputNumber].X + inputNumberOffsetX, inputNodes[inputNumber].Y + inputNumberOffsetY)));
                arrows.Add(new BigArrow(new Point(inputNodes[inputNumber].X + LevelEquipmentOffsetX * 2 + inputArrowOffset, inputNodes[inputNumber].Y), inputNodes[inputNumber]));
                inputNumber++;
            }

        }

        Point GetStackLocationFLE(Point stackLocation)
        {
            return new Point(stackLocation.X + LevelEquipmentOffsetX, stackLocation.Y);
        }

        void CalculateNumbers(int number)
        {
            if (number>=12)
            {
                firstLevelNumber = number / 60;
                individualNumber = (number % 60) / 12;
                signalNumber = (number % 60) % 12;
            }
            else
            {
                firstLevelNumber = number / 60;
                individualNumber = (number % 60) / 4;
                signalNumber = (number % 60) % 4;
            }
        }

        void CalculateHeight()
        {
            int theoreticalHeight = firstLevelNumber * HeightFLE + individualNumber * HeightIE + signalNumber * HeightS - 30;
            Height = Math.Max(theoreticalHeight, 50);
        }

        public override void AddToForm(Form form, List<Label> Lablels)
        {
            form.Controls.Add(this);
            Lablels.Add(this);
            foreach (FirstLevelEquipment firstLevelEquipment in equipmentsFL)
            {
                firstLevelEquipment.AddToForm(form, Lablels);
            }
            foreach (IndividualEquipment individualEquipment in equipmentsI)
            {
                individualEquipment.AddToForm(form, Lablels);
            }
            foreach (SchemaLablel signal in signals)
            {
                signal.AddToForm(form, Lablels);
            }
        }
    }
}
