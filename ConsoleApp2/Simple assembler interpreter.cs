using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://www.codewars.com/kata/58e24788e24ddee28e000053
namespace ConsoleApp2
{
    internal class Simple_assembler_interpreter
    {
        public static Dictionary<string, int> Interpret(string[] program)
        {
            Dictionary<string, int> result = new();
            var p = program.Select(s => s.Split(' '));
            for (int i = 0; i < p.Count(); i++)
            {
                var instruction = p.ElementAt(i);
                switch (p.ElementAt(i)[0])
                {
                    case "mov":
                        var value = int.TryParse(instruction[2], out int a) ? a : result[instruction[2]];
                        if (result.ContainsKey(instruction[1]))
                        {
                            result[instruction[1]] = value;
                        }
                        else
                        {
                            result.Add(instruction[1], value);
                        }
                        break;
                    case "inc":
                        result[instruction[1]]++;
                        break;
                    case "dec":
                        result[instruction[1]]--;
                        break;
                    case "jnz":
                        if ((result.ContainsKey(instruction[1]) && result[instruction[1]] != 0) || (int.TryParse(instruction[1], out int b) && b != 0))
                        {
                            i += (int.TryParse(instruction[2], out int c) && c != 0 ? c : result[instruction[1]]) - 1;
                        }
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
