using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder
{
    static class Program
    {
		public static Form1 mainWindow;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			mainWindow = new Form1();
            Application.Run(mainWindow);
        }
    }
}
