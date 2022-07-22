using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://www.codewars.com/kata/58e77c88fd2d893a77000102
namespace ConsoleApp2
{
    internal class CitySwim2D
    {
        static long Calculate(int[] arr)
        {
            int leftTowerIndex = 0;
            int rightTowerIndex;
            long result = 0;
            while (arr[leftTowerIndex..].Length >= 3)
            {
                rightTowerIndex = Array.IndexOf(arr[(leftTowerIndex + 1)..], arr[(leftTowerIndex + 1)..].Max())
                        + leftTowerIndex + 1;
                if (rightTowerIndex - leftTowerIndex > 1)
                {
                    result += arr[rightTowerIndex]
                                * arr[(leftTowerIndex + 1)..rightTowerIndex].Length
                                - arr[(leftTowerIndex + 1)..rightTowerIndex].Sum();
                }
                leftTowerIndex = rightTowerIndex;
            }
            return result;
        }

        public static long RainVolume(int[] towers)
        {
            if (towers.Length < 3)
            {
                return 0;
            }
            var maxI = Array.IndexOf(towers, towers.Max());
            var arrL = towers[..(maxI + 1)].Reverse().ToArray();
            var arrR = towers[maxI..];
            return Calculate(arrL) + Calculate(arrR);
        }
    }
}
