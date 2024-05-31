using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

class CueTextBox : TextBox
{
	[Localizable(true)]
	public string Cue
	{
		get { return mCue; }
		set { mCue = value; updateCue(); }
	}

	private void updateCue()
	{
		if (this.IsHandleCreated && mCue != null)
		{
			SendMessage(this.Handle, 0x1501, (IntPtr)0, mCue);
		}
	}

	private string mCue;

	// PInvoke
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
}