using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Zip_Fibkind
    {
        public static long LengthSupUK(int n, int k)
        {
            return Un(n).Count(i => i >= k);
        }
        public static long Comp(int n)
        {
            var tmp = Un(n);
            /* 
            int c = 0;
            for (int i = 1; i < n; i++)
            {
                if (tmp[i - 1] > tmp[i])
                    c++;
            }
            return c;
            */
            return tmp.Zip(tmp.Skip(1), (i, j) => new { i, j }).Count(t => t.i > t.j);
        }
        public static List<int> Un(int n)
        {
            List<int> list = new() { 1, 1 };
            for (int i = 2; i < n; i++)
            {
                list.Add(list[i - list[i - 1]] + list[i - list[i - 2]]);
            }
            return list;
        }
    }
}
