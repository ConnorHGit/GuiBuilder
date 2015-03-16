﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
namespace GuiBuilder.Editor_Framework
{
	public class Window : Form
	{

		public string title = "Window";
		public Header header;
		public const int HT_CAPTION = 0x2;
		public const int WM_NCLBUTTONDOWN = 0xA1;

		public Window(){}
		public Window(String title)
		{
			this.title = title;
			header = new Header(this);
			header.title.Text = title;
		}

		public virtual void revalidate(){}

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();
		public void TitleDrag(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
		//
		private const int SnapDist = 10;
		private bool DoSnap(int pos, int edge)
		{
			int delta = pos - edge;
			return delta > 0 && delta <= SnapDist;
		}
		protected override void OnResizeEnd(EventArgs e)
		{
			base.OnResizeEnd(e);
			Screen scn = Screen.FromPoint(this.Location);
			if (DoSnap(this.Left, scn.WorkingArea.Left)) this.Left = scn.WorkingArea.Left;
			if (DoSnap(this.Top, scn.WorkingArea.Top)) this.Top = scn.WorkingArea.Top;
			if (DoSnap(scn.WorkingArea.Right, this.Right)) this.Left = scn.WorkingArea.Right - this.Width;
			if (DoSnap(scn.WorkingArea.Bottom, this.Bottom)) this.Top = scn.WorkingArea.Bottom - this.Height;
		}

		public void InitializeComponent()
		{
			this.SuspendLayout(); 
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Window";
			this.ResumeLayout(false);

		}
	}
}
