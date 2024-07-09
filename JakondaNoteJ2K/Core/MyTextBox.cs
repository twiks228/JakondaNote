using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JakondaNoteJ2K.Core
{
    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
