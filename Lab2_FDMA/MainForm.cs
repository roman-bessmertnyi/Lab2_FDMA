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
        MainSchema schema;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (schema != null) schema.Draw(e);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (schema != null) schema.Clear();
            schema = new MainSchema(this, Convert.ToInt16(textBoxSignals.Text));
            Invalidate();
            schema.CreateSchema(0,30);
        }
    }
}
