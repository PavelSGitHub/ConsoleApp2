using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/567e8dbb9b6f4da558000030
namespace ConsoleApp2
{
    static internal class Regexp_Basics___is_it_a_six_bit_unsigned_number
    {
        public static bool SixBitNumber(this string str)
        {
            return Regex.IsMatch(str, @"^([0-9]{1}|[1-5]{1}[0-9]{1}|6[0-3]{1})\z");
        }
    }
}
