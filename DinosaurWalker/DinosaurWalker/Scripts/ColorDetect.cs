using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinosaurWalker.Scripts
{
    class ColorDetect
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        int x, y;
        bool detect = false;
        public ColorDetect(int _x, int _y, Panel col, Label textCol)
        {
            x = _x;
            y = _y;

            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, Cursor.Position.X, Cursor.Position.Y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)pixel);

            col.ForeColor = color;
            textCol.Text = color.ToString();
            if (color.R * color.G * color.B < 100 * 100 * 100)
            {
                detect = true;
            }
            else { detect = false; }
        }


        internal bool ColorDetected 
        { 
            get
            {
                

                return detect; 
            }
            private set { }
        }


    }
}
