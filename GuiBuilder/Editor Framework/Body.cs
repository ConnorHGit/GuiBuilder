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
		public Panel content;
		private Form1 parentForm;
		public Body(Form1 parentForm)
		{
			this.parentForm = parentForm;
			int topSize = parentForm.header.height + parentForm.menuBar.height;
			content = new Panel();
			content.Location = new Point(0, topSize);
			content.Size = new Size(parentForm.Width, parentForm.Height - topSize);
			content.BackColor = SystemColors.ControlLightLight;
			parentForm.Controls.Add(content);

		}
		public void revalidate()
		{
			int topSize = parentForm.header.height + parentForm.menuBar.height;
			content.Location = new Point(0, topSize);
			content.Size = new Size(parentForm.Width, parentForm.Height - topSize);
		}
	}
}
