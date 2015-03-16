using System;
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
		public Label minimize, maximize, exit, title, iconLabel;
		Image whiteMinimize, whiteMaximize, whiteRestoreDown, whiteExit,
				blackMinimize, blackMaximize, blackRestoreDown, blackExit,
				iconImage;
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
			iconLabel = new Label();

			whiteRestoreDown = Image.FromFile("Resources/white restore down.png");
			whiteMinimize = Image.FromFile("Resources/white minimize.png");
			whiteMaximize = Image.FromFile("Resources/white maximize.png");
			whiteExit = Image.FromFile("Resources/white exit.png");
			blackRestoreDown = Image.FromFile("Resources/black restore down.png");
			blackMinimize = Image.FromFile("Resources/black minimize.png");
			blackMaximize = Image.FromFile("Resources/black maximize.png");
			blackExit = Image.FromFile("Resources/black exit.png");
			iconImage = Image.FromFile("Resources/logo.png");

			content.BackColor = SystemColors.Control;
			title.AutoSize = true;
			title.Padding = new Padding(5, 0, 5, 0);
			title.Location = new Point(height, 5);
			title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title.ForeColor = Color.Gray;
			iconLabel.AutoSize = false;
			iconLabel.Size = new Size(height, height);
			iconLabel.Image = iconImage;
			

			minimize.AutoSize = false;
			maximize.AutoSize = false;
			exit.AutoSize = false;
			content.Size = new Size(parentDockableWindow.content.Width,height);
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

			content.Controls.Add(iconLabel);
			content.Controls.Add(title);
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
			Program.mainWindow.WindowState = FormWindowState.Minimized;
			parentDockableWindow.revalidate();
			//revalidate();
		}
		private void maximizeClicked(object sender, EventArgs e)
		{
		
			Program.mainWindow.WindowState = Program.mainWindow.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
			maximize.Image = blackRestoreDown;
			parentDockableWindow.revalidate();
			//revalidate();
		}
		private void exitClicked(object sender, EventArgs e)
		{
			Application.Exit();
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
			if (!parentDockableWindow.docked)
				maximize.Image = Program.mainWindow.WindowState == FormWindowState.Maximized ? whiteRestoreDown : whiteMaximize;

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
			maximize.Image = Program.mainWindow.WindowState == FormWindowState.Maximized ? blackRestoreDown : blackMaximize;
		}
		private void exitExited(object sender, EventArgs e)
		{
			exit.BackColor = SystemColors.Control;
			exit.Image = blackExit;

		}

		private void sizeChange(object sender, EventArgs e)
		{
			//revalidate();
			parentDockableWindow.revalidate();
		}
		public void revalidate()
		{
			int width = parentDockableWindow.content.Width;
			if (parentDockableWindow.docked) 
			{
				
				content.Size = new Size(width, 25);
				//minimize.Location = new Point(width - 75, 0);
				maximize.Location = new Point(width - 50, 0);
				exit.Location = new Point(width - 25, 0);
				//parentForm.revalidate();
				if (content.Controls.Contains(minimize))
					content.Controls.Remove(minimize);
				if (parentDockableWindow.window.Controls.Contains(content))
				{
					//parentDockableWindow.window.Controls.Remove(background);
					parentDockableWindow.content.Controls.Add(content);
				}
			}
			else
			{
				if (!content.Controls.Contains(minimize))
					content.Controls.Add(minimize);
				minimize.Location = new Point(width - 75, 0);
			}
			
		}
	}
}


