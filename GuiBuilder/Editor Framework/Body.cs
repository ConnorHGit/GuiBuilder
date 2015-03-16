using GuiBuilder.Editor_Framework.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework
{
	public class Body
	{
		public Form1 parentForm;
		public Segment segment;
		public Body(Form1 parentForm)
		{
			segment = new Segment();
			this.parentForm = parentForm;
			int topSize = parentForm.header.height + parentForm.menuBar.height;
			segment.segmentType = SegmentType.Body;
			segment.content = new Panel();
			segment.content.Location = new Point(0, topSize);
			segment.content.Size = new Size(parentForm.Width, parentForm.Height - topSize);
			segment.content.BackColor = SystemColors.ControlLightLight;
			parentForm.Controls.Add(segment.content);
		}
		public void revalidate()
		{
			int topSize = parentForm.header.height + parentForm.menuBar.height;
			segment.content.Location = new Point(0, topSize);
			segment.content.Size = new Size(parentForm.Width, parentForm.Height - topSize);
		}
	}
}
