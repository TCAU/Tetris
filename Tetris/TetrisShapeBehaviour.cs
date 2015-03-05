using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    // static class that contains methods for manipulating TetrisShapes

    class TetrisShapeBehaviour
    {
        public static void ShiftRight(TetrisShape shape)
        {
            for (int i = 0; i < 4; i++)
            {
                shape.cords[i, 0] = shape.cords[i, 0] + 1;
            }
        }

        public static void ShiftLeft(TetrisShape shape)
        {
            for (int i = 0; i < 4; i++)
            {
                shape.cords[i, 0] = shape.cords[i, 0] - 1;
            }
        }
        public static void DropDown(TetrisShape shape)
        {
            for (int i = 0; i < 4; i++)
            {
                shape.cords[i, 1] = shape.cords[i, 1] + 1;
            }
        }

        public static bool dropDownInstantly(TetrisShape shape, bool[,] grid, Brush[,] brushgrid, int canvasMaxHeight)
        {
            int i = 0;

            while (nextRowIsEmpty(shape, grid, canvasMaxHeight, i))
            {
                i++;
            }

            if (i>0)
            {
                for (int j = 0; j < 4; j++)
                {
                    shape.cords[j, 1] += i;
                }

                AddToGrid(shape, grid, brushgrid);
                return true;
            }
            return false;
        }

        private static bool nextRowIsEmpty(TetrisShape shape, bool[,] grid, int canvasMaxHeight, int i)
        {
            for (int j = 0; j < 4; j++)
            {
                if (shape.cords[j, 1] < 0)
                {
                    return false;
                }
                else if (shape.cords[j, 1] + i == canvasMaxHeight - 1 || grid[shape.cords[j, 0], shape.cords[j, 1] + i + 1] == true)
                {
                    return false;
                }
            }
            return true;
        }

        public static void AddToGrid(TetrisShape shape, bool[,] grid, Brush[,] brushgrid)
        {
            for (int i = 0; i < 4; i++)
            {
                grid[shape.cords[i, 0], shape.cords[i, 1]] = true;
                brushgrid[shape.cords[i, 0], shape.cords[i, 1]] = shape.color;
            }
        }


        #region Shape Rotation

        public static void tryRotatingShape(TetrisShape shape, bool[,] grid, int canvasMaxWidth, int canvasMaxHeight)
        {
            if (NoCollisionsWhenRotating(shape, grid, canvasMaxWidth, canvasMaxHeight))
            {
                RotateShape(shape);
            }
        }

        private static bool NoCollisionsWhenRotating(TetrisShape shape, bool[,] grid, int canvasMaxWidth, int canvasMaxHeight)
        {
            TetrisShape testShape = new TetrisShape();
            MakeTetrisShapeCopy(testShape, shape);

            RotateShape(testShape);

            for (int i = 0; i < 4; i++)
            {
                if (testShape.cords[i, 0] < 0 || testShape.cords[i, 0] > canvasMaxWidth - 1)
                {
                    return false;
                }

                if (testShape.cords[i, 1] > canvasMaxHeight - 1)
                {
                    return false;
                }

                if (testShape.cords[i, 1] >= 0 && grid[testShape.cords[i, 0], testShape.cords[i, 1]] == true)
                {
                    return false;
                }
            }
            return true;
        }

        private static void MakeTetrisShapeCopy(TetrisShape copy, TetrisShape original)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    copy.cords[i, j] = original.cords[i, j];
                }
            }
        }

        private static void RotateShape(TetrisShape shape)
        {
            for (int i = 1; i < 4; i++)
            {
                // all cords are in are relation to the pivot tile, which is [0,0]

                if ((shape.cords[i, 1] - shape.cords[0, 1]) == 1 && shape.cords[i, 0] == shape.cords[0, 0]) // [0,1] to [-1,0]
                {
                    shape.cords[i, 0]--;
                    shape.cords[i, 1]--;
                }
                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == 1 && shape.cords[i, 1] == shape.cords[0, 1])  // [1,0] to [0,1]
                {
                    shape.cords[i, 0]--;
                    shape.cords[i, 1]++;
                }
                else if ((shape.cords[i, 1] - shape.cords[0, 1]) == -1 && shape.cords[i, 0] == shape.cords[0, 0]) // [1,0] to [0,1]
                {
                    shape.cords[i, 0]++;
                    shape.cords[i, 1]++;
                }
                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == -1 && shape.cords[i, 1] == shape.cords[0, 1]) // [-1,0] to [0,-1]
                {
                    shape.cords[i, 0]++;
                    shape.cords[i, 1]--;
                }

                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == 1 && (shape.cords[i, 1] - shape.cords[0, 1]) == 1) // [1,1] to [-1,1]
                {
                    shape.cords[i, 0] -= 2;
                }
                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == -1 && (shape.cords[i, 1] - shape.cords[0, 1]) == 1) // [-1,1] to [-1,-1]
                {
                    shape.cords[i, 1] -= 2;
                }
                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == -1 && (shape.cords[i, 1] - shape.cords[0, 1]) == -1) // [-1,-1] to [1,-1]
                {
                    shape.cords[i, 0] += 2;
                }
                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == 1 && (shape.cords[i, 1] - shape.cords[0, 1]) == -1) // [1,-1] to [1,1]
                {
                    shape.cords[i, 1] += 2;
                }

                else if ((shape.cords[i, 1] - shape.cords[0, 1]) == 2 && shape.cords[i, 0] == shape.cords[0, 0]) // [0,2] to [-2,0]
                {
                    shape.cords[i, 0] -= 2;
                    shape.cords[i, 1] -= 2;
                }
                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == -2 && shape.cords[i, 1] == shape.cords[0, 1]) // [-2,0] to [0,-2]
                {
                    shape.cords[i, 0] += 2;
                    shape.cords[i, 1] -= 2;
                }
                else if ((shape.cords[i, 1] - shape.cords[0, 1]) == -2 && shape.cords[i, 0] == shape.cords[0, 0]) // [0,-2] to [2,0]
                {
                    shape.cords[i, 0] += 2;
                    shape.cords[i, 1] += 2;
                }
                else if ((shape.cords[i, 0] - shape.cords[0, 0]) == 2 && shape.cords[i, 1] == shape.cords[0, 1])  // [2,0] to [0,2]
                {
                    shape.cords[i, 0] -= 2;
                    shape.cords[i, 1] += 2;
                }


            }

        }
        #endregion
    }
}
