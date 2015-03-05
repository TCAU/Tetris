using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    // static class with game settings
    static class Settings
    {
        public static int tileWidth = 25;
        public static int tileHeight = 25;
        public static int score = 0;
        public static bool isGameOver = false;
        public static int level = 0;
        public static int scoreNeededForNextLevel = 5000;

        public static int basePointsSingle = 100;
        public static int basePointsDouble = 100;
        public static int basePointsTriple = 100;
        public static int basePointsTetris = 100;

        public static void NewSettings()
        {            
            level = 0;
            scoreNeededForNextLevel = 5000;
            score = 0;
            isGameOver = false;
        }

    }
}
