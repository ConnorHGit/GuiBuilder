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
		public DockableHeader dockableHeader;

		public DockableWindow() { }
		public DockableWindow(Segment parentSegment) {
			this.parentSegment = parentSegment;
			docked = true;
			parentSegment.content.Controls.Add(content);
			dockableHeader = new DockableHeader(this);
			content.Controls.Add(dockableHeader.content);

		}
		public override void revalidate()
		{
			dockableHeader.revalidate();
		}
		public void dock(Segment segment, SegmentSpot  segmentSpot) 
		{
			docked = true;

		}
		public void undock()
		{
			docked = false;
			parentSegment.removeChild(this);

		}
	}

	
}
