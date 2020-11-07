using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinosaurWalker.Scripts
{
    class MouseMove
    {

        public MouseMove(int x, int y, System.Windows.Forms.Label lX, System.Windows.Forms.Label lY)
        {
            lX.Text = Cursor.Position.X.ToString();
            lY.Text = Cursor.Position.Y.ToString();
            Cursor.Position = new System.Drawing.Point(x, y);
        }
    }
}
