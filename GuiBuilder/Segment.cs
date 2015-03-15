using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework.Windows
{
	public class Segment : Segmentable
	{
		private Segmentable[] children = new Segmentable[2];
		public SegmentStyle segmentStyle;
		public Label splitBar;	//the bar that seperates and can resize the two children segmentables, if there are not two children there will be no bar.
		public int barOffset;
		public Segment(Segment parentSegment)
		{
			type = SegmentType.Segment;
			this.parentSegment = parentSegment;
		}

		public void revalidate()
		{


		}

		//removes 
		public void removeChild(Segmentable child)
		{
			int toRemove = -1;
			toRemove = child == children[0] ? 0 : toRemove;
			toRemove = child == children[1] ? 1 : toRemove;
			if (toRemove != -1)
			{
				children[toRemove] = null;
				revalidate();
			}

			// if the first child was removed, and there is a second child, the first child becomes the second child;
			if (children[0] == null)
			{
				if (children[1] != null)
				{
					children[0] = children[1];
					children[1] = null;
				}
			}
		}

		//if the segment style is none then if there is alrady 1 child, the docked window becomes a docked window group;
		//if its already a docked window group, then that child gets added 
		public void addChild(Segmentable child, SegmentSpot segmentStyle)
		{
			if (segme)
		}
	}

	public enum SegmentStyle
	{
		Horizontal, Vertical, None
	}

	public enum SegmentSpot
	{
		Left, Right, Up, Down, Share
	}

	public enum SegmentType
	{
		DockableWindow, DockableWindowGroup, Segment
	}

}
