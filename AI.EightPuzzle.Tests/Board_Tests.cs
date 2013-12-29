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
        public void GetNextStatesTest()
        {
            int[][] tiles = null; // TODO: Initialize to an appropriate value
            Board target = new Board(tiles); // TODO: Initialize to an appropriate value
            List<Board> expected = null; // TODO: Initialize to an appropriate value
            List<Board> actual;
            actual = target.GetNextStates();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
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
    }
}
