using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinosaurWalker.Scripts
{
    class PressKey
    {
        public PressKey (string key)
        {
            SendKeys.Send(key);
        }
    }
}
