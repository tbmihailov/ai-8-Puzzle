using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.EightPuzzle.Helpers;

namespace AI.EightPuzzle
{
    public class Board
    {
        public int Size
        {
            get { return _tiles.Length; }
        }

        public Board(int[][] tiles)
        {
            this._tiles = tiles;
        }

        int[][] _tiles;
        public int[][] Tiles
        {
            get { return _tiles; }
        }

        private List<Board> _successors;
        public List<Board> Successors
        {
            get
            {
                if (_successors == null)
                {
                    _successors = this.GetSolvableSuccessorStates();
                }
                return _successors;
            }
        }


        /// <summary>
        /// Generates board states from moving left/right/up/down tiles
        /// </summary>
        /// <returns></returns>
        public List<Board> GetSuccessorStates()
        {
            Board board = this;
            List<Board> nextStates = new List<Board>();

            int freeTileRow = 0;
            int freeTileColumn = 0;
            GetEmptyTilePoint(board, out freeTileRow, out freeTileColumn);

            //move left tile
            if (freeTileColumn > 0)
            {
                nextStates.Add(this.GetBoardFromMoveLeftTile());
            }

            //move right tile
            if (freeTileColumn < board.Size - 1)
            {
                nextStates.Add(this.GetBoardFromMoveRightTile());
            }

            //move up tile
            if (freeTileRow > 0)
            {
                nextStates.Add(this.GetBoardFromMoveUpTile());
            }


            if (freeTileRow < board.Size - 1)
            {
                nextStates.Add(this.GetBoardFromMoveDownTile());
            }

            return nextStates;
        }

        public List<Board> GetSolvableSuccessorStates()
        {
            var states = GetSuccessorStates();
            var solvableStates = states
                                    .Where(s => s.IsSolvable())
                                    .DefaultIfEmpty()
                                    .ToList();

            return solvableStates;
        }

        public Board GetBoardFromMoveLeftTile()
        {
            Board board = this;

            int freeTileRow = 0;
            int freeTileColumn = 0;
            GetEmptyTilePoint(board, out freeTileRow, out freeTileColumn);


            if (freeTileColumn == 0)
            {
                throw new InvalidOperationException();
            }

            var tiles = board.Tiles.CloneArray();
            int tileToMoveRow = freeTileRow;
            int tileToMoveColumn = freeTileColumn - 1;//left tile

            //swap tiles position
            int value = tiles[tileToMoveRow][tileToMoveColumn];
            tiles[tileToMoveRow][tileToMoveColumn] = 0;
            tiles[freeTileRow][freeTileColumn] = value;

            var newBoardState = new Board(tiles);

            return newBoardState;
        }

        public Board GetBoardFromMoveRightTile()
        {
            Board board = this;

            int freeTileRow = 0;
            int freeTileColumn = 0;
            GetEmptyTilePoint(board, out freeTileRow, out freeTileColumn);

            if (freeTileColumn >= (board.Size - 1))//last column
            {
                throw new InvalidOperationException();
            }

            var tiles = board.Tiles.CloneArray();
            int tileToMoveRow = freeTileRow;
            int tileToMoveColumn = freeTileColumn + 1;//right tile

            //swap tiles position
            int value = tiles[tileToMoveRow][tileToMoveColumn];
            tiles[tileToMoveRow][tileToMoveColumn] = 0;
            tiles[freeTileRow][freeTileColumn] = value;

            var newBoardState = new Board(tiles);

            return newBoardState;
        }

        public Board GetBoardFromMoveUpTile()
        {
            Board board = this;

            int freeTileRow = 0;
            int freeTileColumn = 0;
            GetEmptyTilePoint(board, out freeTileRow, out freeTileColumn);

            if (freeTileRow == 0)//zero row
            {
                throw new InvalidOperationException();
            }

            var tiles = board.Tiles.CloneArray();
            int tileToMoveRow = freeTileRow - 1;//up tile
            int tileToMoveColumn = freeTileColumn;

            //swap tiles position
            int value = tiles[tileToMoveRow][tileToMoveColumn];
            tiles[tileToMoveRow][tileToMoveColumn] = 0;
            tiles[freeTileRow][freeTileColumn] = value;

            var newBoardState = new Board(tiles);

            return newBoardState;
        }

