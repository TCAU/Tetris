using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace Tetris
{

    // class that makes new TetrisShapes 

    enum TetrisShapes { I = 0, O, L, J, S, Z, T }

    class TetrisShapeFactory
    {
        private Random random;
        private TetrisShapes tetrisShapeEnum;
        private TetrisShapes nextShapeEnum;
        private int brushColorIndex;

        public TetrisShape currentShape;
        public TetrisShape nextShape;
        private Tile tile;
        
        public TetrisShapeFactory()
        {
            random = new Random();
            tile = new Tile { X = 4, Y = 2 };
            currentShape = new TetrisShape(tile);
            nextShape = new TetrisShape(tile);

            tetrisShapeEnum = (TetrisShapes)random.Next(7);
            nextShapeEnum = (TetrisShapes)random.Next(7);

            currentShape = GenerateShape(tile);
            nextShape = GenerateShape(tile);

            brushColorIndex = random.Next(10);
        }

        public TetrisShape GetShape()
        {
            TetrisShape temp = currentShape;

            currentShape = nextShape;
            nextShape = GenerateShape(tile);

            return temp;
        }

        private TetrisShape GenerateShape(Tile tile)
        {
            TetrisShape shape = new TetrisShape(tile);
            AddAdjacentTiles(tetrisShapeEnum, shape, tile);
            shape.color = PickRandomBrush();
            moveShapeQueue();
            return shape;
        }

        private void moveShapeQueue()
        {
            tetrisShapeEnum = nextShapeEnum;
            nextShapeEnum = (TetrisShapes)random.Next(7);
        }

        private void AddAdjacentTiles(TetrisShapes tetrisShapeEnum, TetrisShape shape, Tile tile)
        {
            switch (tetrisShapeEnum)
            {
                case TetrisShapes.I:
                    shape.cords[1, 0] = tile.X;
                    shape.cords[1, 1] = tile.Y + 1;

                    shape.cords[2, 0] = tile.X;
                    shape.cords[2, 1] = tile.Y - 1;

                    shape.cords[3, 0] = tile.X;
                    shape.cords[3, 1] = tile.Y - 2;
                    break;
                case TetrisShapes.O:
                    
                    shape.cords[1, 0] = tile.X;
                    shape.cords[1, 1] = tile.Y - 1;

                    shape.cords[2, 0] = tile.X + 1;
                    shape.cords[2, 1] = tile.Y - 1;

                    shape.cords[3, 0] = tile.X + 1;
                    shape.cords[3, 1] = tile.Y;
                    break;
                case TetrisShapes.L:
                    shape.cords[1, 0] = tile.X;
                    shape.cords[1, 1] = tile.Y - 1;

                    shape.cords[2, 0] = tile.X;
                    shape.cords[2, 1] = tile.Y - 2;

                    shape.cords[3, 0] = tile.X + 1;
                    shape.cords[3, 1] = tile.Y;

                    break;
                case TetrisShapes.J:
                    shape.cords[1, 0] = tile.X;
                    shape.cords[1, 1] = tile.Y - 1;

                    shape.cords[2, 0] = tile.X;
                    shape.cords[2, 1] = tile.Y - 2;
                    
                    shape.cords[3, 0] = tile.X - 1;
                    shape.cords[3, 1] = tile.Y;
                    break;
                case TetrisShapes.S:
                    shape.cords[1, 0] = tile.X;
                    shape.cords[1, 1] = tile.Y - 1;
                    
                    shape.cords[2, 0] = tile.X - 1;
                    shape.cords[2, 1] = tile.Y - 1;

                    shape.cords[3, 0] = tile.X + 1;
                    shape.cords[3, 1] = tile.Y;
                    break;
                case TetrisShapes.Z:
                    shape.cords[1, 0] = tile.X;
                    shape.cords[1, 1] = tile.Y - 1;

                    shape.cords[2, 0] = tile.X - 1;
                    shape.cords[2, 1] = tile.Y;
                    
                    shape.cords[3, 0] = tile.X + 1;
                    shape.cords[3, 1] = tile.Y - 1;
                    break;
                case TetrisShapes.T:
                    shape.cords[1, 0] = tile.X;
                    shape.cords[1, 1] = tile.Y - 1;

                    shape.cords[2, 0] = tile.X - 1;
                    shape.cords[2, 1] = tile.Y;
                    
                    shape.cords[3, 0] = tile.X + 1;
                    shape.cords[3, 1] = tile.Y;
                    break;
                default:
                    break;
            }
        }

        private Brush PickRandomBrush()
        {
            Brush result = Brushes.Transparent;

            switch (brushColorIndex)
            {   
                case 0:
                    result = Brushes.Red;
                    break;
                case 1:
                    result = Brushes.Lime;
                    break;
                case 2:
                    result = Brushes.Blue;
                    break;
                case 3:
                    result = Brushes.Cyan;
                    break;
                case 4:
                    result = Brushes.Yellow;
                    break;
                case 5:
                    result = Brushes.LightGray;
                    break;
                case 6:
                    result = Brushes.Magenta;
                    break;
                case 7:
                    result = Brushes.Orange;
                    break;
                case 8:
                    result = Brushes.Purple;
                    break;
                case 9:
                    result = Brushes.Pink;
                    break;
                default:
                    break;
            }

            brushColorIndex = random.Next(10);
            
            return result;
        }
    }
}
