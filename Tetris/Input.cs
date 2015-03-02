using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    // static class for reading input from keyboard
    class Input
    {
        private static Dictionary<Keys, bool> keys = new Dictionary<Keys, bool>();
        public Input()
        {
            keys.Add(Keys.Down, false);
            keys.Add(Keys.Up, false);
            keys.Add(Keys.Left, false);
            keys.Add(Keys.Right, false);
            keys.Add(Keys.Enter, false);
        }

        public static bool isKeyPressed (Keys key)
        {
            return (bool)keys[key];
        }

        public static void changeState (Keys key, bool state)
        {
            keys[key] = state;
        }

    }
}
