using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private int canvasMaxWidth;
        private int canvasMaxHeight;
        private Tile tile = new Tile(); // to be deleted
        private TetrisShape shape;
        private TetrisShapeFactory shapeFactory = new TetrisShapeFactory();

        private bool[,] grid;
        private Brush[,] brushGrid;
        private int completedRows;
        private List<int> indexesOfCompletedRows = new List<int>();

        public Form1()
        {
            InitializeComponent();
            new Input();
            new Settings();

            canvasMaxHeight = pictureBoxCanvas.Height / Settings.tileHeight;
            canvasMaxWidth = pictureBoxCanvas.Width/ Settings.tileWidth;

            grid =  new bool[canvasMaxWidth,canvasMaxHeight]; // [10,20]
            brushGrid = new Brush[canvasMaxWidth, canvasMaxHeight]; // [10,20]

            playerInputTimer.Tick += CheckForPlayerInput;
            gameTimer.Tick += Update;
            GameStart();
        }
        private void GameStart()
        {
            labelGameOver.Visible = false;
            labelGameOver2.Visible = false;
            new Settings();
            clearGrid();
            completedRows = 0;
        }

        private void clearGrid()
        {
            for (int i = 0; i < canvasMaxWidth; i++)
            {
                for (int j = 0; j < canvasMaxHeight; j++)
                {
                    grid[i, j] = false;
                    brushGrid[i, j] = null;
                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            checkForGameOver();            
            if(Settings.isGameOver)
            {
                labelGameOver.Text = "\n\nGame Over.\nScore : " + Settings.score + "\n press Enter to restart";
                labelGameOver.Visible = true;
                labelGameOver2.Visible = true;
                gameTimer.Stop();
                labelTime.Text = "0";
            }
            else if (shape == null)
            {
                if (Settings.score > Settings.scoreNeededForNextLevel)
                {
                    Settings.scoreNeededForNextLevel += 5000;
                    Settings.level++;
                    labelLevel.Text = (Settings.level + 1).ToString();
                    gameTimer.Interval = 1000 / (Settings.level + 1);
                }
                tile = new Tile { X = 4, Y = 2 };
                shape = shapeFactory.GetShape();

            }
            else 
            {
                if (completedRows > 0)
                {
                    ProcessCompletedRows();
                    labelScore.Text = Settings.score.ToString();
                }
                AutoFall();
            }
        }

        private void checkForGameOver()
        {
            if (shape!=null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (grid[shape.cords[i, 0], shape.cords[i, 1]] == true)
                    {
                        Settings.isGameOver = true;
                    }
                }                
            }

            for (int i = 0; i < canvasMaxWidth; i++)
            {
                if(grid[i,0]==true)
                    Settings.isGameOver = true;
            }
        }

        private void ProcessCompletedRows()
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
                            grid[j, i] = grid[j, i - 1];
                            brushGrid[j, i] = brushGrid[j, i - 1];

                        }
                    }

                    for (int i = 0; i < canvasMaxWidth; i++)
                    {
                        grid[i, 0] = false;
                        brushGrid[i, 0] = null;
                    }

                    indexesOfCompletedRows.Remove(indexesOfCompletedRows[0]);
                    completedRows--;
                }
        }

        private void CheckForPlayerInput(object sender, EventArgs e)
        {
            if (Settings.isGameOver && Input.isKeyPressed(Keys.Enter))
            {
                gameTimer.Start();
                GameStart();
            }

            if(shape == null)
            {
                return;
            }
            else 
            {
                if (Input.isKeyPressed(Keys.Left) && !Input.isKeyPressed(Keys.Right))
                {
                    if (noCollisionsToTheLeft(shape))
                    {
                        TetrisShapeBehaviour.ShiftLeft(shape);                     
                    }
                }
                else if (Input.isKeyPressed(Keys.Right) && !Input.isKeyPressed(Keys.Left))
                {
                    if (noCollisionsToTheRight(shape))
                    {
                        TetrisShapeBehaviour.ShiftRight(shape);
                    }
                }
                else if (Input.isKeyPressed(Keys.Down) && noCollisionsBelow(shape))
                {
                    TetrisShapeBehaviour.DropDown(shape);
                }
                else if (Input.isKeyPressed(Keys.Up))
                {
                    TetrisShapeBehaviour.tryRotatingShape(shape, grid, canvasMaxWidth, canvasMaxHeight);
                }
            }

            CheckForCompletedRows();
            pictureBoxCanvas.Invalidate();
            pictureBoxNextShape.Invalidate();
        }

        #region Collision Detection for Moving Shapes

        private bool noCollisionsToTheLeft(TetrisShape shape)
        {
            for (int i = 0; i < 4; i++)
            {
                if (shape.cords[i, 0] == 0 || grid[shape.cords[i, 0] - 1, shape.cords[i, 1]] == true)
                {
                    return false;
                }                                 
            }
            return true;
        }

        private bool noCollisionsToTheRight(TetrisShape shape)
        {
            for (int i = 0; i < 4; i++)
            {
                if (shape.cords[i, 0] == canvasMaxWidth - 1 || grid[shape.cords[i, 0] + 1, shape.cords[i, 1]] == true)
                {
                    return false;
                }                                 
            }
            return true;
        }

        private bool noCollisionsBelow(TetrisShape shape)
        {
            for (int i = 0; i < 4; i++)
            {
                if (shape.cords[i, 1] == canvasMaxHeight - 1 || grid[shape.cords[i, 0], shape.cords[i, 1] + 1] == true)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion


        private void AutoFall()
        {
            if (noCollisionsBelow(shape))
            {
                for (int i = 0; i < 4; i++)
                {
                    shape.cords[i, 1]++;
                }
            }
            else 
            {
                TetrisShapeBehaviour.AddToGrid(shape, grid, brushGrid);
                shape = null;
            }
        }

        private void CheckForCompletedRows()
        {
            int filledCell = 0;

            for (int i = 0; i < canvasMaxHeight; i++)
            {
                if(grid[0,i]==true)
                {
                    for (int j = 0; j < canvasMaxWidth; j++)
                    {
                        if (grid[j, i] == true)
                            filledCell++;
                    }

                    if (filledCell == 10 && !indexesOfCompletedRows.Contains(i))
                    {
                        indexesOfCompletedRows.Add(i);
                        completedRows++;
                    }
                }
                filledCell = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false);
        }

        private void GameTimerIncrement_Timer(object sender, EventArgs e)
        {
            int x = System.Convert.ToInt32(labelTime.Text);
            x++;
            labelTime.Text = x.ToString();
        }


        #region Graphics

        private void pictureBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            
            if(shape!=null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (shape.cords[i, 0] >= 0 && shape.cords[i, 1] >=0)
                    {
                        canvas.FillRectangle(shape.color, shape.cords[i, 0] * Settings.tileWidth,
                                                shape.cords[i, 1] * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);
                       
                        canvas.DrawRectangle(pen, shape.cords[i, 0] * Settings.tileWidth,
                                                shape.cords[i, 1] * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);
                    }
                }
            }

            for (int i = 0; i < canvasMaxHeight; i++)
            {
                for (int j = 0; j < canvasMaxWidth; j++)
                {

                    if (indexesOfCompletedRows.Contains(i))
                    {
                        canvas.FillRectangle(Brushes.White, j * Settings.tileWidth,
                                                i * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);
                    }
                    else if (grid[j, i] == true)
                    {
                        canvas.FillRectangle(brushGrid[j,i], j * Settings.tileWidth,
                                                i * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);

                        canvas.DrawRectangle(pen, j * Settings.tileWidth,
                                                i * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);
                    }
                }
            }

        }

        private void pictureBoxNextShape_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

            TetrisShape nextShape = shapeFactory.currentShape;

            if (nextShape != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (nextShape.cords[i, 0] >= 0 && nextShape.cords[i, 1] >= 0)
                    {
                        canvas.FillRectangle(nextShape.color, (nextShape.cords[i, 0] - 3) * Settings.tileWidth,
                                                nextShape.cords[i, 1] * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);

                        canvas.DrawRectangle(pen, (nextShape.cords[i, 0] - 3) * Settings.tileWidth,
                                                nextShape.cords[i, 1] * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);
                    }
                }
            }

        }

        #endregion  
    }
}
