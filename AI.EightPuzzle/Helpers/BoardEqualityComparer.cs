using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
    public class  BoardEqualityComparer : IEqualityComparer<Board>
    {
        public bool Equals(Board x, Board y)
        {
           return x.Equals(y);
        }

        public int GetHashCode(Board obj)
        {
            return obj.GetHashCode();
        }
    }
}
