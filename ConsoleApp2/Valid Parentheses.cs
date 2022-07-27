using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://www.codewars.com/kata/52774a314c2333f0a7000688
namespace ConsoleApp2
{
    internal class Valid_Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            int c = 0;
            for (int i = 0; c >= 0 && c <= 50 && i < input.Length; i++)
            {
                c += input[i] == '(' ? 1 : input[i] == ')' ? -1 : 0;
            }
            return c == 0;
        }
    }
}
