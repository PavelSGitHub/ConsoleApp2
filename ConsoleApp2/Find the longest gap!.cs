using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/55b86beb1417eab500000051
namespace ConsoleApp2
{
    internal class FindTheLongestGap
    {
        public static int Gap(int num)
        {

            return Regex.Replace(Convert.ToString(num, toBase: 2), @"^0+|0+$", string.Empty).Split('1').Max(s => s.Count(c => c == '0'));
        }
    }
}
