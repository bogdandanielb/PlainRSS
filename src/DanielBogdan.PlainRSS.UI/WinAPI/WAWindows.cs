using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DanielBogdan.PlainRSS.UI.WinAPI
{
    public class WAWindows
    {
        #region Import WinApi Functions

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx,
                                               int cy, uint wFlags);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = ("GetSystemMetrics"))]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        #endregion

        #region Consts and structures

        public const int GwlStyle = -16;

        public const long WsSizebox = 0x00040000L;

        public static readonly IntPtr HwndTop = new IntPtr(0);

        public const uint SwpShowWindow = 0x0040;

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public int Width
            {
                get { return Right - Left; }
            }

            public int Height
            {
                get { return Bottom - Top; }
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (obj.GetType() != typeof(Rect)) return false;
                return Equals((Rect)obj);
            }

            public bool Equals(Rect other)
            {
                return other.Left == Left && other.Top == Top && other.Right == Right && other.Bottom == Bottom;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var result = Left;
                    result = (result * 397) ^ Top;
                    result = (result * 397) ^ Right;
                    result = (result * 397) ^ Bottom;
                    return result;
                }
            }
        }

        public enum WindowShowStyle : uint
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            ShowNormalNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActivate = 7,
            ShowNoActivate = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimized = 11
        }

        #endregion
    }
}
