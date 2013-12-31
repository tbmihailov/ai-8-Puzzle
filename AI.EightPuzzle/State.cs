using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
    public class State
    {
        Board _board;
        public Board Board
        {
            get { return _board; }
        }

        State _previousState;
        public State PreviousState
        {
            get { return _previousState; }
        }

        int _movesCount;
        public int MovesCount
        {
            get { return _movesCount; }
        }

        PriorityType _priorityType;

        public State(Board board, State previous, int movesCount, PriorityType priorityType)
        {
            this._board = board;
            this._previousState = previous;
            this._movesCount = movesCount;
            this._priorityType = priorityType;
        }

        public bool IsGoal()
        {
            return Board.IsGoal();
        }

        List<State> _successorStates;
        public List<State> SuccessorStates
        {
            get
            {
                if (_successorStates == null)
                {
                    _successorStates = GetSuccessorStates();
                }
                return _successorStates;
            }
        }

        private List<State> GetSuccessorStates()
        {
            var neighbourBoards = Board.GetSuccessorStates();
            List<State> succStates = new List<State>();
            foreach (var board in neighbourBoards)
            {
                if (!this.IsContainedInSolutionChain(board))
                {
                    var newState = new State(board, this, MovesCount + 1, _priorityType);
                    succStates.Add(newState);
                }
            }


            return succStates;
        }

        private bool IsContainedInSolutionChain(Board board)
        {
            State state = this;
            while (state.PreviousState != null)
            {
                if (state.PreviousState.Board.Equals(board))
                {
                    return true;
                }

                state = state.PreviousState;
            }

            return false;
        }

        public List<State> GetSolutionStates()
        {
            List<State> states = new List<State>();
            State state = this;
            while (state != null)
            {
                states.Add(state);
                state = state.PreviousState;
            }

            return states.OrderBy(s=>s.MovesCount).ToList();
        }

        public int Priority()
        {
            return MovesCount + Board.Priority(_priorityType);
        }
    }
}
