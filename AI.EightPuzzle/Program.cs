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
            var initialBoard = new Board(new int[][]{
            new int[]{6,5,3},
            new int[]{2,4,8},
            new int[]{7,0,1},
            });

            var solver = new Solver(initialBoard, 2000);
            solver.WriteOutputToConsole();

            Console.ReadLine();
        }
    }
}
