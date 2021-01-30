using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClick
{
    public partial class AutoClick : Form
    {
        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        public AutoClick()
        {
            InitializeComponent();
        }

        private void AutoClick_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (WindowState == FormWindowState.Minimized)
            {
                mouseTimer.Interval = int.Parse(txtTime.Text);
                mouseTimer.Start();
            }
            if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
            {
                mouseTimer.Stop();
            }
        }

        private void MouseTimeDo(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, "BlueStacks");
            ShowWindow(hwnd, SW_MAXIMIZE);
            Thread.Sleep(200);
            Point leftTop = new Point(int.Parse(txtX.Text), int.Parse(txtY.Text));
            Cursor.Position = leftTop;
            var mmoutPoint = GetCursorPosition();
            mouse_event((int)MouseEventFlags.LeftDown, mmoutPoint.X, mmoutPoint.Y, 0, 0);
            mouse_event((int)MouseEventFlags.LeftUp, mmoutPoint.X, mmoutPoint.Y, 0, 0);
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        public static MousePoint GetCursorPosition()
        {
            var gotPoint = GetCursorPos(out MousePoint currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }
    }

    [Flags]
    public enum MouseEventFlags
    {
        LeftDown = 0x00000002,
        LeftUp = 0x00000004,
        MiddleDown = 0x00000020,
        MiddleUp = 0x00000040,
        Move = 0x00000001,
        Absolute = 0x00008000,
        RightDown = 0x00000008,
        RightUp = 0x00000010
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MousePoint
    {
        public int X;
        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
