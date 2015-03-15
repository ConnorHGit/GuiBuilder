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
		private Label splitBar;
		public SegmentStyle segmentStyle;
	}

	public enum SegmentStyle
	{
		Horizontal, Vertical
	}
}
