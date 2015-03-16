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
		public int barThickness = 6;
		public Label splitBar;
		public Panel content;
		public SegmentStyle segmentStyle = SegmentStyle.None;
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
			childOne.parentSegment = this;
			childTwo.parentSegment = this;
			children[0] = childOne;
			children[1] = childTwo;
			content.Controls.Add(childOne.content);
			content.Controls.Add(childTwo.content);
			parentSegment.content.Controls.Add(content);
			barOffset = 0;
		}

		public override void revalidate()
		{
			if (children[1] != null) {
				if (segmentStyle == SegmentStyle.Horizontal)
				{
					int width, height, childWidth, childHeight, position1Offset, position2Offset, size1Offset, size2Offset;
					width = content.Size.Width;
					height = content.Size.Height;
					childWidth = (width / 2) - (barThickness / 2);
					childHeight = height;
					size1Offset = barOffset;
					size2Offset = -barOffset + barThickness + childWidth;
					position1Offset = 0;
					position2Offset = barOffset;

					splitBar.Size = new Size(width, barThickness);
					splitBar.Location = new Point(0, (height / 2) - (barThickness / 2));
					children[0].content.Size = new Size(childWidth + barOffset, childHeight);
					children[1].content.Size = new Size(childWidth - barOffset, childHeight);
					children[0].content.Location = new Point(position1Offset, 0);
					children[1].content.Location = new Point(position2Offset, 0);
				}
				else if (segmentStyle == SegmentStyle.Vertical)
				{
					int width, height, childWidth, childHeight, position1Offset, position2Offset, size1Offset, size2Offset;
					width = content.Size.Width;
					height = content.Size.Height;
					childWidth = width;
					childHeight = (height / 2) - (barThickness / 2);
					size1Offset = barOffset;
					size2Offset = -barOffset + barThickness + childHeight;
					position1Offset = 0;
					position2Offset = barOffset;

					splitBar.Size = new Size(barOffset, height);
					splitBar.Location = new Point((width / 2) - (barThickness / 2), 0);
					children[0].content.Size = new Size(childWidth, childHeight + barOffset);
					children[1].content.Size = new Size(childWidth, childHeight - barOffset);
					children[0].content.Location = new Point(position1Offset, 0);
					children[1].content.Location = new Point(position2Offset, 0);
				}
				children[0].revalidate();
				children[1].revalidate();
			}
			else if (children[0] != null && children[1] == null) 
			{
				children[0].content.Size = new Size(content.Size.Width, content.Size.Height);
				children[0].revalidate();
			}
		}

		//removes child
		public void removeChild(Segmentable child)
		{
			int toRemove = -1;
			toRemove = child == children[0] ? 0 : toRemove;
			toRemove = child == children[1] ? 1 : toRemove;
			if (toRemove != -1)
			{
				content.Controls.Remove(child.content);
				children[toRemove].parentSegment = null;
				children[toRemove] = null;
			}
			fixChildren();
			revalidate();
		}

		// if the first child was removed, and there is a second child, the first child becomes the second child;
		public void fixChildren()
		{
			if (children[0] == null)
			{
				if (children[1] != null)
				{
					children[0] = children[1];
					children[1] = null;
				}
			}

			if (children[1] == null)
			{
				segmentStyle = SegmentStyle.None;
				if (content.Controls.Contains(splitBar))
					content.Controls.Remove(splitBar);
			}
			if (children[1] != null)
				if (!content.Controls.Contains(splitBar))
					content.Controls.Add(splitBar);

		}

		//if the segment style is none then if there is alrady 1 child, the docked window becomes a docked window group;
		//if its already a docked window group, then that child gets added 
		public void addChild(Segmentable child, SegmentSpot segmentSpot, Segmentable sendingChild)
		{
			if (children[0] == null)
			{
				content.Controls.Add(child.content);
				child.parentSegment = this;
				children[0] = child;
				segmentStyle = SegmentStyle.None;
			}
			else if (children[1] == null)
			{
				content.Controls.Add(child.content);
				child.parentSegment = this;
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
				Segmentable temp = children[index];
				removeChild(temp);
				if (segmentSpot == SegmentSpot.Up || segmentSpot == SegmentSpot.Left)
					children[index] = new Segment(this, child, temp, segmentStyle);
				else if (segmentSpot == SegmentSpot.Down || segmentSpot == SegmentSpot.Right)
					children[index] = new Segment(this, temp, child, segmentStyle);
				else
					System.Console.Out.WriteLine("Did not make dockable window groups yet.");
			}

		}
	}



}
