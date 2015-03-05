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

    enum TetrisShapesEnum { I = 0, O, L, J, S, Z, T }

    class TetrisShapeFactory
    {
        private Random random;
        private TetrisShapesEnum tetrisShapeEnum;
        private TetrisShapesEnum nextShapeEnum;
        private int brushColorIndex;

        public TetrisShape currentShape;
        public TetrisShape nextShape;
        
        public TetrisShapeFactory()
        {
            random = new Random();

            tetrisShapeEnum = (TetrisShapesEnum)random.Next(7);
            nextShapeEnum = (TetrisShapesEnum)random.Next(7);

            currentShape = GenerateShape();
            nextShape = GenerateShape();

            brushColorIndex = random.Next(10);
        }

        public TetrisShape GetShape()
        {
            TetrisShape temp = currentShape;

            currentShape = nextShape;
            nextShape = GenerateShape();

            return temp;
        }

        private TetrisShape GenerateShape()
        {
            TetrisShape shape = new TetrisShape();
            AddAdjacentTiles(tetrisShapeEnum, shape);
            shape.color = PickRandomBrush();
            tetrisShapeEnum = nextShapeEnum;
            nextShapeEnum = (TetrisShapesEnum)random.Next(7);
            return shape;
        }

        private void AddAdjacentTiles(TetrisShapesEnum tetrisShapeEnum, TetrisShape shape)
        {
            switch (tetrisShapeEnum)
            {
                case TetrisShapesEnum.I:
                    shape.cords[1, 0] = shape.cords[0,0];
                    shape.cords[1, 1] = shape.cords[0,1] + 1;

                    shape.cords[2, 0] = shape.cords[0,0];
                    shape.cords[2, 1] = shape.cords[0,1] - 1;

                    shape.cords[3, 0] = shape.cords[0,0];
                    shape.cords[3, 1] = shape.cords[0,1] - 2;
                    break;
                case TetrisShapesEnum.O:
                    
                    shape.cords[1, 0] = shape.cords[0,0];
                    shape.cords[1, 1] = shape.cords[0,1] - 1;

                    shape.cords[2, 0] = shape.cords[0,0] + 1;
                    shape.cords[2, 1] = shape.cords[0,1] - 1;

                    shape.cords[3, 0] = shape.cords[0,0] + 1;
                    shape.cords[3, 1] = shape.cords[0,1];
                    break;
                case TetrisShapesEnum.L:
                    shape.cords[1, 0] = shape.cords[0,0];
                    shape.cords[1, 1] = shape.cords[0,1] - 1;

                    shape.cords[2, 0] = shape.cords[0,0];
                    shape.cords[2, 1] = shape.cords[0,1] - 2;

                    shape.cords[3, 0] = shape.cords[0,0] + 1;
                    shape.cords[3, 1] = shape.cords[0,1];

                    break;
                case TetrisShapesEnum.J:
                    shape.cords[1, 0] = shape.cords[0,0];
                    shape.cords[1, 1] = shape.cords[0,1] - 1;

                    shape.cords[2, 0] = shape.cords[0,0];
                    shape.cords[2, 1] = shape.cords[0,1] - 2;
                    
                    shape.cords[3, 0] = shape.cords[0,0] - 1;
                    shape.cords[3, 1] = shape.cords[0,1];
                    break;
                case TetrisShapesEnum.S:
                    shape.cords[1, 0] = shape.cords[0,0];
                    shape.cords[1, 1] = shape.cords[0,1] - 1;
                    
                    shape.cords[2, 0] = shape.cords[0,0] - 1;
                    shape.cords[2, 1] = shape.cords[0,1] - 1;

                    shape.cords[3, 0] = shape.cords[0,0] + 1;
                    shape.cords[3, 1] = shape.cords[0,1];
                    break;
                case TetrisShapesEnum.Z:
                    shape.cords[1, 0] = shape.cords[0,0];
                    shape.cords[1, 1] = shape.cords[0,1] - 1;

                    shape.cords[2, 0] = shape.cords[0,0] - 1;
                    shape.cords[2, 1] = shape.cords[0,1];
                    
                    shape.cords[3, 0] = shape.cords[0,0] + 1;
                    shape.cords[3, 1] = shape.cords[0,1] - 1;
                    break;
                case TetrisShapesEnum.T:
                    shape.cords[1, 0] = shape.cords[0,0];
                    shape.cords[1, 1] = shape.cords[0,1] - 1;

                    shape.cords[2, 0] = shape.cords[0,0] - 1;
                    shape.cords[2, 1] = shape.cords[0,1];
                    
                    shape.cords[3, 0] = shape.cords[0,0] + 1;
                    shape.cords[3, 1] = shape.cords[0,1];
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
