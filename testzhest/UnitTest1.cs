using System;
using Xunit;
using FluentAssertions;
using US_5A_Net.models;

namespace testzhest
{
    public class UnitTest1
    {
        public bibl.Class1 Flights = new bibl.Class1();
        [Fact]
        public void PLustest()
        {
            Flights flight = new Flights
            {
                numflight = 1488,
                type = Types.Боинг,
                eta = DateTime.Parse("24.02.2004"),
                countPas = 17,
                pricePas = 1337.00,
                countCrew = 2,
                priceCrew = 4200.00,
                procDop = 2,
                sum = (17 * 1337.00 + 2 * 1337.00) * 2
            };
            var res = Flights.Add(flight);
            var fls = Flights.GetFlights();
            res.Should().Be(flight);
            fls.Should().HaveCount(1).And.NotBeEmpty();
        }
        [Fact]
        public void Minustest()
        {
            Flights flight = new Flights
            {
                numflight = 1488,
                type = Types.Боинг,
                eta = DateTime.Parse("24.02.2004"),
                countPas = 17,
                pricePas = 1337.00,
                countCrew = 2,
                priceCrew = 4200.00,
                procDop = 2,
                sum = (17 * 1337.00 + 2 * 1337.00) * 2
            };
            Flights.Add(flight);
            var res = Flights.GetFlights();
            res.Should().HaveCount(1).And.NotBeEmpty();
            res.Remove(flight);
            res.Should().HaveCount(0).And.BeEmpty();
        }
        [Fact]
        public void Test1()
        {
            Flights[] flight = {new Flights
            {
                 numflight = 1488,
                type = Types.Боинг,
                eta = DateTime.Parse("24.02.2004"),
                countPas = 17,
                pricePas = 1337.00,
                countCrew = 2,
                priceCrew = 4200.00,
                procDop = 2,
                sum = (17 * 1337.00 + 2 * 1337.00) * 2
            },new Flights
            {
                 numflight = 1488,
                type = Types.Боинг,
                eta = DateTime.Parse("24.02.2004"),
                countPas = 17,
                pricePas = 1337.00,
                countCrew = 2,
                priceCrew = 4200.00,
                procDop = 2,
                sum = (17 * 1337.00 + 2 * 1337.00) * 2
            },new Flights
            {
                numflight = 1488,
                type = Types.Боинг,
                eta = DateTime.Parse("24.02.2004"),
                countPas = 17,
                pricePas = 1337.00,
                countCrew = 2,
                priceCrew = 4200.00,
                procDop = 2,
                sum = (17 * 1337.00 + 2 * 1337.00) * 2
            }};
            Flights.Add(flight[0]);
            Flights.Add(flight[1]);
            Flights.Add(flight[2]);
            var res = Flights.GetFlights();
            res.Should().HaveCount(3).And.NotBeEmpty();
            res.Remove(flight[1]);
            res.Should().HaveCount(2).And.NotBeEmpty();
            res[0].countCrew.Should().Be(res[1].countCrew);
            flight[0].countCrew = 4;
            res[0].countCrew.Should().NotBe(res[1].countCrew);
        }
        [Fact]
        public void Test2()
        {
            Flights[] flight = {new Flights
            {
                 numflight = 1488,
                type = Types.Боинг,
                eta = DateTime.Parse("24.02.2004"),
                countPas = 17,
                pricePas = 1337.00,
                countCrew = 2,
                priceCrew = 4200.00,
                procDop = 2,
                sum = (17 * 1337.00 + 2 * 1337.00) * 2
            },new Flights
            {
                numflight = 1488,
                type = Types.Боинг,
                eta = DateTime.Parse("24.02.2004"),
                countPas = 17,
                pricePas = 1337.00,
                countCrew = 2,
                priceCrew = 4200.00,
                procDop = 2,
                sum = (17 * 1337.00 + 2 * 1337.00) * 2
            }};
            Flights.Add(flight[0]);
            Flights.Add(flight[1]);
            var res = Flights.GetFlights();
            res.Should().HaveCount(2).And.NotBeEmpty();
            var resCount = Flights.WithSumLessThan(flight[1].sum);
            resCount.Should().Be(0);
        }
    }
}