        public Board GetBoardFromMoveDownTile()
        {
            Board board = this;

            int freeTileRow = 0;
            int freeTileColumn = 0;
            GetEmptyTilePoint(board, out freeTileRow, out freeTileColumn);

            if (freeTileRow >= board.Size - 1)//bottom row
            {
                throw new InvalidOperationException();
            }

            var tiles = board.Tiles.CloneArray();
            int tileToMoveRow = freeTileRow + 1;//down tile
            int tileToMoveColumn = freeTileColumn;

            //swap tiles position
            int value = tiles[tileToMoveRow][tileToMoveColumn];
            tiles[tileToMoveRow][tileToMoveColumn] = 0;
            tiles[freeTileRow][freeTileColumn] = value;

            var newBoardState = new Board(tiles);

            return newBoardState;
        }

        private void GetEmptyTilePoint(Board board, out int zeroRow, out int zeroColumn)
        {
            for (int i = 0; i < board.Tiles.Length; i++)
            {
                for (int j = 0; j < board.Tiles[i].Length; j++)
                {
                    if (board.Tiles[i][j] == 0)
                    {
                        zeroRow = i;
                        zeroColumn = j;

                        return;
                    }
                }
            }

            throw new ArgumentException("Board has no empty tile");
        }

        /// <summary>
        /// Generates new Default Goal Board depending on size
        /// Example: size=3
        /// 1 2 3
        /// 4 5 6
        /// 7 8 0
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Board GetDefaultGoalBoard(int size)
        {
            var tilesList = new List<int[]>() { };//dynamic array in c# can be initialized with list
            for (int i = 0; i < size; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < size; j++)
                {
                    int value = 0;
                    if (i != (size - 1) || j != (size - 1))//checks if last cell is reached
                    {
                        value = i * size + (j + 1);
                    }

                    row.Add(value);
                }
                tilesList.Add(row.ToArray());
            }

            int[][] tiles = tilesList.ToArray();

            var board = new Board(tiles);

            return board;
        }

        public bool IsGoal()
        {
            int size = Size;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int tileValue = Tiles[row][col];
                    int goalRow = ((tileValue - 1) / size);
                    int goalCol = ((tileValue - 1) % size);

                    if (Tiles[row][col] != 0
                        && (goalRow != row || goalCol != col))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///  Check if solvable
        /// </summary>
        /// Odd board size:
        /// Given a board, an inversion is any pair of blocks i and j where i < j but i appears after j when considering the board in row-major order (row 0, followed by row 1, and so forth).
        ///         1  2  3              1  2  3              1  2  3              1  2  3              1  2  3
        ///         4  5  6     =>       4  5  6     =>       4     6     =>          4  6     =>       4  6  7
        ///         8  7                 8     7              8  5  7              8  5  7              8  5 
        ///
        /// 1 2 3 4 5 6 8 7      1 2 3 4 5 6 8 7      1 2 3 4 6 8 5 7      1 2 3 4 6 8 5 7      1 2 3 4 6 7 8 5
        ///
        ///  inversions = 1       inversions = 1       inversions = 3       inversions = 3       inversions = 3
        ///          (8-7)                 (8-7)        (6-5 8-5 8-7)        (6-5 8-5 8-7)         (6-5 7-5 8-5)
        ///If the board size N is an odd integer, then each legal move changes the number of inversions by an even number. Thus, if a board has an odd number of inversions, then it cannot lead to the goal board by a sequence of legal moves because the goal board has an even number of inversions (zero).
        ///The converse is also true: if a board has an even number of inversions, then it can lead to the goal board by a sequence of legal moves.
        ///
        ///            1  3              1     3              1  2  3              1  2  3              1  2  3
        ///         4  2  5     =>       4  2  5     =>       4     5     =>       4  5        =>       4  5  6
        ///         7  8  6              7  8  6              7  8  6              7  8  6              7  8 
        /// 1 3 4 2 5 7 8 6      1 3 4 2 5 7 8 6      1 2 3 4 5 7 8 6      1 2 3 4 5 7 8 6      1 2 3 4 5 6 7 8
        ///  inversions = 4       inversions = 4       inversions = 2       inversions = 2       inversions = 0
        ///(3-2 4-2 7-6 8-6)   (3-2 4-2 7-6 8-6)            (7-6 8-6)            (7-6 8-6)         
        ///
        /// Even board size:
        /// If the board size N is an even integer, then the parity of the number of inversions is not invariant. However, the parity of the number of inversions plus the row of the blank square is invariant: each legal move changes this sum by an even number. If this sum is even, then it cannot lead to the goal board by a sequence of legal moves; if this sum is odd, then it can lead to the goal board by a sequence of legal moves.
        ///
        ///    1  2  3  4           1  2  3  4           1  2  3  4           1  2  3  4           1  2  3  4
        ///    5  6     8     =>    5  6     8     =>    5  6  7  8     =>    5  6  7  8     =>    5  6  7  8
        ///    9 10  7 11           9 10  7 11           9 10    11           9 10 11              9 10 11 12
        ///   13 14 15 12          13 14 15 12          13 14 15 12          13 14 15 12          13 14 15
        ///
        /// blank row = 1       blank row  = 1       blank row  = 2       blank row  = 2       blank row  = 3
        ///inversions = 6       inversions = 6       inversions = 3       inversions = 3       inversions = 0
        ///--------------       --------------       --------------       --------------       --------------
        ///       sum = 7              sum = 7              sum = 5              sum = 5              sum = 3
        /// <returns></returns>
        public bool IsSolvable()
        {
            //filll values in one dimensional array
            List<int> values = new List<int>();
            for (int i = 0; i < Tiles.Length; i++)
            {
                for (int j = 0; j < Tiles[i].Length; j++)
                {
                    if (Tiles[i][j] != 0)
                    {
                        values.Add(Tiles[i][j]);
                    }
                }
            }

            //count "inversions"
            int inversionsCount = 0;
            for (int valIndex = 0; valIndex < values.Count; valIndex++)
            {
                for (int valSuccIndex = valIndex + 1; valSuccIndex < values.Count; valSuccIndex++)
                {
                    if (values[valIndex] < values[valSuccIndex])
                    {
                        inversionsCount++;
                    }
                }
            }

            //check if solvable
            if (Size % 2 != 0)//odd
            {
                return inversionsCount % 2 == 0;
            }
            else//even
            {
                int emptyTileRow = 0;
                int emptyTileColumn = 0;
                GetEmptyTilePoint(this, out emptyTileRow, out emptyTileColumn);

                int valueCheck = inversionsCount + emptyTileRow;

                return valueCheck % 2 != 0;
            }
        }

        /// <summary>
        /// Hamming priority function. 
        /// The number of blocks in the wrong position, 
        /// plus the number of moves made so far to get to the state. Intutively, 
        /// a state with a small number of blocks in the wrong position is close 
        /// to the goal state, and we prefer a state that have been reached using 
        /// a small number of moves. 
        /// </summary>
        /// <returns>Number of blocks out of place</returns>
        public int HammingPriority()
        {
            int hammingValue = 0;
            int size = Size;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int tileValue = Tiles[row][col];
                    int goalRow = ((tileValue - 1) / size);
                    int goalCol = ((tileValue - 1) % size);

                    if (Tiles[row][col] != 0
                        && (goalRow != row || goalCol != col))
                    {
                        hammingValue++;
                    }
                }
            }

