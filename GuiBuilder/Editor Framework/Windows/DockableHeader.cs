﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiBuilder.Editor_Framework.Windows
{
	public class DockableHeader
	{
		public Panel content;
		public Label minimize, maximize, exit, title;
		Image whiteMinimize, whiteMaximize, whiteRestoreDown, whiteExit,
				blackMinimize, blackMaximize, blackRestoreDown, blackExit;
		DockableWindow parentDockableWindow;
		public int height = 20;

		public DockableHeader(DockableWindow parentDockableWindow)
		{
			this.parentDockableWindow = parentDockableWindow;
			Console.WriteLine(Environment.CurrentDirectory);
			content = new Panel();
			minimize = new Label();
			maximize = new Label();
			exit = new Label();
			title = new Label();

			whiteRestoreDown = Image.FromFile("Resources/white restore down.png");
			whiteMinimize = Image.FromFile("Resources/white minimize.png");
			whiteMaximize = Image.FromFile("Resources/white maximize.png");
			whiteExit = Image.FromFile("Resources/white exit.png");
			blackRestoreDown = Image.FromFile("Resources/black restore down.png");
			blackMinimize = Image.FromFile("Resources/black minimize.png");
			blackMaximize = Image.FromFile("Resources/black maximize.png");
			blackExit = Image.FromFile("Resources/black exit.png");

			content.BackColor = SystemColors.Control;
			title.AutoSize = true;
			title.Padding = new Padding(5, 0, 5, 0);
			title.Location = new Point(0, 3);
			title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title.ForeColor = Color.Gray;

			minimize.AutoSize = false;
			maximize.AutoSize = false;
			exit.AutoSize = false;
			content.Size = new Size(parentDockableWindow.content.Width, height);
			minimize.Size = new Size(height, height);
			maximize.Size = new Size(height, height);
			exit.Size = new Size(height, height);

			minimize.Location = new Point(parentDockableWindow.content.Width - height*3, 0);
			maximize.Location = new Point(parentDockableWindow.content.Width - height*2, 0);
			exit.Location = new Point(parentDockableWindow.content.Width - height, 0);

			minimize.Image = blackMinimize;
			maximize.Image = blackMaximize;
			exit.Image = blackExit;

			minimize.Click += minimizeClicked;
			maximize.Click += maximizeClicked;
			exit.Click += exitClicked;

			minimize.MouseEnter += minimizeEntered;
			maximize.MouseEnter += maximizeEntered;
			exit.MouseEnter += exitEntered;

			minimize.MouseLeave += minimizeExited;
			maximize.MouseLeave += maximizeExited;
			exit.MouseLeave += exitExited;

			content.Controls.Add(minimize);
			content.Controls.Add(maximize);
			content.Controls.Add(exit);
			content.Controls.Add(title);
			parentDockableWindow.content.Controls.Add(content);

			parentDockableWindow.window.Resize += sizeChange;

			title.MouseDown += parentDockableWindow.window.TitleDrag;
			content.MouseDown += parentDockableWindow.window.TitleDrag;
		}

		private void minimizeClicked(object sender, EventArgs e)
		{
			parentDockableWindow.window.WindowState = FormWindowState.Minimized;
			if (parentDockableWindow.docked)
				parentDockableWindow.parentSegment.revalidate();
			else
				parentDockableWindow.revalidate();
			//revalidate();
		}
		private void maximizeClicked(object sender, EventArgs e)
		{
			if (!parentDockableWindow.docked)
				parentDockableWindow.window.WindowState = parentDockableWindow.window.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
			else
				parentDockableWindow.undock();

			maximize.Image = parentDockableWindow.window.WindowState == FormWindowState.Maximized ? blackRestoreDown : blackMaximize;
			
			if (parentDockableWindow.docked)
				parentDockableWindow.parentSegment.revalidate();
			else
				parentDockableWindow.revalidate();
			//revalidate();
		}
		private void exitClicked(object sender, EventArgs e)
		{
			if (parentDockableWindow.docked)
			{
				parentDockableWindow.undock();
				
			}
			parentDockableWindow.window.Hide();
		}

		private void minimizeEntered(object sender, EventArgs e)
		{
			minimize.BackColor = SystemColors.HotTrack;
			minimize.Image = whiteMinimize;
		}

		private void maximizeEntered(object sender, EventArgs e)
		{
			maximize.BackColor = SystemColors.HotTrack;
			maximize.Image = whiteRestoreDown;
			maximize.Image = parentDockableWindow.window.WindowState == FormWindowState.Maximized ? whiteRestoreDown : whiteMaximize;

		}

		private void exitEntered(object sender, EventArgs e)
		{
			exit.BackColor = Color.Red;
			exit.Image = whiteExit;
		}

		private void minimizeExited(object sender, EventArgs e)
		{
			minimize.BackColor = SystemColors.Control;
			minimize.Image = blackMinimize;
		}
		private void maximizeExited(object sender, EventArgs e)
		{
			maximize.BackColor = SystemColors.Control;
			maximize.Image = parentDockableWindow.window.WindowState == FormWindowState.Maximized ? blackRestoreDown : blackMaximize;
		}
		private void exitExited(object sender, EventArgs e)
		{
			exit.BackColor = SystemColors.Control;
			exit.Image = blackExit;
		}

		private void sizeChange(object sender, EventArgs e)
		{
			//revalidate();
			if (parentDockableWindow.docked)
				parentDockableWindow.parentSegment.revalidate();
			else
				parentDockableWindow.revalidate();
		}
		public void revalidate()
		{
			int width = parentDockableWindow.content.Width;
			content.Size = new Size(width, height);
			if (parentDockableWindow.docked) 
			{
				//minimize.Location = new Point(width - height * 3, 0);
				maximize.Location = new Point(width - height * 2, 0);
				exit.Location = new Point(width - height, 0);

				if (content.Controls.Contains(minimize))
					content.Controls.Remove(minimize);
			}
			else
			{
				if (!content.Controls.Contains(minimize))
					content.Controls.Add(minimize);
				minimize.Location = new Point(width - height * 3, 0);
				maximize.Location = new Point(width - height * 2, 0);
				exit.Location = new Point(width - height * 1, 0);
			}
			
		}
	}
}


