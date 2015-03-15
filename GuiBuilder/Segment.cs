using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework.Windows
{
	public class Segment : Segmentable
	{
		public int barOffset;
		public Label splitBar;
		public Panel content;
		public SegmentStyle segmentStyle;
		public SegmentType segmentType = SegmentType.Segment;
		public Segmentable[] children = new Segmentable[2];		
		
		public Segment(){}	//used for constructor in Body class
		public Segment(Segment parentSegment)
		{
			this.parentSegment = parentSegment;
			content.Size = new Size(parentSegment.content.Size.Width, parentSegment.content.Size.Height);
		}
		public Segment(Segment parentSegment, Segmentable childOne, Segmentable childTwo, SegmentStyle segmentStyle)
		{
			this.parentSegment = parentSegment;
			this.segmentStyle = segmentStyle;
			content.Size = new Size(parentSegment.content.Size.Width, parentSegment.content.Size.Height);
			children[0] = childOne;
			children[1] = childTwo;
			barOffset = 0;
		}

		public void revalidate()
		{


		}

		//removes child
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
		public void addChild(Segmentable child, SegmentSpot segmentSpot, Segmentable sendingChild)
		{
			if (children[0] == null)
			{
				children[0] = child;
				segmentStyle = SegmentStyle.None;
			}
			else if (children[1] == null)
			{
				children[1] = child;
				this.segmentStyle = segmentSpot == SegmentSpot.Left || segmentSpot == SegmentSpot.Right ? SegmentStyle.Vertical : this.segmentStyle;
				this.segmentStyle = segmentSpot == SegmentSpot.Up || segmentSpot == SegmentSpot.Down ? SegmentStyle.Horizontal : this.segmentStyle;
				this.segmentStyle = segmentSpot == SegmentSpot.Share ? SegmentStyle.None : this.segmentStyle;

			}
			else if (children[1] != null)
			{
				SegmentStyle segmentStyle;
				segmentStyle = segmentSpot == SegmentSpot.Left || segmentSpot == SegmentSpot.Right ? SegmentStyle.Vertical : this.segmentStyle;
				segmentStyle = segmentSpot == SegmentSpot.Up || segmentSpot == SegmentSpot.Down ? SegmentStyle.Horizontal : this.segmentStyle;
				segmentStyle = segmentSpot == SegmentSpot.Share ? SegmentStyle.None : this.segmentStyle;
				int index = sendingChild == children[0] ? 0 : 1;
				if (segmentStyle != SegmentStyle.None)
					children[index] = new Segment(this, children[index], child, segmentStyle);
				else ;
					//children[index] = new DockableWindowGroup(this, children[index], child);
			}

		}
	}



}
