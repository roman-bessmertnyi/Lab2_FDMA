using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_FDMA.View_Models
{
    class MainSchema : Schema, Drawable
    {
        List<Label> lables;
        MainForm MainForm;
        int x; int y;

        public MainSchema(MainForm mainForm)
        {
            MainForm = mainForm;
            lables = new List<Label>();
        }

        public void CreateSchema(int x, int y)
        {
            this.x = x;
            this.y = y;
            AddElements();
        }

        void AddElements()
        {
            UnificationEquipment unificationEquipment = new UnificationEquipment(75, new Point(700, 20));
            unificationEquipment.AddToForm(MainForm, lables);
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
                Drawable drawable = label as Drawable;
                if (drawable != null)
                {
                    drawable.Draw(e);
                }
            }
        }
    }
}
