using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{

    class TetrisShape
    {

        public int[,] cords = new int[4,2]; 

        public Brush color;

        public TetrisShape(Tile tile)
        {
            color = Brushes.Black;
            cords[0,0] = tile.X;
            cords[0,1] = tile.Y;
        }

        public TetrisShape()
        {
        }

    }


}
