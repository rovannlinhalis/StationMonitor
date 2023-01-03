using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace smsrv
{
    public class WindowsAPI
    {
        [DllImport("use32.dll")]
        public static extern bool GetCursorPos(ref Point pt);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        //[DllImport("Wtsapi32.dll")]
        //public static extern bool WTSEnumerateSessionsA(IN HANDLE          hServer,  IN DWORD           Reserved,  IN DWORD           Version,  PWTS_SESSION_INFOA* ppSessionInfo,  DWORD* pCount);
    }
}
