using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_FDMA.View_Models
{
    interface Schema
    {
        void CreateSchema(int x, int y, int width);
        void AddElements();
        void AddExplanations();
        void Clear();
    }
}
