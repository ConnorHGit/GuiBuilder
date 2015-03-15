using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework.Windows
{
	public abstract class Segmentable
	{
		public Panel background;
		public Segment parentSegment;
		public Segmentable partnerSegmentable;
		public void revalidate() {}
	}
}
