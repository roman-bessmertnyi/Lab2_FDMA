using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_FDMA.View_Models
{
    class MainSchema : ISchema, IDrawable
    {
        List<Label> lables = new List<Label>();
        MainForm MainForm;
        int x; int y;
        int signalNumber;

        public MainSchema(MainForm mainForm, int signalNumber)
        {
            MainForm = mainForm;
            this.signalNumber = signalNumber;
        }

        public void CreateSchema(int x, int y)
        {
            this.x = x;
            this.y = y;
            AddElements();
        }

        void AddElements()
        {
            UnificationEquipment unificationEquipment = new UnificationEquipment(signalNumber, new Point(400 + x, 20 + y));
            unificationEquipment.AddToForm(MainForm, lables);
            GenerationEquipment generationEquipment = new GenerationEquipment(unificationEquipment);
            generationEquipment.AddToForm(MainForm, lables);
            EndingEquipment endingEquipment = new EndingEquipment(unificationEquipment);
            endingEquipment.AddToForm(MainForm, lables);

            //FirstLevelEquipment firstEquipment = new FirstLevelEquipment(0, new Point(300, 20));
            //firstEquipment.AddToForm(MainForm, lables);
        }

        public void Clear()
        {
            foreach(Label label in lables)
            {
                MainForm.Controls.Remove(label);
            }
            lables.Clear();
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (Label label in lables)
            {
                if (label is IDrawable drawable)
                {
                    drawable.Draw(e);
                }
            }
        }
    }
}
