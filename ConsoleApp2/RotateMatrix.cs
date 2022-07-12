using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class RotateMatrix
    {
        public static int[][] RotateLikeAVortex(int[][] matrix)
        {
            int r = 0;
            int len = matrix.Length;
            int[][] result = matrix.Select(r => r.ToArray()).ToArray();
            for (int n = 0; n < len / 2; n++)
            {
                for (int repeat = 0; repeat < r + 1; repeat++)
                {
                    for (int i = 0; i < len - 1 - r * 2; i++)
                    {
                        int temp = result[i + r][r];
                        result[i + r][r] = result[r][len - 1 - i - r];
                        int temp2 = result[len - 1 - r][i + r];
                        result[len - 1 - r][i + r] = temp;
                        temp = result[len - 1 - i - r][len - 1 - r];
                        result[len - 1 - i - r][len - 1 - r] = temp2;
                        result[r][len - 1 - i - r] = temp;
                    }
                }
                r++;
            }
            return result;
        }
    }
}
