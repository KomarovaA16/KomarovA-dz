using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = {"Апельсин, Екатеринбург", "Мандарин: облако", "Южная - АФрика", "Урал; Яков"};

            foreach (var kv in GetVowelWordCount(text))
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }

            var records = new List<Record>
            {
                new Record { ClientID = 1, Year = 2020, Month = 1, Duration = 10 },
                new Record { ClientID = 1, Year = 2020, Month = 2, Duration = 15 },
                new Record { ClientID = 1, Year = 2020, Month = 3, Duration = 12 },
                new Record { ClientID = 1, Year = 2021, Month = 1, Duration = 8 },
                new Record { ClientID = 1, Year = 2021, Month = 2, Duration = 9 },
                new Record { ClientID = 2, Year = 2020, Month = 4, Duration = 20 },
                new Record { ClientID = 2, Year = 2020, Month = 5, Duration = 18 },
                new Record { ClientID = 2, Year = 2020, Month = 6, Duration = 18 },
                new Record { ClientID = 2, Year = 2021, Month = 4, Duration = 22 },
                new Record { ClientID = 2, Year = 2021, Month = 5, Duration = 21 }
            };

            PrintMinDurationMonths(1, records);
            PrintMinDurationMonths(2, records);
            PrintMinDurationMonths(3, records);
        }

        static Dictionary<string, int> GetVowelWordCount(string[] text)
        {
            string vowels = "АЕИОУЫЭЮЯ";

            var words = text.SelectMany(t => Regex.Split(t, @"\W+").Where(w => !string.IsNullOrEmpty(w))).ToArray();

            var vowelWordCount = vowels.Select(v => v.ToString())
                           .ToDictionary(v => v, v => words.Count(w => w[0].ToString().ToUpper() == v));

            return vowelWordCount;
        }

        public struct Record
        {
            public int ClientID;
            public int Year;
            public int Month;
            public int Duration;
        }

        static void PrintMinDurationMonths(int clientID, List<Record> records)
        {
            var clientRecords = records.Where(r => r.ClientID == clientID);

            if (clientRecords.Any())
            {
                var yearGroups = clientRecords.GroupBy(r => r.Year);

                var minDurationMonths =
                    from g in yearGroups
                    let minDurationMonth =
                        (from r in g
                         orderby r.Duration ascending,
                                 r.Month descending
                         select r).First()
                    select minDurationMonth;

                foreach (var m in minDurationMonths.OrderBy(m => m.Year))
                {
                    Console.WriteLine($"{m.Year} {m.Duration} {m.Month}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных о клиенте с заданным кодом.");
            }
        }
    }
}