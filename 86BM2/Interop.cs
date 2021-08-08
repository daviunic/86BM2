using System;
using System.Runtime.InteropServices;

namespace _86BM2
{
    internal static class Interop
    {
        //Posts a message to the window with specified handle - DOES NOT WAIT FOR THE RECIPIENT TO PROCESS THE MESSAGE!!!
        [DllImport("user32.dll")]
        internal static extern int PostMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        //Focus a window
        [DllImport("user32.dll")]
        internal static extern int SetForegroundWindow(IntPtr hwnd);

        [StructLayout(LayoutKind.Sequential)]
        internal struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
    }
}