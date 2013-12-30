using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.EightPuzzle.Helpers
{
    public static class ArrayHelpers
    {
        public static int[][] CloneArray(this int[][] arrayToCopy)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < arrayToCopy.Length; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < arrayToCopy[i].Length; j++)
                {
                    row.Add(arrayToCopy[i][j]);                    
                }
                list.Add(row.ToArray());
            }

            return list.ToArray();
        }

        /// <summary>
        /// Multidimensional array hash code.
        /// Remark:Modification of http://stackoverflow.com/questions/3404715/c-sharp-hashcode-for-array-of-ints suggestion for single dimensional array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetHashCode(int[][] array)
        {
            int elemCount = array.Sum(a => a.Count());
            int hc = elemCount;

            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length ; j++)
                {
                    hc = unchecked(hc * 314159 + array[i][j]);    
                }
                
            }
            return hc;
        }
    }
}
