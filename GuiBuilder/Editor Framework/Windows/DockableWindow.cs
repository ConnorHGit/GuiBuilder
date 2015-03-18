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
			init();
			this.parentSegment = parentSegment;
			parentSegment.content.Controls.Add(content);
			dock(parentSegment, defaultSegmentSpot);
		}
		public void init()
		{
			content = new Panel();
			window = new Window();
			dockableHeader = new DockableHeader(this);
			dockableHeader.title.Text = "Dockable Window";
			content.BackColor = SystemColors.ControlLightLight;
			content.Controls.Add(dockableHeader.content);
		}
		
		public override void revalidate()
		{
			if (!docked)
			{
				content.Size = new Size(window.Size.Width - 10, window.Size.Height - 10);
				content.Location = new Point(5, 5);
			}
			dockableHeader.revalidate();
		}
		public void dock(Segment segment, SegmentSpot segmentSpot, Segment sendingChild) 
		{
			if (window != null)
				window.Hide();
			docked = true;
			segment.addChild(this, segmentSpot, sendingChild);
		}
		public void dock(Segment segment, SegmentSpot segmentSpot)
		{
			if (window != null)
				window.Hide();
			docked = true;
			segment.addChild(this, segmentSpot, segment.children[0]);
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
