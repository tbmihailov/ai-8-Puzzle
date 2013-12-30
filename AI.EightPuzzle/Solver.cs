using NGenerics.DataStructures.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
    public class Solver
    {
        Board _initialBoard;
        public Solver(Board initialBoard, int maxMoves)
        {
            _initialBoard = initialBoard;
            Solve(maxMoves);
        }

        private List<Board> _solution;
        public List<Board> Solution
        {
            get { return _solution; }
        }

        private int _moves;
        public int Moves
        {
            get { return _moves; }
        }
        
        private void Solve(int maxMovesCount)
        {
            Board currentState = null;
            Board previousState = null;
            int movesCount=0;
            List<Board> solution = new List<Board>();

            PriorityQueue<Board, int> priorityQueue = new PriorityQueue<Board,int>(PriorityQueueType.Minimum);
            var initialBoard = _initialBoard;
            priorityQueue.Enqueue(initialBoard, initialBoard.ManhattanPriority());

            while (priorityQueue.Count > 0 && movesCount<maxMovesCount)
            {
                previousState = currentState;
                
                currentState = priorityQueue.Dequeue();
                if (solution.Contains(currentState, new BoardEqualityComparer()))
                {
                    continue;
                }

                solution.Add(currentState);
                movesCount++;
                if (currentState.IsGoal())
                {
                    _solution = solution;
                    _moves = movesCount;
                    return;
                }
                else
                {
                    var successors = currentState.GetSuccessorStates();
                    foreach(var board in successors)
                    {
                        if (!board.Equals(previousState) && !solution.Contains(board, new BoardEqualityComparer()))
                        {
                            priorityQueue.Enqueue(board, board.ManhattanPriority());
                        }
                    }
                }
            }

            throw new Exception(string.Format("No solution in {0} moves", movesCount));
        }

        public void WriteOutputToConsole()
        {
            var solver = this;
            Console.WriteLine("Moves:{0}", solver.Moves);
            //Console.WriteLine("Solution moves:");
            //foreach (var board in solver.Solution)
            //{
            //    Console.WriteLine(board);
            //    Console.WriteLine();
            //}
        }
    }
}
