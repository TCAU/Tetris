using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace TetrisTests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void ShouldDetectCompletedRowsAtTheBottom()
        {
            //arrange
            TetrisGrid sut = new TetrisGrid(500, 250); ;

            //act
            for (int i = 0; i < sut.boolGrid.GetLength(0); i++)
            {
                sut.boolGrid[i, 19] = true;
            }

            //assert
            Assert.IsTrue(sut.CheckForCompletedRows());
        }


        [TestMethod]
        public void ShouldDetectCompletedRowsAtTheTop()
        {
            //arrange
            TetrisGrid sut = new TetrisGrid(500, 250);;

            //act
            for (int i = 0; i < sut.boolGrid.GetLength(0); i++)
            {
                sut.boolGrid[i, 0] = true;
            }

            //assert
            Assert.IsTrue(sut.CheckForCompletedRows());
        }

        [TestMethod]
        public void GridsShouldBeTenByTwenty()
        {
            //arrange
            TetrisGrid sut; 

            //act
            sut = new TetrisGrid(500, 250);

            //assert
            Assert.AreEqual(sut.boolGrid.GetLength(0), 10);
            Assert.AreEqual(sut.boolGrid.GetLength(1), 20);
            Assert.AreEqual(sut.brushGrid.GetLength(0), 10);
            Assert.AreEqual(sut.brushGrid.GetLength(1), 20);
        }
    }
}
