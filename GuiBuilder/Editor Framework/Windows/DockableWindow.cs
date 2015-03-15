using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework.Windows
{
	public class DockableWindow
	{
		private Window window;
		private Panel panel;
		private Boolean docked;
		private List<DockableWindow> right, left, up, down;

		
	}

	public enum DockPosition
	{
		up, down, left, right
	}
}
