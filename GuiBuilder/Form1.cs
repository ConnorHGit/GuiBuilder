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
			System.Console.Out.WriteLine("Form created");
			title = "Gui Builder";
            InitializeComponent();
			header = new Header(this);
			menuBar = new MenuBar(); 
			body = new Body(this);
			DockableWindow test = new DockableWindow(body.segment);
			
		}

		public override void revalidate()	
		{
			body.revalidate();
			menuBar.revalidate();
		}
		private void Form1_Load(object sender, EventArgs e) {}

		
    }
}
