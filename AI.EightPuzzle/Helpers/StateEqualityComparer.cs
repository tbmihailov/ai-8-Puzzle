using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle
{
  public class  StateEqualityComparer : IEqualityComparer<State>
    {
      public bool Equals(State x, State y)
        {
            return x.Board.Equals(y.Board);
        }

      public int GetHashCode(State obj)
        {
            return obj.Board.GetHashCode();
        }
    }
}
