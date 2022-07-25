using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/5917fbed9f4056205a00001e
namespace ConsoleApp2
{
    internal class BananasKata
    {
        public static HashSet<string> Bananas(string s)
        {
            HashSet<string> result = new();
            for (int i = 0; true; i++)
            {
                var combination = Convert.ToString(i, toBase: 2);
                if (combination.Length > s.Length)
                {
                    break;
                }
                if (combination.Count(c => c == '1') == s.Length - 6)
                {
                    if (combination.Length != s.Length)
                    {
                        combination = combination.PadLeft(s.Length, '0');
                    }
                    var tmp = s.ToCharArray();
                    for (int j = 0; j < combination.Length; j++)
                    {
                        if (combination[j] == '1')
                        {
                            tmp[j] = '-';
                        }
                    }
                    if (string.Concat(tmp.Where(c => c != '-')) == "banana")
                    {
                        result.Add(string.Concat(tmp));
                    }
                }
            }
            return result;
        }
    }
}
