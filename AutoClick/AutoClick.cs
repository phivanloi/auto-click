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
        private bool blueStacksIsOpened = false;
        private int playCount = 0;

        public AutoClick()
        {
            InitializeComponent();
        }

        private void AutoClick_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                mouseTimer.Interval = blueStacksIsOpened ? int.Parse(txtTime.Text) : 100;
                mouseTimer.Start();
            }
            if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
            {
                mouseTimer.Stop();
            }
        }

        private void MouseTimeDo(object sender, EventArgs e)
        {
            if (blueStacksIsOpened)
            {
                Point leftTop = new Point(int.Parse(txtX.Text), int.Parse(txtY.Text));
                Cursor.Position = leftTop;
                var mmoutPoint = GetCursorPosition();
                mouse_event((int)MouseEventFlags.LeftDown, mmoutPoint.X, mmoutPoint.Y, 0, 0);
                mouse_event((int)MouseEventFlags.LeftUp, mmoutPoint.X, mmoutPoint.Y, 0, 0);
                Thread.Sleep(10000);
                if (playCount == 0)
                {
                    Point leftTop1 = new Point(50, 640);
                    Cursor.Position = leftTop1;
                    var mmoutPoint1 = GetCursorPosition();
                    mouse_event((int)MouseEventFlags.LeftDown, mmoutPoint1.X, mmoutPoint1.Y, 0, 0);
                    mouse_event((int)MouseEventFlags.LeftUp, mmoutPoint1.X, mmoutPoint1.Y, 0, 0);
                }
                mouseTimer.Interval = int.Parse(txtTime.Text);
                mouseTimer.Start();
                playCount++;
            }
            else
            {
                Process.Start(@"cmd.exe ", @"/c D:\GrowCastle.lnk");
                blueStacksIsOpened = true;
                mouseTimer.Interval = 20000;
                mouseTimer.Start();
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);

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
