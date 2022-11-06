namespace OricExplorer.Class
{
    using System;
    using System.Runtime.InteropServices;
    using static OricExplorer.Class.NativeMethods;

    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("user32.dll")]
        internal static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

    }
}
