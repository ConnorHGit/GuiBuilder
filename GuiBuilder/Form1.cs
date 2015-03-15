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
		public Header header;
		public MenuBar menuBar;
		public Body body;

        public Form1()
        {
			title = "Gui Builder";
            InitializeComponent();
			header = new Header(this);
			menuBar = new MenuBar(); 
			body = new Body(this);
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		public new void revalidateButtons()
		{
			body.revalidate();
		}
    }
}
