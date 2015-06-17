namespace Tetris
{
    partial class TetrisGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.playerInputTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.labelGameOver = new System.Windows.Forms.Label();
            this.pictureBoxNextShape = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelGameOver2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.completedRowCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.actualTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNextShape)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.White;
            this.pictureBoxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(250, 500);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score: ";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(349, 15);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(13, 13);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "0";
            // 
            // playerInputTimer
            // 
            this.playerInputTimer.Enabled = true;
            this.playerInputTimer.Interval = 50;
            this.playerInputTimer.Tick += new System.EventHandler(this.CheckForPlayerInput);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time: ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(349, 31);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(13, 13);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerIncrement_Timer);
            // 
            // labelGameOver
            // 
            this.labelGameOver.BackColor = System.Drawing.Color.Transparent;
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelGameOver.ForeColor = System.Drawing.Color.Black;
            this.labelGameOver.Location = new System.Drawing.Point(12, 12);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(250, 500);
            this.labelGameOver.TabIndex = 5;
            this.labelGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxNextShape
            // 
            this.pictureBoxNextShape.BackColor = System.Drawing.Color.White;
            this.pictureBoxNextShape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNextShape.Location = new System.Drawing.Point(310, 190);
            this.pictureBoxNextShape.Name = "pictureBoxNextShape";
            this.pictureBoxNextShape.Size = new System.Drawing.Size(77, 100);
            this.pictureBoxNextShape.TabIndex = 6;
            this.pictureBoxNextShape.TabStop = false;
            this.pictureBoxNextShape.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxNextShape_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Next :";
            // 
            // labelGameOver2
            // 
            this.labelGameOver2.Location = new System.Drawing.Point(310, 190);
            this.labelGameOver2.Name = "labelGameOver2";
            this.labelGameOver2.Size = new System.Drawing.Size(77, 100);
            this.labelGameOver2.TabIndex = 8;
            this.labelGameOver2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Level :";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(349, 46);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(13, 13);
            this.labelLevel.TabIndex = 10;
            this.labelLevel.Text = "1";
            // 
            // completedRowCheckTimer
            // 
            this.completedRowCheckTimer.Enabled = true;
            this.completedRowCheckTimer.Interval = 10;
            this.completedRowCheckTimer.Tick += new System.EventHandler(this.completedRowCheckTimer_Tick);
            // 
            // actualTimer
            // 
            this.actualTimer.Enabled = true;
            this.actualTimer.Interval = 1000;
            this.actualTimer.Tick += new System.EventHandler(this.actualTimer_Tick);
            // 
            // TetrisGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 526);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelGameOver2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBoxNextShape);
            this.Controls.Add(this.labelGameOver);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxCanvas);
            this.Name = "TetrisGame";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNextShape)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer playerInputTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.PictureBox pictureBoxNextShape;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelGameOver2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Timer completedRowCheckTimer;
        private System.Windows.Forms.Timer actualTimer;
    }
}

