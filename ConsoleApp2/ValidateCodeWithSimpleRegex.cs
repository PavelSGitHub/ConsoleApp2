using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/56a25ba95df27b7743000016
namespace ConsoleApp2
{
    internal class ValidateCodeWithSimpleRegex
    {
        public static bool ValidateCode(string code)
        {
            return Regex.IsMatch(code, @"^[1|2|3]");
        }
    }
}
