using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/567e8f7b4096f2b4b1000005
namespace ConsoleApp2
{
    static class Regexp_Basics___is_it_a_eight_bit_unsigned_number
    {
        public static bool EightBitNumber(this string str)
        {
            foreach (var item in str)
            {
                Console.WriteLine((int)item);
            }
            return Regex.IsMatch(str, @"^[0-9]{1}$|^[1-9]{1}[0-9]{1}$|^1[0-9]{1,2}$|^2[0-4]{1}[0-9]{1}$|^2[0-5]{1,2}\z");
        }
    }
}
