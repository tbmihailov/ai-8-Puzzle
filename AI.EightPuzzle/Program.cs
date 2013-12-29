using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
    class Program
    {
        //assignment: http://www.cs.princeton.edu/courses/archive/fall12/cos226/assignments/8puzzle.html
        //http://www.cs.princeton.edu/courses/archive/fall11/cos226/checklist/8puzzle.html
        static void Main(string[] args)
        {
            var board = new Board(new int[][]{
            new int[]{1,2,3},
            new int[]{4,5,6},
            new int[]{7,8,0},
            });

            var board1 = Board.GetDefaultGoalBoard(3);
            Console.WriteLine(board1.ToString());
            bool isGoalState = board1.IsInGoalState();
        }
    }
}
