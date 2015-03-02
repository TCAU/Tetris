using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    // static class with game settings
    class Settings
    {
        public static int tileWidth;
        public static int tileHeight;
        public static int score = 0;
        public static bool isGameOver;
        public static int level;
        public static int scoreNeededForNextLevel;

        public static int basePointsSingle;
        public static int basePointsDouble;
        public static int basePointsTriple;
        public static int basePointsTetris;

        public Settings()
        {
            
            level = 0;
            scoreNeededForNextLevel = 5000;

            tileHeight = tileWidth = 25;
            score = 0;
            basePointsSingle = 100;
            basePointsDouble = 100;
            basePointsTriple = 100;
            basePointsTetris = 100;

            isGameOver = false;
        }


    }
}
