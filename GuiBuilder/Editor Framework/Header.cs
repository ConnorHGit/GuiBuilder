using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GuiBuilder.Editor_Framework
{
	public class Header
	{
		public int height = 25;
		public Window parentForm;
		public Panel background;
		public Label minimize, maximize, exit, title, iconLabel;
		public Image whiteMinimize, whiteMaximize, whiteRestoreDown, whiteExit,
				blackMinimize, blackMaximize, blackRestoreDown, blackExit,
				iconImage;
		
		public Header(Window parentForm)
		{
			this.parentForm = parentForm;
			Console.WriteLine(Environment.CurrentDirectory);
			background = new Panel();
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

			title.AutoSize = true;
			title.Text = parentForm.title;
			title.Padding = new Padding(5, 0, 5, 0);
			title.Location = new Point(25, 5);
			title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title.ForeColor = Color.Gray;
			iconLabel.AutoSize = false;
			iconLabel.Size = new Size(25, 25);
			iconLabel.Image = iconImage;
			
			minimize.AutoSize = false;
			maximize.AutoSize = false;
			exit.AutoSize = false;
			background.Size = new Size(parentForm.Width,25);
			minimize.Size = new Size(25, 25);
			maximize.Size = new Size(25, 25);
			exit.Size = new Size(25, 25);

			minimize.Location = new Point(parentForm.Width - 75, 0);
			maximize.Location = new Point(parentForm.Width - 50, 0);
			exit.Location     = new Point(parentForm.Width - 25, 0);

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

			background.Controls.Add(iconLabel);
			background.Controls.Add(title);
			background.Controls.Add(minimize);
			background.Controls.Add(maximize);
			background.Controls.Add(exit);
			background.Controls.Add(title);
			parentForm.content.Controls.Add(background);

			parentForm.Resize += sizeChange;

			title.MouseDown += parentForm.TitleDrag;
			background.MouseDown += parentForm.TitleDrag;
		}

		private void minimizeClicked(object sender, EventArgs e)
		{
			Program.mainWindow.WindowState = FormWindowState.Minimized;
			revalidate();
		}
		private void maximizeClicked(object sender, EventArgs e)
		{
			Program.mainWindow.WindowState = Program.mainWindow.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
			maximize.Image = blackRestoreDown;
			revalidate();
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
			parentForm.revalidate();
			System.Console.Out.WriteLine("Resized");
		}
		public void revalidate()
		{
			int width = parentForm.content.Width;
			background.Size = new Size(width, 25);
			minimize.Location = new Point(width - 75, 0);
			maximize.Location = new Point(width - 50, 0);
			exit.Location = new Point(width - 25, 0);
		}
	}
}
