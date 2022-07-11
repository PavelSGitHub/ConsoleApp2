using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Agregate
    {
        // Абсолютная разница меджу прозведением всех членов массива int[] a и произведением всех членов массива int[] b
        public static int FindDifference(int[] a, int[] b) => Math.Abs(
            a.Aggregate(1, (x, y) => x * y) //прозведение всех членов массива int[] a
            - 
            b.Aggregate(1, (x, y) => x * y)); //прозведение всех членов массива int[] b


        //Write a function insert_dash(num) / insertDash(num) / InsertDash(int num)
        //that will insert dashes ('-') between each two odd digits in num.
        //For example: if num is 454793 the output should be 4547-9-3. Don't count zero as an odd digit.
        public static string InsertDash(int num)
        {
            /*string tmp = num.ToString();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tmp.Length -1; i++)
            {
                if (Convert.ToInt32(tmp[i]) % 2 != 0 && Convert.ToInt32(tmp[i + 1]) % 2 != 0)
                    sb.Append(tmp[i] + "-");
                else
                    sb.Append(tmp[i]);
            }
            sb.Append(tmp[^1]);
            return sb.ToString();*/
            return num.ToString().Aggregate("", (a, b) => {
                if (a.Length > 0 && Convert.ToInt32(a[^1]) % 2 != 0 && Convert.ToInt32(b) % 2 != 0)
                    return a + "-" + b;
                return a + b;
            });
        }
    }
}
