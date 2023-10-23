using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AZZ_Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([0-1][0-9]|2[0-4]):[0-5][0-9]";
            string Air = "24:h4";

            Console.WriteLine(Regex.IsMatch(Air, pattern) && Air.Length == 5);

            //string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            //int L = 50;



            //Console.Write("Введите длину строки, которая будет равна длине месяца: ");
            //int.TryParse(Console.ReadLine(), out int n);

            //var monthsByLenght = from m in months
            //                     where m.Length == n
            //                     select m;

            //Console.WriteLine($"Месяцы длина которых равна {n}:");
            //foreach (var item in monthsByLenght) Console.WriteLine(item);
            //Console.WriteLine();


            //Console.WriteLine(new string('-', L));


            //var monthsBySeasons = from m in months
            //                      where m.Equals("June") || m.Equals("July") || m.Equals("August")
            //                      || m.Equals("December") || m.Equals("January") || m.Equals("February")
            //                      select m;

            //Console.WriteLine("Летние и зимние месяцы:");
            //foreach (var item in monthsBySeasons) Console.WriteLine(item);
            //Console.WriteLine();


            //Console.WriteLine(new string('-', L));


            //var monthsByAlphabet = from m in months
            //                       orderby m
            //                       select m;

            //Console.WriteLine("Месяцы в алфавитном порядке:");
            //foreach (var item in monthsByAlphabet) Console.WriteLine(item);
            //Console.WriteLine();


            //Console.WriteLine(new string('-', L));


            //var monthsByLetterLenght = from m in months
            //                           where m.Contains("u") && m.Length >= 4
            //                           select m;

            //Console.WriteLine("Количество месяцев содержащих <u> и длиной не менее 4-х");
            //Console.WriteLine(monthsByLetterLenght.Count());
            //Console.WriteLine();
        }
    }
}