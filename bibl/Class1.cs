using System;
using System.Collections.Generic;
using System.Linq;
using US_5A_Net.models;

namespace bibl
{
    public class Class1
    {
        public IList<Flights> Flights = new List<Flights>();
        public IList<Flights> GetFlights() { return Flights; }
        public Flights Add(Flights flights) { Flights.Add(flights); return flights; }
        public int WithSumLessThan(double that)
        {
            return Flights.Where(a => a.sum < that).Count();
        }
    }
}