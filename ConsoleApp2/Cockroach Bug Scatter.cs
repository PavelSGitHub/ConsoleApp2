using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://www.codewars.com/kata/59aac7a9485a4dd82e00003e
namespace ConsoleApp2
{
    internal class CockroachBugScatter
    {
        public static int[] Cockroaches(char[][] room)
        {
            int index = 0;
            int[] result = new int[10];
            StringBuilder wallsB = new StringBuilder();
            wallsB.Append(room[0]);
            wallsB.Append(string.Concat(room[1..^1].Select(s => s.Last())));
            wallsB.Append(string.Concat(room[room.Length - 1].Reverse()));
            wallsB.Append(string.Concat(room[1..^1].Select(s => s.First()).Reverse()));
            var walls = wallsB.ToString();
            for (int i = 1; i < room.Length - 1; i++)
            {
                for (int j = 1; j < room[i].Length - 1; j++)
                {
                    switch (room[i][j])
                    {
                        case ' ':
                            continue;
                        case 'U':
                            index = j;
                            break;
                        case 'L':
                            index = walls.Length - i;
                            break;
                        case 'D':
                            index = walls.Length - (room.Length - 1 + j);
                            break;
                        case 'R':
                            index = room[i].Length - 1 + i;
                            break;
                        default:
                            break;
                    }
                    for (int w = index; w < walls.Length; w--)
                    {
                        if (char.IsDigit(walls[w]))
                        {
                            result[(int)char.GetNumericValue(walls[w])]++;
                            break;
                        }
                        if (w == 0)
                        {
                            w = walls.Length;
                        }
                    }
                }
            }
            return result;
        }
    }
}
