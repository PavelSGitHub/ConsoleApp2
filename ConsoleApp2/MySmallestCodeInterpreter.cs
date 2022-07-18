using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.codewars.com/kata/526156943dfe7ce06200063e

namespace ConsoleApp2
{
    internal class MySmallestCodeInterpreter
    {
        public static string BrainLuck(string code, string input)
        {
            int cellsPtr = 0;
            int inputPtr = 0;
            byte[] cells = new byte[30000];
            int ignore = 0;
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i])
                {
                    case ',':
                        cells[cellsPtr] = (byte)input[inputPtr];
                        inputPtr++;
                        break;
                    case '>':
                        cellsPtr++;
                        break;
                    case '<':
                        cellsPtr--;
                        break;
                    case '+':
                        cells[cellsPtr]++;
                        break;
                    case '-':
                        cells[cellsPtr]--;
                        break;
                    case '.':
                        output.Append((char)cells[cellsPtr]);
                        break;
                    case '[':
                        if (cells[cellsPtr] != 0)
                        {
                            continue;
                        }
                        else
                        {
                            for (int j = i + 1; j < code.Length; j++)
                            {
                                if (code[j] == '[')
                                {
                                    ignore++;
                                }
                                else if (ignore != 0 && code[j] == ']')
                                {
                                    ignore--;
                                }
                                else if (ignore == 0 && code[j] == ']')
                                {
                                    i = j;
                                    break;
                                }
                            }
                        }
                        break;
                    case ']':
                        if (cells[cellsPtr] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            for (int j = i - 1; j > 0; j--)
                            {
                                if (code[j] == ']')
                                {
                                    ignore++;
                                }
                                else if (ignore != 0 && code[j] == '[')
                                {
                                    ignore--;
                                }
                                else if (ignore == 0 && code[j] == '[')
                                {
                                    i = j;
                                    break;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return output.ToString();
        }
    }
}