            return hammingValue;
        }

        /// <summary>
        /// Manhattan priority function. 
        /// The sum of the distances (sum of the vertical and horizontal distance) 
        /// from the blocks to their goal positions, plus the number of moves made 
        /// so far to get to the state. 
        /// </summary>
        /// <returns>Sum of Manhattan distances between blocks and goal</returns>
        public int ManhattanPriority()
        {
            int manhattanValue = 0;
            int size = Size;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (Tiles[row][col] != 0)
                    {
                        int tileValue = Tiles[row][col];

                        int goalRow = ((tileValue - 1) / size);
                        int goalCol = ((tileValue - 1) % size);

                        int valManhDistance = Math.Abs(goalRow - row) + Math.Abs(goalCol - col);
                        manhattanValue += valManhDistance;
                    }
                }
            }

            return manhattanValue;
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            for (int i = 0; i < Tiles.Length; i++)
            {
                for (int j = 0; j < Tiles[i].Length; j++)
                {
                    print.AppendFormat("{0,2}", Tiles[i][j]);
                }

                if (i != Tiles.Length - 1)
                {
                    print.AppendLine();
                }
            }

            return print.ToString();
        }

        public bool Equals(Board other)
        {
            if (other == null)
            {
                return false;
            }

            for (int i = 0; i < Tiles.Length; i++)
            {
                for (int col = 0; col < Tiles[i].Length; col++)
                {
                    if (this.Tiles[i][col] != other.Tiles[i][col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            bool areBoardsEqual = this.Equals((Board)obj);
            return areBoardsEqual;
        }

        /// <summary>
        /// Multidimensional array hashcode 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int tilesHashCode = ArrayHelpers.GetHashCode(this.Tiles);
            return tilesHashCode;
        }
    }

}
