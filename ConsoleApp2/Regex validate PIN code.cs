using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/55f8a9c06c018a0d6e000132
namespace ConsoleApp2
{
    internal class RegexValidatePINCode
    {
        public static bool ValidatePin(string pin)
        {
            return Regex.IsMatch(pin, @"^[0-9]{4}\z|^[0-9]{6}\z");
        }
    }
}
