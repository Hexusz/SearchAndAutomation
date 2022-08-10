using System.Runtime.InteropServices;

namespace SAAlib
{
    public class WinFunc
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Struct.Rect rectangle);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);
    }
}