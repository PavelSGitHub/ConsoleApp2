using System.Globalization;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FileMaster FM = new FileMaster("/Users/person1/Pictures/house.png");
            //Robot vicky = new Robot();
            //Console.WriteLine(TwoSum(new[] { 1234, 5678, 9012 }, 14690)[0] + " " + TwoSum(new[] { 1234, 5678, 9012 }, 14690)[1]);

            Console.WriteLine(ValidateCodeWithSimpleRegex.ValidateCode("8"));
   
        }

        //https://www.codewars.com/kata/562b099becfe844f3800000a/train/csharp
        public static int BouncyRatio(double p)
        {
            if (p < 0 || p > 0.99) throw new ArgumentException("input cannot be less than 0.1 or greater than 0.99");
            if (p == 0) return 1;
            int bouncy = 0;
            var ratio = 0d;
            bool inc = false;
            bool dec = false;
            int i = 0;
            while (ratio < p)
            {
                i++;
                var s = i.ToString();
                for (int j = 0; j < s.Length - 1 && (!inc || !dec); j++)
                {
                    if (s[j] < s[j + 1])
                    {
                        inc = true;
                    }
                    else if (s[j] > s[j + 1])
                    {
                        dec = true;
                    }
                }
                if (inc && dec)
                {
                    bouncy++;
                }
                inc = false;
                dec = false;
                ratio = bouncy / (double)i;
            }
            return i;
        }

        public static string AntBridge(string ants, string terrain)
        {
            if (!terrain.Contains('.')) return ants;
            terrain = terrain.Replace(".-.", "...").Replace(".-.", "...");
            Queue<char> que = new Queue<char>();
            foreach (char c in ants.Reverse())
            {
                que.Enqueue(c);
            }
            for (int i = 0; i < terrain.Count(c => c == '.') + terrain.Replace("-.", "1").Count(c => c == '1') * 2; i++)
            {
                que.Enqueue(que.Dequeue());
            }
            return string.Concat(que.Reverse());
        }

        public static Dictionary<string, int> ParseMolecule(string formula)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var f = formula.ToCharArray();
            int brackets = 0;
            int bracketsIgnore = 0;
            string current = "";
            int currentCount = 0;
            for (int i = 0; i < f.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                if (char.IsLetter(f[i]) && char.IsUpper(f[i]))
                {
                    if (i < f.Length - 1 && char.IsLetter(f[i + 1]) && char.IsLower(f[i + 1]))
                    {
                        sb.Append(f[i]);
                        for (int j = i + 1; j < f.Length; j++)
                        {
                            if (char.IsLower(f[j]))
                            {
                                sb.Append(f[j]);
                                i++;
                            }
                            else
                                break;
                        }
                        current = sb.ToString();
                        sb.Clear();
                    }
                    else
                    {
                        current = f[i].ToString();
                    }
                    if (i < f.Length - 1 && !char.IsDigit(f[i + 1]))
                    {
                        currentCount = 1;
                    }
                    else if (i < f.Length - 1 && char.IsDigit(f[i + 1]))
                    {
                        for (int j = i + 1; j < f.Length; j++)
                        {
                            if (char.IsDigit(f[j]))
                            {
                                sb.Append(f[j]);
                                i++;
                            }
                            else
                                break;
                        }
                        currentCount = int.Parse(sb.ToString());
                        sb.Clear();
                    }
                    else
                    {
                        currentCount = 1;
                    }
                    if (i > 0)
                    {
                        for (int j = i; j >= 0; j--)
                        {
                            if ("{[(".Contains(f[j])) brackets++;
                            else if ("}])".Contains(f[j])) brackets--;
                        }
                        if (brackets != 0)
                        {
                            for (int j = i + 1; j < f.Length && brackets != 0; j++)
                            {
                                sb.Clear();
                                if (j == f.Length - 1)
                                {
                                    break;
                                }
                                if (brackets > 0)
                                {
                                    if ("{[(".Contains(f[j]))
                                    {
                                        bracketsIgnore++;
                                    }
                                    else if ("}])".Contains(f[j]) && bracketsIgnore != 0)
                                    {
                                        bracketsIgnore--;
                                    }
                                    else if ("}])".Contains(f[j]) && bracketsIgnore == 0)
                                    {
                                        if (j < f.Length - 1 && char.IsDigit(f[j + 1]))
                                        {
                                            for (int n = j + 1; n < f.Length; n++)
                                            {
                                                if (char.IsDigit(f[n]))
                                                {
                                                    sb.Append(f[n]);
                                                }
                                                else
                                                    break;
                                            }
                                            currentCount *= int.Parse(sb.ToString());
                                        }
                                        brackets--;
                                    }
                                }
                            }
                        }
                    }
                    if (result.ContainsKey(current))
                        result[current] += currentCount;
                    else
                        result.Add(current, currentCount);
                }
            }
            return result;
        }

        public static int PeakHeight(char[][] mountain)
        {
            int[][] m = new int[mountain.Length][];
            bool zero = true;
            for (int i = 0; i < mountain.Length; i++)
            {
                m[i] = new int[mountain[i].Length];
                for (int j = 0; j < mountain[i].Length; j++)
                {
                    m[i][j] = mountain[i][j] == ' ' ? -1 : 0;
                    if (m[i][j] == 0) zero = false;
                }
            }
            if (zero) return 0;
            List<int> min = new List<int>();
            for (int n = 2; string.Concat(m.Select(i => string.Concat(i.Select(j => j == 0)))).Contains("True"); n++)
            {
                for (int i = 0; i < m.Length; i++)
                {
                    for (int j = 0; j < m[i].Length; j++)
                    {
                        if (m[i][j] == 0 && (i == 0 || i == m.Length - 1 || j == m[i].Length - 1))
                        {
                            m[i][j] = 1;
                        }
                        else if (m[i][j] == 0 && j == 0)
                        {
                            m[i][j] = 1;
                        }
                        else if (m[i][j] == 0
                            && (j == 0
                            || m[i][j - 1] == -1
                            || m[i][j + 1] == -1
                            || m[i - 1][j] == -1
                            || m[i + 1][j] == -1))
                        {
                            m[i][j] = 1;
                        }
                        else if (m[i][j] == 0 || (m[i][j] == 0 && m[i][j + 1] != 0))
                        {
                            if (m[i][j - 1] > 0) min.Add(m[i][j - 1]);
                            if (m[i][j + 1] > 0) min.Add(m[i][j + 1]);
                            if (m[i - 1][j] > 0) min.Add(m[i - 1][j]);
                            if (m[i + 1][j] > 0) min.Add(m[i + 1][j]);
                            if (min.Count() > 0 && min.Min() + 1 <= n)
                                m[i][j] = min.Min() + 1;
                            min.Clear();
                        }
                    }
                }
            }
            return m.Select(i => i.Max()).Max();
        }

        /*public static int PeakHeight(char[][] m)
        {
            for (int i = 0; i < m.Length - 1; i++)
            {
                m[i] = string.Concat(m[i]).Replace("^", $"{i + 1}").ToCharArray();
                m[m.Length - 1 - i] = string.Concat(m[m.Length - 1 - i]).Replace("^", $"{i + 1}").ToCharArray();
                char n = char.Parse($"{i + 1}");
                for (int j = i + 1; j < m.Length - 1; j++)
                {
                    var elemIndex = m[j].ToList().FindIndex(c => c == '^');
                    if (elemIndex != -1)
                        m[j][elemIndex] = n;
                    else
                        break;
                }
                for (int ii = 1; ii < m.Length - 1 && i == 0; ii++)
                {
                    for (int j = m[ii].Length - 1; j > 0; j--)
                    {
                        if (m[ii][j] == '^' && (j == m[ii].Length - 1 || m[ii][j + 1] == ' ' || (m[ii - 1][j] == ' ' || m[ii + 1][j] == ' ')))
                        {
                            m[ii][j] = '1';
                        }
                    }
                }
                for (int j = i + 1; j < m.Length - 1 && i != 0; j++)
                {
                    Array.Reverse(m[j]);
                    var elemIndex = m[j].ToList().FindIndex(c => c == '^');
                    if (elemIndex != -1)
                        m[j][elemIndex] = n;
                    Array.Reverse(m[j]);
                }
            }
            //Console.WriteLine((int)char.GetNumericValue(string.Concat(m.Select(r => r.Where(c => char.IsDigit(c))).Select(i => string.Join(string.Empty, i))).ToCharArray().Max()));
            return (int)char.GetNumericValue(string.Concat(m.Select(r => r.Where(c => char.IsDigit(c))).Select(i => string.Join(string.Empty, i))).ToCharArray().Max());
        }*/

        public static int SumGroups(int[] arr)
        {
            int sum = 0;
            var list1 = new List<int>();
            var list = arr.ToList();
            while (Check(list))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] % 2 == 0)
                    {
                        for (int j = i; j < list.Count && list[j] % 2 == 0; j++)
                        {
                            sum += list[j];
                            i = j;
                        }
                        list1.Add(sum);
                        sum = 0;
                    }
                    else
                    {
                        for (int j = i; j < list.Count && list[j] % 2 != 0; j++)
                        {
                            sum += list[j];
                            i = j;
                        }
                        list1.Add(sum);
                        sum = 0;
                    }

                }
                list.Clear();
                list1.ForEach(i => list.Add(i));
                list1.Clear();
            }
            Console.WriteLine(String.Join(",", list));
            return list.Count();
        }

        public static bool Check(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] % 2 == 0 && list[i + 1] % 2 == 0)
                    return true;
                else if (list[i] % 2 != 0 && list[i + 1] % 2 != 0)
                    return true;
            }
            return false;
        }

        public static int[] SortTwisted37(int[] array)
        {
            string result = string.Join(' ', array.OrderBy(i => i));
            result = result.Replace('3', '_');
            result = result.Replace('7', '3');
            result = result.Replace('_', '7');
            result = string.Join(" ", result.Split().OrderBy(i => i));
            result = result.Replace('3', '_');
            result = result.Replace('7', '3');
            result = result.Replace('_', '7');
            return result.Split().Select(i => int.Parse(i)).ToArray();
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            /*var result = new int[2];
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        break;
                    }
                }
            }
            Console.WriteLine(result[0] + " " + result[1]);
            return result;*/
            return Enumerable.Range(0, numbers.Length).Select(i => Enumerable.Range(i + 1, numbers.Length - i - 1).Select(j => numbers[i] + numbers[j] == target ? new[] { i, j } : new[] { -1, -1 }).Where(p => p[0] != -1).ToArray()).ToArray().Where(p => p.Length > 0).ToArray()[0][0];
        }

        public static string SortCsvColumns(string csvFileContent)
        {
            var inputArr = csvFileContent.Split("\n").Select(s => s.Split(';')).ToArray();
            var rowsCount = csvFileContent.Split("\n").Count();
            var sb = new StringBuilder();
            var colsCount = inputArr[0].Length;
            var cols = new List<string>();
            for (int i = 0; i < colsCount; i++)
            {
                for (int j = 0; j < rowsCount; j++)
                {
                    sb.Append($"{inputArr[j][i]};");
                }
                cols.Add(sb.ToString()[..^1]);
                sb.Clear();
            }
            cols = cols.OrderBy(s => s.Split(';').First()).ToList();
            return string.Join("\n", Enumerable.Range(0, rowsCount).Select(i => string.Join(';', cols.Select(s => s.Split(';')[i]))));
        }

        public static string Order(string words)
        {
            /*var list = words.Split();
            var result = new List<string>(list);
            foreach (var word in list)
            {
                var index = Convert.ToInt32(string.Concat(word.Where(c => char.IsDigit(c)))) - 1;
                result.Insert(index, word);
                result.RemoveAt(index + 1);
            }
            return String.Join(" ", result);*/

            //return String.Join(" ", words.Split().OrderBy(s => s.ToList().Find(c => char.IsDigit(c))));
            return String.Join(" ", words.Split().OrderBy(w => w.SingleOrDefault(char.IsDigit)));
        }

        public static string Likes(string[] name)
        {
            switch (name.Length)
            {
                case 0: return "no one likes this";
                case 1: return $"{name[0]} likes this";
                case 2: return $"{name[0]} and {name[1]} like this";
                case 3: return $"{name[0]}, {name[1]} and {name[2]} like this";
                default: return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            }
        }

        public static string[] WhoEatsWho(string zoo)
        {
            if (zoo.Length < 1) return new string[] { };
            var dict = new Dictionary<string, string>()
            {
                { "antelope", "grass" },
                { "big-fish", "little-fish" },
                { "bug", "leaves" },
                { "bear", "big-fish bug chicken cow leaves sheep" },
                { "chicken", "bug" },
                { "cow", "grass" },
                { "fox", "chicken sheep" },
                { "giraffe", "leaves" },
                { "lion", "antelope cow" },
                { "panda", "leaves" },
                { "sheep", "grass" }
            };
            var list = new List<string>();
            list.Add(zoo);
            List<string> input = zoo.Split(',').ToList();
            for (int i = 0; i < input.Count && input.Count > 1; i++)
            {
                if (!dict.ContainsKey(input.ElementAt(i)))
                    continue;
                if (i == 0)
                {
                    if (dict[input.ElementAt(i)].Contains(input.ElementAt(i + 1)))
                    {
                        list.Add($"{input.ElementAt(i)} eats {input.ElementAt(i + 1)}");
                        input.RemoveAt(i + 1);
                        i = -1;
                    }
                }
                else if (i != 0 && i != input.Count - 1)
                {
                    if (dict[input.ElementAt(i)].Contains(input.ElementAt(i - 1)))
                    {
                        list.Add($"{input.ElementAt(i)} eats {input.ElementAt(i - 1)}");
                        input.RemoveAt(i - 1);
                        i = -1;
                    }
                    else if (dict[input.ElementAt(i)].Contains(input.ElementAt(i + 1)))
                    {
                        list.Add($"{input.ElementAt(i)} eats {input.ElementAt(i + 1)}");
                        input.RemoveAt(i + 1);
                        i = -1;
                    }
                }
                else if (i == input.Count - 1)
                {
                    if (dict[input.ElementAt(i)].Contains(input.ElementAt(i - 1)))
                    {
                        list.Add($"{input.ElementAt(i)} eats {input.ElementAt(i - 1)}");
                        input.RemoveAt(i - 1);
                        i = -1;
                    }
                }
            }
            list.Add(string.Join(',', input));
            Console.WriteLine(string.Join(", ", list));
            return list.ToArray();
        }

        /*public static List<long[]> KprimesStep(int k, int step, long start, long nd)
        {
            var kPrimes = new List<long>();

        }*/

        public static string stat(string strg)
        {
            if (strg == "") return "";
            var list = strg.Replace(" ", "").Replace('|', ':').Split(',').Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture).TimeOfDay);
            var range = (list.MaxBy(t => t.TotalSeconds) - list.MinBy(t => t.TotalSeconds)).ToString(@"hh\|mm\|ss");
            var average = TimeSpan.FromSeconds(list.Average(t => t.TotalSeconds)).ToString(@"hh\|mm\|ss");
            string median = "";
            if (list.Count() % 2 != 0)
                median = list.OrderBy(t => t).ElementAt((int)Math.Floor(list.Count() / 2d)).ToString(@"hh\|mm\|ss");
            else
                median = TimeSpan.FromSeconds(((list.OrderBy(t => t).ElementAt(list.Count() / 2 - 1).TotalSeconds + list.OrderBy(t => t).ElementAt(list.Count() / 2).TotalSeconds) / 2)).ToString(@"hh\|mm\|ss");
            return $"Range: {range} Average: {average} Median: {median}";

        }

        public static string ToCamelCase(string str)
        {
            //return String.Concat(str.Split('-', '_').First()) + String.Concat(str.Split('-', '_').Skip(1).Select(w => $"{Char.ToUpper(w[0])}{string.Concat(w.Skip(1))}"));
            return string.Concat(str.Split('-', '_').Select((w, i) => i == 0 ? w : char.ToUpper(w[0]) + w.Substring(1)));
        }

        public static string MakeAWindow(int num)
        {
            var sb = new StringBuilder();
            sb.Append($"---{new string('-', num * 2)}\n");
            sb.Append(string.Concat(Enumerable.Repeat($"|{new string('.', num)}|{new string('.', num)}|\n", num)));
            sb.Append($"|{new string('-', num)}+{new string('-', num)}|\n");
            sb.Append(string.Concat(Enumerable.Repeat($"|{new string('.', num)}|{new string('.', num)}|\n", num)));
            sb.Append($"---{new string('-', num * 2)}");
            return sb.ToString();
        }

        public static string Arrange(string strng)
        {
            var list = strng.Split();
            string tmp;
            bool flag = true;
            for (int i = 0; i < list.Count() - 1; i++)
            {
                if (i % 2 == 0)
                {
                    if (list[i].Length > list[i + 1].Length)
                    {
                        tmp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp;
                    }
                    list[i] = list[i].ToLower();
                    flag = false;
                }
                else
                {
                    if (list[i].Length < list[i + 1].Length)
                    {
                        tmp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp;
                    }
                    list[i] = list[i].ToUpper();
                    flag = true;
                }
            }
            if (flag) list[^1] = list.Last().ToLower();
            else list[^1] = list.Last().ToUpper();
            return string.Join(" ", list);
        }

        public static String balanceStatements(String lst)
        {
            if (lst == "") return "Buy: 0 Sell: 0";
            var list = lst.Split(',').Select(s => s.Trim());
            var bad = new List<string>();
            var buySell = new StringBuilder();
            double buy = 0;
            double sell = 0;
            foreach (var item in list)
            {
                if ((item.Split().Count() != 4) || (item.Split()[1].Any(c => !char.IsDigit(c))) || (!item.Split()[2].Contains('.')) || (item.Split()[3].Length != 1 || !"BS".Contains(item.Split()[3])))
                {
                    bad.Add(item);
                    continue;
                }
                if (item.Split()[3] == "B")
                    buy += double.Parse(item.Split()[2], NumberFormatInfo.InvariantInfo) * Int32.Parse(item.Split()[1]);
                else
                    sell += double.Parse(item.Split()[2], NumberFormatInfo.InvariantInfo) * Int32.Parse(item.Split()[1]);
            }
            buySell.Append($"Buy: {buy.ToString("F0", CultureInfo.InvariantCulture)} Sell: {sell.ToString("F0", CultureInfo.InvariantCulture)}");
            if (bad.Count > 0)
                buySell.Append($"; Badly formed {bad.Count}: {string.Join(" ;", bad)} ;");
            return buySell.ToString();
        }

        public static string LongestConsec(string[] strarr, int k)
        {
            if (strarr.Length == 0 || k > strarr.Length || k <= 0) return "";
            int cmax = 0;
            string cstr = "";
            for (int i = 0; i < strarr.Length - k + 1; i++)
            {
                int currentSeqLen = strarr[i..(i + k)].Select(s => s.Length).Sum();
                if (cmax < currentSeqLen)
                {
                    cmax = currentSeqLen;
                    cstr = string.Concat(strarr[i..(i + k)]);
                }
            }
            return cstr;
        }

        public static string howmuch(int m, int n)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            int b = n;
            int s = n;
            if (m > n) { b = m; s = n; }
            else if (m < n) { b = n; s = m; }
            for (int i = 1; i < b + 1; i++)
            {
                var sum = 7 * i + 2;
                if (sum < s) continue;
                var carsCost = (sum - 1) / 9d;
                if (carsCost == (int)carsCost && sum == 9 * carsCost + 1 && sum <= b)
                    sb.Append($"[M: {sum} B: {i} C: {carsCost}]");
            }
            sb.Append(']');
            return sb.ToString();
        }

        public static int GetLengthOfMissingArray(object[][] arrayOfArrays)
        {
            if (arrayOfArrays is null)
                return 0;
            var arrOfLengths = arrayOfArrays.Select(i => i is null ? 0 : i.Length).OrderBy(i => i).ToArray();
            if (arrOfLengths.Contains(0)) return 0;
            for (int i = 0; i < arrOfLengths.Length - 1; i++)
            {
                if (arrOfLengths[i] + 1 != arrOfLengths[i + 1])
                    return arrOfLengths[i] + 1;
            }
            return 0;
        }

        public static string encode(string text)
        {
            //return string.Concat(text.Select(c => (int)c).Select(c => Convert.ToString(c, 2).PadLeft(8, '0')).Select(s => string.Concat(s.Select(c => new string(c, 3)))));
            return string.Concat(text.Select(c => Convert.ToString(c, 2).PadLeft(8, '0')).Select(s => string.Concat(s.Select(c => new string(c, 3)))));
        }
        public static string decode(string bits)
        {
            return string.Concat(bits.Chunk(3).Select(i => new string(i)).Select(i => string.Concat(i.Count(i => i == '1') > 1 ? '1' : '0')).Chunk(8).Select(i => string.Concat(i)).Select(s => (char)Convert.ToInt32(s, 2)));
        }

        public static long findNb(long m)
        {
            int c = 0;
            for (int i = 1; m > 0; i++)
            {
                m -= (long)Math.Pow(i, 3);
                c++;
            }
            return m == 0 ? c : -1;
        }

        public static List<string> movingShift(string s, int shift)
        {
            StringBuilder sb = new StringBuilder();
            var list = new List<string>();
            var fragLength = (int)Math.Ceiling(s.Length / 5d);
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    var shifted = s[i] + ((i + shift) % 26);

                    if (char.IsLower(s[i]))
                        sb.Append(shifted > (int)'z' ? (char)(shifted % 'z' + 'a' - 1) : (char)shifted);
                    else
                        sb.Append(shifted > (int)'Z' ? (char)(shifted % 'Z' + 'A' - 1) : (char)shifted);
                }
                else
                    sb.Append(s[i]);
                count++;
                if (count == fragLength)
                {
                    list.Add(sb.ToString());
                    sb.Clear();
                    count = 0;
                }
            }
            while (list.Count < 5)
            {
                list.Add(sb.Length != 0 ? sb.ToString() : "");
            }
            /*Console.Write(String.Join("|", list));
            Console.WriteLine("<|");*/
            return list;
        }

        public static string demovingShift(List<string> s, int shift)
        {
            var sb = new StringBuilder();
            var str = string.Concat(s);
            for (int i = 0; i < str.Length; i++)
            {
                var shifted = str[i] - ((i + shift) % 26);
                if (char.IsLetter(str[i]))
                {
                    if (char.IsLower(str[i]))
                        //sb.Append(shifted > (int)'z' ? (char)(shifted % 'z' + 'a' - 1) : (char)shifted);
                        sb.Append(shifted < (int)'a' ? (char)(shifted + 'z' - 'a' + 1) /*+ $"|{shifted}| {shifted + 'z' - 'a' + 1} "*/ : (char)shifted);
                    else
                        sb.Append(shifted < (int)'A' ? (char)(shifted + 'Z' - 'A' + 1) : (char)shifted);
                }
                else
                    sb.Append(str[i]);
            }
            return sb.ToString();
        }

        public static String isSumOfCubes(String s)
        {
            var list = new List<string>();
            var list3 = new List<int>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]) || (s[i] == '-' && char.IsDigit(s[i])))
                    sb.Append(s[i]);
                else
                {
                    list.Add(sb.ToString());
                    sb.Clear();
                }
            }
            list.Add(sb.ToString());
            foreach (var item in list)
            {
                if (item.Contains('-') || item == "")
                    continue;
                else if (item.Length < 4)
                    list3.Add(Int32.Parse(item));
                else
                    for (int i = 0; i < Math.Ceiling(item.Length / 3d) * 3; i += 3)
                    {
                        if (i + 3 > item.Length)
                            list3.Add(Int32.Parse(item[i..^0]));
                        else
                            list3.Add(Int32.Parse(item[i..(i + 3)]));
                    }
            }
            list = list3.Select(x => x.ToString()).ToList();
            list3.Clear();
            foreach (var item in list)
            {
                if (item.Sum(c => Math.Pow((int)char.GetNumericValue(c), 3)) == Int32.Parse(item))
                    list3.Add(Int32.Parse(item));
            }
            return list3.Count() == 0 ? "Unlucky" : string.Join(" ", list3) + $" {list3.Sum()} Lucky";
        }

        public static string GoodVsEvil(string good, string evil)
        {
            var goodInput = ToArr(good);
            var evilInput = ToArr(evil);
            var goodWorth = new Dictionary<int, int>() { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 3 }, { 4, 4 }, { 5, 10 } };
            var evilWorth = new Dictionary<int, int>() { { 0, 1 }, { 1, 2 }, { 2, 2 }, { 3, 2 }, { 4, 3 }, { 5, 5 }, { 6, 10 } };
            Console.WriteLine(WorthCount(goodInput, goodWorth));
            Console.WriteLine(WorthCount(evilInput, evilWorth));
            return WorthCount(goodInput, goodWorth) == WorthCount(evilInput, evilWorth) ? "Battle Result: No victor on this battle field" :
                WorthCount(goodInput, goodWorth) > WorthCount(evilInput, evilWorth) ?
                "Battle Result: Good triumphs over Evil" : "Battle Result: Evil eradicates all trace of Good";
        }

        public static int WorthCount(int[] arr, Dictionary<int, int> worth) => arr.Select((v, i) => worth[i] * v).Sum();
        public static int[] ToArr(string str) => str.Split().Select(c => Int32.Parse(c)).ToArray();

        public static string expandedForm2(double num)
        {
            var str = num.ToString().Split(',');
            var list = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < str[i].Length; j++)
                {
                    if (str[i][j] == '0')
                        continue;
                    if (i == 0)
                        list.Add($"{str[i][j]}{new string('0', str[i].Length - j - 1)}");
                    else
                        list.Add($"{str[i][j]}/1{new string('0', j + 1)}");
                }
            }
            return string.Join(" + ", list);
        }

        public static string ExpandedForm(long num)
        {
            var list = new List<string>();
            var str = num.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '0')
                    list.Add($"{str[i]}{new string('0', str.Length - i - 1)}");
            }
            return string.Join(" + ", list);
        }

        public static bool IsHollow(int[] x)
        {
            if (x.Count(i => i == 0) < 3) return false;
            for (int i = 0; i < x.Length - 2; i++)
            {
                if ((x[i] == 0 && x[i + 1] == 0 && x[i + 2] == 0) && (x[0..(i)].Count(i => i != 0) == x[(i + 3)..^0].Count(i => i != 0)))
                    return true;
            }
            return false;
        }

        public static int FindMissing(List<int> list)
        {
            int step = Math.Min(list[1] - list[0], list[^1] - list[^2]);
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] + step != list[i])
                {
                    return list[i] - step;
                }
            }
            return 0;
        }

        public static string[] inArray(string[] array1, string[] array2)
        {
            return array1.Where(s1 => array2.Any(s2 => s2.Contains(s1))).OrderBy(s1 => s1).ToArray();
        }

        public static string Part(string[] x)
        {
            int count = x.Count(s => new[] { "Partridge", "PearTree", "Chat", "Dan", "Toblerone", "Lynn", "AlphaPapa", "Nomad" }.Contains(s));
            return count == 0 ? "Lynn, I've pierced my foot on a spike!!" : $"Mine's a Pint{string.Concat(Enumerable.Repeat("!", count))}";
        }

        public static string SplitInParts(string s, int partLength)
        {
            return string.Join(" ", s.Chunk(partLength).Select(x => string.Concat(x)));
        }

        public static double[] ToDoubleArray(string[] stringArray)
        {
            return stringArray.Select(s => Double.Parse(s)).ToArray();
        }

        public static string Change(string input)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            return String.Concat(alphabet.Select(c => input.Contains(c) ? 1 : 0));
        }

        public static int Digits(ulong n)
        {
            return n.ToString().Count(c => char.IsDigit(c));
        }

        public static string Encode(string str)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            /*StringBuilder sb = new StringBuilder(); 
            foreach (var c in str)
            {
                sb.Append(alphabet.Contains(char.ToLower(c)) ? (alphabet.IndexOf(char.ToLower(c)) + 1).ToString() : c);
            }
            return sb.ToString();*/
            return String.Concat(str.ToLower().Select(c => alphabet.Contains(c) ? $"{alphabet.IndexOf(c) + 1}" : $"{c}"));
        }

        public static int CountSalutes(string hallway)
        {
            if (hallway is null || hallway.Length < 1) return 0;
            int count = 0;
            for (int i = 0; i < hallway.Length; i++)
            {
                if (hallway[i] != '>')
                    continue;
                for (int j = i + 1; j < hallway.Length; j++)
                {
                    if (hallway[j] == '<')
                        count += 2;
                }
            }
            return count;
        }

        public static string MakeComplement(string dna)
        {
            return string.Concat(dna.Select(c =>
            {
                switch (c)
                {
                    case 'A': return 'T';
                    case 'T': return 'A';
                    case 'C': return 'G';
                    case 'G': return 'C';
                    default: return c;
                }
            }));
        }

        public static string Sabb(string s, int val, int happiness)
        {
            return s.Count(c => "sabbatical".Contains(Char.ToLower(c))) + val + happiness > 22 ? "Sabbatical! Boom!" : "Back to your desk, boy.";
        }

        public static string PrinterError(String s)
        {
            return $"{s.Count(c => (int)c < (int)'a' || (int)c > 'm')}/{s.Length}";
        }

        public static bool comp(int[] a, int[] b)
        {
            if (a is null || b is null) return false;
            if (a.Length == 0 && b.Length == 0) return true;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] * a[i] == b[j])
                    {
                        a[i] = 0;
                        b[j] = 0;
                        break;
                    }
                }
            }
            return a.All(i => i == 0) && b.All(i => i == 0);
        }

        public static bool Compare(string s1, string s2)
        {
            s1 = s1 is null || !s1.All(c => char.IsLetter(c)) ? "" : s1.ToUpper();
            s2 = s2 is null || !s2.All(c => char.IsLetter(c)) ? "" : s2.ToUpper();
            return Encoding.ASCII.GetBytes(s1).Aggregate(0, (x, y) => x + y) == Encoding.ASCII.GetBytes(s2).Aggregate(0, (x, y) => x + y);
        }

        public static string Spoonerize(string str)
        {
            var arr = str.Split();
            return $"{arr[1][0]}{arr[0][1..^0]} {arr[0][0]}{arr[1][1..^0]}";
        }

        public static string GetMiddle(string s)
        {
            return s.Length % 2 == 0 ? $"{s[(s.Length / 2 - 1)..(s.Length / 2 + 1)]}" : $"{s[((s.Length - 1) / 2)]}";
        }

        public static string ReverseWords1(string str)
        {
            /*List<string> list = new List<string>();
            StringBuilder tmp = new StringBuilder();
            bool flag = true;
            foreach (char c in str)
            {
                if (c != ' ')
                {
                    if (!flag)
                    {
                        list.Add(tmp.ToString());
                        tmp.Clear();
                        flag = true;
                    }
                }
                else
                {
                    if (flag)
                    {
                        list.Add(string.Concat(tmp.ToString().Reverse()));
                        tmp.Clear();
                        flag = false;
                    }
                }
                tmp.Append(c);
            }
            list.Add(string.Concat(tmp.ToString().Reverse()));
            return String.Concat(list);*/

            return String.Join(" ", str.Split().Select(word => string.Concat(word.Reverse())));
        }

        public static int Solve(string str)
        {
            int count = 0;
            int tmp = 0;
            bool flag = false;
            foreach (char c in str)
            {
                if ("aeiou".Contains(c)) flag = true;
                else flag = false;
                if (flag)
                {
                    tmp++;
                    count = tmp > count ? tmp : count;
                }
                else
                    tmp = 0;
            }
            return count;
        }

        public static string RemoveHelper(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (Char.IsLetter(s[i]) && s[i + 1] == '!')
                    s = s[0..(i + 1)];
            }
            return s;
        }

        public static string Remove(string s)
        {
            return string.Join(" ", s.Split().Select(x => RemoveHelper(x)));
        }

        public static int KookaCounter(string laughing)
        {
            int c = 0;
            for (int i = 0; i < laughing.Length - 2; i += 2)
            {
                if (laughing[i].Equals(laughing[i + 2]))
                    c++;
            }
            return c;
        }

        public static string ShorterReverseLonger(string a, string b)
        {
            if (a is null) a = string.Empty;
            if (b is null) b = string.Empty;
            return a.Length >= b.Length ? $"{b}{string.Concat(a.Reverse())}{b}" : $"{b}{string.Concat(a.Reverse())}{b}";
        }

        public static string SevenAteNine(string str)
        {
            while (str.Contains("797"))
                str = str.Replace("797", "77");
            return str;
        }

        public static bool IsValidWalk(string[] walk)
        {
            Stack<string> stack = new Stack<string>();
            foreach (string s in walk)
            {
                if (walk.Length != 10)
                    return false;
                else if (stack.Count == 0)
                    stack.Push(s);
                else
                {
                    switch (stack.Peek())
                    {
                        case "n": if (s == "s") stack.Pop(); else stack.Push(s); break;
                        case "s": if (s == "n") stack.Pop(); else stack.Push(s); break;
                        case "w": if (s == "e") stack.Pop(); else stack.Push(s); break;
                        case "e": if (s == "w") stack.Pop(); else stack.Push(s); break;
                        default:
                            break;
                    }
                }
            }
            return stack.Count == 0;
        }

        public static bool DivisibleByThree(string n)
        {
            return n.Sum(c => (int)Char.GetNumericValue(c)) % 3 == 0;
        }

        public static bool ValidateWord(string s)
        {
            int a, b;
            foreach (char c in s)
            {
                a = s.Where(x => char.ToLower(x) == char.ToLower(s[0])).Count();
                b = s.Where(x => char.ToLower(x) == char.ToLower(c)).Count();
                Console.WriteLine(a + " " + b);
                if (a != b)
                    return false;
            }
            return true;
        }

        public static Boolean ContainAllRots(string strng, List<string> arr)
        {
            var lst = strng.ToList();
            foreach (char c in strng)
            {
                lst.Insert(0, lst.Last());
                lst.RemoveAt(lst.Count - 1);
                Console.WriteLine(string.Concat(lst));
                if (!arr.Contains(string.Concat(lst)))
                    return false;
            }
            return true;
        }

        public static string Sentencify(string[] words)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(" ", words);
            sb.Append('.');
            sb.Replace(sb.ToString()[0], char.ToUpper(sb.ToString()[0]), 0, 1);
            return sb.ToString();
        }

        public static string Explode(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                for (int i = 0; i < (int)char.GetNumericValue(c); i++)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();

            //return string.Concat(s.Select(i => string.Concat(Enumerable.Repeat(i, Convert.ToInt32(i.ToString())))));
        }

        public static int[] Capitals(string word)
        {
            /*var result = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (Char.IsUpper(word[i]))
                    result.Add(i);
            }
            return result.ToArray();*/

            return Enumerable.Range(0, word.Length).Where(i => Char.IsUpper(word[i])).ToArray();
        }

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
            return num.ToString().Aggregate("", (a, b) =>
            {
                if (a.Length > 0 && Convert.ToInt32(a[^1]) % 2 != 0 && Convert.ToInt32(b) % 2 != 0)
                    return a + "-" + b;
                return a + b;
            });
        }

        public static List<int> Solve(List<string> arr)
        {
            /*char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            List<int> result = new List<int>();
            foreach (string word in list)
            {
                int count = 0;
                if (word.Length > 26)
                    continue;
                for (int i = 0; i < word.Length; i++)
                {
                    if (Char.ToUpper(word[i]) == alpha[i])
                        count++;
                }
                result.Add(count);
            }
            return result;*/

            return arr.Select(word => word.Where((v, i) => Char.ToLower(v) == string.Concat(Enumerable.Range('a', 'z' - 'a' + 1)
                .Select(c => Convert.ToChar(c))).ToArray()[i]).Count()).ToList();
        }

        public static string Maskify(string cc)
        {
            return cc.Length < 4 ? cc : string.Concat(cc[0..^3].Select(c => '#')) + cc[^4..^0];
        }

        public static int GetVowelCount(string str)
        {
            return str.Count(c => "aeiou".Contains(c));
        }

        public static string ToJadenCase(string phrase)
        {
            return String.Join(" ", phrase.Split(' ').Select(word => Char.ToUpper(word.First()) + word[1..^0]));
        }

        public static bool IsPangram(string str)
        {
            /*string alph = "qwertyuiopasdfghjklzxcvbnm";
            foreach(var l in str)
            {
                alph = alph.Replace(l.ToString().ToLower(), "");
                if (alph == string.Empty)
                    return true;
            }
            return false;*/

            return str.ToLower().Where(character => char.IsLetter(character)).Distinct().Count() == 26;
        }

        public static string GhostBusters(string building)
        {
            return building.Replace(" ", "");
        }

        public static string[] Last(string x)
        {
            string[] result = x.Split();
            return x.Split().OrderBy(w => w.Last()).ToArray();
        }

        public static int getNumberFromString(string s)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsNumber(c))
                    result.Append(c);
            }
            return Convert.ToInt32(result.ToString());
            //return Convert.ToInt32(string.Concat(s.Where(x => Char.IsNumber(x))));
        }

        public static string Reverse(string text)
        {
            return string.Join(" ", text.Split(" ").Reverse());
        }

        public static string RepeatString(object toRepeat, int n)
        {
            return toRepeat is string ? string.Concat(Enumerable.Repeat(toRepeat, n)) : "Not a string";
            //return toRepeat.GetType().ToString();
        }

        public static Dictionary<char, int> CharFreq(string message)
        {

            return message.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            /*
            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach (char c in message)
            {
                if (d.ContainsKey(c))
                    d[c]++;
                else
                    d.Add(c, 1);
            }
            return d;
            */
        }

        public static string FormatMoney(double amount)
        {
            return $"${amount:F2}";
        }

        public static string TwoSort(string[] s)
        {
            return string.Join("***", s.OrderBy(x => x, StringComparer.Ordinal).First().Select(x => x));
        }

        public static string MultiTable(int number)
        {
            return string.Join(@"\n", Enumerable.Range(1, 10).Select(x => $"{x} * {number} = {x * number}"));
            //return string.Join(@"\n" ,Enumerable.Repeat($"{i++} * {number} = {i * number}", 10));
        }

        public static bool Check(object[] a, object x)
        {
            return a.Any(o => o.Equals(x));
        }

        public static object[] IsVow(object[] a)
        {
            return a.Select(x => "aeiou".Contains(Convert.ToChar(x)) ? Convert.ToChar(x).ToString() : x).ToArray();
        }

        public static string Arr(string s)
        {
            return s.Count(c => c == ',') < 2 ? "null" : string.Join(" ", s.Split(',')[1..^1]);
        }

        public string dnaToRna(string dna)
        {
            return dna.Replace('T', 'U');
        }

        public static string Shortcut(string input)
        {
            char[] lowerVovels = { 'a', 'e', 'i', 'o', 'u' };
            return string.Concat(input.Where(x => !lowerVovels.Contains(x)));
        }

        public static string AbbrevName(string name)
        {
            return String.Join(".", name.Split().Select(x => x.ToUpper().First()));
        }
        public static string Well(string[] x)
        {
            int count = 0;
            count = x.Where(x => x == "good").Count();
            if (count == 0)
                return "Fail!";
            else if (count <= 2)
                return "Publish!";
            else
                return "I smell a series!";
        }

        public static string ReverseWords(string str)
        {
            return String.Join(" ", str.Split().Reverse());
        }
        public static int SumMul(int n, int m)
        {
            if (n < 1 || m < n)
                throw new ArgumentException();
            return Enumerable.Range(0, m).Where(x => x % n == 0).Sum();
        }

        public static IEnumerable<string> GooseFilter(IEnumerable<string> birds)
        {
            string[] geese = new string[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" };

            //return birds.Where(x => !geese.Contains(x));
            return birds.Except(geese);
        }
        public static string ToAlternatingCase(string s)
        {
            return string.Join("", s.Select(x => Char.IsUpper(x) ? Char.ToLower(x) : Char.ToUpper(x)));
        }
        public static IEnumerable<IEnumerable<int>> EachCons(int[] list, int n)
        {
            int[][] result = new int[list.Length - n + 1][];
            for (int i = 0; i < list.Length - n + 1; i++)
            {
                result[i] = list[i..(i + n)];
            }
            return result;
        }
    }
}