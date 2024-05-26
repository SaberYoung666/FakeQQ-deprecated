using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace FakeQQ.RoundedCorners
{

	public class RoundCorner
	{
		#region Public extern methods

		[DllImport("gdi32.dll")]
		public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

		[DllImport("user32.dll")]
		public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);

		[DllImport("gdi32.dll", EntryPoint = "DeleteObject", CharSet = CharSet.Ansi)]
		public static extern int DeleteObject(int hObject);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();
		#endregion
	}

}
