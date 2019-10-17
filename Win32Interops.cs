using System;
using System.Runtime.InteropServices;

namespace AutoClick
{
    public static class Win32Interops
    {
        #region Win32 Interops 

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern void SendInput(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        #endregion

        /// <summary>
        /// see <ref="https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mouse_event" />
        /// </summary>
        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            MOVE = 0x0001,
            ABSOLUTE = 0x8000,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010
        }
    }
}
