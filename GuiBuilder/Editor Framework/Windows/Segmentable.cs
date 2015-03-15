using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework.Windows
{
	public class Segmentable
	{
		public Panel content;
		public Segment parentSegment;
		public SegmentType segmentType;
		public virtual void revalidate() {}
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
		DockableWindow, DockableWindowGroup, Segment, Body
	}
}
