using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2_FDMA.Graphics;
using Lab2_FDMA.View_Models;

namespace Lab2_FDMA
{
    public partial class MainForm : Form
    {
        List<Label> schemaLabels;
        IndividualEquipment firstEquipment;

        public MainForm()
        {
            InitializeComponent();
            schemaLabels = new List<Label>();
            firstEquipment = new IndividualEquipment(0, new Point(50, 20));
            firstEquipment.AddToForm(this, schemaLabels);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            firstEquipment.Draw(e);
        }
    }
}
