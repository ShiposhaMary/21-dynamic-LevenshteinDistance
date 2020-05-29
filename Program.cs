using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_LevenshteinDistance
{
    class Program
    {/*алгоритм поиска расстояния Левенштейна. 
        На вход алгоритм принимает две строки, 
        а возвращает расстояние Левенштейна.

Расстояние Левенштейна — это минимальное количество 
правок (вставки, удаления или изменения одного символа на другой),
которое нужно сделать, чтобы из первого слова получить второе.*/

        public static int LevenshteinDistance(string first, string second)
        {
            var opt = new int[first.Length + 1, second.Length + 1];
            for (var i = 0; i <= first.Length; ++i) opt[i, 0] = i;
            for (var j = 0; j <= second.Length; ++j) opt[0, j] = j;
            for (var i = 1; i <= first.Length; ++i)
                for (var j = 1; j <= second.Length; ++j)
                {
                    if (first[i - 1] == second[j - 1])
                        opt[i, j] = opt[i - 1, j - 1];
                    else
                        opt[i, j] = 1 + Math.Min(Math.Min(opt[i - 1, j], opt[i, j - 1]), opt[i - 1, j - 1]);
                }
            return opt[first.Length, second.Length];
        }
        static void Main(string[] args)
        {
            Assert.AreEqual(0, LevenshteinDistance("a", "a"));
            Assert.AreEqual(1, LevenshteinDistance("a", "aa"));
            Assert.AreEqual(2, LevenshteinDistance("кот", "клон"));
            Assert.AreEqual(3, LevenshteinDistance("yabx", "abcd"));
            Assert.AreEqual(4, LevenshteinDistance("студент", "солдат"));
            SecretTests();
            Console.WriteLine("OK");
        }
    }
}
