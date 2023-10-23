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

        
    }
}
