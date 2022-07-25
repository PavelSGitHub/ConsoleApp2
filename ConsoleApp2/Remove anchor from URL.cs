using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/51f2b4448cadf20ed0000386
namespace ConsoleApp2
{
    internal class RemoveAnchorFromURL
    {
        public static string RemoveUrlAnchor(string url)
        {
            return Regex.Replace(url, @"#.*", string.Empty);
        }
    }
}
