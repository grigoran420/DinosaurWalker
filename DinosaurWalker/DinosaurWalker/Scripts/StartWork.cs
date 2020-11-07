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
        ///<summary>
        ///
        ///класс описывает начало работы приложения. Активирует окно, направляет мышь в нужную позицию, считывет цвет пикселя под мышью, нажимает пробел.
        ///
        ///</summary>
        ///
        ///<param name="ShowWindow"> открывает стороннее окно </param>
        ///<value name="hWnd"> дискриптор окна, хз что это такое, но без этого не рботает </value>
        ///<value name="showWindowCommand"> управляет отображением окна </value>    
        ///
        ///<param name="SetForegroundWindow"> Позволяет вводить данные с клавиатуры в сторонее окно </param>
        ///<value name="hWnd"> дискриптор окна, хз что это такое, но без этого не рботает </value>
        /// 
        ///<param name="SetWindowPos"> изменяет местоположение стороннего окна </param>
        ///<value name="hWnd"> дискриптор окна, хз что это такое, но без этого не рботает </value>
        ///<value name="hWndInsertAfter"> режим открытия окна </value>
        ///<value name="x, y"> местоположение окна в пиксилях </value>
        ///<value name="cx, cy"> размеры окна </value>
        ///<value name="uFlags"> Флаги изменения размера и положения окна </value>

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);


        public StartWork(int x, Label LX, int y, Label LY, string key, Panel Color, string Proces, Label textCol)
        {
            ///<summary>направляет фокус на окно, разрешает ввод в него с клавиатуры, меняет местоположение</summary>
            Process[] procs = Process.GetProcessesByName(Proces);
            foreach (Process p in procs)
            {
                ShowWindow(p.MainWindowHandle, 1);
                SetForegroundWindow(p.MainWindowHandle);
                SetWindowPos(p.MainWindowHandle, 0, 0, 0, 1920, 500, 0x0040);
            }

            ///<summary>разрешает нажимает кнопки</summary>
            if (key != " ") { key = "{" + key.ToUpperInvariant() + "}"; }
            ColorDetect detect = new ColorDetect(x, y, Color, textCol);
            if (detect.ColorDetected)
            {
                PressKey press = new PressKey(key);
            }
            MouseMove move = new MouseMove(x, y, LX, LY);
            



        }
    }
}
