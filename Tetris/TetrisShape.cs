using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public class TetrisShape
    {
        /// <summary>
        /// A tetris shape has four blocks, which are recorded in a multidimensional array, 
        /// The first index combined with the second index determines the x or y value of one of the four blocks.
        /// </summary>
        public int[,] cords = new int[4,2]; 

        public Brush color;

        public TetrisShape()
        {
            cords[0,0] = 4;
            cords[0,1] = 0;
        }
    }
}
