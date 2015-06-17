using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// TODO
// play tetris song
// add a sound effect to clearing a row
// smoother row clear

namespace Tetris
{
    public partial class TetrisGame : Form
    {
        private TetrisGrid grid;
        private TetrisShape shape;
        private TetrisShapeFactory shapeFactory = new TetrisShapeFactory();

        public TetrisGame()
        {
            InitializeComponent();
            grid = new TetrisGrid(pictureBoxCanvas.Height, pictureBoxCanvas.Width);
            GameStart();
        }

        private void GameStart()
        {
            labelGameOver.Visible = false;
            labelGameOver2.Visible = false;
            Settings.NewSettings();
            grid.clearGrid();
        }

        private void CheckForPlayerInput(object sender, EventArgs e)
        {
            if (Settings.isGameOver && Input.isKeyPressed(Keys.Enter))
            {
                gameTimer.Start();
                actualTimer.Start();
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
                    TetrisShapeBehaviour.tryRotatingShape(shape, grid.boolGrid, grid.canvasMaxWidth, grid.canvasMaxHeight);
                }
                else if (Input.isKeyPressed(Keys.Enter))
                {
                    if(TetrisShapeBehaviour.dropDownInstantly(shape, grid.boolGrid, grid.brushGrid, grid.canvasMaxHeight))
                    {
                        shape = null;
                    }
                }
            }

            pictureBoxCanvas.Invalidate();
            pictureBoxNextShape.Invalidate();
        }

        #region Collision Detection for Moving Shapes

        private bool noCollisionsToTheLeft(TetrisShape shape)
        {
            for (int i = 0; i < 4; i++)
            {
                if (shape.cords[i, 0] == 0 || (shape.cords[i, 1] >=0 && grid.boolGrid[shape.cords[i, 0] - 1, shape.cords[i, 1]] == true))
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
                if (shape.cords[i, 0] == grid.canvasMaxWidth - 1 || (shape.cords[i, 1] >= 0 && grid.boolGrid[shape.cords[i, 0] + 1, shape.cords[i, 1]] == true))
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
                if (shape.cords[i, 1] == grid.canvasMaxHeight - 1 || (shape.cords[i, 1] >=0 && grid.boolGrid[shape.cords[i, 0], shape.cords[i, 1] + 1] == true))
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
                TetrisShapeBehaviour.AddNewShapeToGrid(shape, grid.boolGrid, grid.brushGrid);
                shape = null;
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
            //update
            if (Settings.isGameOver)
            {
                labelGameOver.Text = "\n\nGame Over.\nScore : " + Settings.score + "\n press Enter to restart";
                labelGameOver.Visible = true;
                labelGameOver2.Visible = true;
                gameTimer.Stop();
                actualTimer.Stop();
                labelTime.Text = "0";
            }
            AutoFall();
        }

        private void completedRowCheckTimer_Tick(object sender, EventArgs e)
        {
            if (shape == null)
            {
                if (Settings.score > Settings.scoreNeededForNextLevel)
                {
                    Settings.scoreNeededForNextLevel += 5000;
                    Settings.level++;
                    labelLevel.Text = (Settings.level + 1).ToString();
                    gameTimer.Interval = 1000 / (Settings.level + 1);
                }
                shape = shapeFactory.GetNextShape();
            }
            else if (grid.CheckForCompletedRows())
            {
                grid.ProcessCompletedRows();
                labelScore.Text = Settings.score.ToString();
                pictureBoxCanvas.Invalidate();
                pictureBoxNextShape.Invalidate();
            }
        }

        private void pictureBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

            if (shape != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (shape.cords[i, 0] >= 0 && shape.cords[i, 1] >= 0)
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

            for (int i = 0; i < grid.canvasMaxHeight; i++)
                for (int j = 0; j < grid.canvasMaxWidth; j++)
                {
                    if (grid.indexesOfCompletedRows.Contains(i))
                    {
                        canvas.FillRectangle(Brushes.White, j * Settings.tileWidth,
                                                i * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);
                    }
                    else if (grid.boolGrid[j, i] == true)
                    {
                        canvas.FillRectangle(grid.brushGrid[j, i], j * Settings.tileWidth,
                                                i * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);

                        canvas.DrawRectangle(pen, j * Settings.tileWidth,
                                                i * Settings.tileHeight,
                                                Settings.tileWidth, Settings.tileHeight);
                    }
                }
        }

        private void pictureBoxNextShape_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Pen pBlack = new Pen(Color.Black, 2);
            pBlack.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

            TetrisShape nextShape = shapeFactory.currentShape;

            if (nextShape != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    canvas.FillRectangle(nextShape.color, (nextShape.cords[i, 0] - 3) * Settings.tileWidth,
                                            (nextShape.cords[i, 1] + 2) * Settings.tileHeight,
                                            Settings.tileWidth, Settings.tileHeight);

                    canvas.DrawRectangle(pBlack, (nextShape.cords[i, 0] - 3) * Settings.tileWidth,
                                            (nextShape.cords[i, 1] + 2) * Settings.tileHeight,
                                            Settings.tileWidth, Settings.tileHeight);
                }
            }
        }

        private void actualTimer_Tick(object sender, EventArgs e)
        {
            ///increment game timer
            int x = System.Convert.ToInt32(labelTime.Text);
            x++;
            labelTime.Text = x.ToString();
        }
    }
}
