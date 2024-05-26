using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeQQ.RoundedCorners
{
	public class RoundControl
	{
		public static void SetFormRoundRectRgn(Form form, int rgnRadius)
		{
			int hRgn = 0;
			hRgn = RoundCorner.CreateRoundRectRgn(0, 0, form.Width, form.Height, rgnRadius, rgnRadius);
			RoundCorner.SetWindowRgn(form.Handle, hRgn, true);
			RoundCorner.DeleteObject(hRgn);
		}
		public static void SetPanelRoundRectRgn(Panel panel, int rgnRadius)
		{
			int hRgn = 0;
			hRgn = RoundCorner.CreateRoundRectRgn(0, 0, panel.Width, panel.Height, rgnRadius, rgnRadius);
			RoundCorner.SetWindowRgn(panel.Handle, hRgn, true);
			RoundCorner.DeleteObject(hRgn);
		}
		public static void SetLabelRoundRectRgn(Label label, int rgnRadius)
		{
			int hRgn = 0;
			hRgn = RoundCorner.CreateRoundRectRgn(0, 0, label.Width, label.Height, rgnRadius, rgnRadius);
			RoundCorner.SetWindowRgn(label.Handle, hRgn, true);
			RoundCorner.DeleteObject(hRgn);
		}
	}
}
