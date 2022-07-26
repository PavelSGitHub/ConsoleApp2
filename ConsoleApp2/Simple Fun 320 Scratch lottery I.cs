using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/594a1822a2db9e93bd0001d4
namespace ConsoleApp2
{
    internal class Simple_Fun_320_Scratch_lottery_I
    {
        public static int Scratch(string[] lottery)
        {
            return lottery.Sum(s => Regex.Matches(s, @"\w+").Select(m => m.Value).ToHashSet().Count == 2 ? int.Parse(Regex.Match(s, @"\d+").Value) : 0);
        }
    }
}
