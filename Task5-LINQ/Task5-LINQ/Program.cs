using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task5_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Введите текст");

            var lines = Console.ReadLine().Split();

            var strings = Task1(lines.ToArray());

            foreach (var str in strings)
                Console.WriteLine(str);

            Console.WriteLine("__________________");
            Console.WriteLine("Task 2");

            var db = new List<Record>
            {
                new Record(1, 2019, 4, 20),
                new Record(2, 2019, 5, 80),
                new Record(3, 2019, 4, 44),
                new Record(1, 2020, 1, 46),
                new Record(3, 2019, 10, 70)
            };

            Task2(db);

            Console.ReadKey();
        }

        public static string[] Task1(string[] str) =>
            str
            .Where(s => !string.IsNullOrEmpty(s))
            .Select(s => s.Length > 3 ? s.Substring(0, 3).ToUpper() : s.ToUpper())
            .Distinct()
            .OrderByDescending(s => s)
            .ToArray();

        public static void Task2(List<Record> db)
        {
            var dict = db
                .GroupBy(r => r.ClientID)
                .Select(g => new
                {
                    ClientID = g.Key,
                    TotalDuration = g.Sum(r => r.Duration)
                })
                .OrderByDescending(x => x.TotalDuration)
                .ThenBy(x => x.ClientID)
                .ToList();

            foreach (var record in dict)
                Console.WriteLine($"Суммарная продолжительность: {record.TotalDuration}, Клиент: {record.ClientID}");

        }
    }
}
