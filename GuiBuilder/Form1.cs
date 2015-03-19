using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiBuilder.Editor_Framework;
using GuiBuilder.Editor_Framework.Windows;

namespace GuiBuilder
{
    public partial class Form1 : Window
    {
		public MenuBar menuBar;
		public Body body;
		
        public Form1()
        {
			title = "Gui Builder";
            InitializeComponent();
			Controls.Add(content);
			header = new Header(this);
			menuBar = new MenuBar(); 
			body = new Body(this);
			DockableWindow d1 = new DockableWindow(body.segment);
			DockableWindow d2 = new DockableWindow(body.segment);

		}

		public override void revalidate()	
		{
			content.Size = new Size(Size.Width - 10, Size.Height - 10);
			content.Location = new Point(5, 5);
			header.revalidate();
			body.revalidate();
			menuBar.revalidate();
		}
		private void Form1_Load(object sender, EventArgs e) {}

		
    }
}
