using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FakeQQ.RoundedCorners
{
	public class RoundCorner
	{
		// 创建一个圆角矩形区域
		[DllImport("gdi32.dll")]
		public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

		// 设置边框
		[DllImport("user32.dll")]
		public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, Boolean bRedraw);
		
		// 删除句柄
		[DllImport("gdi32.dll", EntryPoint = "DeleteObject", CharSet = CharSet.Ansi)]
		public static extern int DeleteObject(int hObject);

		// 控制控件的圆角
		public static void SetRoundRectRgn(Control control, int rgnRadius)
		{
			int hRgn = 0;
			hRgn = CreateRoundRectRgn(0, 0, control.Width, control.Height, rgnRadius, rgnRadius);
			SetWindowRgn(control.Handle, hRgn, true);
			DeleteObject(hRgn);
		}
	}
}
