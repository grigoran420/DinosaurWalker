using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.InteropServices;

namespace DinosaurWalker.Scripts
{
    class StartWork
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);


        public StartWork(int x, int y, string key, Panel Color, string Proces)
        {
            Process[] procs = Process.GetProcessesByName(Proces);
            if (key != " ") { key = "{" + key.ToUpperInvariant() + "}"; }
            foreach (Process p in procs)
            {
                SetForegroundWindow(p.MainWindowHandle);
                ShowWindow(p.MainWindowHandle, 1);

            }
            PressKey press = new PressKey(key);

        }
    }
}
