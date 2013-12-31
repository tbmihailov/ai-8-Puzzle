using AI.EightPuzzle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AI.EightPuzzle.Tests
{
    
    
    /// <summary>
    ///This is a test class for SolverTest and is intended
    ///to contain all SolverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Solver_Tests
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
        public void Test_Solver_Result_Moves_01()
        {
            var initialBoard = new Board(new int[][]{
            new int[]{6,5,3},
            new int[]{2,4,8},
            new int[]{7,0,1},
            });
            int expectedMoves = 21;

            int maxMoves = 2000; // TODO: Initialize to an appropriate value
            AI.EightPuzzle.Solver target = new AI.EightPuzzle.Solver(initialBoard, maxMoves, PriorityType.Manhattan); // TODO: Initialize to an appropriate value
            int actual = target.Moves;
            Assert.AreEqual(actual, expectedMoves);
        }

        [TestMethod()]
        public void Test_Solver_Result_Moves_02()
        {
            var initialBoard = new Board(new int[][]{
            new int[]{1,0,3},
            new int[]{8,2,4},
            new int[]{5,6,7},
            });

            int expectedMoves = 17;

            int maxMoves = 2000; // TODO: Initialize to an appropriate value
            AI.EightPuzzle.Solver target = new AI.EightPuzzle.Solver(initialBoard, maxMoves, PriorityType.Manhattan); // TODO: Initialize to an appropriate value
            int actual = target.Moves;
            Assert.AreEqual(actual, expectedMoves);
        }
    }
}
