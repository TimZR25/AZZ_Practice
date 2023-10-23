using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AZZ_Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int L = 50;



            Console.Write("Введите длину строки, которая будет равна длине месяца: ");
            int.TryParse(Console.ReadLine(), out int n);

            var monthsByLenght = from m in months
                                 where m.Length == n
                                 select m;

            Console.WriteLine($"Месяцы длина которых равна {n}:");
            foreach (var item in monthsByLenght) Console.WriteLine(item);
            Console.WriteLine();


            Console.WriteLine(new string('-', L));


            var monthsBySeasons = from m in months
                                  where m.Equals("June") || m.Equals("July") || m.Equals("August")
                                  || m.Equals("December") || m.Equals("January") || m.Equals("February")
                                  select m;

            Console.WriteLine("Летние и зимние месяцы:");
            foreach (var item in monthsBySeasons) Console.WriteLine(item);
            Console.WriteLine();


            Console.WriteLine(new string('-', L));


            var monthsByAlphabet = from m in months
                                   orderby m
                                   select m;

            Console.WriteLine("Месяцы в алфавитном порядке:");
            foreach (var item in monthsByAlphabet) Console.WriteLine(item);
            Console.WriteLine();


            Console.WriteLine(new string('-', L));


            var monthsByLetterLenght = from m in months
                                       where m.Contains("u") && m.Length >= 4
                                       select m;

            Console.WriteLine("Количество месяцев содержащих <u> и длиной не менее 4-х");
            Console.WriteLine(monthsByLetterLenght.Count());

            Console.WriteLine();
            Console.WriteLine(new string('-', L));

            List<Airline> airlines = new List<Airline>() { new Airline("Astana", 1111, "14:15", "Monday"),
                new Airline("Moscow", 2222, "15:50", "Friday"), new Airline("Astana", 1112, "14:30", "Monday"), new  Airline("Париж", 1113, "00:00", "Monday"),
                new Airline("Novosibirsk", 3333, "22:58", "Wednesday")};


            string dest = "Astana";
            var airlines1 = from airline in airlines
                            where airline.Destination.Equals(dest)
                            select airline;

            Console.WriteLine("Количество рейсов в " + dest + ": " + airlines1.Count());

            Console.WriteLine(new string('-', L));

            string day = "Monday";

            var airlines2 = from airline in airlines
                            where airline.DayOfTheWeek.Equals(day)
                            select airline;

            Console.WriteLine("Количество рейсов в " + day + ": " + airlines2.Count());

            Console.WriteLine(new string('-', L));

            var airlines3 = from airline in airlines
                            where airline.DayOfTheWeek.Equals("Monday")
                            orderby airline.DepartureTime
                            select airline;

            foreach (var item in airlines3) Console.WriteLine(item);

            Console.WriteLine("\nСаммый ранний рейс в понедельник отправляется в: " + airlines3.First().DepartureTime);

            Console.WriteLine(new string('-', L));

            var airlines4 = from airline in airlines
                            where (airline.DayOfTheWeek.Equals("Friday") || airline.DayOfTheWeek.Equals("Wednesday"))
                            orderby airline.DepartureTime descending
                            select airline;

            foreach (var item in airlines4) Console.WriteLine(item);

            Console.WriteLine("\nСаммый поздний рейс в пятницу или среду отправляется в: " + airlines4.First().DepartureTime);

            Console.WriteLine(new string('-', L));

            var airlines5 = from airline in airlines
                            orderby airline.DepartureTime
                            select airline;

            Console.WriteLine("Отсортированный список рейсов по времени вылета:\n");
            foreach (var item in airlines5) Console.WriteLine(item);
        }
    }
}