using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisGrid
    {
        public int canvasMaxWidth;
        public int canvasMaxHeight;

        public bool[,] boolGrid;
        public  Brush[,] brushGrid;

        public int completedRows;
        public List<int> indexesOfCompletedRows = new List<int>();

        public TetrisGrid(int height, int width)
        {
            canvasMaxHeight = height / Settings.tileHeight;
            canvasMaxWidth = width / Settings.tileWidth;

            boolGrid = new bool[canvasMaxWidth, canvasMaxHeight]; // should be [10,20]
            brushGrid = new Brush[canvasMaxWidth, canvasMaxHeight]; // should be [10,20]
        }


        public void clearGrid()
        {
            for (int i = 0; i < canvasMaxWidth; i++)
                for (int j = 0; j < canvasMaxHeight; j++)
                {
                    boolGrid[i, j] = false;
                    brushGrid[i, j] = null;
                }
            completedRows = 0;
        }

        public void ProcessCompletedRows()
        {
            switch (completedRows)
            {
                case 1:
                    Settings.score += 50;
                    break;
                case 2:
                    Settings.score += 150;
                    break;
                case 3:
                    Settings.score += 450;
                    break;
                case 4:
                    Settings.score += 1350;
                    break;
                default:
                    break;
            }

            while (completedRows > 0)
            {
                for (int i = indexesOfCompletedRows[0]; i > 0; i--)
                {
                    for (int j = 0; j < canvasMaxWidth; j++)
                    {
                        boolGrid[j, i] = boolGrid[j, i - 1];
                        brushGrid[j, i] = brushGrid[j, i - 1];

                    }
                }

                for (int i = 0; i < canvasMaxWidth; i++)
                {
                    boolGrid[i, 0] = false;
                    brushGrid[i, 0] = null;
                }

                indexesOfCompletedRows.Remove(indexesOfCompletedRows[0]);
                completedRows--;
            }
        }

        public bool CheckForCompletedRows()
        {
            for (int i = 0; i < canvasMaxHeight; i++)
            {
                int filledCell = 0;
                if (boolGrid[0, i] == true)
                {
                    for (int j = 0; j < canvasMaxWidth; j++)
                    {
                        if (boolGrid[j, i] == true)
                            filledCell++;
                    }

                    if (filledCell == 10 && !indexesOfCompletedRows.Contains(i))
                    {
                        indexesOfCompletedRows.Add(i);
                        completedRows++;
                    }
                }
            }

            return (completedRows > 0);
        }

    }
}
