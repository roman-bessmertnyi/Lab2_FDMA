using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab2_FDMA.View_Models
{
    public class SchemaLablel : Label
    {
        public SchemaLablel(string text, string name, Point Location)
        {
            this.Location = Location;
            Font = new Font("Arial", 10);
            Text = text;
            Name = name;
            AutoSize = true;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        public virtual void AddToForm(Form form, List<Label> schemaLablels)
        {
            form.Controls.Add(this);
            schemaLablels.Add(this);
        }
    }
}
