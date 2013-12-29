using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
    public class Board
    {
        private int _size;
        public int Size
        {
            get { return _size; }
        }

        public Board(int[][] tiles)
        {
            this._tiles = tiles;
            this._size = tiles.Length;
        }

        int[][] _tiles;
        public int[][] Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        List<Board> _nextStates;
        public List<Board> GetNextStates()
        {
            throw new NotImplementedException();
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

        public bool IsInGoalState()
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
        /// Hamming priority function. 
        /// The number of blocks in the wrong position, 
        /// plus the number of moves made so far to get to the state. Intutively, 
        /// a state with a small number of blocks in the wrong position is close 
        /// to the goal state, and we prefer a state that have been reached using 
        /// a small number of moves. 
        /// </summary>
        /// <returns>Number of blocks out of place</returns>
        public int HammingValue()
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
        public int ManhattanValue()
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
    }
}
