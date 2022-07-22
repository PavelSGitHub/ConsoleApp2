using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/588f5a38ec641b411200005b
namespace ConsoleApp2
{
    internal class DifferenceBetweenYears
    {
        public static int HowManyYears(string date1, string date2)
        {
            return Math.Abs(int.Parse(Regex.Match(date1, @"\d*").Value) - int.Parse(Regex.Match(date2, @"\d*").Value));
        }
    }
}
