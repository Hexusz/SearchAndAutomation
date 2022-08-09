using SAAlib.Enum;
using System.Runtime.InteropServices;

namespace SAAlib
{
    public class WinFunc
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Struct.Rect rectangle);

    }
}