using System;
using System.Collections.Generic;
using System.Drawing;
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
		public SegmentSpot defaultSegmentSpot = SegmentSpot.Right;
		public SegmentSpot lastSegmentSpot;

		public DockableWindow() { }
		public DockableWindow(Segment parentSegment) {
			this.parentSegment = parentSegment;
			docked = true;
			content = new Panel();
			window = new Window();
			content.BackColor = SystemColors.ControlLightLight;
			parentSegment.content.Controls.Add(content);
			dockableHeader = new DockableHeader(this);
			content.Controls.Add(dockableHeader.content);
			dock(parentSegment, defaultSegmentSpot, null);
			undock();
		}


		public override void revalidate()
		{
			if (!docked)
				content.Size = new Size(window.Size.Width, window.Size.Height);
			dockableHeader.revalidate();
		}
		public void dock(Segment segment, SegmentSpot segmentSpot, Segment sendingChild) 
		{
			if (window != null)
				window.Hide();
			docked = true;
			segment.addChild(this, segmentSpot, sendingChild);
		}
		public void undock()
		{
			if (window == null)
				window = new Window();
			if (!window.Controls.Contains(content))
				window.Controls.Add(content);
			window.Show();
			window.InitializeComponent();
			docked = false;
			parentSegment.removeChild(this);
			
		}
		public int getWidth()
		{
			return content.Size.Width;
		}
	}

	
}
