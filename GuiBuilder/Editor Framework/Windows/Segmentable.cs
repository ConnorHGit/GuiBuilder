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
		public SegmentType type;
		public virtual void revalidate() {}
	}
}
