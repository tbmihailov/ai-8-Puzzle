using AI.EightPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AI.EightPuzzle.Tests
{


    /// <summary>
    ///This is a test class for BoardTest and is intended
    ///to contain all BoardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Board_Tests
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void Test_ToString()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,5,6},
                            new int[]{7,8,0},
                            };
            Board target = new Board(tiles);
            string expected = " 1 2 3\r\n 4 5 6\r\n 7 8 0";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_Equals_If_Works_When_Equal()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,5,3},
                            new int[]{4,2,6},
                            new int[]{7,8,0},
                            };
            Board target = new Board(tiles);

            int[][] otherTiles = new int[][]{
                            new int[]{1,5,3},
                            new int[]{4,2,6},
                            new int[]{7,8,0},
                            };
            Board otherBoard = new Board(otherTiles);
            bool areEqual = target.Equals(otherBoard);
            Assert.IsTrue(areEqual);
        }

        [TestMethod()]
        public void Test_Equals_If_Works_When_Not_Equal()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,5,3},
                            new int[]{4,6,2},
                            new int[]{7,8,0},
                            };
            Board target = new Board(tiles);

            int[][] otherTiles = new int[][]{
                            new int[]{1,5,3},
                            new int[]{4,2,6},
                            new int[]{7,8,0},
                            };
            Board otherBoard = new Board(otherTiles);
            bool areEqual = target.Equals(otherBoard);
            Assert.IsFalse(areEqual);
        }

        [TestMethod()]
        public void Test_If_GetDefaultGoalBoard_Return_True_Goal_State()
        {
            int size = 3;
            Board expected = new Board(new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,5,6},
                            new int[]{7,8,0},
                            });
            Board actual = Board.GetDefaultGoalBoard(size);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_HammingValue_Primer_1()
        {
            int[][] tiles = new int[][]{
                            new int[]{8,1,3},
                            new int[]{4,0,2},
                            new int[]{7,6,5},
                            };
            Board target = new Board(tiles);
            int expected = 5;
            int actual = target.HammingValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_HammingValue_Primer_2()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,7,6},
                            new int[]{5,8,0},
                            };
            Board target = new Board(tiles);
            int expected = 2;
            int actual = target.HammingValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_If_IsInGoalState_Works_When_True()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,5,6},
                            new int[]{7,8,0},
                            };
            Board target = new Board(tiles);
            bool actual = target.IsInGoalState();

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void Test_If_IsInGoalState_Works_When_False()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,5,3},
                            new int[]{4,0,6},
                            new int[]{7,8,2},
                            };
            Board target = new Board(tiles);
            bool actual = target.IsInGoalState();

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Test_ManhattanValue_Primer_1()
        {
            int[][] tiles = new int[][]{
                            new int[]{8,1,3},
                            new int[]{4,0,2},
                            new int[]{7,6,5},
                            };
            Board target = new Board(tiles);
            int expected = 10;
            int actual = target.ManhattanValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_ManhattanValue_Primer_2()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,7,3},
                            new int[]{4,2,6},
                            new int[]{5,8,0},
                            };
            Board target = new Board(tiles);
            int expected = 6;
            int actual = target.ManhattanValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_GetBoard_From_Move_Left_Tile()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,0,6},
                            new int[]{7,5,8},
                            };
            Board initialBoard = new Board(tiles);

            //expected
            int[][] expectedTiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{0,4,6},
                            new int[]{7,5,8},
                            };
            Board expectedBoard = new Board(expectedTiles);


            //actual
            Board actualBoard = initialBoard.GetBoardFromMoveLeftTile();

            bool areEqual = expectedBoard.Equals(actualBoard);
            Assert.IsTrue(areEqual);
        }

        [TestMethod()]
        public void Test_GetBoard_From_Move_Right_Tile()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,0,6},
                            new int[]{7,5,8},
                            };
            Board initialBoard = new Board(tiles);

            //expected
            int[][] expectedTiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,6,0},
                            new int[]{7,5,8},
                            };
            Board expectedBoard = new Board(expectedTiles);


            //actual
            Board actualBoard = initialBoard.GetBoardFromMoveRightTile();

            bool areEqual = expectedBoard.Equals(actualBoard);
            Assert.IsTrue(areEqual);
        }

        [TestMethod()]
        public void Test_GetBoard_From_Move_Up_Tile()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,0,6},
                            new int[]{7,5,8},
                            };
            Board initialBoard = new Board(tiles);

            //expected
            int[][] expectedTiles = new int[][]{
                            new int[]{1,0,3},
                            new int[]{4,2,6},
                            new int[]{7,5,8},
                            };
            Board expectedBoard = new Board(expectedTiles);


            //actual
            Board actualBoard = initialBoard.GetBoardFromMoveUpTile();

            bool areEqual = expectedBoard.Equals(actualBoard);
            Assert.IsTrue(areEqual);
        }

        [TestMethod()]
        public void Test_GetBoard_From_Move_Down_Tile()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,0,6},
                            new int[]{7,5,8},
                            };
            Board initialBoard = new Board(tiles);

            //expected
            int[][] expectedTiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,5,6},
                            new int[]{7,0,8},
                            };
            Board expectedBoard = new Board(expectedTiles);


            //actual
            Board actualBoard = initialBoard.GetBoardFromMoveDownTile();

            bool areEqual = expectedBoard.Equals(actualBoard);
            Assert.IsTrue(areEqual);
        }

        [TestMethod()]
        public void Test_GetNextStates_When_NoLeft_Allowed()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{0,4,6},
                            new int[]{7,5,8},
                            };
            Board initialBoard = new Board(tiles);


            //expected

            //right
            Board expectedBoard0 = new Board(
                 new int[][]{
                            new int[]{1,2,3},
                            new int[]{4,0,6},
                            new int[]{7,5,8},
                            });
            //up
            Board expectedBoard1 = new Board(
                 new int[][]{
                            new int[]{0,2,3},
                            new int[]{1,4,6},
                            new int[]{7,5,8},
                            });

            //down
            Board expectedBoard2 = new Board(
              new int[][]{
                            new int[]{1,2,3},
                            new int[]{7,4,6},
                            new int[]{0,5,8},
                            });


            //actual
            List<Board> actualBoards = initialBoard.GetNextStates();


            bool areAllOk = actualBoards[0].Equals(expectedBoard0)
                && actualBoards[1].Equals(expectedBoard1)
                && actualBoards[2].Equals(expectedBoard2);
            Assert.IsTrue(areAllOk);
        }

        [TestMethod()]
        public void Test_If_IsInSolvableState_Works_For_Odd_Size_Expected_False_1()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3},
                            new int[]{0,4,6},
                            new int[]{8,5,7},
                            };
            Board target = new Board(tiles);
            bool expected = false;
            bool actual = target.IsInSolvableState();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_If_IsInSolvableState_Works_For_Odd_Size_Expected_True_1()
        {
            int[][] tiles = new int[][]{
                            new int[]{0,1,3},
                            new int[]{4,2,5},
                            new int[]{7,8,6},
                            };
            Board target = new Board(tiles);
            bool expected = true;
            bool actual = target.IsInSolvableState();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void Test_If_IsInSolvableState_Works_For_Even_Size_Expected_True_1()
        {
            int[][] tiles = new int[][]{
                            new int[]{1,2,3,4},
                            new int[]{5,6,0,8},
                            new int[]{9,10,0,11},
                            new int[]{13,14,15,12},
                            };

            Board target = new Board(tiles);
            bool expected = true;
            bool actual = target.IsInSolvableState();
            Assert.AreEqual(expected, actual);
        }
    }
}
