using AZZ_Practice_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZZ_Practice_4
{
    internal class Airline
    {
        private string pattern = @"([0-1][0-9]|2[0-4]):[0-5][0-9]";

        private string? _destination;
        public string? Destination 
        { 
            get { return _destination; } 
            set 
            {
                if (string.IsNullOrEmpty(value)) return;
                _destination = value; 
            }
        }

        private int _flightNumber;
        public int FlightNumber
        {
            get { return _flightNumber; }
            set
            {
                if (value <= 0) return; 
                _flightNumber = value;
            }
        }

        private string? departureTime;

        private string? dayOfTheWeek;
        public string? DepartureTime
        {
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (Regex.IsMatch(value, pattern) && value.Length == 5)
                {
                    departureTime = value;
                }
                else { throw new Exception("Неправильно введено время вылета"); }
            }
            get { return departureTime; }
        }
        public string? DayOfTheWeek { 
            set { 
                if (string.IsNullOrEmpty(value)) return;
                dayOfTheWeek = value; 
            } get { return dayOfTheWeek; } }



        public Airline(string destination, int flightNumber, string departureTime, string dayOfTheWeek)
        {
            Destination = destination;
            FlightNumber = flightNumber;
            DepartureTime = departureTime;
            DayOfTheWeek = dayOfTheWeek;
        }

        public override string ToString() { return $"Отправление в {Destination} в {DayOfTheWeek} {DepartureTime} по рейсу с номером: {FlightNumber}\n"; }
    }
}
