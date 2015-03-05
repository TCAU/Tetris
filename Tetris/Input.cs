using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Tetris
{
    // static class for reading input from keyboard

    static class Input
    {
        private static Dictionary<Keys, bool> keys = new Dictionary<Keys, bool> ()
        { 
            {Keys.Down, false},
            {Keys.Up, false},
            {Keys.Left, false},
            {Keys.Right, false},
            {Keys.Enter, false}
        };

        public static bool isKeyPressed(Keys key)
        {
            return (bool)keys[key];
        }

        public static void changeState(Keys key, bool state)
        {
            keys[key] = state;
        }
    }
}
