using System;
using System.IO;

namespace Day01
{
    public class Puzzle
    {
        private int _total;
        private readonly string _day;
        private String[] _input;

        public Puzzle()
        {
            _day = "day01";
            _input = File.ReadAllLines(_day + "/input");
        }
        
        public void run()
        {
            Console.WriteLine(_day);
            Console.WriteLine("Part 1:");
            Part1();
            _total = 0;
            Console.WriteLine("Part 2:");
            Part2();
        }

        private void Part1()
        {
            foreach (var line in _input)
            {
                int lineInt = Int32.Parse(line);
                _total += CalcFuel(lineInt);
            }
            Console.WriteLine(_total);
        }

        private void Part2()
        {
            foreach (var line in _input)
            {
                int lineInt = Int32.Parse(line);
                _total += CalcFuelRecursive(lineInt);
            }
            Console.WriteLine(_total);
        }
        
        private int CalcFuel(int mass)
        {
            int fuelNeed = (mass / 3) - 2;
            return fuelNeed;
        }

        private int CalcFuelRecursive(int mass)
        {
            int fuelNeed = CalcFuel(mass);
            
            if (fuelNeed > 0)
            {
                fuelNeed += CalcFuelRecursive(fuelNeed);
                return fuelNeed;
            }
            return 0;
        }
    }
}