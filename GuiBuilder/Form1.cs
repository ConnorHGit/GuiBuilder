﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiBuilder.Editor_Framework;

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
		}

		public override void revalidate()	
		{
			System.Console.Out.WriteLine("WTf revalidating");
			body.revalidate();
			menuBar.revalidate();
		}
		private void Form1_Load(object sender, EventArgs e) {}

		
    }
}
