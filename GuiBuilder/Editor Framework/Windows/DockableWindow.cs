using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework.Windows
{
	public class DockableWindow : Segmentable
	{
		public Window window;
		public Boolean docked;
		public Header header;

		public DockableWindow(Segment parentSegment) {
			this.parentSegment = parentSegment;
			docked = true;
			parentSegment.content.Controls.Add(content);
			//content.

		}
		public void revalidate()
		{

		}
		public void dock()
	}

	
}
