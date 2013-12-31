using NGenerics.DataStructures.Queues;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
    public class Solver
    {
        Board _initialBoard;

        public Solver(Board initialBoard, int maxMoves, PriorityType priorityType)
        {
            _initialBoard = initialBoard;
            Solve(initialBoard, maxMoves, priorityType);
        }

        private State _solution;
        public State Solution
        {
            get { return _solution; }
        }

        private int _moves;
        public int Moves
        {
            get { return _moves; }
        }

        private int _statesChecked;
        public int StatesChecked
        {
            get { return _statesChecked; }
        }
        

        private void Solve(Board initialBoard, int maxMovesCount, PriorityType priorityType)
        {
            State currentState = null;
            int movesCount = 0;
            int statesChecked = 0;

            PriorityQueue<State, int> priorityQueue = new PriorityQueue<State, int>(PriorityQueueType.Minimum);
            var initialState = new State(initialBoard, null, 0, priorityType);

            priorityQueue.Enqueue(initialState, initialState.Priority());
            HashSet<Board> closedStates = new HashSet<Board>();

            while (priorityQueue.Count > 0 && movesCount < maxMovesCount)
            {
                currentState = priorityQueue.Dequeue();
                closedStates.Add(currentState.Board);

                statesChecked++;
                movesCount = currentState.MovesCount;
                if (currentState.IsGoal())
                {
                    _solution = currentState;
                    _moves = currentState.MovesCount;
                    _statesChecked = statesChecked;
                    return;
                }
                else
                {
                    List<State> successors = currentState.SuccessorStates;
                    foreach (var state in successors)
                    {
                        if (!closedStates.Contains(state.Board, new BoardEqualityComparer()))
                        {
                            priorityQueue.Enqueue(state, state.Priority());
                        }
                    }
                }
            }

            throw new Exception(string.Format("No solution in {0} moves", movesCount));
        }


        public void WriteOutputWitStatesToConsole()
        {
            var solver = this;
            Console.WriteLine("Moves:{0}", solver.Moves);
            Console.WriteLine("States checked:{0}", solver.StatesChecked);
            Console.WriteLine("Solution moves:");

            List<State> solutionStates = Solution.GetSolutionStates();
            foreach (var state in solutionStates)
            {
                Console.WriteLine(state.Board);
                Console.WriteLine("Manhattan:{0}", state.Board.ManhattanPriority());
                Console.WriteLine("Hamming:{0}", state.Board.HammingPriority());
                Console.WriteLine();
            }
        }
    }
}
