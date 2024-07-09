using System;
using System.Windows.Forms;
using JakondaNoteJ2K.Core;

namespace JakondaNote
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            SecurityManager.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormj2k());
        }
    }
}
