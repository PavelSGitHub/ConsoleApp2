using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/56a3f08aa9a6cc9b75000023
namespace ConsoleApp2
{
    internal class SimpleValidation
    {
        public static bool ValidateUsr(string username)
        {
            return Regex.IsMatch(username, @"^[a-z\d_]{4,16}\z");
        }
    }
}
