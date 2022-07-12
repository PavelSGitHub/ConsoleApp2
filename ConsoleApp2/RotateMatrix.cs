using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class RotateMatrix
    {
                                         /*{ 5, 3, 6, 1 },
                                 new int[] { 5, 8, 7, 4 },
                                 new int[] { 1, 2, 4, 3 },
                                 new int[] { 3, 1, 2, 2 }*/
        public static int[][] RotateLikeAVortex(int[][] matrix)
        {
            int r = 0;
            int len = matrix.Length;
            int[][] input = new int[len][];
            int[][] result = new int[len][];
            for (int i = 0; i < len; i++)
            {
                input[i] = new int[len];
                result[i + r] = new int[len];
                for (int j = 0; j < len; j++)
                {
                    input [i][j] = matrix[i][j];
                    result [i][j] = matrix[i][j];
                }
            }
            for (int n = 0; n < len / 2; n++)
            {
                for (int repeat = 0; repeat < r + 1; repeat++)
                {
                    for (int i = 0; i < len - 1 - r * 2; i++)
                    {
                        result[i + r][r] = input[r][len - 1 - i -r];
                        result[len - 1 - r][i + r] = input[i + r][r];
                        result[len - 1 - i - r][len - 1 - r] = input[len - 1 - r][i + r];
                        result[r][len - 1 - i - r] = input[len - 1 - i - r][len - 1 - r];

                        input[i + r][r] = result[i + r][r];
                        input[len - 1 - r][i + r] = result[len - 1 - r][i + r];
                        input[len - 1 - i - r][len - 1 - r] = result[len - 1 - i - r][len - 1 - r];
                        input[r][len - 1 - i - r] = result[r][len - 1 - i - r];
                    }
                }
                r++;
            }
            return result;
        }
    }
}
